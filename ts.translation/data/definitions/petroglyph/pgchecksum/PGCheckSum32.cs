using System;

namespace ts.translation.data.definitions.petroglyph.pgchecksum
{
    internal class PGCheckSum32
    {
        private static readonly ulong[] LOOKUP_TABLE = new ulong[256];
        private static bool _tableInitialised = false;

        private static void InitTable()
        {
            for (int i = 0; i < 256; i++)
            {
                uint crc = (uint)i;
                for (int j = 0; j < 8; j++)
                {
                    crc = ((crc & 1) != 0) ? (crc >> 1) ^ 0xEDB88320 : (crc >> 1);
                }
                LOOKUP_TABLE[i] = crc & 0xFFFFFFFF;
            }
            _tableInitialised = true;
        }

        internal uint Checksum { get; set; }
        public PGCheckSum32(uint newCrc32)
        {
            Checksum = newCrc32;
        }
        public PGCheckSum32(string inputVal)
        {
            Checksum = ComputeCrc32(inputVal);
        }

        internal static uint ComputeCrc32(string inputVal)
        {
            if (!_tableInitialised)
            {
                InitTable();
            }
            ulong crc = 0xFFFFFFFF;
            for (int j = 0; j < inputVal.Length; j++)
            {
                crc = ((crc >> 8) & 0x00FFFFFF) ^ LOOKUP_TABLE[(crc ^ (inputVal)[j]) & 0xFF];
            }
            return Convert.ToUInt32(crc ^ 0xFFFFFFFF);
        }

        public byte[] ToBytes()
        {
            return BitConverter.GetBytes(Checksum);
        }
    }
}
