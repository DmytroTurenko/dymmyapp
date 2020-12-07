using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Netwatch.Cams.UI
{
    public class CustomCommand : ICommand
    {
        private Action<object> m_execute;
        private Predicate<object> m_canExecute;

        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.m_execute = execute;
            this.m_canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            bool b = m_canExecute == null ? true : m_canExecute(parameter);
            return b;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            m_execute(parameter);
        }
    }
}
