namespace NowListeningParserTool.ViewModels
{
    using System;
    using System.Windows.Input;
    using System.Timers;
    using System.Windows.Threading;
    using FirstFloor.ModernUI.Presentation;
    using Classes;
    using CsQuery;
    using Commands;
    using Properties;

    public class LastfmViewModel : NotifyPropertyChanged
    {
        private readonly TimerManager _animationUpdater = new TimerManager();
        private readonly Timer _timer;
        private readonly Dispatcher _currentDispatcher = Dispatcher.CurrentDispatcher;

        public LastfmViewModel()
        {
            _timer = _animationUpdater.SetUpTimer(GetLastFmCurrentSong, 10);
        }

        private string _songNameTextBox = "Open Last.fm scrobbler and start music player";

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

        private void GetLastFmCurrentSong()
        {
            CQ dom = CQ.CreateFromUrl("http://www.last.fm/user/" + ApplicationSettings.Default.Username + "");

            string listeningNow = dom["#recentTracks:first .dateCell:first"].Text();

            string track;
            if (listeningNow.Contains("Listening now"))
            {
                track = dom["#recentTracks:first .subjectCell:first"].Text();
                track = track.Substring(2, track.Length - 3);
            }
            else
            {
                track = "Not listening anything";
            }

            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\song.txt", track);

            _currentDispatcher.Invoke(() =>
            {
                SongNameTextBox = track;
            });
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
    }
}
