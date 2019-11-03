namespace DataModel.Converter
{
    public static class BinaryConverter
    {
        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
