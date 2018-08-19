using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda.View
{ 
    /// <summary>
    /// Interaction logic for AddContactView.xaml
    /// </summary>
    public partial class AddContactView : UserControl
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        public AddContactView()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.AddContactViewModel();
        }

        public void StartAnimation() {

            try
            {
                var myStoryboard = (BeginStoryboard)Application.Current.FindResource("MoveNameBack");
                myStoryboard.Storyboard.Begin();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

        }


    }
}
