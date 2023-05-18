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
    /// Логика взаимодействия для ForAdministrators.xaml
    /// </summary>
    public partial class ForAdministrators : Window
    {
        AccessControl accessControl = new AccessControl();
        string log;
        string pass;
        public ForAdministrators(AccessControl AC, string p, string l)
        {
            InitializeComponent();
            accessControl = AC;
            log = l;
            pass = p;
        }

        private void WorkWithBookClick(object sender, RoutedEventArgs e)
        {
            var wds = new ChoiceBooks(accessControl, pass, log);
            wds.Owner = this;
            //this.Hide();
            wds.ShowDialog();
            //this.Show();
        }

        private void ExtensionRightsClick(object sender, RoutedEventArgs e)
        {
            var wds = new ExtensionRights(accessControl, log, pass);
            wds.Owner = this;
            //this.Hide();
            wds.ShowDialog();
            //this.Show();
        }

        private void DeleteUserClick(object sender, RoutedEventArgs e)
        {
            var wds = new DeleteUser(accessControl);
            wds.Owner = this;
            //this.Hide();
            wds.ShowDialog();
            //this.Show();
        }

        private void SingUpClick(object sender, RoutedEventArgs e)
        {
            var wds = new SingUpWindow(accessControl);
            wds.Owner = this;
            //this.Hide();
            wds.ShowDialog();
            //this.Show();
            
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
