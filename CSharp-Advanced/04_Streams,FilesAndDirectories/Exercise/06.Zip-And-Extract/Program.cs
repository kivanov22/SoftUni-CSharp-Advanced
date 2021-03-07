using System;
using System.IO.Compression;

namespace _06.Zip_And_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("zipFile.zip", ZipArchiveMode.Create);
            ZipArchiveEntry zipArchuve = zipFile.CreateEntryFromFile("copyMe.png", "newCopyMe.png");
        }
    }
}
