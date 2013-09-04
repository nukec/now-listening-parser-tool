namespace NowListeningParserTool.Views
{
    using ViewModels;

    /// <summary>
    /// Interaction logic for SettingsAppearance.xaml
    /// </summary>
    public partial class SettingsAppearance
    {
        public SettingsAppearance()
        {
            InitializeComponent();

            // create and assign the appearance view model
            DataContext = new SettingsAppearanceViewModel();
        }
    }
}
