namespace NowListeningParserTool.ViewModels
{
    using System.Windows.Input;
    using FirstFloor.ModernUI.Presentation;
    using Commands;
    using Properties;

    public class SettingsLastfmViewModel : NotifyPropertyChanged
    {
        private string _usernameTextBox = ApplicationSettings.Default.Username;

        public string UsernameTextBox
        {
            get
            {
                return _usernameTextBox;
            }
            set
            {
                _usernameTextBox = value;
                OnPropertyChanged("UsernameTextBox");
                SaveButtonIsEnabled = true;
                SaveButton = "Save";
            }
        }

        private string _saveButton = "Save";

        public string SaveButton
        {
            get
            {
                return _saveButton;
            }
            set
            {
                _saveButton = value;
                OnPropertyChanged("SaveButton");
            }
        }

        private bool _saveButtonIsEnabled;

        public bool SaveButtonIsEnabled
        {
            get { return _saveButtonIsEnabled; }
            set
            {
                _saveButtonIsEnabled = value;
                OnPropertyChanged("SaveButtonIsEnabled");
            }
        }

        public ICommand SaveUsernameCommand
        {
            get
            {
                return new MethodInvokerCommand(SaveUsername);
            }
        }

        private void SaveUsername()
        {
            SaveButtonIsEnabled = false;
            SaveButton = "Done";
            ApplicationSettings.Default.Username = UsernameTextBox;
            ApplicationSettings.Default.Save();
        }
    }
}
