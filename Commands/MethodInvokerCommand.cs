namespace NowListeningParserTool.Commands
{
    using System;
    using System.Windows.Input;

    public class MethodInvokerCommand : ICommand
    {
        private readonly Action _action;

        public MethodInvokerCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
