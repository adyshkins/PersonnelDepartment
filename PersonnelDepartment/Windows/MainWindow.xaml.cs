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
using PersonnelDepartment.Pages;
using PersonnelDepartment.ClassHelper;

namespace PersonnelDepartment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateClass.frame = MainFrame;

        }

        private void BtnEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeePage());
        }

        private void btnDepartment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DepartmentPage()); 
        }
             
        private void btnPostList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PostPage());
        }
    }
}
