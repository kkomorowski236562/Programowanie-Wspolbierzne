using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class RelayCommand : ICommand
    {

        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.m_Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.m_CanExecute = canExecute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. Because the command does not require data
        /// to be passed, this parameter is always ignored</param>
        /// <returns><c>true</c> if this command can be executed; otherwise, <c>false</c>.</returns>
        public bool CanExecute(object parameter)
        {
            if (this.m_CanExecute == null)
                return true;
            if (parameter == null)
                return this.m_CanExecute();
            return this.m_CanExecute();
        }
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. Because the command does not require data
        /// to be passed, this parameter is always ignored</param>
        public virtual void Execute(object parameter)
        {
            this.m_Execute();
        }

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged" /> event.
        /// </summary>
        internal void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }


        private readonly Action m_Execute;
        private readonly Func<bool> m_CanExecute;
    }
}
