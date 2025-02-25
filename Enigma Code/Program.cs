using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Enigma_Code;
using Enigma_Code.Properties;

internal class Program
{
	public static bool InternetOK()
	{
		try
		{
			Dns.GetHostEntry("dotnet.beget.tech");
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void Cmd(string line)
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = "cmd",
			Arguments = "/c " + line,
			WindowStyle = ProcessWindowStyle.Hidden
		});
	}

	public static void Update(WebClient webClient, string friendlyName, string location)
	{
        if (Settings.Default.Language == 0 && (int)MessageBox.Show("Установить обновление?", "Доступно обновление", (MessageBoxButtons)4, (MessageBoxIcon)32) == 6)
        {
            webClient.DownloadFile("https://module.24hdm.ru/Enigma/Enigma.exe", "EnigmaNew.exe");
            Cmd("taskkill /f /im \"" + friendlyName + "\" && timeout /t 1 && del \"" + location + "\" && ren EnigmaNew.exe \"" + friendlyName + "\" && \"" + location + "\"");
        }
        else if (Settings.Default.Language == 1 && (int)MessageBox.Show("Do you want to install update?", "Update available", (MessageBoxButtons)4, (MessageBoxIcon)32) == 6)
        {
            webClient.DownloadFile("https://module.24hdm.ru/Enigma/Enigma.exe", "EnigmaNew.exe");
            Cmd("taskkill /f /im \"" + friendlyName + "\" && timeout /t 1 && del \"" + location + "\" && ren EnigmaNew.exe \"" + friendlyName + "\" && \"" + location + "\"");
        }
    }

	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		WebClient webClient = new WebClient();
		Directory.SetCurrentDirectory(AppContext.BaseDirectory);

		string location = Assembly.GetExecutingAssembly().Location;
		string friendlyName = AppDomain.CurrentDomain.FriendlyName;
		string localVer = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
		string serverVer = "-";

		if (InternetOK())
		{
			serverVer = webClient.DownloadString("https://module.24hdm.ru/Enigma/EnigmaVer.txt");
		}

		string[] localVerArr = localVer.Split(new char[1] { '.' });
		string[] serverVerArr = serverVer.Split(new char[1] { '.' });


		if (int.Parse(serverVerArr[0]) > int.Parse(localVerArr[0]) && int.Parse(serverVerArr[1]) == int.Parse(localVerArr[1]) && int.Parse(serverVerArr[2]) == int.Parse(localVerArr[2]))
		{
            Update(webClient, friendlyName, location);
        }
        else if (int.Parse(serverVerArr[0]) == int.Parse(localVerArr[0]) && int.Parse(serverVerArr[1]) > int.Parse(localVerArr[1]) && int.Parse(serverVerArr[2]) == int.Parse(localVerArr[2]))
        {
            Update(webClient, friendlyName, location);
        }
        else if (int.Parse(serverVerArr[0]) == int.Parse(localVerArr[0]) && int.Parse(serverVerArr[1]) == int.Parse(localVerArr[1]) && int.Parse(serverVerArr[2]) > int.Parse(localVerArr[2]))
        {
            Update(webClient, friendlyName, location);
        }

        Application.Run(new formMain());
	}
}
