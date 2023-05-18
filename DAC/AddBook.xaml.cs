using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        AccessControl accessControl = new AccessControl();
        string log;
        string pass;
        public AddBook(AccessControl AC, string p, string l)
        {
            InitializeComponent();
            accessControl = AC;
            log = l;
            pass = p;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            string namebook = NameTextBox.Text.ToString();
            string authorname=AuthorNameTextBox.Text.ToString();
            string authorsurname=AuthorSurnameTextBox.Text.ToString();
            if(namebook!="" && authorname!="" && authorsurname != "")
            {
                int owner = WorkWithEXCEL.SearchUserInExcel(log,pass);
                accessControl.AddBook(namebook,authorname,authorsurname,owner);
                FileStream F = new FileStream(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + namebook + @".txt", 
                    FileMode.OpenOrCreate, FileAccess.ReadWrite);
                F.Close();
                FileAttributes yourFile = File.GetAttributes(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + namebook + @".txt");
                File.SetAttributes(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + namebook + @".txt", FileAttributes.Normal);
                Process.Start(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + namebook + @".txt");
                MessageBox.Show("Книга успешно добавлена.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены.");
            }
        }
    }
}
