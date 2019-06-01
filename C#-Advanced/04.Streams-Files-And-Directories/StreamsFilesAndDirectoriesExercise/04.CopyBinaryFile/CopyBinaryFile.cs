namespace _04.CopyBinaryFile
{
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            string directory = "files";

            string picturePath = Path.Combine(directory, "copyMe.png");
            string copiedPicturePath = Path.Combine(directory, "copyMe-copy.png");

            using (FileStream reader = new FileStream(picturePath, FileMode.Open))
            {
                byte[] buffer = new byte[4096];

                int readBytesCount = default;

                while ((readBytesCount = reader.Read(buffer, 0, buffer.Length)) != 0)
                {
                    using (FileStream writer = new FileStream(copiedPicturePath, FileMode.Append))
                    {
                        writer.Write(buffer, 0, readBytesCount);
                    }
                }               
            }
        }
    }
}
