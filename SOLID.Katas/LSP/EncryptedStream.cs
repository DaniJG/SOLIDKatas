
namespace SOLID.Katas.LSP
{
    using System;

    public class EncryptedStream : Stream
    {
        public string Key { get; set; }

        public EncryptedStream(string filename) : base(filename)
        {
        }

        public EncryptedStream(string filename, string key) : base(filename)
        {
            this.Key = key;
        }

        public override string Read()
        {
            var encryptedContent = base.Read();
            
            Console.Write("Decypting content");
            if (Key == null)
            {
                throw new Exception("Cannot read content without decyption key.");
            }

            // The following cancatination is just a samle code
            // representing usage of content with decryption key.
            return encryptedContent + Key;
        }
    }
}
