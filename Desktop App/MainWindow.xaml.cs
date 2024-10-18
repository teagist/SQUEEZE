using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

namespace FileEncoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // File check values
        private bool isFileUploaded = false;
        private bool isNewFileLocUploaded = false;

        //********************************************************************
        // Color values for app theme
        SolidColorBrush darkModeColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
        SolidColorBrush darkModeTextBoxColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C"));
        SolidColorBrush darkModeButtonColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6C6C6C"));
        SolidColorBrush darkModeTabItemColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF68217A"));

        SolidColorBrush defaultTabBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE3E3E3"));
        SolidColorBrush defaultTextBoxBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        SolidColorBrush defaultButtonBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDDDDDD"));

        SolidColorBrush blueModeTabItemColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE5C365"));
        SolidColorBrush blueModeBckGrdColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0E6198"));

        SolidColorBrush whiteTextColorBrush = Brushes.White;
        //********************************************************************

        /*********************************************************************
         * METHOD NAME: Constructor. 
         ********************************************************************/
        public MainWindow()
        {
            InitializeComponent();

            string prefFilePath = @"..\..\..\InformationTextFiles\preferences.txt";
            int theme = 0;
            try
            {
                using (StreamReader sr = new StreamReader(prefFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("theme = light"))
                        {
                            theme = 1;
                            break;
                        }
                        else if (line.Contains("theme = dark"))
                        {
                            theme = 2;
                            break;
                        }
                        else if (line.Contains("theme = blue"))
                        {
                            theme = 3;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("No theme found in preferences file.");
                        }
                    }
                }

                if (theme == 1)
                {
                    setLightTabControlColors(TabCtrl);
                }
                else if (theme == 2)
                {
                    setDarkTabControlColors(TabCtrl);
                }
                else if (theme == 3)
                {
                    setBlueTabControlColors(TabCtrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Exception: " + ex);
            }
        }

        //********************************************************************
        //  METHOD NAME: 
        //
        //  DESCRIPTION: 
        //********************************************************************
        private void NewFile_ClickHandler(object sender, RoutedEventArgs e)
        {

        }

        //********************************************************************
        //  METHOD NAME: FileExitApplication_ClickHandler.
        //
        //  DESCRIPTION: If the 'Exit' button is clicked, then the program
        //               will close.  
        //********************************************************************
        private void FileExitApplication_ClickHandler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //********************************************************************
        //  METHOD NAME: About_ClickHandler.
        //
        //  DESCRIPTION: If the 'About' button is clicked from the menu bar,
        //               then the About window will be displayed.    
        //********************************************************************
        private void About_ClickHandler(object sender, RoutedEventArgs e)
        {
            AboutWindow abtWin = new AboutWindow();
            abtWin.Show();
        }

        //********************************************************************
        //  METHOD NAME: 
        //
        //  DESCRIPTION:  
        //********************************************************************
        private void EncodeButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isFileUploaded && isNewFileLocUploaded)
                {
                    MessageBox.Show("Encoded message!");
                }
                else if (!isFileUploaded && !isNewFileLocUploaded)
                {
                    MessageBox.Show("Please upload a file to encode and a " +
                                    "location for the new file.");
                }
                else if (!isFileUploaded)
                {
                    MessageBox.Show("Please upload a file to encode.");
                }
                else if (!isNewFileLocUploaded)
                {
                    MessageBox.Show("Please upload a destination for the " +
                                    "new file.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //********************************************************************
        //  METHOD NAME: changeTabControlColors.
        //
        //  DESCRIPTION: This method changes the theme of the app and its 
        //               elements to dark colors.  
        //********************************************************************
        private void setDarkTabControlColors(TabControl tabControl)
        {
            this.Background = darkModeColorBrush;
            tabControl.Background = darkModeTabItemColor;
            tabControl.Foreground = whiteTextColorBrush;

            foreach (TabItem tabItem in tabControl.Items)
            {
                tabItem.Background = darkModeTabItemColor;
                tabItem.Foreground = whiteTextColorBrush;

                if (tabItem.Content is Panel panel)
                {
                    foreach (UIElement element in panel.Children)
                    {
                        if (element is TextBlock textBlock)
                        {
                            textBlock.Foreground = whiteTextColorBrush;
                        }
                    }
                }
            }

            Tab1Grid.Background = darkModeColorBrush;
            Tab2Grid.Background = darkModeColorBrush;

            EncodeFileLocLabel.Foreground = whiteTextColorBrush;
            EncodeFileTextBox.Background = darkModeTextBoxColor;
            EncodeFileTextBox.Foreground = whiteTextColorBrush;

            NewFileFileLocLabel.Foreground = whiteTextColorBrush;
            NewFileLocTextBox.Background = darkModeTextBoxColor;
            NewFileLocTextBox.Foreground = whiteTextColorBrush;

            EncodeFileLocButton.Background = darkModeButtonColor;
            EncodeFileLocButton.Foreground = whiteTextColorBrush;

            NewFileLocButton.Background = darkModeButtonColor;
            NewFileLocButton.Foreground = whiteTextColorBrush;

            EncodeButton.Background = darkModeTextBoxColor;
            EncodeButton.Foreground = whiteTextColorBrush;
        }

        //********************************************************************
        //  METHOD NAME: resetTabControlColors.
        //
        //  DESCRIPTION: This method resets the colors of the app and its 
        //               elements to the defaults or light colors.  
        //********************************************************************
        private void setLightTabControlColors(TabControl tabControl)
        {
            this.Background = SystemColors.ControlBrush;
            tabControl.Background = SystemColors.ControlBrush;
            tabControl.Foreground = SystemColors.ControlTextBrush;

            foreach (TabItem tabItem in tabControl.Items)
            {
                tabItem.Background = SystemColors.ControlBrush;
                tabItem.Foreground = SystemColors.ControlTextBrush;

                if (tabItem.Content is Panel panel)
                {
                    foreach (UIElement element in panel.Children)
                    {
                        if (element is TextBlock textBlock)
                        {
                            textBlock.Foreground = SystemColors.ControlTextBrush;
                        }
                    }
                }
            }

            Tab1Grid.Background = defaultTabBackgroundColor;
            Tab2Grid.Background = defaultTabBackgroundColor;

            EncodeFileLocLabel.Foreground = Brushes.Black;
            EncodeFileTextBox.Background = defaultTextBoxBackgroundColor;
            EncodeFileTextBox.Foreground = Brushes.Black;

            NewFileFileLocLabel.Foreground = Brushes.Black;
            NewFileLocTextBox.Background = defaultTextBoxBackgroundColor;
            NewFileLocTextBox.Foreground = Brushes.Black;

            EncodeFileLocButton.Background = defaultButtonBackgroundColor;
            EncodeFileLocButton.Foreground = Brushes.Black;

            NewFileLocButton.Background = defaultButtonBackgroundColor;
            NewFileLocButton.Foreground = Brushes.Black;

            EncodeButton.Background = defaultButtonBackgroundColor;
            EncodeButton.Foreground = Brushes.Black;
        }

        //********************************************************************
        //  METHOD NAME: resetTabControlColors.
        //
        //  DESCRIPTION: This method resets the colors of the app and its 
        //               elements to blue colors.  
        //********************************************************************
        private void setBlueTabControlColors(TabControl tabControl)
        {
            this.Background = blueModeBckGrdColor;
            tabControl.Background = blueModeTabItemColor;
            tabControl.Foreground = SystemColors.ControlTextBrush;

            foreach (TabItem tabItem in tabControl.Items)
            {
                tabItem.Background = blueModeTabItemColor;
                tabItem.Foreground = SystemColors.ControlTextBrush;

                if (tabItem.Content is Panel panel)
                {
                    foreach (UIElement element in panel.Children)
                    {
                        if (element is TextBlock textBlock)
                        {
                            textBlock.Foreground = SystemColors.ControlTextBrush;
                        }
                    }
                }
            }

            Tab1Grid.Background = Brushes.CornflowerBlue;
            Tab2Grid.Background = Brushes.CornflowerBlue;

            EncodeFileLocLabel.Foreground = Brushes.White;
            EncodeFileTextBox.Background = defaultTextBoxBackgroundColor;
            EncodeFileTextBox.Foreground = Brushes.Black;

            NewFileFileLocLabel.Foreground = Brushes.White;
            NewFileLocTextBox.Background = defaultTextBoxBackgroundColor;
            NewFileLocTextBox.Foreground = Brushes.Black;

            EncodeFileLocButton.Background = Brushes.CadetBlue;
            EncodeFileLocButton.Foreground = Brushes.White;
            EncodeFileLocButton.BorderBrush = Brushes.Black;

            NewFileLocButton.Background = Brushes.CadetBlue;
            NewFileLocButton.Foreground = Brushes.White;
            NewFileLocButton.BorderBrush = Brushes.Black;

            EncodeButton.Background = Brushes.CadetBlue;
            EncodeButton.Foreground = Brushes.White;
            EncodeButton.BorderBrush = Brushes.Black;

            GridZeroToolBar.Background = Brushes.CornflowerBlue;
        }

        //********************************************************************
        //  METHOD NAME: EncodeFileLocationButton_Click.
        //
        //  DESCRIPTION: If the "Encode File Location" Button is clicked, 
        //               then the user will be able to search for the file
        //               to encode.  
        //********************************************************************
        private void EncodeFileLocationButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                string shortPathBegin = @"..\";
                string path = openFileDlg.FileName;
                string[] pathArr = path.Split('\\');
                string fileName = shortPathBegin + pathArr.Last().ToString();
                EncodeFileTextBox.Text = fileName;
                isFileUploaded = true;
            }
        }

        //********************************************************************
        //  METHOD NAME: NewFileLocationButton_Click.
        //
        //  DESCRIPTION: If the "New File Location" Button is clicked,
        //               then the user will be able to search for a 
        //               destination.  
        //********************************************************************
        private void NewFileLocationButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                string shortPathBegin = @"..\";
                string path = openFileDlg.FileName;
                string[] pathArr = path.Split('\\');
                string fileName = shortPathBegin + pathArr.Last().ToString();
                NewFileLocTextBox.Text = fileName;
                isNewFileLocUploaded = true;
            }
        }

        //********************************************************************
        //  METHOD NAME: updatePrferencesDarkModeValue.
        //
        //  DESCRIPTION: This method will update the preferences file to 
        //               set the value for dark mode to true or false,
        //               depending on the value of the parameter "darkMode".
        //********************************************************************
        private void updatePrferencesDarkModeValue(int theme)
        {
            string prefFilePath = @"..\..\..\InformationTextFiles\preferences.txt";
            string newThemeValue = string.Empty;

            switch (theme)
            {
                case 1:
                    newThemeValue = "light";
                    break;
                case 2:
                    newThemeValue = "dark";
                    break;
                case 3:
                    newThemeValue = "blue";
                    break;
                default:
                    MessageBox.Show("Invalid theme value");
                    return;
            }

            try
            {
                string[] lines = File.ReadAllLines(prefFilePath);

                // Open a stream to write back the modified content
                using (StreamWriter writer = new StreamWriter(prefFilePath))
                {
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("theme = "))
                        {
                            // Write the updated line with the new theme value
                            writer.WriteLine($"theme = {newThemeValue}");
                        }
                        else
                        {
                            // Write the unchanged lines
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Exception occurred while updating preferences file: " + ex);
            }
        }
        
        //********************************************************************
        //  METHOD NAME: DarkModeEnvironmentMenuItem_Click.
        //
        //  DESCRIPTION: If the user selects the dark mode environment,
        //               this method will set the theme.  
        //********************************************************************
        private void DarkModeEnvironmentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            updatePrferencesDarkModeValue(2);
            setDarkTabControlColors(TabCtrl);
        }

        //********************************************************************
        //  METHOD NAME: LightModeEnvironmentMenuItem_Click.
        //
        //  DESCRIPTION: If the user selects the light mode environment,
        //               this method will set the theme.
        //********************************************************************
        private void LightModeEnvironmentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            updatePrferencesDarkModeValue(1);
            setLightTabControlColors(TabCtrl);
        }

        private void BlueModeEnvironmentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            updatePrferencesDarkModeValue(3);
            setBlueTabControlColors(TabCtrl);
        }
    }
}
