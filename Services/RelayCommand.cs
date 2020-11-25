using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POS_Demo.Services
{
    public class RelayCommand : ICommand
    {
        private Action _action;
        private Action<object> _actionWithParam;
        private bool _withParam;

        public event EventHandler CanExecuteChanged;


        public RelayCommand(Action action)
        {
            _action = action;
            _withParam = false;
        }

        public RelayCommand(Action<object> action)
        {
            _actionWithParam = action;
            _withParam = true;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_withParam)
                _actionWithParam(parameter);
            else
                _action();
        }
    }
}
