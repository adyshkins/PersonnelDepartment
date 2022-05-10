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
using PersonnelDepartment.ClassHelper;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnSignIN_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = EFData.Context.Employee.ToList().
                Where(i => i.Login == txtLogin.Text && i.Password == txtPassword.Password).
                FirstOrDefault();

            if (userAuth != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
