using System;
using System.Collections.Generic;
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
using System.IO;

namespace rapide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string defFileDirectory = Directory.GetCurrentDirectory();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "(*.txt)|*.txt|(*.pdf)|*.pdf|(*.epub)|*.epub";


            ofd.InitialDirectory = defFileDirectory;

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true)
            {
                int fIndex = ofd.FilterIndex;
                string fileName = ofd.FileName;
                switch (fIndex)
                {
                    case 1:
                        txtbxEditor.Text = File.ReadAllText(ofd.FileName);
                        break;
                    case 2:
                        txtbxEditor.Text = PdfOps.ExtractTextFromPdf(ofd.FileName);
                        break;
                    case 3:
                        txtbxEditor.Text = EpubOps.ExtractTextFromEpub(ofd.FileName);
                        break;
                }
                CleanText.MatchAndReplace(txtbxEditor.Text);
            }
        }
    }
}
