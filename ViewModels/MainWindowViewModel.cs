namespace Agenda.ViewModels
{
    using Agenda.Enumerations;
    using Agenda.Models;
    using Agenda.ViewModels.Base;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="MainWindowViewModel" />
    /// </summary>
    public class MainWindowViewModel : NotifyPropertyBase
    {
        #region Fields

        public Strings GetDescriptions = new Strings(Language.en);

        private AddContactViewModel addContactVM = null;
                
        private InterfaceMode interfaceMode = InterfaceMode.ModelON;

        /// <summary>
        /// Defines the searchText
        /// </summary>
        private string searchText;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            AddContactToListCommand = new Command(AddContactToListCommandExecute, CanAddContactToListCommandCommand);
            ClearContactListCommand = new Command(ClearContactListExecute, CanClearContactListCommand);
            AddNewContactCommand = new Command(AddNewContactExecute, CanAddNewContactCommand);
            EditContactCommand = new Command(EditContactCommandExecute, CanEditContactCommand);

            LoadContacts();

            AppStatus = InterfaceMode.Default;
        }

        #endregion

        #region Properties

        public Command AddContactToListCommand { get; set; }

        public AddContactViewModel AddContactVM {
            get => addContactVM;
            set {
                addContactVM = value;
                //OnPropertyChanged();
                NotifyPropertyChanged();
            }
        }
        
        public InterfaceMode AppStatus {
            get {
                return interfaceMode;
            }
            set {
                this.interfaceMode = value;
                NotifyPropertyChanged();
            }
        }

        public Command ClearContactListCommand { get; private set; }

        public List<Person> Contacts { get; set; } = new List<Person>();

        public ObservableCollection<Person> ContactsSearch { get; set; } = new ObservableCollection<Person>();

        public ObservableCollection<Person> ContactsSelected { get; set; } = new ObservableCollection<Person>();

        public string SearchText {
            get { return searchText; }
            set {
                this.searchText = value;
                SearchResult();
                NotifyPropertyChanged("SearchText");
            }
        }

        public Command AddNewContactCommand { get; private set; }

        public Command EditContactCommand { get; private set; }

        #endregion

        #region Methods

        private void AddContactToListCommandExecute(object obj)
        {
            Person t = (Person)obj;
            if (ContactsSelected.Contains(t) == false)
            {
                ContactsSelected.Add(t);
            }
            else
            {
                ContactsSelected.Remove(t);
            }
            NotifyPropertyChanged("ContactsSelected");
            ClearContactListCommand.RaiseCanExecuteChange();
        }

        private bool CanAddContactToListCommandCommand(object obj)
        {
            return true;
        }

        private bool CanClearContactListCommand(object obj)
        {
            if (ContactsSelected.Count > 0)
            {
                return true;
            }
            return false;
        }

        private bool CanAddNewContactCommand(object obj)
        {
            return true;
        }

        private void ClearContactListExecute(object obj)
        {
            try
            {
                foreach (Person t in ContactsSelected)
                {
                    t.IsChecked = false;
                    NotifyPropertyChanged("ContactsSelected");
                }
                ContactsSelected.Clear();
                NotifyPropertyChanged("ContactsSelected");
            }
            catch (System.Exception err)
            {
                string e = "";
            }
        }

        private void LoadContacts()
        {

            Contacts.Add(new Person() { Id = 1001, Name = "Mahesh", Surname = "Lux", Color = "00dd11", Number = "+39 345.1549141" });
            Contacts.Add(new Person() { Id = 1002, Name = "Amit", Surname = "Belloni", Color = "00dd11", Number = "+39 345.1235541" });
            Contacts.Add(new Person() { Id = 1003, Name = "Vaibhav", Surname = "Lora", Color = "00dd11", Number = "+39 345.5242341" });
            Contacts.Add(new Person() { Id = 1004, Name = "Ashwin", Surname = "Malnati", Color = "00dd11", Number = "+39 345.2552231" });
            Contacts.Add(new Person() { Id = 1005, Name = "Prashant", Surname = "Poretti", Color = "00dd11", Number = "+39 345.2525321" });
            Contacts.Add(new Person() { Id = 1006, Name = "Vinit", Surname = "Coccè", Color = "00dd11", Number = "+39 345.2243541" });
            Contacts.Add(new Person() { Id = 1007, Name = "Abhijit", Surname = "Valente", Color = "00dd11", Number = "+39 345.1123124" });
            Contacts.Add(new Person() { Id = 1008, Name = "Pankaj", Surname = "Oliviero", Color = "00dd11", Number = "+39 345.2142124" });
            Contacts.Add(new Person() { Id = 1009, Name = "Kaustubh", Surname = "Vanoni", Color = "00dd11", Number = "+39 345.2414241" });
            Contacts.Add(new Person() { Id = 1010, Name = "Mohan", Surname = "Atabiano", Color = "00dd11", Number = "+39 345.1241241" });
            Contacts.Sort((x, y) => x.Name.CompareTo(y.Name));


            char tempChar = ' ';

            foreach (Person t in Contacts)
            {
                if (t.Initial != tempChar) {
                    t.LetterPlaceHolder = t.Initial;
                    tempChar = t.Initial;
                }
                ContactsSearch.Add(t);
            }
        }

        // http://www.devcurry.com/2010/07/filter-data-in-wpf-listbox.html
        private void SearchResult()
        {
            ContactsSearch.Clear();
            foreach (Person t in Contacts)
            {
                if (t.FullName.ToLower().Contains(SearchText.ToLower()) == true)
                {
                    ContactsSearch.Add(t);
                    NotifyPropertyChanged("lstEmployeeSearch");
                }
            }
        }

        private void AddNewContactExecute(object obj)
        {
            try
            {
                AddContactVM = new AddContactViewModel(this);
                AppStatus = InterfaceMode.ModelON;
                NotifyPropertyChanged("AppStatus");
            }
            catch (System.Exception err)
            {
                string e = "";
            }
        }

        private void EditContactCommandExecute(object obj)
        {

            Person personToEdit = (Person)obj;
            AddContactVM = new AddContactViewModel(this, personToEdit);
            AppStatus = InterfaceMode.ModelON;
            NotifyPropertyChanged("AppStatus");

        }

        private bool CanEditContactCommand(object obj)
        {
            return true;
        }
        


        #endregion
    }

    
}
