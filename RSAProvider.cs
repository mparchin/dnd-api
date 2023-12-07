using System.Security.Cryptography;

namespace authority
{
    public interface IPublicRSAProvider : IDisposable
    {
        public RSA Key { get; }
    }
    public interface IPrivateRSAProvider : IDisposable
    {
        public RSA Key { get; }
    }

    public class PublicRSAProvider : IPublicRSAProvider
    {
        public RSA Key { get; }
        public PublicRSAProvider(string path)
        {
            Key = RSA.Create();
            if (File.Exists(path))
                Key.ImportFromPem(File.ReadAllText(path).ToCharArray());
        }

        public void Dispose()
        {
            Key.Dispose();
            GC.SuppressFinalize(this);
        }
    }
    public class PrivateRSAProvider : IPrivateRSAProvider
    {
        public RSA Key { get; }
        public PrivateRSAProvider(string path)
        {
            Key = RSA.Create();
            if (File.Exists(path))
                Key.ImportFromPem(File.ReadAllText(path).ToCharArray());
        }

        public void Dispose()
        {
            Key.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}