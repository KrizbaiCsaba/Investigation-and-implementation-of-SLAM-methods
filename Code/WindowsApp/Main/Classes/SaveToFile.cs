using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Classes
{
    class SaveToFile
    {

        #region Variables
        //data saving
        string pathFiles = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\_MySource\PlotData.csv";
        //string pathFiles = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\_MySource\PlotData.csv";
        StringBuilder csv = new StringBuilder();
        #endregion


        #region SavePlot Data
        public int SavePlotData( string[] splitCommand)
        {
            {
                try
                {
                    #region About This 
                    /* === About This ====
                    Split_Command :
                    [0] -- Timestamp
                    [1] -- Starting 
                    [2] -- Ending 
                    [3] -- Cluster
                    [4]...[n] -- Distances

                    Return Value:
                        -1: error
                         1: data is saved
                    */
                    #endregion

                    // === split command is empty return -1
                    if (splitCommand.Count() == 0)
                        return -1;

                    // === Save timestamp , Starting, Ending, Cluster, distances ===
                    foreach( string item in splitCommand)
                        csv.Append(item + ",");

                    // === New Line ===
                    csv.AppendLine();

                    // === Save Data to path ====
                    File.WriteAllText(pathFiles, csv.ToString());
                    return 1;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message); //debug
                    return -1;
                }
            }
        }
        #endregion

    }
}
