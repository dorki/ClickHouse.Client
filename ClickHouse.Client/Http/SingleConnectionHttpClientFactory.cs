using System;
using System.Net;
using System.Net.Http;

namespace ClickHouse.Client.Http;

internal class SingleConnectionHttpClientFactory : IHttpClientFactory, IDisposable
{
    private readonly DefaultHttpClientHandler handler;

    public TimeSpan Timeout { get; init; }

    public SingleConnectionHttpClientFactory(bool allowInsecureTls)
    {
        handler = new(allowInsecureTls) {MaxConnectionsPerServer = 1};
    }

    public HttpClient CreateClient(string name) => new(handler, false)
    {
        Timeout = Timeout,
    };

    public void Dispose() => handler.Dispose();
}
