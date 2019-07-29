using ts.translation.data.definitions.petroglyph.pgchecksum;

namespace ts.translation.common.util.generic
{
    internal static class Crc32Utility
    {
        internal static uint Crc32(string toCrc32)
        {
            PGCheckSum32 crc32 = new PGCheckSum32(toCrc32);
            return crc32.Checksum;
        }
    }
}