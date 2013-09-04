using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NowListeningParserTool.Classes
{
    public class LiveThreeSixFiveWebsiteParser : WebsiteParser
    {
        private const string websiteLogoUri = "/NowListeningParserTool;component/Resources/Images/logo_live365.png";

        #region WebsiteParser Members

        public override string WebsiteLogoUri
        {
            get
            {
                return websiteLogoUri;
            }
        }

        #endregion
    }
}
