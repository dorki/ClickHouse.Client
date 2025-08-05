using System.Net;
using System.Net.Http;

namespace ClickHouse.Client.Http;

internal class DefaultHttpClientHandler : HttpClientHandler
{
    public DefaultHttpClientHandler(bool allowInsecureTls)
    {
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        if (allowInsecureTls)
        {
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
        }
    }
}
