using FileChecker;

namespace FileCheckerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] teste = System.IO.File.ReadAllBytes(@"C:\Users\ramaral\Downloads\true.jpg");
            var bb = new FileProperties(teste);
            var cc = bb.CheckExtension(new Signature[] { Signature.AVI, Signature.PNG, Signature.PSD });
            cc = bb.IsImage();
            cc = bb.IsAudio();
            cc = bb.IsUnderSize(5 * 1024);
            var tt = bb;
        }
    }
}
