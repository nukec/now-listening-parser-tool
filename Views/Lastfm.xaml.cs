namespace NowListeningParserTool.Views
{
    using ViewModels;
    /// <summary>
    /// Interaction logic for Lastfm.xaml
    /// </summary>
    public partial class Lastfm
    {
        public Lastfm()
        {
            InitializeComponent();
            DataContext = new LastfmViewModel();
        }
    }
}
