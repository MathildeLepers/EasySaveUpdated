using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Livrable2.Modele;

namespace Livrable2.Vue
{
    /// <summary>
    /// Logique d'interaction pour Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }



        private void progress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int c;
            c = sauvegarde.nbfile;
            for (int i = 0; i == sauvegarde.nb;)
            {
                progress.Value = sauvegarde.pourcent;
                if (sauvegarde.nbfile != c)
                {
                    c = sauvegarde.nbfile;
                    i++;
                }
            }
        }
    }
}
