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
using System.Diagnostics;
using System.IO;
using System.Threading;
using Livrable2.Modele;
using Livrable2.Vue;

namespace Livrable2
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public List<sauvegarde> saveList = new List<sauvegarde>();
        public List<Thread> threadList = new List<Thread>();
        
        public Window1()
        {
            InitializeComponent();
        }

       
        
        private void Source3Points_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                TextboxSourceFR.Text = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {
                MessageBox.Show("Le répertoire de Source précisé est vide");
            }
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow Menu = new MainWindow();
            Menu.Show();
            this.Close();
        }

        private void DestinationPath_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                TextboxDestinationFR.Text = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {

                MessageBox.Show("Le répertoire source Destination est vide");
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            sauvegarde save = new sauvegarde();
            save.set_nom(TextboxName.Text);
            save.set_source(TextboxSourceFR.Text);
            save.set_destination(TextboxDestinationFR.Text);
            saveList.Add(save);
            TextboxSourceFR.Text = "";
            TextboxDestinationFR.Text = "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < saveList.Count; i++){
               
                
                sauvegarde save = saveList[i];
                  
                Thread thread = new Thread(() => sauvegarde.sauvegarde_complet(save.get_source(), save.get_destination(), save));
                threadList.Add(thread);


            }


            for(int j = 0; j < threadList.Count; j++)
            {

                threadList[j].Start();
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Multiselect = true;
            dialog.InitialDirectory = TextboxSourceFR.Text;
            if (TextboxSourceFR.Text != "") { dialog.ShowDialog(); } else { MessageBox.Show("veuillez entrer un chemin valide"); }


            foreach (var file in dialog.FileNames)
            {
                var fileToCrypt = file.Replace(TextboxSourceFR.Text, TextboxDestinationFR.Text);
                Prosoft dr = new Prosoft();
                dr.Cryptage(file, fileToCrypt);
            }
        }

    }
}
