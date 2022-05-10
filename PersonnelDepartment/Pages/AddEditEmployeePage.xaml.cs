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
    /// Логика взаимодействия для AddEditEmployeePage.xaml
    /// </summary>
    public partial class AddEditEmployeePage : Page
    {

        private bool isEdit = false;
        private EF.Employee editEmployee = new EF.Employee();

        public AddEditEmployeePage()
        {
            InitializeComponent();
        }

        public AddEditEmployeePage(EF.Employee employee)
        {
            InitializeComponent();

            isEdit = true;
            editEmployee = employee;    
            // заполнение полей работника

            txtLastName.Text = employee.LastName;
            txtFirstName.Text = employee.FirstName;
            txtMiddleName.Text = employee.MiddleName;
            txtID.Text = employee.ID.ToString();
            txtINN.Text = employee.INN;
            txtDateOfBirth.Text = employee.DateOfBirth.ToString();
            txtCoefficient.Text = employee.Coefficient.ToString();
            txtAddress.Text = employee.Address.ToString();  
            txtPhone.Text = employee.Phone.ToString();

            // заполнение паспорта
            var passportUser = EFData.Context.Passport.ToList().Where(i => i.IDEmployee == employee.ID).First();

            txtPassportNumber.Text = passportUser.Number;
            txtPassportSeries.Text = passportUser.Series.ToString();    
            txtPlaceOfIssue.Text = passportUser.PlaceOfIssue.ToString();
            txtDateOfIssue.Text = passportUser.DateOfIssue.ToString();



        }

        private void btnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || txtLastName.Text == "Фамилия")
            {
                MessageBox.Show("Поле Фамилия не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || txtFirstName.Text == "Имя")
            {
                MessageBox.Show("Поле Имя не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text == "Адрес")
            {
                MessageBox.Show("Поле Адресс не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCoefficient.Text) || txtCoefficient.Text == "Коэффициент")
            {
                MessageBox.Show("Поле Коэффициент не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text == "Телефон")
            {
                MessageBox.Show("Поле Телефон не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtINN.Text) || txtINN.Text == "ИНН")
            {
                MessageBox.Show("Поле ИНН не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!txtDateOfBirth.SelectedDate.HasValue)
            {
                MessageBox.Show("Поле Дата рождения не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!txtDateOfIssue.SelectedDate.HasValue)
            {
                MessageBox.Show("Поле Дата выдачи не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Decimal.TryParse(txtCoefficient.Text, out decimal coefficient))
            {
                MessageBox.Show("Неверный формат данных для поля Коэффициент", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // внесение изменений

            if (isEdit)
            {
                editEmployee.LastName = txtLastName.Text;
                editEmployee.FirstName = txtFirstName.Text;
                editEmployee.MiddleName = txtMiddleName.Text;
                editEmployee.Address = txtAddress.Text;
                editEmployee.Coefficient = Convert.ToDecimal(txtCoefficient.Text);
                editEmployee.Phone = txtPhone.Text;
                editEmployee.DateOfBirth = txtDateOfBirth.SelectedDate.Value;
                editEmployee.INN = txtINN.Text;
                editEmployee.IsActive = true;
                editEmployee.Login = "user";
                editEmployee.Password = "user";

                EFData.Context.SaveChanges();
                MessageBox.Show("Данные изменены", "Выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                EF.Employee addEmployee = new EF.Employee();

                addEmployee.LastName = txtLastName.Text;
                addEmployee.FirstName = txtFirstName.Text;
                addEmployee.MiddleName = txtMiddleName.Text;
                addEmployee.Address = txtAddress.Text;
                addEmployee.Coefficient = Convert.ToDecimal(txtCoefficient.Text);
                addEmployee.Phone = txtPhone.Text;
                addEmployee.DateOfBirth = txtDateOfBirth.SelectedDate.Value;
                addEmployee.INN = txtINN.Text;
                addEmployee.IsActive = true;
                addEmployee.Login = "user";
                addEmployee.Password = "user";



                EFData.Context.Employee.Add(addEmployee);
                EFData.Context.SaveChanges();

                MessageBox.Show("Сотрудник добавлен", "Выполнено", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            NavigateClass.frame.Navigate(new EmployeePage());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new EmployeePage());
        }
    }
}
