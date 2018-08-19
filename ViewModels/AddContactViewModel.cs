using NLog;
using NLog.Fluent;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Agenda.ViewModels
{
    public class AddContactViewModel : MainWindowViewModel
    {
        #region Fields

        private static Logger log = LogManager.GetCurrentClassLogger();

        public string status = "1";
        private String addNewContact_surname1 = "Giorgio";
        private string testString = "test";


        public Models.Person AddPerson = new Models.Person();


        public Boolean IsLoggedIn {
            get;
            set;
        } = true;


        public string Name {
            get {
                return AddPerson.Name;
            }
            set {
                
                AddPerson.Name = value;
                this.mWindow.StartAnimation();



            }
        }

        #endregion

        #region Constructors

        public AddContactViewModel()
        {
            status = "2";
        }

        public View.AddContactView mWindow;

        public AddContactViewModel(MainWindowViewModel parentVM)
        {
            try
            {                
                ParentVM = parentVM;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        #endregion

        #region Properties

        public String AddNewContact_surname1 {
            get {
                return addNewContact_surname1;
            }

            set {
                this.addNewContact_surname1 = value;
                //BeginStoryboard sb = this.FindResource("SurnameAnimationTop") as BeginStoryboard;
                //sb.Storyboard.Begin();
                //var view = Application.Current.FindResource("AddContactVM") as DataTemplate;
                //var control = new ContentControl { Content = AddContactVM, ContentTemplate = view };
            }
        }

        public string TestString {
            get { return testString; }
            set { testString = value; }
        }

        private MainWindowViewModel ParentVM { get; set; }

        #endregion
    }
}
