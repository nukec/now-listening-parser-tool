namespace NowListeningParserTool.Views
{
    using ViewModels;

    /// <summary>
    /// Interaction logic for Web.xaml
    /// </summary>
    public partial class Web
    {
        public Web()
        {
            InitializeComponent();
            DataContext = new WebViewModel();
        }
    }
}
