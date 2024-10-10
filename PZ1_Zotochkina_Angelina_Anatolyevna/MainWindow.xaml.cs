using PZ1_Zotochkina_Angelina_Anatolyevna.Models;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PZ1_Zotochkina_Angelina_Anatolyevna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string email, password;
            email = tbEmail.Text;
            password = ComputeSha256Hash(tbPassword.Text);

            using (var context = new PZ1_Zotochkina_Angelina_AnatolyevnaContext())
            {
                var user = context.Users.Where(x => x.Email == email).Where(x => x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    MessageBox.Show("Успешный вход!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Windows.AdmMenu menu = new Windows.AdmMenu();
                    menu.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка почты или пароля", "Ошыбка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        static string ComputeSha256Hash(string rawData) //Хеширование
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Преобразуем строку в байты
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Преобразуем байты в строку в формате hex
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }


}