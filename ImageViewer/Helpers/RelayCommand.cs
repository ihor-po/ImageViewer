using System;
using System.Windows.Input;

namespace ImageViewer.Helpers
{
    public class RelayCommand : ICommand
    {

        #region Fields

        //delegate void myHandler(object o);    //эквивалент записи ниже
        // myHadler execute;

        private Action<object> execute;         //Обобщенный делегат для хранения метода который будет выполняться
        private Func<object, bool> canExecute;  //Обобщенный делегат

        #endregion

        #region Constructors
        public RelayCommand(Action<object> _execute, Func<object, bool> _canExecute)
        {
            if (_execute == null)
            {
                throw new ArgumentException("Параметр _execute не может быть null");
            }

            this.execute = _execute;
            this.canExecute = _canExecute;
        }

        public RelayCommand(Action<object> _execute) : this(_execute, null) { }

        #endregion

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
