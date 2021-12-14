using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Livrable2.Modele;
using System.Diagnostics;

namespace Livrable2.Modele
{
    public class sauvegarde
    {
        private string source;
        public static State etat_file;
        public static int nbfile;
        private string destination;
        private string nom;
        private string type;
        private static double tmp;
        public string[] ext;



        public static void sauvegarde_complet(sauvegarde save)
        {
            string dest = save.get_destination();
            string[] ext = save.get_ext();
            string source = save.get_source();
            Stopwatch sw = Stopwatch.StartNew();
            etat_file = State.INPROGRESS;

            DirectoryInfo disource = new DirectoryInfo(source);
            long taille = log.file_size(disource);
            

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

            foreach (var file in Directory.GetFiles(source))
            {
                foreach(string extention in ext)
                {
                    if(Path.GetExtension(file).Equals(extention, StringComparison.InvariantCultureIgnoreCase))
                    {
                        listFilePrio.Add(file);
                    }
                    else
                    {
                        listFileNoPrio.Add(file);
                    }
                }
            }

            foreach(var file in listFilePrio)
            {
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
                nbfile++;
            }

            foreach (var file in listFileNoPrio)
            {
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
                nbfile++;
            }

            etat_file = State.END;

            sw.Stop();
            double time_exec = sw.Elapsed.TotalMilliseconds;
            log.write_log(save, taille, log.time_now(), time_exec); // execute fonction qui va permettre d'écrire dans fichier JSON
            states.write_file(save, taille);

        }


        public static void sauvegarde_differentiel()
        {

        }

        public void set_ext(string[] ext)
        {
            this.ext = ext;
        }

        public void set_source(string source)
        {
            this.source = source;
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
    }
}
