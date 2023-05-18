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

namespace DAC
{
    /// <summary>
    /// Логика взаимодействия для DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        AccessControl accessControl = new AccessControl();
        public DeleteUser(AccessControl AC)
        {
            InitializeComponent();
            List<string> UserList = new List<string>();
            WorkWithEXCEL.ReadUsersFromExcelForListBox(UserList);
            for (int i = 0; i < UserList.Count; i++)
            {
                UsersListBox.Items.Add(UserList[i]);
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UsersListBox.SelectedItem != null)
                {
                    string log = UsersListBox.SelectedItem.ToString();
                    accessControl.DeleteUser(log);
                    this.Close();
                }
                 else
                {
                    MessageBox.Show("Пользователь не выбран.");
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Пользователь не выбран.");
            }
        }
    }
}
