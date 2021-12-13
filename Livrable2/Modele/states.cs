using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using Livrable2.Modele;

namespace Livrable2.Modele
{
    class states
    {
        private static List<JSONFile> listJSONfile = new List<JSONFile>();



        public static void write_file(sauvegarde entrer, long size) // écrire dans le fichier file 
        {
            try
            {
                JSONFile file = new JSONFile();
                file.Name = entrer.get_nom();
                file.Source = entrer.get_source();
                file.Destination = entrer.get_destination();
                file.Size = size;
                file.Date = Modele.log.time_now();
                file.State = Modele.sauvegarde.etat_file;
                file.NbFiles = Modele.sauvegarde.nbfile;

                string fileName = @"C:\Users\leper\Documents\CESI\Informatique\02-ProgrammationSysteme\Projet"; // emplacement fichier file
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(file, options);
                    File.WriteAllText(@fileName, jsonString);

                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
    }
}
