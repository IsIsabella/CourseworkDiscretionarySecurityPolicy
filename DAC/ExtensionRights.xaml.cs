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
    /// Логика взаимодействия для ExtensionRights.xaml
    /// </summary>
    public partial class ExtensionRights : Window
    {
        AccessControl accessControl = new AccessControl();
        string log;
        string logChanger;
        string passChanger;
        public ExtensionRights(AccessControl AC, string l, string p)
        {
            InitializeComponent();
            List<string> UserList = new List<string>();
            WorkWithEXCEL.ReadUsersFromExcelForListBox(UserList);
            for (int i = 0; i < UserList.Count; i++)
            {
                UsersListBox.Items.Add(UserList[i]);
            }
            List<string> BooksList = new List<string>();
            WorkWithEXCEL.ReadFromExcelForInternalSystemWindow(BooksList);
            for (int i = 0; i < BooksList.Count; i++)
            {
                BooksListComboBox.Items.Add(BooksList[i]);
            }
            accessControl = AC;
            logChanger= l;
            passChanger = p;
        }

        private void ExtensionClick(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem != null)
            {
                log = UsersListBox.SelectedItem.ToString();
                if (BooksListComboBox.Text.ToString() != "")
                {
                    int idChanger = WorkWithEXCEL.SearchUserInExcel(logChanger, passChanger);
                    int idBook = WorkWithEXCEL.SearchBookInExcel(BooksListComboBox.Text.ToString());
                    if (accessControl.TypeOfAccess(idChanger, idBook) == "rwo" || accessControl.TypeOfAccess(idChanger, idBook) == "rwdo" || accessControl.TypeOfAccess(idChanger, idBook) == "rdo" || accessControl.TypeOfAccess(idChanger, idBook) == "ro")
                    {
                        int id = WorkWithEXCEL.SearchUserInExcelForExtendingRights(log);
                        var wds = new ChoiceRights(accessControl, id, idBook, log, BooksListComboBox.Text.ToString());
                        wds.Owner = this;
                        wds.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно прав.");
                    }
                }
                else
                {
                    MessageBox.Show("Книга не выбрана.");
                }
            }
            else
            {
                MessageBox.Show("Пользователь не выбран.");
            }

        }
    }
}
