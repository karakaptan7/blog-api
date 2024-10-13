using System.Web;

namespace BlogApi.Utilities
{
    public class HtmlContentHandler
    {
        public string DecodeHtmlContent(string encodedContent)
        {
            return HttpUtility.HtmlDecode(encodedContent);
        }
    }
}