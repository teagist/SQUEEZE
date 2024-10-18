using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileEncoder
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            try
            {
                string filePath = @"..\..\..\InformationTextFiles\aboutTextFile.txt";
                string[] lines = File.ReadAllLines(filePath);
                string text = string.Join(" ", lines);
                
                AboutTextBox.Text = text;
            }
            catch(IOException ex)
            {
                MessageBox.Show("Error loading content.");
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
