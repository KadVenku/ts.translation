namespace ts.translation.common.util.generic
{
    internal class XmlUtility
    {
        internal static string EscapeXml(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            string returnString = s;
            returnString = returnString.Replace("'", "&apos;");
            returnString = returnString.Replace("\"", "&quot;");
            returnString = returnString.Replace(">", "&gt;");
            returnString = returnString.Replace("<", "&lt;");
            returnString = returnString.Replace("&", "&amp;");
            return returnString;
        }
        public static string UnescapeXml(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            string returnString = s;
            returnString = returnString.Replace("&apos;", "'");
            returnString = returnString.Replace("&quot;", "\"");
            returnString = returnString.Replace("&gt;", ">");
            returnString = returnString.Replace("&lt;", "<");
            returnString = returnString.Replace("&amp;", "&");
            return returnString;
        }
    }
}
