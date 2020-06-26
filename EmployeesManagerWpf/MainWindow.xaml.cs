using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using EmployeeManager.Entities;
using EmployeeManager.Services;

namespace Mitarbeiter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeesService _employeesService = new EmployeesService(); 

        public MainWindow()
        {
            InitializeComponent();

            uiMitarbeiterGrid.ItemsSource = _employeesService.EmployeesList;
        }

        private void BtnClick_Add(object sender, RoutedEventArgs e)
        {
            Employee newEmployee = new Employee();

            if (ValidateInputs())
            {
                newEmployee.Id = int.Parse(uiTextboxId.Text);
                newEmployee.Lastname = uiTextboxLastname.Text;
                newEmployee.Firstname = uiTextboxFirstname.Text;

                if (_employeesService.AddEmployee(newEmployee) == false)
                {
                    MessageBox.Show("Konnte den Mitarbeiter nicht hinzufügen. Personalnummer ist bereits in Verwendung.");
                }

                CollectionViewSource.GetDefaultView(uiMitarbeiterGrid.ItemsSource).Refresh();
            }
        }

        private void BtnClick_Delete(object sender, RoutedEventArgs e)
        {

            try
            {
                _employeesService.DeleteEmployee(uiMitarbeiterGrid.SelectedItem as Employee);

                CollectionViewSource.GetDefaultView(uiMitarbeiterGrid.ItemsSource).Refresh();
            }
            catch (Exception)
            { }
        }

        private void BtnClick_Save(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = uiMitarbeiterGrid.SelectedItem as Employee;
            Employee editedEmployee = new Employee();

            if (selectedEmployee != null && ValidateInputs())
            {
                editedEmployee.Id = int.Parse(uiTextboxId.Text);
                editedEmployee.Lastname = uiTextboxLastname.Text;
                editedEmployee.Firstname = uiTextboxFirstname.Text;

                if (_employeesService.SaveEmployee(selectedEmployee, editedEmployee) == false)
                {
                    MessageBox.Show("Konnte den Mitarbeiter nicht speichern. Personalnummer ist bereits in Verwendung.");
                }

                CollectionViewSource.GetDefaultView(uiMitarbeiterGrid.ItemsSource).Refresh();
            }
        }

        private void Grid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = ((sender as DataGrid).SelectedValue as Employee);

            uiTextboxId.Text = selectedEmployee.Id.ToString();
            uiTextboxLastname.Text = selectedEmployee.Lastname;
            uiTextboxFirstname.Text = selectedEmployee.Firstname;
        }

        private bool ValidateInputs()
        {
            bool retVal = false;

            int intValue;

            if (int.TryParse(uiTextboxId.Text, out intValue) == false)
            {
                MessageBox.Show("Fehler: Die Personalnummer " + uiTextboxId.Text + " konnte nicht in eine Zahl umgewandelt werden!");
            }
            else if (uiTextboxLastname.Text == string.Empty)
            {
                MessageBox.Show("Fehler: Das Feld für den Nachnamen darf nicht leer sein.");
            }
            else if (uiTextboxFirstname.Text == string.Empty)
            {
                MessageBox.Show("Fehler: Das Feld für den Vornamen darf nicht leer sein.");
            }
            else
            {
                retVal = true;
            }

            return retVal;
        }
    }
}
