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
namespace DAC
{
    /// <summary>
    /// Логика взаимодействия для SingUpWindow.xaml
    /// </summary>
    public partial class SingUpWindow : Window
    {
        AccessControl accessControl = new AccessControl();
        List<string> UserList = new List<string>();
        public SingUpWindow(AccessControl AC)
        {
            InitializeComponent();
            accessControl = AC;
            UserList = new List<string>();
            WorkWithEXCEL.ReadUsersFromExcelForListBox(UserList);
        }

        private void SingUpClick(object sender, RoutedEventArgs e)
        {
            string pas = UserPasswordTextBox.Password.ToString();
            string stat = UserTypeComboBox.Text.ToString();
            string log = UserNameTextBox.Text.ToString();
            if (pas != "" && log != "" && stat!="")
            {
                if (!UserList.Contains(log))
                {
                    WorkWithEXCEL.WriteToExcelForSingUp(pas, stat, log);
                    accessControl.FillingMatrix();
                    MessageBox.Show("Данные успешно сохранены.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Данное имя пользователя уже существует.");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены.");
            }
            
        }


    }
}
