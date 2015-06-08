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
using System.Windows.Shapes;

namespace rapide
{
    /// <summary>
    /// Interaction logic for SpreadWindow.xaml
    /// </summary>
    public partial class SpreadWindow : Window
    {
        public SpreadWindow()
        {
            InitializeComponent();
            hsbTextScroller.Maximum = Spreader.spreadText.Length;
        }

        private void txtbxScroller_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!inChange)
            {
                int result;
                Int32.TryParse(txtbxScroller.Text, out result);
                ChangePosition(result);
            }
        }

        private bool inChange = false;

        public void ChangePosition(int value)
        {
            if (!inChange)
            {
                inChange = true;
                if (value > 0 & value < Spreader.GetLength() + 1)
                {
                    txtbxScroller.Text = value.ToString();
                    hsbTextScroller.Value = value - 1;
                    rtbDisplay.Document.Blocks.Clear();
                    rtbDisplay.Document.Blocks.Add(new Paragraph(new Run(Spreader.spreadText[value-1])));
                }
            }
            inChange = false;
        }

        private void hsbTextScroller_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ChangePosition(Convert.ToInt32(hsbTextScroller.Value + 1));
        }

    }
}

