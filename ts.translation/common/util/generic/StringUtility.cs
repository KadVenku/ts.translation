using System.Text;

namespace ts.translation.common.util.generic
{
    internal class StringUtility
    {
        internal static string Validate(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (string.IsNullOrEmpty(s)) return string.Empty;
            foreach (char t in s)
            {
                char current = t;
                if ((current == 0x9 || current == 0xA || current == 0xD) ||
                    ((current >= 0x20) && (current <= 0xD7FF)) ||
                    ((current >= 0xE000) && (current <= 0xFFFD)) ||
                    ((current >= 0x10000) && (current <= 0x10FFFF)))
                {
                    stringBuilder.Append(current);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
