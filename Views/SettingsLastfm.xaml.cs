namespace NowListeningParserTool.Views
{
    using ViewModels;

    /// <summary>
    /// Interaction logic for SettingsLastfm.xaml
    /// </summary>
    public partial class SettingsLastfm
    {
        public SettingsLastfm()
        {
            InitializeComponent();
            DataContext = new SettingsLastfmViewModel();
        }
    }
}
