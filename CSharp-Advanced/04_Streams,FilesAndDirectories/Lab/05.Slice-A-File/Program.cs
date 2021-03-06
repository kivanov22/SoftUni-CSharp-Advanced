using System;
using System.IO;

namespace _05.Slice_A_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using(FileStream streamReader = new FileStream("sliceMe.txt",FileMode.Open))
            {
                int chunkSize = (int)streamReader.Length / 4;

                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = new byte[1];
                    int count = 0;

                    using(FileStream streamWrite = new FileStream($"slice-{i + 1}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (count<chunkSize)
                        {
                            streamReader.Read(buffer, 0, buffer.Length);
                            streamWrite.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;
                        }

                        if (streamReader.Position!=streamReader.Length && i==3)
                        {
                            int remainingBytes = (int)streamReader.Length - (int)streamReader.Position;
                            byte[] lastBuffer = new byte[remainingBytes];
                            streamReader.Read(lastBuffer, 0, remainingBytes);
                            streamWrite.Write(lastBuffer, 0, lastBuffer.Length);

                        }
                    }
                }
            }
        }
    }
}
