namespace NowListeningParserTool.ViewModels
{
    using FirstFloor.ModernUI.Presentation;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Timers;
    using System.Web;
    using System.Windows;
    using Classes;
    using System.Windows.Threading;
    using System.Windows.Input;
    using Commands;

    public class WebViewModel : NotifyPropertyChanged
    {
        readonly TimerManager _animationUpdater = new TimerManager();
        readonly WebsiteDictionary _website = new WebsiteDictionary();
        readonly Timer _timer = new Timer();
        private readonly Dispatcher _currentDispatcher = Dispatcher.CurrentDispatcher;

        public WebViewModel()
        {
            _timer = _animationUpdater.SetUpTimer(GetSongTimer, 10);
        }

        private string _songNameTextBox = "Please open website in selected browser";

        public string SongNameTextBox
        {
            get
            {
                return _songNameTextBox;
            }
            set
            {
                _songNameTextBox = value;
                OnPropertyChanged("SongNameTextBox");
            }
        }

        private string _websiteNameTextBlock;

        public string WebsiteNameTextBlock
        {
            get
            {
                return _websiteNameTextBlock;
            }
            set
            {
                _websiteNameTextBlock = value;
                OnPropertyChanged("WebsiteNameTextBlock");
            }
        }

        private Visibility _websiteNameVisibility;

        public Visibility WebsiteNameVisibility
        {
            get { return _websiteNameVisibility; }
            set
            {
                _websiteNameVisibility = value;
                OnPropertyChanged("WebsiteNameVisibility");
            }
        }

        private string _logoUrlSource;

        public string LogoUrlSource
        {
            get
            {
                return _logoUrlSource;
            }
            set
            {
                _logoUrlSource = value;
                OnPropertyChanged("LogoUrlSource");
            }
        }

        private string _browserNameSelectedItem;

        public string BrowserNameSelectedItem
        {
            get
            {
                return _browserNameSelectedItem;
            }
            set
            {
                _browserNameSelectedItem = value;
                GetSongTimer();
                OnPropertyChanged("BrowserNameSelectedItem");
            }
        }

        private string _websiteNameSelectedItem;

        public string WebsiteNameSelectedItem
        {
            get
            {
                return _websiteNameSelectedItem;
            }
            set
            {
                _websiteNameSelectedItem = value;
                GetSongTimer();
                OnPropertyChanged("WebsiteNameSelectedItem");
            }
        }

        public ICommand LoadTimerCommand
        {
            get
            {
                return new MethodInvokerCommand(LoadTimer);
            }
        }

        public ICommand StopTimerCommand
        {
            get
            {
                return new MethodInvokerCommand(StopTimer);
            }
        }

        private void LoadTimer()
        {
            _timer.Enabled = true;
        }

        private void StopTimer()
        {
            _timer.Enabled = false;
        }

        private void GetSongTimer()
        {
            GetSongName(GetBrowserName(), GetWebsiteName());
        }

        private string GetBrowserName()
        {
            return (BrowserNameSelectedItem != null) ? BrowserNameSelectedItem.Remove(0, 37) : string.Empty;
        }

        private string GetWebsiteName()
        {
            return (WebsiteNameSelectedItem != null) ? WebsiteNameSelectedItem.Remove(0, 37) : string.Empty;
        }

        public void GetSongName(string browser, string website)
        {
            WebsiteNameTextBlock = "";
            WebsiteNameVisibility = Visibility.Hidden;
            LogoUrlSource = "";

            var songName = string.Empty;


            // Get title from window, based on selected browser and website from listboxes
            var browserProc = Process.GetProcessesByName(browser).FirstOrDefault(b => b.MainWindowTitle.Contains(website));
            if (browserProc != null)
            {
                songName = browserProc.MainWindowTitle;

                // Because we get all title content, we have to delete website and browser name to get artist and title only
                try
                {
                    songName = _website.GetArtistAndTitle(website, browser, songName);
                    WebsiteNameTextBlock = "now on " + website;
                    LogoUrlSource = _website.GetWebsiteLogoUri(website);
                    WebsiteNameVisibility = Visibility.Visible;
                }
                // Catches exception if website is not selected
                catch
                {
                    songName = "Please select browser and website";
                }

                songName = HttpUtility.HtmlDecode(songName);
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\song.txt", songName);
            }

            // 
            _currentDispatcher.Invoke(() =>
            {
                SongNameTextBox = (songName == string.Empty) ? "Please open website in selected browser" : songName;
            });
        }
    }
}
