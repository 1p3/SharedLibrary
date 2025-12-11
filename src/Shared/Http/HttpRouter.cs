namespace Shared.Http;

using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Web;

public class HttpRouter
{
    public const int RESPONSE_NOT_SENT = 777;

    private static ulong requestId = 0;
    private string basePath;

    private List<HttpMiddleware> middlewares;
    private List<(string, string, HttpMiddleware[])> routes;

    public HttpRouter()
    {
        basePath = string.Empty;
        middlewares = [];
        routes = [];
    }

    public HttpRouter Use(params HttpMiddleware[] middlewares)
    {
        this.middlewares.AddRange(middlewares);
        return this;
    }

    public HttpRouter Map(string method, string path, params HttpMiddleware[] middlewares)
{
routes.Add((method.ToUpperInvariant(), path, middlewares));
return this;
}
public HttpRouter MapGet(string path, params HttpMiddleware[] middlewares)
{
return Map("GET", path, middlewares);
}
public HttpRouter MapPost(string path, params HttpMiddleware[] middlewares)
{
return Map("POST", path, middlewares);
}
public HttpRouter MapPut(string path, params HttpMiddleware[] middlewares)
{
return Map("PUT", path, middlewares);
}
public HttpRouter MapDelete(string path, params HttpMiddleware[] middlewares)
{
return Map("DELETE", path, middlewares);
}
}
