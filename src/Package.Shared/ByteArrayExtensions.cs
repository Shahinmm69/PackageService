namespace Package.Shared
{
    public static class ByteArrayExtensions
    {
        public static int CompareTo(this byte[]? firstArray, byte[]? secondArray)
        {
            if (firstArray == null && secondArray == null)
            {
                return 0;
            }

            if (firstArray == null)
            {
                return -1;
            }

            if (secondArray == null)
            {
                return 1;
            }

            for (int i = 0; i < Math.Min(firstArray.Length, secondArray.Length); i++)
            {
                int num = firstArray[i].CompareTo(secondArray[i]);
                if (num != 0)
                {
                    return num;
                }
            }

            return firstArray.Length.CompareTo(secondArray.Length);
        }

        public static bool IsLessThan(this byte[]? firstArray, byte[]? seccondArray)
        {
            return firstArray.CompareTo(seccondArray) < 0;
        }

        public static bool IsLessThanOrEqual(this byte[]? firstArray, byte[]? secondArray)
        {
            return firstArray.CompareTo(secondArray) <= 0;
        }

        public static bool IsGreaterThan(this byte[]? firstArray, byte[]? secondArray)
        {
            return firstArray.CompareTo(secondArray) > 0;
        }

        public static bool IsGreaterThanOrEqual(this byte[]? firstArray, byte[]? secondArray)
        {
            return firstArray.CompareTo(secondArray) >= 0;
        }

        public static bool IsEqual(this byte[]? firstArray, byte[]? secondArray)
        {
            return firstArray.CompareTo(secondArray) == 0;
        }
    }
}
