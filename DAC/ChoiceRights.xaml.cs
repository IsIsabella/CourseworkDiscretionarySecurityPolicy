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
    /// Логика взаимодействия для ChoiceRights.xaml
    /// </summary>
    public partial class ChoiceRights : Window
    {
        AccessControl accessControl = new AccessControl();
        int IDUser;
        int IDBook;
        string Login;
        string BookName;
        char[] TypeOfAccess = new char[4];
        public ChoiceRights(AccessControl AC, int log, int book, string login, string bookname)
        {
            InitializeComponent();
            accessControl = AC;
            IDUser = log;
            IDBook = book;
            Login = login;
            BookName = bookname;
            TypeOfAccess = accessControl.TypeOfAccess(IDUser, IDBook).ToCharArray();
            if (TypeOfAccess.Contains('w'))
            {
                checkBoxWrite.IsChecked = true;
            }
            if (TypeOfAccess.Contains('d'))
            {
                checkBoxDelete.IsChecked = true;
            }
            if (TypeOfAccess.Contains('o'))
            {
                checkBoxOwner.IsChecked = true;
            }
        }

        private void ExtensionClick(object sender, RoutedEventArgs e)
        {
            string newRights = "r";
            if (checkBoxWrite.IsChecked == true)
                newRights += "w";
            if (checkBoxDelete.IsChecked == true)
                newRights += "d";
            if (checkBoxOwner.IsChecked == true)
            {
                newRights += "o";
                WorkWithEXCEL.ChangeOwnerBookInMatrixExcel(IDBook + 2, IDUser + 1);
            }
            accessControl.ChangeRights(Login, BookName, newRights);
            MessageBox.Show("Права успешно изменены.");
            this.Close();
        }
    }
}
