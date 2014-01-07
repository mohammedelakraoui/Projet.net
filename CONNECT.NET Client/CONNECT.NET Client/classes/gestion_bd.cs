using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.Collections;
namespace CONNECT.NET_Client.classes
{
    class gestion_bd
    {
        public static string connexionString = "Data Source=.;Initial Catalog=connect.net;Integrated Security=True";
        # region Gestion des fichiers
        //Open file in to a filestream and read data in a byte array.
     
        //Get table rows from sql server to be displayed in Datagrid.
    public    void GetFilesFromDatabase(string req,string out_)
        {
         //   try
         //   {

               
                ArrayList array_name = new ArrayList();
                ArrayList array_file = new ArrayList();
                SqlConnection connection = new SqlConnection(connexionString);
                connection.Open();
                SqlCommand command = new
                SqlCommand(req, connection);
                
                SqlDataReader dr= command.ExecuteReader();
                array_name.Clear();
                array_file.Clear();
                while (dr.Read()) {
                    array_name.Add(dr[0]);
                    array_file.Add((byte[])dr[1]);

                }
                connection.Close();
                int i = 0;
                foreach (byte[] buffer in array_file)
                {
                    FileStream fs = new FileStream(out_ + @"\"+array_name[i], FileMode.Create);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                    i++;
                }
               
         //   }
//catch 
        //    {
              
         //   }
        }

        public string  insert_files(string path_file,int id_class,string Description) {


            
            // Read the file and convert it to Byte Array
            string filePath = path_file;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
                 default:
                    contenttype="Other Extension";
                    break;

            }
            if (contenttype != String.Empty)
            {

                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                //insert the file into database
                string strQuery = "insert into files( nom,description,fichier,date,id_class )" +
                   " values ( @nom,@description,@fichier,@date,@id_class)";
                SqlCommand cmd = new SqlCommand(strQuery);
                //cmd.Parameters.Add("@id", SqlDbType.Int).Value = ;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = filename;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = Description;
                cmd.Parameters.Add("@fichier", SqlDbType.Binary).Value = bytes;
                cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Today;
                cmd.Parameters.Add("@id_class", SqlDbType.Int).Value = id_class;
                if (InsertFilesData(cmd))
                {
                    return "File Uploaded Successfully";
                }
                else
                {
                    return "Oops!Error on request!!!";
                }

            }
            else
            {
                
                 return "File format not recognised.Upload (*.*)  formats";
            }

        }

        private Boolean InsertFilesData(SqlCommand cmd)
        {
            String strConnString = connexionString;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }
#endregion

#region requete standard

        public void Open(SqlCommand cmd) {
            String strConnString = connexionString;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
        }

        public void Close(SqlCommand cmd)
        {
            String strConnString = connexionString;
            SqlConnection con = new SqlConnection(strConnString);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Close();
            con.Dispose();
        }
        public ArrayList Reader_Array(string req)
        {
            ArrayList array = new ArrayList();
            array.Clear();
            SqlDataReader dr= Reader(req);
            while (dr.Read())
            {
                array.Add(dr[0]);
            }
            dr.Close();
            return array;
           
        }
        public SqlDataReader Reader(string req){

            try
            {
                SqlCommand cmd = new SqlCommand(req);
                Open(cmd);
                SqlDataReader read = cmd.ExecuteReader();
                Close(cmd);
                return read;
            }
            catch
            {

            }
            

            return null;
        }

        public void Charger_combo(ComboBox combo,string req){
        
            combo.Items.Clear();
            SqlDataReader read=Reader(req);
            while (read.Read()){

            combo.Items.Add(read[0].ToString()+"-"+read[1].ToString());
            }
        
        }



#endregion
    }
}
