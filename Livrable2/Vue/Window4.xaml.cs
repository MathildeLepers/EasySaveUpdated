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
using System.Windows.Threading;

namespace Livrable2.Vue
{
    /// <summary>
    /// Logique d'interaction pour Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public static Window4 w = new Window4();
        public static Canvas cv = new Canvas();
        public static int j = 20;
        public static int k = 0;

        public Window4()
        {
            InitializeComponent();
        }

        public void Add()
        {
            ProgressBar pg = new ProgressBar();


            pg.Maximum = 100;
            pg.Minimum = 0;
            pg.Value = 0;
            pg.Height = 30;
            pg.Width = 200;
            pg.Name = "prog" + k.ToString();
            k = k + 1;
            j = j + 40;
            Canvas.SetTop(pg, j);
            cv.Children.Add(pg);

        }
        public static void ProgressBar(double i, int a)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => {
                w.Content = cv;
                w.Show();
                foreach (var child in cv.Children)
                {
                    if (child is ProgressBar && (child as ProgressBar).Name == "prog" + a.ToString())
                    {
                        (child as ProgressBar).Value = i;
                    }
                }
            }), DispatcherPriority.ContextIdle);
            

        }
    }
}
