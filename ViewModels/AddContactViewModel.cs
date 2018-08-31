using Agenda.Models;
using Agenda.ViewModels.Base;
using NLog;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Agenda.ViewModels
{
    public class AddContactViewModel : NotifyPropertyBase
    {
        #region Fields

        public Models.Person AddPerson = new Models.Person();

        private static Logger log = LogManager.GetCurrentClassLogger();

        private County countySelected;

        public string HeaderTitle { get; set; }

        #endregion

        #region Constructors

        public AddContactViewModel(MainWindowViewModel parentVM)
        {
            try
            {
                ParentVM = parentVM;
                LoadCommands();

                MainWindowViewModel mainWin = Application.Current.MainWindow.DataContext as MainWindowViewModel;               
                HeaderTitle = mainWin.GetDescriptions.AddNewContact_title;
                
                CountryList.Add(new County() { Name = "Italy", CountryCode = "ITA", Number = "+39" });
                CountryList.Add(new County() { Name = "China", CountryCode = "CHN", Number = "+22" });
                CountryList.Add(new County() { Name = "UK", CountryCode = "ENG", Number = "+12" });

                CountySelected = CountryList[0];
                NotifyPropertyChanged("CountySelected");
                NotifyPropertyChanged("CountryList");

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public AddContactViewModel(MainWindowViewModel parentVM, Person person)
        {
            try
            {

                AddPerson = person;

                object dc = Application.Current.MainWindow.DataContext;
                MainWindowViewModel t = (MainWindowViewModel)dc;
                HeaderTitle = t.GetDescriptions.EditContact_title;

                ParentVM = parentVM;
                LoadCommands();

                CountryList.Add(new County() { Name = "Italy", CountryCode = "ITA", Number = "+39" });
                CountryList.Add(new County() { Name = "China", CountryCode = "CHN", Number = "+22" });
                CountryList.Add(new County() { Name = "UK", CountryCode = "ENG", Number = "+12" });

                CountySelected = CountryList[0];
                NotifyPropertyChanged("CountySelected");
                NotifyPropertyChanged("CountryList");

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        #endregion

        #region Properties

        public bool AnimationHideName { get; set; } = false;

        public bool AnimationLostFocusName { get; set; } = false;

        public string Company {

            get {
                return AddPerson.Company;
            }

            set {
                AddPerson.Company = value;
            }
        }

        public ObservableCollection<County> CountryList { get; set; } = new ObservableCollection<County>();

        public County CountySelected {
            get {
                return countySelected;
            }
            set {
                countySelected = value;
                NotifyPropertyChanged();
            }
        }

        public string Job {

            get {
                return AddPerson.Job;
            }

            set {
                AddPerson.Job = value;
            }
        }

        public string Mail {

            get {
                return AddPerson.Mail;
            }

            set {
                AddPerson.Mail = value;
                SaveCommand.RaiseCanExecuteChange();
            }
        }

        public string Name {
            get {
                return AddPerson.Name;
            }
            set {
                AddPerson.Name = value;
                if (value.Length == 0)
                {
                    AnimationLostFocusName = true;
                    NotifyPropertyChanged("AnimationLostFocusName");
                    AnimationLostFocusName = false;
                }
                SaveCommand.RaiseCanExecuteChange();
            }
        }

        public string Number {
            get {
                return AddPerson.Number;
            }
            set {
                AddPerson.Number = value;
                SaveCommand.RaiseCanExecuteChange();
            }
        }

        public Command SaveCommand { get; set; }

        public Command CancelCommand { get; set; }

        public string Surname {

            get {
                return AddPerson.Surname;
            }

            set {
                AddPerson.Surname = value;
                SaveCommand.RaiseCanExecuteChange();
            }
        }

        private MainWindowViewModel ParentVM { get; set; }

        #endregion

        #region Methods

        private bool CanSaveCommand(object obj)
        {

            if (String.IsNullOrEmpty(AddPerson.Name))
                return false;
            if (String.IsNullOrEmpty(AddPerson.Surname))
                return false;
            if (String.IsNullOrEmpty(AddPerson.Mail))
                return false;
            if (String.IsNullOrEmpty(AddPerson.Number))
                return false;

            return true;
        }

        private void LoadCommands()
        {
            SaveCommand = new Command(SaveCommandExecute, CanSaveCommand);
            CancelCommand = new Command(CancelCommandExecute, CanCancelCommand);
        }

        private void SaveCommandExecute(object obj)
        {
            ParentVM.AppStatus = Enumerations.InterfaceMode.Default;
            ParentVM.ContactsSearch.Add(AddPerson);
            NotifyPropertyChanged("AppStatus");
        }

        private void CancelCommandExecute(object obj)
        {
            ParentVM.AppStatus = Enumerations.InterfaceMode.Default;
            NotifyPropertyChanged("AppStatus");
        }

        private bool CanCancelCommand(object obj)
        {
            return true;
        }

        #endregion
    }
}
