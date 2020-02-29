
using System;
using System.Windows.Input;

namespace Khmil_lab_2
{
    class DelegateCommand : ICommand
    {
        private Action<object> excute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> excute, Func<object, bool> canExecute = null)
        {
            this.excute = excute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.excute(parameter);
        }
    }
}
