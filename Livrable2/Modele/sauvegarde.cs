using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Livrable2.Modele;
using System.Diagnostics;
using Livrable2.Vue;

namespace Livrable2.Modele
{
    public class sauvegarde
    {
       
        public static float pourcent;
        private string source;
        public static State etat_file;
        public static int nbfile;
        public static int nb;

        private string destination;
        private string nom;
        private string type;
        private static double tmp;
        public float p;
        public string[] ext;



        public static void sauvegarde_complet(sauvegarde save)
        {
            string source = save.get_source();
            string dest = save.get_destination();
            Stopwatch sw = Stopwatch.StartNew();
            etat_file = State.INPROGRESS;

            DirectoryInfo disource = new DirectoryInfo(source);
            long taille = log.file_size(disource);


            //Window4 gggg = new Window4();
            //gggg.Show();
           

            foreach (var directory in Directory.GetDirectories(source))
            {

                string dirName = Path.GetFileName(directory);
                if (!Directory.Exists(Path.Combine(dest, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, dirName));
                    Console.Write(Path.Combine(dest, dirName));
                }
                source = directory;
                dest = Path.Combine(dest, dirName); 
                sauvegarde_complet(save);
            }
            
            nbfile = 0;

            List<string> listFilePrio = new List<string>();
            List<string> listFileNoPrio = new List<string>();

            foreach (string file in Directory.GetFiles(source))
            {
                bool softwarestate = Livrable2.Modele.logicielmetier.Logiciel_Metier(Path.GetFileNameWithoutExtension(file)); // Vérifie chaque file n'est pas ouvert en processus 
                //System.Windows.MessageBox.Show(softwarestate.ToString() + " " + file);

                if (softwarestate == false)
                { 
                    foreach (string extention in save.get_ext())
                    {
                        if (Path.GetExtension(file).Equals(extention, StringComparison.InvariantCultureIgnoreCase))
                        {
                            listFilePrio.Add(file);
                        }
                        else
                        {
                            listFileNoPrio.Add(file);
                        }
                    }
                }
            }

            foreach(var fileprio in listFilePrio)
            {
                File.Copy(fileprio, Path.Combine(dest, Path.GetFileName(fileprio)));
                nbfile++;
            }

            foreach (var filenoprio in listFileNoPrio)
            {
                File.Copy(filenoprio, Path.Combine(dest, Path.GetFileName(filenoprio)));
                nbfile++;
                //int ca = (nbfile / nb) * 100;
                //pourcent = ca;

            }

            etat_file = State.END;

            sw.Stop();
            double time_exec = sw.Elapsed.TotalMilliseconds;
            log.write_log(save, taille, log.time_now(), time_exec); // execute fonction qui va permettre d'écrire dans fichier JSON
            states.write_file(save, taille);
            System.Windows.MessageBox.Show("Sauvegarde terminé avec succès");

        }


        public static void sauvegarde_differentiel()
        {

        }


        public void set_source(string source)
        {
            this.source = source;
        }

        public void set_ext(string[] ext)
        {
            this.ext = ext;
        }

        public void set_destination(string destination)
        {
            this.destination = destination;
        }

        public void set_nom(string nom)
        {
            this.nom = nom;
        }

        public void set_type(string type)
        {
            this.type = type;
        }

        public void set_tmp(double temp)
        {
            tmp = temp;
        }
        public void Set_P()
        {
          p = pourcent;
        }

        public string get_source()
        {
            return this.source;
        }

        public string[] get_ext()
        {
            return this.ext;
        }

        public string get_destination()
        {
            return this.destination;
        }
        public string get_nom()
        {
            return this.nom;
        }

        public string get_type()
        {
            return this.type;
        }
        public float get_p()
        {
            return p;
        }
    }
}
