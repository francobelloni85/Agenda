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

        public char Initial {

            get {
                string t = name.Substring(0, 1).ToUpper();
                return t[0];
            }
        }

        public char letterPlaceHolder = ' ';
        public char LetterPlaceHolder {
            get {
                return letterPlaceHolder;
            }
            set {
                letterPlaceHolder = value;
                NotifyPropertyChanged();
            }
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

        private string mail = string.Empty;
        public string Mail {

            get {
                return mail;
            }

            set {
                mail = value;
                NotifyPropertyChanged();
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

        private string job = string.Empty;
        public string Job {

            get {
                return job;
            }

            set {
                job = value;
                NotifyPropertyChanged();
            }

        }



    }


}
