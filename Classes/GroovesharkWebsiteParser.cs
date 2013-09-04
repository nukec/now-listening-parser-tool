namespace NowListeningParserTool.Classes
{
    public class GroovesharkWebsiteParser : WebsiteParser
    {
        private const string websiteLogoUri = "/NowListeningParserTool;component/Resources/Images/logo_grooveshark.png";

        public override string WebsiteLogoUri
        {
            get
            {
                return websiteLogoUri;
            }
        }
    }
}
