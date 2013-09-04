namespace NowListeningParserTool.Classes
{
    public class SpotifyWebsiteParser : WebsiteParser
    {
        private const string websiteLogoUri = "/NowListeningParserTool;component/Resources/Images/logo_spotify.png";

        public override string WebsiteLogoUri
        {
            get
            {
                return websiteLogoUri;
            }
        }
    }
}
