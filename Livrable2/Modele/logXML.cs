using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;


namespace Livrable2.Modele
{
    class logXML
    {
        public static void log_xml(sauvegarde entrer, long size, string date, double time_exec)
        {
            string file_path = @"C:\Users\ryan2\Desktop\CESI\CI A3\Programmation système\Projet\Projet final\Livrable2\bin\Debug\netcoreapp3.1\logXML.xml";
            if (!File.Exists(file_path))
            {
                using (XmlWriter writer = XmlWriter.Create("logXML.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Saves");

                    writer.WriteStartElement("Save");

                    writer.WriteElementString("Name", entrer.get_nom());
                    writer.WriteElementString("Date", date);
                    writer.WriteElementString("Source", entrer.get_source());
                    writer.WriteElementString("Destination", entrer.get_destination());
                    writer.WriteElementString("Size", size.ToString());
                    writer.WriteElementString("Time", time_exec.ToString());

                    writer.WriteEndElement();

                    writer.WriteEndElement();                                    
                    writer.WriteEndDocument();
                }
            }
            else
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("logXML.xml");
                XmlNode nl = xd.SelectSingleNode("//Saves");
                XmlDocument xd2 = new XmlDocument();
                xd2.LoadXml("<Save><Name>"+entrer.get_nom()+ "</Name><Date>" + date + "</Date><Source>" + entrer.get_source() + "</Source><Destination>" + entrer.get_destination() + "</Destination><Size>" + size.ToString() + "</Size><Time>" + time_exec.ToString() + "ms</Time></Save>");
                XmlNode n = xd.ImportNode(xd2.FirstChild, true);
                nl.AppendChild(n);
                xd.Save("logXML.xml");
                 
                
            }


        }
    }
}