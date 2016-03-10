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

            List<KeyValuePair<double, double>> entries = new List<KeyValuePair<double, double>>();
            entries.Add(new KeyValuePair<double, double>(0.0, 1.0));
            entries.Add(new KeyValuePair<double, double>(1.0, 1.2));
            entries.Add(new KeyValuePair<double, double>(2.0, 1.3));
            entries.Add(new KeyValuePair<double, double>(3.0, 1.5));
            entries.Add(new KeyValuePair<double, double>(5.0, 1.9));

            S11Chart.DataContext = entries;
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
