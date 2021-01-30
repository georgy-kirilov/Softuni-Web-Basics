namespace SUS.HTTP
{
    public enum HttpStatusCode
    {
        OK = 200,
        MovedPermanently = 301,
        MovedTemporarily = 302,
        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        ServiceUnavailable = 503,
    }
}
