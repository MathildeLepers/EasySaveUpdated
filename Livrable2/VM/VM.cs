using System;
using System.Collections.Generic;
using System.Text;
using Livrable2.Modele;
using System.Threading;
using System.Diagnostics;

namespace Livrable2.VM
{
    public class VM
    {
        public static List<sauvegarde> saveList = new List<sauvegarde>();
        public static List<Thread> threadList = new List<Thread>();
        public static bool? xmlchecked;
        public static bool? jsonchecked;


        public static void run_windows_fr()
        {
            Window1 gg = new Window1();
            gg.Show();
        }

        public static void run_windows_en()
        {
            Window2 g = new Window2();
            g.Show();
        }

        public static void add_save(String[] list, string name, string src, string dest)
        {
            sauvegarde save = new sauvegarde();
            
            save.set_ext(list);
            save.set_nom(name);
            save.set_source(src);
            save.set_destination(dest);
            saveList.Add(save);
        }

        public static void start_save()
        {
            if (xmlchecked == true || jsonchecked == true)
            {
                for (int i = 0; i < saveList.Count; i++)
                {

                    sauvegarde save = saveList[i];

                    Thread thread = new Thread(() => sauvegarde.sauvegarde_complet(save));
                    threadList.Add(thread);
                }


                for (int j = 0; j < threadList.Count; j++)
                {
                    threadList[j].Start();
                   
                    
                }
                
            }

            
        }
     

        public static void button_checked(bool? statexml, bool? statejson)
        {
            if (statexml == true || statejson == false)
            {
                Livrable2.VM.VM.xmlchecked = true;
                Livrable2.VM.VM.jsonchecked = false;

            }
            else if (statexml == false || statejson == true)
            {
                Livrable2.VM.VM.xmlchecked = false;
                Livrable2.VM.VM.jsonchecked = true;
            }


        }

        public void lancer_s(int g)
        {
          
           
//Thread th = new Thread(serverEcoute(g));
            //th.Start();
        }
        public void serverEcoute(int progression)
        {
            string g;
            server s = new server();
            s.SeConnecter("127.0.0.1", 80);
            s.AccepterConnection();
            System.Windows.MessageBox.Show("client connecté");
            string dataReceve = "";
            while (true)
            {
                dataReceve = s.EcouterReseau();
                Debug.WriteLine(dataReceve);
                if (dataReceve == "demande d info")
                {
                    g = progression.ToString();
                    s.envoiData(g);
                }
            }

        }
        public static void crypt()
        {
        //    Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
        //    dialog.Multiselect = true;
        //    dialog.InitialDirectory = TextboxSourceFR.Text;
        //    if (TextboxSourceFR.Text != "") { dialog.ShowDialog(); } else { MessageBox.Show("veuillez entrer un chemin valide"); }


        //    foreach (var file in dialog.FileNames)
        //    {
        //        var fileToCrypt = file.Replace(TextboxSourceFR.Text, TextboxDestinationFR.Text);
        //        Prosoft dr = new Prosoft();
        //        dr.Cryptage(file, fileToCrypt);
        //    }
        }
    }
}
