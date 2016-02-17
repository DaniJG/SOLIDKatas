
namespace SOLID.Katas.LSP
{
    using System;

    public static class FileManager
    {
        public static void StreamToFile(Stream stream, string filename)
        {
            var content = stream.Read();
            if (content == null)
            {
                throw new Exception("Stream content cannot be null!");
            }
            Console.WriteLine("Create new file");
            Console.WriteLine("Write content into file");
        }
    }
}
