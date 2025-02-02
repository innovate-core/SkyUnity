using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SkyUnityServer;

public class SkyUnityTPCServer
{
    private TcpListener _listener;
    private readonly int _port = 12345;  // Порт для з'єднання з клієнтами

    public SkyUnityTPCServer()
    {
        _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), _port);
    }

    public void Start()
    {
        _listener.Start();
        Console.WriteLine("The server is running at 127.0.0.1:12345. Waiting for connection..");

        while (true)
        {
            // Чекаємо на підключення клієнта
            TcpClient client = _listener.AcceptTcpClient();
            Console.WriteLine("Client connected.");

            NetworkStream stream = client.GetStream();

            // Прочитати запит клієнта (якщо потрібно)
            byte[] requestBuffer = new byte[256];
            int bytesRead = stream.Read(requestBuffer, 0, requestBuffer.Length);
            string requestMessage = Encoding.ASCII.GetString(requestBuffer, 0, bytesRead);
            Console.WriteLine("Request received: " + requestMessage);

            // Відправити повідомлення клієнту
            string responseMessage = "Hello, the server is up!";
            byte[] responseBuffer = Encoding.ASCII.GetBytes(responseMessage);
            stream.Write(responseBuffer, 0, responseBuffer.Length);

            // Закриття з'єднання
            stream.Close();
            client.Close();
        }
    }
}
