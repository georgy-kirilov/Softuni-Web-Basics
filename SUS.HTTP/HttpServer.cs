namespace SUS.HTTP
{
    using System;
    using System.Net;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class HttpServer
    {
        private readonly IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable;

        public HttpServer()
        {
            routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();
        }

        public void AddRoute(string route, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(route))
            {
                throw new ArgumentException("Route already exists");
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            routeTable.Add(route, action);
        }

        public async Task StartAsync(int port)
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                ProcessClientAsync(client);
            }
        }

        private async Task ProcessClientAsync(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                var bytesRead = new List<byte>();
                var buffer = new byte[HttpConstants.BufferLength];

                int offset = 0;

                while (true)
                {
                    int bytesReadCount = await stream.ReadAsync(buffer, offset, buffer.Length);
                    offset += bytesReadCount;

                    if (bytesReadCount < buffer.Length)
                    {
                        var trimmedBuffer = new byte[bytesReadCount];
                        Array.Copy(buffer, trimmedBuffer, trimmedBuffer.Length);
                        bytesRead.AddRange(trimmedBuffer);
                        break;
                    }
                    else
                    {
                        bytesRead.AddRange(buffer);
                    }
                }
                string requestAsString = Encoding.UTF8.GetString(bytesRead.ToArray());
                var request = new HttpRequest(requestAsString);

                string responseHtml = "<h1>Response</h1>";

                string responseAsString = "HTTP/1.1 200 OK" + HttpConstant|s.NewLine
                    + "Server: SUS Server" + HttpConstants.NewLine
                    + "Content-Type: text/html" + HttpConstants.NewLine
                    + "Content-Length: " + responseHtml.Length + HttpConstants.NewLine + HttpConstants.NewLine
                    + responseHtml;

                byte[] reponseBytes = Encoding.UTF8.GetBytes(responseAsString);

                await stream.WriteAsync(reponseBytes, 0, reponseBytes.Length);

                Console.WriteLine();
            }
        }
    }
}
