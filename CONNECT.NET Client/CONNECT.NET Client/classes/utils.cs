using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Collections;
namespace CONNECT.NET_Client.classes
{
    class utils
    {
        private gestion_bd bd = new gestion_bd();

        public ArrayList Get_Object_At_BD(string req,int position) {
            ArrayList array = new ArrayList();
          SqlDataReader dr = bd.Reader(req);
          array.Clear();
          while (dr.Read()) {
              array.Add(dr[position]);


          }
          return array;
            
        }

        public void load_email(DataGrid data,string req_style,string req){
            
            SqlDataReader dr = bd.Reader(req);
            SqlDataReader dr_style = bd.Reader(req_style);
            if (dr_style[0].ToString() == "0") {
               
            
            }
            
        
        }
        
        public string ShowDialog() {

            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "All Files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                return (filename);
            }
            else {

                return null;
            }
        }

    }
}
