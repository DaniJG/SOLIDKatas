
namespace SOLID.Katas.LSP
{
    using System;

    public class Stream
    {
        private string filename;

        public Stream(string filename)
        {
            this.filename = filename;
        }

        public virtual string Read()
        {
            // Some complicate read mechanism ;)
            Console.WriteLine("Reading stream...");
            return "mock string";
        }
    }
}
