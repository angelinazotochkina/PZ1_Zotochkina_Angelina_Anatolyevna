using PZ1_Zotochkina_Angelina_Anatolyevna.Models;
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

namespace PZ1_Zotochkina_Angelina_Anatolyevna.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdmMenu.xaml
    /// </summary>
    public partial class AdmMenu : Window
    {
        public AdmMenu()
        {
            InitializeComponent();

            using (var db = new PZ1_Zotochkina_Angelina_AnatolyevnaContext())
            {
                admDg.ItemsSource = db.Users.ToList();
            }
        }
    }
}
