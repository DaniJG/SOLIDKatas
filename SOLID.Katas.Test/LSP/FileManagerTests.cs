
namespace SOLID.Katas.Test.LSP
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Katas.LSP;

    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void SaveStreamToFile()
        {
            // Setup
            var stream = new Stream("FileToRead.txt");
            var newFilename = "FileToWrite.txt";

            // Act
            FileManager.StreamToFile(stream, newFilename);
        }

        [TestMethod]
        public void SaveEncryptedStreamToFile()
        {
            // Setup
            var stream = new EncryptedStream("FileToRead.txt");
            var newFilename = "FileToWrite.txt";

            // Act
            FileManager.StreamToFile(stream, newFilename);
        }

    }
}
