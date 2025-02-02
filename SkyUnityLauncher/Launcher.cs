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

        await tcpClientHandler.RegisterUser("TestName", "TestEmail", "TestPassword");
    }
}
