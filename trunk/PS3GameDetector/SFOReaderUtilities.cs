using System;
using System.Text;

namespace SFOReaderSharp
{
    static class SFOReaderUtilities
    {
        /**
         * Converts any byte[]-Array to a string with the specified encoding.
         * 
         * @param byteArray
         * @param encoding
         * @return String
         */

        public static String byteArrayToString(byte[] byteArray)
        {
            return byteArrayToString(byteArray, false);
        }

        public static String byteArrayToString(byte[] byteArray, bool isUTF)
        {
            if (isUTF)
                return System.Text.UTF8Encoding.UTF8.GetString(byteArray);
            else
                return System.Text.ASCIIEncoding.ASCII.GetString(byteArray);
        }

        /**
         * Reverse any byte[]-Array and converts it then to an int
         * 
         * @param b
         * @return int
         */
        public static int byteArrayReverseToInt(byte[] b)
        {
            byte[] bTemp = new byte[b.Length];

            for (int i = b.Length - 1, j = 0; i >= 0; i--, j++)
            {
                bTemp[j] = b[i];
            }

            return byteArrayToInt(bTemp);
        }

        /**
         * Returns any byte[]-Array as an int
         * 
         * @param b
         * @return Integer
         */
        public static int byteArrayToInt(byte[] b)
        {
            return byteArrayToInt(b, 0);
        }

        /**
         * Returns any byte[]-Array as an int from the given offset
         * 
         * @param b
         * @param offset
         * @return Integer
         */
        public static int byteArrayToInt(byte[] b, int offset)
        {
            int value = 0;
            for (int i = 0; i < 4; i++)
            {
                int shift = (4 - 1 - i) * 8;
                value += (b[i + offset] & 0x000000FF) << shift;
            }
            return value;
        }
    }
}
