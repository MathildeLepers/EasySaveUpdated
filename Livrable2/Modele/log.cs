using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Livrable2.Modele
{
    class log
    {
        public static long file_size(DirectoryInfo d)
        {
            long Size = 0;
            // Ajoute taille des fichiers
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            // Ajoute taille des sous répertoires
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += file_size(di);
            }
            return (Size);
        }

        public static string time_now()
        {
            DateTime time = DateTime.Now;
            string time2 = time.ToString();
            return time2;
        }

        public static void write_log(sauvegarde entrer, long size, string date, double time_exec)
        {
            List<JSON> listJSON = new List<JSON>();
            try
            {

                JSON log = new JSON();
                log.horodatage = date;
                log.Name = entrer.get_nom();
                log.Destination = entrer.get_destination();
                log.Source = entrer.get_source();
                log.Size = size;
                log.tmp_exec = time_exec;

                string json = JsonConvert.SerializeObject(log);

                string fileName = @"C:\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Projet\Log.JSON"; // emplacement fichier log
                {
                    if (!File.Exists(fileName))
                    {
                        listJSON.Add(log);
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString = System.Text.Json.JsonSerializer.Serialize(listJSON, options);
                        File.WriteAllText(@fileName, jsonString);
                    }
                    else
                    {
                        StreamReader r = new StreamReader(fileName);
                        string jsonString2 = r.ReadToEnd();
                        r.Close();
                        List<JSON> m = JsonConvert.DeserializeObject<List<JSON>>(jsonString2);
                        m.Add(log);
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString3 = System.Text.Json.JsonSerializer.Serialize(m, options);
                        File.WriteAllText(@fileName, jsonString3);
                    }




                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }


        }
    }
}
