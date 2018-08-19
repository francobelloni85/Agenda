using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class Person : ViewModels.Base.NotifyPropertyBase
    {
        private int id;
        public int Id {
            get { return id; }
            set { id = value; }
        }

        private string name = string.Empty;
        public string Name {

            get {
                return name;
            }

            set {
                name = value;
                NotifyPropertyChanged();
            }

        }

        private string surname = string.Empty;
        public string Surname {

            get {
                return surname;
            }

            set {
                surname = value;
                NotifyPropertyChanged();
            }

        }

        public string FullName {
            get { return this.name + " " + this.surname; }
        }

        public string Initial {
            get { return this.name.Substring(0, 1).ToUpper(); }
        }

        private string number = string.Empty;
        public string Number {

            get {
                return number;
            }

            set {
                number = value;
                NotifyPropertyChanged();
            }

        }

        private string color = string.Empty;
        public string Color {

            get {
                return color;
            }

            set {
                color = value;
                NotifyPropertyChanged();
            }

        }

        private bool isChecked = false;
        public bool IsChecked {
            get {
                return isChecked;
            }

            set {
                this.isChecked = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("IsChecked");
                NotifyPropertyChanged("ContactsSearch");
            }
        }

        private string company = string.Empty;
        public string Company {

            get {
                return company;
            }

            set {
                company = value;
                NotifyPropertyChanged();
            }

        }




    }


}
