using System;

namespace ts.translation.data.definitions.petroglyph.formats.dat.content.record
{
    internal abstract class APGDatTableRecordHolder : IPGBinary
    {
        protected static byte[] CutArray(byte[] array, uint startingIndex, uint endIndex)
        {
            if (startingIndex >= endIndex || startingIndex + endIndex > array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            byte[] returnArray = new byte[endIndex - startingIndex];
            for (uint i = 0; i < endIndex - startingIndex; i++)
            {
                returnArray[i] = array[startingIndex + i];
            }

            return returnArray;
        }

        public abstract byte[] ToBytes();
    }
}