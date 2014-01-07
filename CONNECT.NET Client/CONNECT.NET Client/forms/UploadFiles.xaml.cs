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
using MahApps.Metro.Controls;
using CONNECT.NET_Client.classes;

namespace CONNECT.NET_Client
{
    /// <summary>
    /// Interaction logic for UploadFiles.xaml
    /// </summary>
    public partial class UploadFiles : MetroWindow
    {

        gestion_bd gestion = new gestion_bd();
        public UploadFiles()
        {
            InitializeComponent();
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            utils ut = new utils();
            string[] id_class= LisClass.SelectedValue.ToString().Split('-');
         
            string path=ut.ShowDialog();
            TextRange textRange = new TextRange(Description.Document.ContentStart,
                        Description.Document.ContentEnd  );
                //never gets here because result is always null
            if (MessageBox.Show("Vous êtes sur?Yes/No",
                        "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                MessageBox.Show(gestion.insert_files(path, int.Parse(id_class[0]),textRange.Text), "Info");
            }
            else
            {
                MessageBox.Show("Oops!!! Opération annulée");
            } 
          
          
        
         
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gestion.Charger_combo(LisClass, "select * from classes");

        }

        private void LisClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnFiles.Visibility = Visibility.Visible;
        }
    }
}
