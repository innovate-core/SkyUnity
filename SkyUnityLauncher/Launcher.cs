using System.Net.Sockets;
using System.Text;

namespace SkyUnityLauncher;

public partial class Launcher : Form
{
    public Launcher()
    {
        InitializeComponent();
    }

    private void startServer_Click(object sender, EventArgs e)
    {
        string serverAddress = "127.0.0.1";  // Локальна адреса
        int serverPort = 12345;  // Порт сервера

        // Спроба підключитися до сервера
        try
        {
            TcpClient client = new TcpClient(serverAddress, serverPort);
            NetworkStream stream = client.GetStream();

            // Відправка запиту на сервер (можна відправити що-небудь, якщо потрібно)
            byte[] requestMessage = Encoding.ASCII.GetBytes("Hello from client");
            stream.Write(requestMessage, 0, requestMessage.Length);

            // Отримання повідомлення від сервера
            byte[] responseBuffer = new byte[256];
            int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
            string responseMessage = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);

            // Виведення отриманого повідомлення
            // Закриття з'єднання
            stream.Close();
            client.Close();
        }
        catch (Exception ex)
        {
        }
    }
}
