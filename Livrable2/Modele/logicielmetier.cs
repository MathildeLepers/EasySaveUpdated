using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Livrable2.Modele
{
    class logicielmetier
    {
        public static bool Logiciel_Metier(string softwareName)
        {
            System.Windows.MessageBox.Show(softwareName + " " + Process.GetProcessesByName("notepad").ToString() );
            if ( Process.GetProcessesByName(softwareName).Length > 0)
            {
                
                var result = System.Windows.MessageBox.Show("Une application est lancé, voulez vous la fermer ? ", "Easysave", System.Windows.MessageBoxButton.YesNo);

                switch (result)
                {

                    case System.Windows.MessageBoxResult.Yes:
                        Process[] proc = Process.GetProcessesByName(softwareName);
                        if(proc.Length == 0)
                        {
                            System.Windows.MessageBox.Show("Le logiciel a été fermer ");
                        }
                        else
                        {
                            proc[0].Kill();
                            System.Windows.MessageBox.Show("Le logiciel a été fermer ");
                        }
                        break;
                    
                    case System.Windows.MessageBoxResult.No:
                        //Logiciel_Metier(softwareName);
                        return true;
                        
                        

                }
                
            }

            return false;
        }
    }
}
