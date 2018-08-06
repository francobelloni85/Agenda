using Agenda.Models;
using Agenda.ViewModels.Base;
using System.Collections.ObjectModel;

namespace Agenda.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyBase
    {

        public ObservableCollection<Person> lstEmployee { get; set; } = new ObservableCollection<Person>();
        public ObservableCollection<Person> lstEmployeeSearch { get; set; } = new ObservableCollection<Person>();

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

            string txtOrig = SearchText;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            lstEmployeeSearch.Clear();


            foreach (Person t in lstEmployee)
            {

                if (t.Name.Contains(SearchText) == true)
                {
                    lstEmployeeSearch.Add(t);
                    NotifyPropertyChanged("lstEmployeeSearch");
                }

            }

            string de = "";
        }


        public MainWindowViewModel()
        {
            lstEmployee.Add(new Person() {  Id = 1001, Name = "Mahesh", Surname="Lux", Color="00dd11", Number="+39 345.2579141" });
            lstEmployee.Add(new Person() { Id = 1002, Name = "Amit", Surname = "Belloni", Color = "00dd11", Number = "+39 345.1235541" });
            lstEmployee.Add(new Person() { Id = 1003, Name = "Vaibhav", Surname = "Lora", Color = "00dd11", Number = "+39 345.5242341" });
            lstEmployee.Add(new Person() { Id = 1004, Name = "Ashwin", Surname = "Malnati", Color = "00dd11", Number = "+39 345.2552231" });
            lstEmployee.Add(new Person() { Id = 1005, Name = "Prashant", Surname = "Poretti", Color = "00dd11", Number = "+39 345.2525321" });
            lstEmployee.Add(new Person() { Id = 1006, Name = "Vinit", Surname = "Coccè", Color = "00dd11", Number = "+39 345.2243541" });
            lstEmployee.Add(new Person() { Id = 1007, Name = "Abhijit", Surname = "Valente", Color = "00dd11", Number = "+39 345.1123124" });
            lstEmployee.Add(new Person() { Id = 1008, Name = "Pankaj", Surname = "Oliviero", Color = "00dd11", Number = "+39 345.2142124" });
            lstEmployee.Add(new Person() { Id = 1009, Name = "Kaustubh", Surname = "Vanoni", Color = "00dd11", Number = "+39 345.2414241" });
            lstEmployee.Add(new Person() { Id = 1010, Name = "Mohan", Surname = "Atabiano", Color = "00dd11", Number = "+39 345.1241241" });

        }



    }
}
