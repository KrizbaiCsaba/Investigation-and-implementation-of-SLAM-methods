using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Forms;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;

namespace Main.Classes
{
    class MQTT
    {

        #region Variables 

        // === MQTT SERVER INFO ===
        private static string MQTTaddress = "farmer.cloudmqtt.com";
        private static int MQTTport = 13528;
        private static string MQTTusername = "fkmsgamj";
        private static string MQTTpassword = "ISPx1eV1D1s3";
        // === MQTT Client ===
        private static IManagedMqttClient managedClient;

        // === _distance list ===
        protected static List<long> _distances = new List<long>();

        // === Inital Form , POPUP MENU 
        private static InitialForm Popup = new InitialForm();
        // === Sensor Parameters ===
        private static string sensorParameters;

        // === SaveToFile Class ===
        private static SaveToFile saveFile = new SaveToFile();

        #endregion


        #region connect To MQTT Cloud Server
        public class UsernameAndPassword : IMqttClientCredentials
        {

            public byte[] Password => Encoding.ASCII.GetBytes(MQTTpassword);
            public string Username => MQTTusername;

        }


        public async Task ConnectToMqtt()
        {
            var options = new ManagedMqttClientOptions
            {
                ClientOptions = new MqttClientOptions
                {
                    ClientId = Guid.NewGuid().ToString(),
                    Credentials = new UsernameAndPassword(),
                    ChannelOptions = new MqttClientTcpOptions
                    {
                        Server = MQTTaddress,
                        Port = MQTTport
                    }
                },

                AutoReconnectDelay = TimeSpan.FromSeconds(1),

            };
            try
            {
                managedClient = new MqttFactory().CreateManagedMqttClient();

                #region Handle Events 
                // === Connecting Failed ===
                managedClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(e =>
                {
                    Console.WriteLine("Connecting Failed");
                    return;
                });
                // === Message Received ===
                managedClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e =>
                {
                    MessageReceived(e.ApplicationMessage.Topic, Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                });
                #endregion

                await managedClient.StartAsync(options);

                //Subscribe
                _ = SubscribeAsync("SS_DATA");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }



        #endregion

        #region Publish
        public async Task PublishAsync(string topic, string payload, bool retainFlag = true, int qos = 1)
        {
            await managedClient.PublishAsync(new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel((MqttQualityOfServiceLevel)qos)
                .WithRetainFlag(retainFlag)
                .Build());
        }

        #endregion


        #region Subscribe
        public static async Task SubscribeAsync(string topic, int qos = 1)
        {
            await managedClient.SubscribeAsync(new TopicFilterBuilder()
                .WithTopic(topic)
                .WithQualityOfServiceLevel((MqttQualityOfServiceLevel)qos)
                .Build());
        }
        #endregion

        #region MessageReceived
        private static void  MessageReceived(string topic, string payLoad)
        {
            if (topic == "SS_DATA") // if is distance input
            {
                //Distance Data: TOPIC: SS_DATA     PAYLOAD: Timestamp, Starting, Ending, Cluster, Distances[0,..,n]
                string[] splitCommand = payLoad.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // === Save received data ===
                saveFile.SavePlotData(splitCommand);

                // === Cut first 4 elements ====
                splitCommand = splitCommand.Skip(4).ToArray();

                // === Clear _distance List ===
                _distances.Clear();

                foreach (string iterator in splitCommand)
                {
                    Console.WriteLine(iterator);
                    _distances.Add(Convert.ToInt64(iterator)); //convert string to long
                }
            }
        }
        #endregion

        #region Get Distance 
        public void getDistanceFromMqtt(ref List<long> distances)
        {
            distances = _distances;
        }

        #endregion
    }
}