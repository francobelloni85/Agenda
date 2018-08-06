﻿using Agenda.Models;
using Agenda.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Agenda.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyBase
    {

        public List<Person> Contacts { get; set; } = new List<Person>();
        public ObservableCollection<Person> ContactsSearch { get; set; } = new ObservableCollection<Person>();
        public ObservableCollection<Person> ContactsSelected { get; set; } = new ObservableCollection<Person>();


        private string searchText;
        public string SearchText {
            get { return searchText; }
            set {
                this.searchText = value;
                SearchResult();
                NotifyPropertyChanged("SearchText");
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


        public MainWindowViewModel()
        {

            AddContactToListCommand = new Command(AddContactToListCommandExecute,CanAddContactToListCommandCommand);

            Contacts.Add(new Person() {  Id = 1001, Name = "Mahesh", Surname="Lux", Color="00dd11", Number="+39 345.1549141" });
            Contacts.Add(new Person() { Id = 1002, Name = "Amit", Surname = "Belloni", Color = "00dd11", Number = "+39 345.1235541" });
            Contacts.Add(new Person() { Id = 1003, Name = "Vaibhav", Surname = "Lora", Color = "00dd11", Number = "+39 345.5242341" });
            Contacts.Add(new Person() { Id = 1004, Name = "Ashwin", Surname = "Malnati", Color = "00dd11", Number = "+39 345.2552231" });
            Contacts.Add(new Person() { Id = 1005, Name = "Prashant", Surname = "Poretti", Color = "00dd11", Number = "+39 345.2525321" });
            Contacts.Add(new Person() { Id = 1006, Name = "Vinit", Surname = "Coccè", Color = "00dd11", Number = "+39 345.2243541" });
            Contacts.Add(new Person() { Id = 1007, Name = "Abhijit", Surname = "Valente", Color = "00dd11", Number = "+39 345.1123124" });
            Contacts.Add(new Person() { Id = 1008, Name = "Pankaj", Surname = "Oliviero", Color = "00dd11", Number = "+39 345.2142124" });
            Contacts.Add(new Person() { Id = 1009, Name = "Kaustubh", Surname = "Vanoni", Color = "00dd11", Number = "+39 345.2414241" });
            Contacts.Add(new Person() { Id = 1010, Name = "Mohan", Surname = "Atabiano", Color = "00dd11", Number = "+39 345.1241241" });

            foreach (Person t in Contacts) {
                ContactsSearch.Add(t);
            }


        }


        #region AddContactToList Command   

        public Command AddContactToListCommand {
            get;
            private set;
        }

        private void AddContactToListCommandExecute(object obj)
        {
            Person t = (Person)obj;
            if (ContactsSelected.Contains(t) == false) {
                ContactsSelected.Add(t);
            }
            else {
                ContactsSelected.Remove(t);
            }

            NotifyPropertyChanged("ContactsSelected");
        }

        private bool CanAddContactToListCommandCommand(object obj)
        {
            return true;
        }

        #endregion

        #region AddContactToList Command   

        public Command RemoveAllContactToListCommand {
            get;
            private set;
        }

        private void RemoveAllContactToListCommandExecute(object obj)
        {
            ContactsSelected.Clear();
            NotifyPropertyChanged("ContactsSelected");
        }

        private bool CanRemoveAllContactToListCommandCommand(object obj)
        {
            return true;
        }

        #endregion



    }
}
