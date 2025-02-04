﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance_SfDataGrid
{
    public class BusinessObjects : INotifyPropertyChanged
    {
        private int _eid;
        public int EmployeeId
        {
            get
            {
                return _eid;
            }
            set
            {
                _eid = value;
                OnPropertyChanged("EmployeeId");
            }
        }

        private string _ename;
        public string EmployeeName
        {
            get
            {
                return _ename;
            }
            set
            {
                _ename = value;
                OnPropertyChanged("EmployeeName");
            }
        }

        private string _edesignation;
        public string EmployeeDesignation
        {
            get
            {
                return _edesignation;
            }
            set
            {
                _edesignation = value;
                OnPropertyChanged("EmployeeDesignation");
            }
        }

        private int _eage;
        public int EmployeeAge
        {
            get
            {
                return _eage;
            }
            set
            {
                _eage = value;
                OnPropertyChanged("EmployeeAge");
            }
        }

        private string _earea;
        public string EmployeeArea
        {
            get
            {
                return _earea;
            }
            set
            {
                _earea = value;
                OnPropertyChanged("EmployeeArea");
            }
        }

        private string _egender;
        public string EmployeeGender
        {
            get
            {
                return _egender;
            }
            set
            {
                _egender = value;
                OnPropertyChanged("EmployeeGender");
            }
        }

        private int _eExpInMonth;
        public int ExperienceInMonth
        {
            get
            {
                return _eExpInMonth;
            }
            set
            {
                _eExpInMonth = value;
                OnPropertyChanged("ExperienceInMonth");
            }
        }

        private double _esalary;
        public double EmployeeSalary
        {
            get
            {
                return _esalary;
            }
            set
            {
                _esalary = value;
                OnPropertyChanged("EmployeeSalary");
            }
        }

        private DateTime _edob;
        public DateTime EmployeeDOB
        {
            get
            {
                return _edob;
            }
            set
            {
                _edob = value;
                OnPropertyChanged("EmployeeDOB");
            }
        }

        private bool _estatus;
        public bool EmployeeStatus
        {
            get
            {
                return _estatus;
            }
            set
            {
                _estatus = value;
                OnPropertyChanged("EmployeeStatus");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
