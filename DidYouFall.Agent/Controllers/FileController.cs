using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DidYouFall.Agent.Info;
using DidYouFall.Agent.Properties;

namespace DidYouFall.Agent.Controllers
{
    public static class FileController
    {
        static string SourceDirectory = new FileInfo((Assembly.GetExecutingAssembly().Location)).Directory.FullName;
        static string ConfigDirectory = SourceDirectory + "\\config\\";
        static string ConfigFileName = "pcinfo.dan";


        public static void SaveConfig()
        {
            if (!Directory.Exists(ConfigDirectory))
                Directory.CreateDirectory(ConfigDirectory);
            string serializationFile = Path.Combine(ConfigDirectory, ConfigFileName);
            Stream stream = File.Open(serializationFile, FileMode.Create, FileAccess.Write);
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bformatter.Serialize(stream, Program.PcInfo);
            stream.Close();
        }
        public static void LoadConfig()
        {
            try
            {
                Stream stream = File.Open(ConfigDirectory + ConfigFileName, FileMode.Open);
                var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                PC pcInfo = (PC)bFormatter.Deserialize(stream);
                stream.Close();
                Program.PcInfo = pcInfo;              

            }
            catch (Exception ex)
            {
                if(ex is  FileNotFoundException || ex is DirectoryNotFoundException)
                {
                MessageBox.Show("Arquivo de configuração não encontrado!","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Program.PcInfo = new PC();
                new Forms.Configuration(Program.PcInfo).Show();
                }
                else
                {
                    throw ex;
                }
            }

           
        }
    }
}
