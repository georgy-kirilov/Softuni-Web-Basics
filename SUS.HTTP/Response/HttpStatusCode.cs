namespace SUS.HTTP.Response
{
    public enum HttpStatusCode
    {
        // Information responses
        Continue = 100,
        SwitchingProtocol = 101,
        Processing = 103,

        // Successful responses
        OK = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,

        // Redirection messages
        MovedPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,

        // Client error responses
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,

        // Server error responses
        InternalServerError = 500,
        ServiceUnavailable = 503,
        HttpVersionNotSupported = 505,
    }
}
