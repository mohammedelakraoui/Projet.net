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
using System.Collections;
using CONNECT.NET_Client.classes;
namespace CONNECT.NET_Client.forms
{
    /// <summary>
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : MetroWindow
    {
        private gestion_bd gestion_ = new gestion_bd();
        private ArrayList emails_recu= new ArrayList();
        private ArrayList emails_env = new ArrayList();
        utils util = new utils();
        public Email()
        {
            InitializeComponent();
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void TabItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TabItem_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

           
        }

        private void TabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
     //       emails = new ArrayList();
       //     utils util = new utils();
      //      emails = util.Get_Object_At_BD("select e.email from emails_etudiant e,etudiants et,profs p where p.id=e.id_emmeteur and et.id=e.id_etudiant and p.id='1'", 0);
      //      envoie.ItemsSource = gestion_.Reader("select CONCAT(p.nom,' : ',p.prenom,' : ',e.objet,' Le: ',e.[date]) Envoyées from emails_etudiant e,etudiants et,profs p where p.id=e.id_emmeteur and et.id=e.id_etudiant and p.id='1'");
      //      reception.ItemsSource = gestion_.Reader("select CONCAT(et.nom,' : ',et.prenom,' : ',e.objet,' Le: ',e.[date]) Reçus from emails_prof e,profs p,etudiants et where et.id=e.id_emmeteur and p.id=e.id_prof and p.id='1'");
        
   
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            emails_recu.Clear();
            emails_env.Clear();
            emails_recu = util.Get_Object_At_BD("select e.corps from emails_prof e,etudiants et where et.id=e.id_emmeteur  and e.id_prof='1'", 0);
            emails_env = util.Get_Object_At_BD("select e.corps from emails_etudiant e,profs p where p.id=e.id_emmeteur and e.id_emmeteur='1'", 0);
            envoie.ItemsSource = gestion_.Reader("select CONCAT(p.nom,' : ',p.prenom,' : ',e.objet,' Le: ',e.[date])  from emails_etudiant e,profs p where p.id=e.id_emmeteur and e.id_emmeteur='1'");
            reception.ItemsSource = gestion_.Reader("select CONCAT(et.nom,' : ',et.prenom,' : ',e.objet,' Le: ',e.[date]) Reçus from emails_prof e,etudiants et where et.id=e.id_emmeteur  and e.id_prof='1'");
        
        }

       
        private void reception_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int index=reception.Items.IndexOf(reception.SelectedItem);
           
            if (index != -1) {
                Lire.Items.Clear();
                 Lire.Items.Add(emails_recu[index].ToString());
            }
            
        }

        private void envoie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = envoie.Items.IndexOf(reception.SelectedItem);
            MessageBox.Show(index + "");
            if (index != -1)
            {
                Lire.Items.Clear();
                Lire.Items.Add(emails_env[index].ToString());
            }
        }

        private void envoie_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int index = envoie.Items.IndexOf(reception.SelectedItem);
            //MessageBox.Show(index + "");
            if (index != -1)
            {
                Lire.Items.Clear();
                Lire.Items.Add(emails_env[index].ToString());
            }
            
        }
        
    }
}
