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


        public static void sauvegarde_complet(string source, string dest)
        {
            etat_file = State.INPROGRESS;

            foreach (var directory in Directory.GetDirectories(source))
            {
                string dirName = Path.GetFileName(directory);
                if (!Directory.Exists(Path.Combine(dest, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, dirName));
                    Console.Write(Path.Combine(dest, dirName));
                }
                sauvegarde_complet(directory, Path.Combine(dest, dirName));
            }
            nbfile = 0;
            foreach (var file in Directory.GetFiles(source))
            {
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
                nbfile++;
            }
            etat_file = State.END;


        }


        public static void sauvegarde_differentiel()
        {

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
