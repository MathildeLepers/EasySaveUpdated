using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

namespace Livrable2.Modele
{
    class fileXML
    {
        public static void file_xml(sauvegarde entrer, long size) // Class which create or update XMLfile
        {
            string file_path = @"C:\Users\ryan2\Desktop\CESI\CI A3\Programmation système\Projet\Projet final\Livrable2\bin\Debug\netcoreapp3.1\fileXML.xml";  // Change by your root access but neccessary to be in .netcoreapp
            if (!File.Exists(file_path)) // if root does'nt exist -> create it
            {
                using (XmlWriter writer = XmlWriter.Create("fileXML.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("States");

                    writer.WriteStartElement("State");

                    writer.WriteElementString("Name", entrer.get_nom());
                    writer.WriteElementString("Date", Modele.log.time_now());
                    writer.WriteElementString("Source", entrer.get_source());
                    writer.WriteElementString("Destination", entrer.get_destination());
                    writer.WriteElementString("Size", size.ToString());
                    writer.WriteElementString("State", Modele.sauvegarde.etat_file.ToString());
                    writer.WriteElementString("NbFile", Modele.sauvegarde.nbfile.ToString());

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            else // or update by xmldocument
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("fileXML.xml");
                XmlNode nl = xd.SelectSingleNode("//States");
                XmlDocument xd2 = new XmlDocument();
                xd2.LoadXml("<State><Name>" + entrer.get_nom() + "</Name><Date>" + Modele.log.time_now() + "</Date><Source>" + entrer.get_source() + "</Source><Destination>" + entrer.get_destination() + "</Destination><Size>" + size.ToString() + "</Size><NbFile>" + Modele.sauvegarde.nbfile.ToString() + "ms</NbFile><State>" + Modele.sauvegarde.etat_file.ToString() + "</State></State>");
                XmlNode n = xd.ImportNode(xd2.FirstChild, true);
                nl.AppendChild(n);
                xd.Save("fileXML.xml");

                
            }
        }
    }
}
