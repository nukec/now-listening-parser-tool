namespace NowListeningParserTool.Classes
{
    public class YoutubeWebsiteParser : WebsiteParser
    {
        private const string websiteLogoUri = "/NowListeningParserTool;component/Resources/Images/logo_youtube.png";

        public override string WebsiteLogoUri
        {
            get
            {
                return websiteLogoUri;
            }
        }
    }
}
