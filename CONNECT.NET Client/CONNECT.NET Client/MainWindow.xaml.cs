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
using MahApps.Metro.Controls;
using CONNECT.NET_Client.forms;
using CONNECT.NET_Client.classes;
namespace CONNECT.NET_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        
        private gestion_bd gestion = new gestion_bd();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Files_Explorer.Items.Clear();
            foreach (var obj in gestion.Reader_Array("select nom from files"))
            {
                Files_Explorer.Items.Add(obj);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
            UploadFiles upload = new UploadFiles();
            upload.Show();
            this.Close();
        }

        private void Email_Click(object sender, RoutedEventArgs e)
        {
            Email em = new Email();
            em.Show();
            this.Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gestion_bd g = new gestion_bd();
            g.GetFilesFromDatabase("select nom,fichier from files ",@"c:\out");
        }

        private void Files_Explorer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
