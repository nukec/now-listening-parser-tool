namespace NowListeningParserTool.Classes
{
    using System.Collections.Generic;

    public class WebsiteDictionary
    {
        private readonly Dictionary<string, WebsiteParser> _website = new Dictionary<string, WebsiteParser>();

        public WebsiteDictionary()
        {
            _website.Add("YouTube", new YoutubeWebsiteParser());
            _website.Add("977 Music", new NineNineSevenMusicWebsiteParser());
            _website.Add("Grooveshark", new GroovesharkWebsiteParser());
            _website.Add("Sky.FM", new SkyfmWebsiteParser());
            _website.Add("iHeart", new IheartWebsiteParser());
            _website.Add("Live365", new LiveThreeSixFiveWebsiteParser());
            _website.Add("Pandora", new PandoraWebsiteParser());
            _website.Add("Spotify", new SpotifyWebsiteParser());
        }

        public string GetArtistAndTitle(string website, string browser, string stringToParse)
        {
            return _website[website].GetArtistAndTitle(browser, website, stringToParse);
        }

        public string GetWebsiteLogoUri(string website)
        {
            return _website[website].WebsiteLogoUri;
        }
    }
}
