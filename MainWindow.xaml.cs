using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String tipp = "";
        String megold = "";
        String mutat = "----";
        String kategoria = "Élőlény";
        static List<string> lista1 =new List<string> {};
        static List<string> lista2 = new List<string> { };
        static List<string> lista3 = new List<string> { };
        static List<string> lista = new List<string> { };
        int hiba = 0;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            Uri kepuri = new Uri("kep0.jpg", UriKind.Relative);
            kep1.Source = new BitmapImage(kepuri);
            Random vsz = new Random();
            
            int rnd = vsz.Next(lista.Count);
            megold = lista[rnd];
            mutat = "";
            for (int i = 0; i < megold.Length; i++) mutat += "-";
            l1.Content = mutat;
            hiba = 0;
            l3.Content = "";
            l2.Content = kategoria;
            kapcsol(true);
        }
        private void kapcsol(bool b)
        {

            bA.IsEnabled = b;
            bÁ.IsEnabled = b;
            bB.IsEnabled = b;
            bC.IsEnabled = b;
            bD.IsEnabled = b;
            bE.IsEnabled = b;
            bÉ.IsEnabled = b;
            bF.IsEnabled = b;
            bG.IsEnabled = b;
            bH.IsEnabled = b;
            bI.IsEnabled = b;
            bÍ.IsEnabled = b;
            bJ.IsEnabled = b;
            bK.IsEnabled = b;
            bL.IsEnabled = b;
            bM.IsEnabled = b;
            bN.IsEnabled = b;
            bO.IsEnabled = b;
            bÓ.IsEnabled = b;
            bÖ.IsEnabled = b;
            bŐ.IsEnabled = b;
            bP.IsEnabled = b;
            bQ.IsEnabled = b;
            bR.IsEnabled = b;
            bS.IsEnabled = b;
            bT.IsEnabled = b;
            bU.IsEnabled = b;
            bÚ.IsEnabled = b;
            bÜ.IsEnabled = b;
            bŰ.IsEnabled = b;
            bV.IsEnabled = b;
            bW.IsEnabled = b;
            bX.IsEnabled = b;
            bY.IsEnabled = b;
            bZ.IsEnabled = b;
        }
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            
            clickedButton.IsEnabled = false;
            
                tipp = clickedButton.Content.ToString();
                
                
                char betu = tipp[0];
                l3.Content += "" + betu;


                if (megold.Contains(betu))
                {
                    for (int i = 0; i < megold.Length; i++)
                    {
                        if (megold[i] == betu)
                        {
                            mutat = mutat.Remove(i, 1);
                            mutat = mutat.Insert(i, "" + betu);
                        }
                    }
                    l1.Content = mutat;
                }
                else
                {
                    hiba++;
                    String ujkep = "kep" + hiba + ".jpg";
                    Uri kep2uri = new Uri(ujkep, UriKind.Relative);
                    kep1.Source = new BitmapImage(kep2uri);

                }
                if (hiba >= 11)
                {
                    l2.Content = "Vesztettél!";
                    kapcsol(false);
                }
                if (mutat == megold)
                {
                    l2.Content = "Győztél!";
                kapcsol(false);
            }


        }// Button_Click_1

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StreamReader s = new StreamReader("szavak.csv", Encoding.UTF8);
            string sor = "";
            while (!s.EndOfStream)
            {
                sor = s.ReadLine();
                string[] tomb = sor.Split(';');
                string szo = tomb[0];
                string kat = tomb[1];
                if (kat == "e") lista1.Add(szo);
                if (kat == "t") lista2.Add(szo);
                if (kat == "f") lista3.Add(szo);


            }
              s.Close();
            lista = lista1;
            kapcsol(false);
        }

        private void radio1_Checked(object sender, RoutedEventArgs e)
        {
            lista = lista1;
            kategoria = "Élőlény";
        }

        private void radio2_Checked(object sender, RoutedEventArgs e)
        {
            lista = lista2;
            kategoria = "Tárgy";
        }

        private void radio3_Checked(object sender, RoutedEventArgs e)
        {
            lista = lista3;
            kategoria = "Fogalom";
        }
    }
}
