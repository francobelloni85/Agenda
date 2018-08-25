using Agenda.Models;
using Agenda.ViewModels.Base;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace Agenda.ViewModels
{
    public class AddContactViewModel : NotifyPropertyBase
    {
        #region Fields

        private MainWindowViewModel ParentVM { get; set; }

        private static Logger log = LogManager.GetCurrentClassLogger();

        public Models.Person AddPerson = new Models.Person();

        public bool AnimationHideName { get; set; } = false;
        public bool AnimationLostFocusName { get; set; } = false;

        public string Name {
            get {
                return AddPerson.Name;
            }
            set {
                AddPerson.Name = value;
                if (value.Length == 0) {
                    AnimationLostFocusName = true;
                    NotifyPropertyChanged("AnimationLostFocusName");
                    AnimationLostFocusName = false;
                }

                
            }
        }
        public string Surname {

            get {
                return AddPerson.Surname;
            }

            set {
                AddPerson.Surname = value;
            }

        }
        public string Company {

            get {
                return AddPerson.Company;
            }

            set {
                AddPerson.Company = value;
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
            }

        }
        public string Number {
            get {
                return AddPerson.Number;
            }
            set {
                AddPerson.Number = value;
            }
        }

        public Command SaveCommand { get; set; }
        
        public ObservableCollection<County> CountryList { get; set; } = new ObservableCollection<County>();
        
        private County countySelected;
        public County CountySelected {
            get {
                return countySelected;
            }
            set {
                countySelected = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Constructors

        //public AddContactViewModel(){
        //    LoadCommands();
        //}

        public AddContactViewModel(MainWindowViewModel parentVM)
        {
            try
            {                
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

        private void LoadCommands() {
            SaveCommand = new Command(SaveCommandExecute, CanSaveCommand);
        }

        #endregion

        private void SaveCommandExecute(object obj) {
            ParentVM.AppStatus = Enumerations.InterfaceMode.Default;
            ParentVM.ContactsSearch.Add(AddPerson);
            NotifyPropertyChanged("AppStatus");
        }

        private bool CanSaveCommand(object obj) {
            return true;
        }



    }
}
