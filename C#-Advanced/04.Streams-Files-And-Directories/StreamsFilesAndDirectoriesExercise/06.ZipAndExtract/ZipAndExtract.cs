namespace _06.ZipAndExtract
{
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        public static void Main()
        {
            string resourceDir = "resources";

            string zipDir = "zippedFiles";
            Directory.CreateDirectory(zipDir);
            string zipPath = Path.Combine(zipDir, "copyMe.zip");

            ZipFile.CreateFromDirectory(resourceDir, zipPath);

            string extractDir = "extractedFiles";
            Directory.CreateDirectory(extractDir);

            ZipFile.ExtractToDirectory(zipPath, extractDir);
        }
    }
}
