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
        private Paragraph paragraph;
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
                    this.paragraph = new Paragraph();
                    rtbDisplay.Document = new FlowDocument(paragraph);
                    var count = Spreader.spreadText[value - 1].Count(x => Char.IsLetterOrDigit(x));
                    int paddingWidth = 0;
                    string direction = "left";
                    int redChar = 0;
                    string output;
                    switch (count)
                    {
                        case 1:
                            paddingWidth = 0;
                            redChar = 1;
                            break;
                        case 2:
                            paddingWidth = 1;
                            direction = "right";
                            redChar = 2;
                            break;
                        case 3:
                            paddingWidth = 0;
                            redChar = 2;
                            break;
                        case 4:
                            paddingWidth = 1;
                            redChar = 2;
                            break;
                        case 5:
                            paddingWidth = 2;
                            redChar = 2;
                            break;
                        case 6:
                            paddingWidth = 1;
                            redChar = 3;
                            break;
                        case 7:
                            paddingWidth = 2;
                            redChar = 3;
                            break;
                        case 8:
                            paddingWidth = 3;
                            redChar = 3;
                            break;
                        case 9:
                            paddingWidth = 4;
                            redChar = 3;
                            break;
                        case 10:
                            paddingWidth = 3;
                            redChar = 4;
                            break;
                        case 11:
                            paddingWidth = 4;
                            redChar = 4;
                            break;
                        case 12:
                            paddingWidth = 3;
                            redChar = 4;
                            break;
                        default:
                            paddingWidth = 4;
                            redChar = 4;
                            break;
                    }
                    if (direction == "left")
                    {
                        output = PadText.Left(Spreader.spreadText[value - 1], paddingWidth);
                    }
                    else
                    {
                        output = PadText.Right(Spreader.spreadText[value - 1], paddingWidth);
                    }
                    seperateOutputs(output, redChar);
                    paragraph.Inlines.Add(new Run(prered));
                    paragraph.Inlines.Add(new Run(redCharacter)
                    {
                        Foreground = Brushes.Red
                    });
                }
            }
            inChange = false;
        }

        private string prered;
        private string redCharacter;
        private string postred;


        private void seperateOutputs(string i, int r)
        {
           
        }

        private void hsbTextScroller_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!inChange)
            {
                ChangePosition(Convert.ToInt32(hsbTextScroller.Value + 1));
            }

        }
    }
}

