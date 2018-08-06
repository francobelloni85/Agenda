using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agenda.ViewModels.Base
{

    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> executeMethod;
        private Predicate<object> CanExecuteMethod;

        public Command(Action<object> _executeMethod, Predicate<object> _canExecuteChange)
        {
            this.executeMethod = _executeMethod;
            this.CanExecuteMethod = _canExecuteChange;
        }

        public Command(Action<object> ExecuteMethod) : this(ExecuteMethod, null)
        {

        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteMethod == null)
                return true;

            return CanExecuteMethod.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("Click button");
            executeMethod.Invoke(parameter);
        }

        public void RaiseCanExecuteChange()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }


}
