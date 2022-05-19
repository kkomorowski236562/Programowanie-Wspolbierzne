using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ModelWidoku

{
    public class RelayCommand : ICommand
    {
        private readonly Action m_Execute;
        private readonly Func<bool> m_CanExecute;

        public RelayCommand(Action execute) : this(execute, null) { }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            m_Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            m_CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (m_CanExecute == null)
                return true;
            if (parameter == null)
                return m_CanExecute();
            return m_CanExecute();
        }

        public virtual void Execute(object parameter)
        {
            this.m_Execute();
        }

        public event EventHandler CanExecuteChanged;

        ///internal void RaiseCanExecuteChanged()
        ///{
        ///    this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        ///}


    }
}