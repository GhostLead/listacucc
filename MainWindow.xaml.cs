using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _ofd = new OpenFileDialog();
            _ofd.Title = "Válassza ki a betötendő fájlt!";

            if (_ofd.ShowDialog() == false)
            {
                return;
            }

            StreamReader fajlOlvaso = new StreamReader(_ofd.FileName);

            String? olvasottSor;

            while (!fajlOlvaso.EndOfStream)
            {
                olvasottSor = fajlOlvaso.ReadLine();

                if (olvasottSor != "")
                {
                    lbOne.Items.Add(olvasottSor);
                }
            }

            fajlOlvaso.Close();

        }

        private void btnElment_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog _sfd = new SaveFileDialog();

            if (_sfd.ShowDialog() == true)
            {
                StreamWriter fajliro = new StreamWriter(_sfd.FileName);
                foreach (Object aktObjektum in lbTwo.Items)
                {
                    fajliro.WriteLine(aktObjektum.ToString());
                }
                fajliro.Close();
            }

        }

        private void btnValogat_Click(object sender, RoutedEventArgs e)
        {
            lbTwo.Items.Clear();
            foreach (Object aktObjektum in lbOne.Items)
            {
                if (chkNincsKulonbseg.IsChecked == true)
                {
                    if (aktObjektum.ToString().ToLower().Contains(txtSzoveg.Text.ToLower()))
                    {
                        lbTwo.Items.Add(aktObjektum.ToString());
                    }
                }
                else
                {
                    if (aktObjektum.ToString().Contains(txtSzoveg.Text))
                    {
                        lbTwo.Items.Add(aktObjektum.ToString());
                    }
                }
            }
        }
    }
}
