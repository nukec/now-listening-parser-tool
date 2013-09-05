namespace NowListeningParserTool.Classes
{
    public class OnefmWebsiteParser : WebsiteParser
    {
        private const string websiteLogoUri = "/NowListeningParserTool;component/Resources/Images/logo_1fm.png";

        public override string WebsiteLogoUri
        {
            get
            {
                return websiteLogoUri;
            }
        }
    }
}
