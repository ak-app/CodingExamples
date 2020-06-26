using System;
using System.Collections.Generic;
using EmployeeManager.Entities;


namespace EmployeeManager.Services
{
    public class EmployeesService
    {
        public List<Entities.Employee> EmployeesList { get; set; }
        
        public EmployeesService()
        {
            EmployeesList = new List<Entities.Employee>();

            EmployeesList.Add(new Entities.Employee() { Id = 1, Lastname = "Burtscher", Firstname = "Sepp" });
            EmployeesList.Add(new Entities.Employee() { Id = 2, Lastname = "Trump", Firstname = "Hias" });
            EmployeesList.Add(new Entities.Employee() { Id = 3, Lastname = "Wayne", Firstname = "Bruce" });
        }

        public bool AddEmployee(Employee newEmployee)
        {
            bool retVal = false;

            if (IsEmployeeIdInUse(newEmployee.Id) == false)
            {
                EmployeesList.Add(newEmployee);
                retVal = true;
            }

            return retVal;
        }

        public void DeleteEmployee(Employee employeeToDelete)
        {
            if (EmployeesList.Contains(employeeToDelete))
            {
                EmployeesList.Remove(employeeToDelete);
            }
        }

        public bool SaveEmployee(Employee existingEmployee, Employee newValues)
        {
            bool retVal = false;

            if (EmployeesList.Contains(existingEmployee))
            {
                if (IsEmployeeIdInUse(newValues.Id) == false)
                {
                    existingEmployee.Id = newValues.Id;
                    existingEmployee.Lastname = newValues.Lastname;
                    existingEmployee.Firstname = newValues.Firstname;

                    retVal = true;
                }
            }

            return retVal;
        }

        private bool IsEmployeeIdInUse(int employeeId)
        {
            bool retVal = false;

            foreach (Employee oneEmp in EmployeesList)
            {
                if (oneEmp.Id == employeeId)
                {
                    retVal = true;
                }
            }

            return retVal;
        }
    }
}
