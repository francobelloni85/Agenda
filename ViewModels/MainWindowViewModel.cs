namespace Agenda.ViewModels
{
    using Agenda.Models;
    using Agenda.ViewModels.Base;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="MainWindowViewModel" />
    /// </summary>
    public class MainWindowViewModel : NotifyPropertyBase
    {
        #region Fields

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
            TestCommand = new Command(TestCommandExecute, CanTestCommandCommand);

            LoadContacts();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the AddContactToListCommand
        /// </summary>
        public Command AddContactToListCommand { get; set; }

        /// <summary>
        /// Gets the ClearContactListCommand
        /// </summary>
        public Command ClearContactListCommand { get; private set; }

        public List<Person> Contacts { get; set; } = new List<Person>();

        /// <summary>
        /// Gets or sets the ContactsSearch
        /// </summary>
        public ObservableCollection<Person> ContactsSearch { get; set; } = new ObservableCollection<Person>();

        /// <summary>
        /// Gets or sets the ContactsSelected
        /// </summary>
        public ObservableCollection<Person> ContactsSelected { get; set; } = new ObservableCollection<Person>();

        /// <summary>
        /// Gets or sets the SearchText
        /// </summary>
        public string SearchText {
            get { return searchText; }
            set {
                this.searchText = value;
                SearchResult();
                NotifyPropertyChanged("SearchText");
            }
        }

        /// <summary>
        /// Gets the TestCommand
        /// </summary>
        public Command TestCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The AddContactToListCommandExecute
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
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

        /// <summary>
        /// The CanAddContactToListCommandCommand
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool CanAddContactToListCommandCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// The CanClearContactListCommand
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool CanClearContactListCommand(object obj)
        {
            if (ContactsSelected.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// The CanTestCommandCommand
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool CanTestCommandCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// The ClearContactListExecute
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
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

        /// <summary>
        /// The LoadContacts
        /// </summary>
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

            foreach (Person t in Contacts)
            {
                ContactsSearch.Add(t);
            }
        }

        // http://www.devcurry.com/2010/07/filter-data-in-wpf-listbox.html
        /// <summary>
        /// The SearchResult
        /// </summary>
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

        /// <summary>
        /// The TestCommandExecute
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
        private void TestCommandExecute(object obj)
        {
            try
            {
                AddContactVM = new AddContactViewModel();
            }
            catch (System.Exception err)
            {
                string e = "";
            }
        }

        #endregion

        #region ModelView

        private AddContactViewModel addContactVM = null;
        public AddContactViewModel AddContactVM {
            get => addContactVM;
            set {
                addContactVM = value;
                //OnPropertyChanged();
                NotifyPropertyChanged();
            }
        }


        #endregion
    }
}
