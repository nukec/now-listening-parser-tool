namespace NowListeningParserTool.Classes
{
    using System;
    using System.Timers;

    public class TimerManager
    {
        public Timer SetUpTimer(Action methodName, int seconds)
        {
            var timerGetSong = new Timer();
            timerGetSong.Elapsed += (o, args) => methodName();
            timerGetSong.Interval = 1000 * seconds;
            return timerGetSong;
        }
    }
}
