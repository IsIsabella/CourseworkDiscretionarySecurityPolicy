using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Read.xaml
    /// </summary>
    public partial class Read : Window
    {
        string NameOfBook = "";
        public Read(string name)
        {
            InitializeComponent();
            NameOfBook = name;
            TB.Text = File.ReadAllText(@"C:\Users\admin\Documents\Учеба\ЯрГУ работы\3 курс\Курсовая\DAC\Books\" + NameOfBook + @".txt", Encoding.GetEncoding(1251));
        }
    }
}
