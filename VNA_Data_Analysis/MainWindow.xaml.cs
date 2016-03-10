using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VNA_Data_Analysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Retrieve InitialDirectory from Properties
            folderTextBox.Text = Properties.Settings.Default.InitialDirectory;
        }

        /// <summary>
        /// Update the selected data folder by using a FolderBrowserDialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.SelectedPath = folderTextBox.Text;
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                folderTextBox.Text = dialog.SelectedPath;
                // Persist InitialDirectory by saving to a custom property
                Properties.Settings.Default.InitialDirectory = dialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
            
        }
    }
}
