using SkyUnityCore.Dto;

namespace SkyUnityLauncher;

public partial class Launcher : Form
{
    public Launcher()
    {
        InitializeComponent();
    }

    private async void startServer_Click(object sender, EventArgs e)
    {
        var tcpClientHandler = new TcpClientHandler();

        var user = new UserDto() { Email = "admin", Password = "0000", Name = "admin", };
        await tcpClientHandler.RegisterUser(user);
    }
}
