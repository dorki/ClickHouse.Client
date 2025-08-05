using System;
using System.Net.Http;

namespace ClickHouse.Client.Http;

internal class DefaultPoolHttpClientFactory : IHttpClientFactory, IDisposable
{
    private readonly DefaultHttpClientHandler handler;

    public DefaultPoolHttpClientFactory(bool allowInsecureTls)
    {
        handler = new(allowInsecureTls);
    }

    public TimeSpan Timeout { get; init; }

    public HttpClient CreateClient(string name) => new(handler, false) {Timeout = Timeout};

    public void Dispose() =>
        handler.Dispose();
}
