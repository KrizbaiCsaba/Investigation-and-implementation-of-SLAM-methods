import paho.mqtt.client as mqtt

MQTT_USER = 'fkmsgamj'
MQTT_PASS = 'ISPx1eV1D1s3'
MQTT_SERVER = 'farmer.cloudmqtt.com'
MQTT_PORT = 13528
MQTT_SSLPORT = 23528

class MQTT():
    def __init__(self, lidar):
        self.lidar = lidar
        # Connect to MQTT Borker
        self.client = mqtt.Client()
        self.client.username_pw_set(MQTT_USER, MQTT_PASS)
        # Attach function to callback
        self.client.on_connect = self.on_connect
        self.client.on_message = self.on_message
        self.client.connect(MQTT_SERVER, MQTT_PORT, MQTT_SSLPORT)
        self.client.loop_start()

    def on_connect(self, client, userdata, flags, rc):
        print(f"Connected to MQTT server with result code {rc}")
        client.subscribe("raspberry/topic")
        client.subscribe('SS_INI')
        client.subscribe('SS_STOP')
        client.subscribe('SS_MOVE')

    def on_message(self, client, userdata, msg):
        if msg.topic == "SS_INI_DONT": #removed
            STARTING = msg.payload[0:4].decode()
            ENDING = msg.payload[4:8].decode()
            CLUSTER = msg.payload[8:10].decode()
            SCANINT = msg.payload[10:11].decode()
            NBOFSCAN = msg.payload[11:13].decode()
            self.lidar.initialParameters(STARTING,ENDING,CLUSTER,SCANINT, NBOFSCAN)
        elif msg.topic == "SS_STOP":
            pass
        else:
            print("Unknow Topic")


    def publish(self,topic , data):
        self.client.publish(topic, data, 0)