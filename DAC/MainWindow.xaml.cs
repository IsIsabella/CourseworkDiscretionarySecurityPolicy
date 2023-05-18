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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccessControl accessControl = new AccessControl();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SingInClick(object sender, RoutedEventArgs e)
        {
            string pass = PasswordTextBox.Password.ToString();
            string log = LoginTextBox.Text.ToString();
            string flag = WorkWithEXCEL.ReadFromExcelForSingIn(pass, log);
            if (flag != null)
            {
                accessControl.ReadingMatrix();
                if (flag == "student")
                {
                    var wds = new ChoiceBooks(accessControl,pass,log);
                    wds.Owner = this;
                    this.Hide();
                    wds.ShowDialog();
                    this.Close();
                }
                if (flag == "professor")
                {
                    var wds = new ForProfessors(accessControl, pass, log);
                    wds.Owner = this;
                    this.Hide();
                    wds.ShowDialog();
                    this.Close();
                }
                if(flag== "admin")
                {
                    var wds = new ForAdministrators(accessControl, pass, log);
                    wds.Owner = this;
                    this.Hide();
                    wds.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Повторите попытку.");
            }
        }

        private void ReloadMatrixClick(object sender, RoutedEventArgs e)
        {
            WorkWithEXCEL.ClearMatrix();
            accessControl.FillingMatrix();
        }
    }
}
