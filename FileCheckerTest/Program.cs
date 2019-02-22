using FileChecker;
namespace FileCheckerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] teste = System.IO.File.ReadAllBytes(@"");
            var bb = new FileProperties(teste);
            var cc = bb.CheckExtension(new Signature[] { Signature.JExif });
            cc = bb.IsImage();
            cc = bb.IsAudio();
            cc = bb.IsUnderSize(FileProperties.FromKilobytes(5120));
            cc = bb.IsUnderSize(FileProperties.FromMegabytes(5));
            var tt = bb;
        }
    }
}
