﻿using System.Collections.ObjectModel;
using System.Windows;

using DataAccess.Data;
using DataAccess.Models;
using VKR.Utils;
using VKR.View;

using MessageBox = HandyControl.Controls.MessageBox;


namespace VKR.ViewModel
{
    internal class CompaniesControlVM : ViewModelBase
    {
        #region Functions

        #region Constructors

        public CompaniesControlVM()
        {
            _db = new ResultDBContext();
            Companies = _db.Companies.Local.ToObservableCollection();
        }

        #endregion

        #endregion


        #region Properties

        private readonly ResultDBContext _db;
        public Company SelectedCompany { get; set; }
        public ObservableCollection<Company> Companies { get; set; }

        #endregion


        #region Commands

        private RelayCommand _addCompany;

        /// <summary>
        ///     Команда, открывающая окно создания цвета
        /// </summary>
        public RelayCommand AddCompany
        {
            get
            {
                return _addCompany ??= new RelayCommand(o =>
                {
                    ShowChildWindow(new CompanyEditWindow(new Company()));
                });
            }
        }

        private RelayCommand _editCompany;

        /// <summary>
        ///     Команда, открывающая окно редактирования цвета
        /// </summary>
        public RelayCommand EditCompany
        {
            get
            {
                return _editCompany ??= new RelayCommand(o =>
                {
                    ShowChildWindow(new CompanyEditWindow(SelectedCompany));
                }, _ => SelectedCompany != null);
            }
        }

        private RelayCommand _deleteCompany;

        /// <summary>
        ///     Команда, удаляющая цвет
        /// </summary>
        public RelayCommand DeleteCompany
        {
            get
            {
                return _deleteCompany ??= new RelayCommand(o =>
                {
                    if (MessageBox.Show($"Вы действительно хотите удалить предприятие: \"{SelectedCompany.Name}\"?",
                                        "Удаление предприятия", MessageBoxButton.YesNo, MessageBoxImage.Warning) ==
                        MessageBoxResult.Yes)
                    {
                        _db.Companies.Remove(SelectedCompany);
                        _db.SaveChanges();
                    }
                }, _ => SelectedCompany != null);
            }
        }

        #endregion
    }
}
