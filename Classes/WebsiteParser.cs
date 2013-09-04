namespace NowListeningParserTool.Classes
{
    public abstract class WebsiteParser
    {
        public abstract string WebsiteLogoUri { get; }

        public string GetArtistAndTitle(string browser, string website, string stringToParse)
        {
            if (browser == "Chrome") return GetSubstring(0, stringToParse, website.Length + 18);
            if (browser == "Firefox") return GetSubstring(0, stringToParse, website.Length + 20);
            return browser == "Opera" ? GetSubstring(0, stringToParse, website.Length + 10) : stringToParse;
        }

        /// <summary>
        /// When we retrieve title from application window, we have to re-parse it, to get only artist and title of track.
        /// Each browser adds different length title for their application in the end.
        /// </summary>
        public string GetSubstring(int start, string songName, int deleteFromEnd)
        {
            return songName.Substring(start, songName.Length - deleteFromEnd);
        }

        // ff 15
        // ch 13
        // op 5
    }
}
