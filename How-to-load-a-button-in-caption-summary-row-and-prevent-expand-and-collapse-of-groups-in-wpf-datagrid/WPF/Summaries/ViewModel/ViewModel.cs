﻿using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SummariesDemo
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.Employees = GetEmployeesDetails(300);
        }

        private ObservableCollection<BusinessObjects> employees;

        public ObservableCollection<BusinessObjects> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        private ICommand myCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (myCommand == null)
                {
                    myCommand = new RelayCommand<object>(CommandExecute, CanCommandExecute);
                }
                return myCommand;
            }
        }

        private void CommandExecute(object parameter)
        {
            var groupKey = (parameter as Group).Key;
        }

        private bool CanCommandExecute(object parameter)
        {
            return true;
        }

        private int number = 0;

        public ObservableCollection<BusinessObjects> GetEmployeesDetails(int count)
        {
            if (ComboBoxItemsSource == null)
            {
                _comboBoxItemsSource = new ObservableCollection<string>();
                for (int i = 0; i < countries.Count(); i++)
                {
                    _comboBoxItemsSource.Add(countries[i]);
                }
            }
            var employees = new ObservableCollection<BusinessObjects>();
            for (int i = 1; i < count; i++)
            {
                employees.Add(GetEmployee(i));
                number++;
            }
            return employees;
        }

        private ObservableCollection<string> _comboBoxItemsSource;

        public ObservableCollection<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
        }

        public BusinessObjects GetEmployee(int i)
        {
            number = number < 10 ? number++ : 1;
            return new BusinessObjects()
            {
                EmployeeName = names[number],
                EmployeeArea = ComboBoxItemsSource.ElementAt(number),
                EmployeeGender = number % 3 != 0 ? "Male" : "Female",
                EmployeeSalary = 1000 + number,
                ContactNumber = "97788090" + number.ToString(),
                JoiningDate = DateTime.Now.AddDays(1000 + number)
            };
        }

        private string[] names = new string[]
        {
            "Robert",
            "John",
            "clarke",
            "Mathews",
            "Smith",
            "Martin",
            "Inigo",
            "Antony",
            "Micheal",
            "Anderson",
            "Alastair",
            "Kevin",
            "Alex",
            "Hussain",
            "Hughes",
            "Andrews",
        };

        private string[] countries = new string[]
        {
            "Brazil",
            "Germany",
            "France",
            "Japan",
            "China",
            "Ireland",
            "Argentina",
            "England",
            "Brazil",
            "Germany",
            "France",
            "Japan",
            "China",
            "Ireland",
            "Argentina",
            "England",
            "Brazil",
            "Germany",
            "France",
            "Japan",
            "China",
            "Ireland",
            "Argentina",
            "England"
        };
    }
}
