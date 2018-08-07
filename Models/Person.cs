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
        public int Id;

        private string name;
        public string Name {

            get {
                return name;
            }

            set {
                name = value;
            }

        }

        private string surname;
        public string Surname {

            get {
                return surname;
            }

            set {
                surname = value;
            }

        }

        public string FullName {
            get { return this.name + " " + this.surname; }
        }

        public string Initial {
            get { return this.name.Substring(0, 1).ToUpper(); }
        }

        private string number;
        public string Number {

            get {
                return number;
            }

            set {
                number = value;
            }

        }

        private string color;
        public string Color {

            get {
                return color;
            }

            set {
                color = value;
            }

        }

        private bool isChecked;
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

    }
    

}
