using Newtonsoft.Json;
using SkyUnityCore.Dto;
using SkyUnityServer.Services;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SkyUnityServer;

public class SkyUnityTPCServer
{
    private TcpListener _listener;
    private readonly int _port = 12345;  // Порт для з'єднання з клієнтами

    private readonly IUserService _userService;

    public SkyUnityTPCServer(IUserService userService)
    {
        _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), _port);
        _userService = userService;
    }

    public async void Start()
    {
        _listener.Start();

        while (true)
        {
            TcpClient client = _listener.AcceptTcpClient();

            NetworkStream stream = client.GetStream();
            byte[] requestBuffer = new byte[1024];

            int bytesRead = stream.Read(requestBuffer, 0, requestBuffer.Length);
            string requestMessage = Encoding.UTF8.GetString(requestBuffer, 0, bytesRead);

            string responseMessage = await HandleRequest(requestMessage);

            byte[] responseBuffer = Encoding.UTF8.GetBytes(responseMessage);
            stream.Write(responseBuffer, 0, responseBuffer.Length);

            stream.Close();
            client.Close();
        }
    }

    private async Task<string> HandleRequest(string request)
    {
        try
        {
            var response = JsonConvert.DeserializeObject<RequestTPC<UserDto>>(request);

            if (!await _userService.ExistAsync(response.Model.Name))
            {
                Task<bool> result = _userService.RegisterAsync(response.Model);

                return result.Result ? "Registration successful" : "Registration failed";
            }

            return "User exist";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}