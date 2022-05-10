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
using PersonnelDepartment.ClassHelper;
using PersonnelDepartment.Pages;

namespace PersonnelDepartment.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            GetList();
        }


        private void GetList()
        {
            List<EF.Employee> listEmployee = new List<EF.Employee>();
            listEmployee = EFData.Context.Employee.ToList();
            LVEmployee.ItemsSource = listEmployee;
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            else
            {
                var user = button.DataContext as EF.Employee;

                MessageBox.Show(user.GetFIO);
                NavigateClass.frame.Navigate(new AddEditEmployeePage(user));
            }
           
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new AddEditEmployeePage());
        }
    }
}
