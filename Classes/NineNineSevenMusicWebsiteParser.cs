namespace NowListeningParserTool.Classes
{
    public class NineNineSevenMusicWebsiteParser : WebsiteParser
    {
        private const string websiteLogoUri = "/NowListeningParserTool;component/Resources/Images/logo_977music.png";

        public override string WebsiteLogoUri
        {
            get
            {
                return websiteLogoUri;
            }
        }
    }
}
