using Newtonsoft.Json;
using SkyUnityCore.Dto;
using SkyUnityCore.Enums;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Nodes;

namespace SkyUnityLauncher;

public class TcpClientHandler
{
    private readonly string _serverIp = "127.0.0.1";
    private readonly int _serverPort = 12345;

    public async Task<string> RegisterUser(UserDto userDto)
    {
        try
        {
            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync(_serverIp, _serverPort);
                NetworkStream stream = client.GetStream();

                // Формуємо JSON для передачі
                var requestData = new RequestTPC<UserDto>() { Model = userDto, Type = ServiceType.Register };

                var str = JsonConvert.SerializeObject(requestData);

                byte[] requestBytes = Encoding.UTF8.GetBytes(str);

                await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

                // Читаємо відповідь від сервера
                byte[] responseBuffer = new byte[256];
                int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                return response;
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}
