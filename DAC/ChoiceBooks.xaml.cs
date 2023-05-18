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
    /// Логика взаимодействия для ChoiceBooks.xaml
    /// </summary>
    public partial class ChoiceBooks : Window
    {
        AccessControl accessControl = new AccessControl();
        int userIndex= -1;
        int bookIndex = -1;
        public ChoiceBooks(AccessControl AC, string p, string l)
        {
            InitializeComponent();
            List<string> BooksList = new List<string>();
            WorkWithEXCEL.ReadFromExcelForInternalSystemWindow(BooksList);
            for (int i = 0; i < BooksList.Count; i++)
            {
                BooksListComboBox.Items.Add(BooksList[i]);
            }
            accessControl = AC;
            userIndex = WorkWithEXCEL.SearchUserInExcel(l,p);
        }

        private void RequestClick(object sender, RoutedEventArgs e)
        {
            if (BooksListComboBox.Text.ToString() != "" && TypeOfAccessComboBox.Text.ToString() != "")
            {
                string NameOfBook = BooksListComboBox.Text.ToString();
                bookIndex = WorkWithEXCEL.SearchBookInExcel(NameOfBook);
                char[] TypeOfAccess = accessControl.TypeOfAccess(userIndex, bookIndex).ToCharArray();
                switch (TypeOfAccessComboBox.Text.ToString())
                {
                    case "Чтение файла":
                        var wds = new Read(NameOfBook);
                        wds.Owner = this;
                        wds.ShowDialog();
                        break;
                    case "Запись в файл":
                        if (TypeOfAccess.Contains('w'))
                        {
                            FileAttributes yourFile = File.GetAttributes(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + NameOfBook + @".txt");
                            File.SetAttributes(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + NameOfBook + @".txt", FileAttributes.Normal);
                            Process.Start(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + NameOfBook + @".txt");
                        }
                        else
                        {
                            MessageBox.Show("Отказ в доступе. Вы не можете дописывать книгу.");
                        }
                        break;
                    case "Удаление файла":
                        if (TypeOfAccess.Contains('d') || TypeOfAccess.Contains('o'))
                        {
                            FileAttributes yourFile = File.GetAttributes(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + NameOfBook + @".txt");
                            File.SetAttributes(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + NameOfBook + @".txt", FileAttributes.Normal);
                            File.Delete(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + NameOfBook + @".txt");
                            accessControl.DeleteBook(NameOfBook);
                            MessageBox.Show("Книга успешно удалена.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Отказ в доступе. Вы не можете удалять книгу.");
                        }
                        break;
                }
                System.IO.FileInfo file = new System.IO.FileInfo(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books");
                file.Attributes = System.IO.FileAttributes.Normal;
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены.");
            }
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            var wds = new MainWindow();
            wds.Owner = this;
            wds.ShowDialog();
            this.Close();
        }
    }
}
