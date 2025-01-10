using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Enigma_Code.Properties;

namespace Enigma_Code;

public class formMain : Form
{
	private bool drag = false;

	private Point start_point = new Point(0, 0);

	public char[] chars = new char[160]
	{
		'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
		'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
		'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
		'э', 'ю', 'я', '0', '1', '2', '3', '4', '5', '6',
		'7', '8', '9', '?', '!', '.', ',', ' ', 'a', 'b',
		'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
		'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
		'w', 'x', 'y', 'z', '/', '|', '(', ')', '+', '-',
		'=', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З',
		'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
		'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы',
		'Ь', 'Э', 'Ю', 'Я', 'A', 'B', 'C', 'D', 'E', 'F',
		'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
		'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
		'*', '\n', '\r', '_', '"', '%', '#', '@', '$', ';',
		':', '^', '>', '<', '&', '[', ']', '{', '}', '`'
	};

	public char[] code = new char[160]
	{
		'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
		'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
		'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
		'э', 'ю', 'я', '0', '1', '2', '3', '4', '5', '6',
		'7', '8', '9', '?', '!', '.', ',', ' ', 'a', 'b',
		'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
		'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
		'w', 'x', 'y', 'z', '/', '|', '(', ')', '+', '-',
		'=', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З',
		'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
		'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы',
		'Ь', 'Э', 'Ю', 'Я', 'A', 'B', 'C', 'D', 'E', 'F',
		'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
		'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
		'*', '\n', '\r', '_', '"', '%', '#', '@', '$', ';',
		':', '^', '>', '<', '&', '[', ']', '{', '}', '`'
	};

	public string[] languages = new string[2] { "Русский", "English" };

	private int charsLength = 160;

	private string lang = "";

	private bool TextToEncrIsNormal = true;

	private string s;

	private string key1;

	private string key2;

	private int letter;

	private char[] text1;

	private char temp;

	private string[] textToDecr;

	private char[] textToEncr;

	private int[] keyNums = new int[2];

	private bool darkTheme;

	private IContainer components = null;

	private Timer timer1;

	private CheckBox checkBoxDarkTheme;

	private TextBox textBox1;

	private Label label1;

	private Label label2;

	private TextBox textBox2;

	private Label label3;

	private Label label4;

	private RichTextBox richTextBox1;

	private RichTextBox richTextBox2;

	private TextBox textBoxKey1;

	private Button button1;

	private RichTextBox richTextBox3;

	private ProgressBar progressBar2;

	private TextBox textBoxKey2;

	private Label labelVer;

	private Panel panel1;

	private Button button4;

	private Button button5;

	private PictureBox pictureBox1;

	private Label label6;

	private ComboBox comboBoxLang;

	private ToolTip toolTip;

	public formMain()
	{
		InitializeComponent();
		((TextBoxBase)textBoxKey1).MaxLength = 2;
		((TextBoxBase)textBoxKey2).MaxLength = 2;
		((Control)labelVer).Text = "V-" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
		charsLength = chars.Length;
		((Control)textBoxKey1).Text = Settings.Default.key1;
		((Control)textBoxKey2).Text = Settings.Default.key2;
		checkBoxDarkTheme.Checked = Settings.Default.darkTheme;
		comboBoxLang.DataSource = languages;
		try
		{
			((Control)comboBoxLang).Text = languages[Settings.Default.Language];
		}
		catch
		{
		}
		charsLength = chars.Length;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		Settings.Default.darkTheme = darkTheme;
		Settings.Default.Language = Array.IndexOf(languages, ((Control)comboBoxLang).Text);
		((SettingsBase)Settings.Default).Save();
		text1 = ((Control)textBox1).Text.ToCharArray();
		if (((Control)textBox1).Text.Length > 0)
		{
			if (textToEncr.All(((IEnumerable<char>)chars).Contains<char>))
			{
				TextToEncrIsNormal = true;
			}
			else
			{
				TextToEncrIsNormal = false;
			}
		}
		else
		{
			TextToEncrIsNormal = false;
		}
		if (!TextToEncrIsNormal && ((Control)textBox1).Text.Length > 0)
		{
			((Control)textBox1).BackColor = Color.Red;
			((Control)textBox1).ForeColor = Color.White;
		}
		else
		{
			((Control)textBox1).BackColor = ((Control)this).BackColor;
			((Control)textBox1).ForeColor = ((Control)label1).ForeColor;
		}
		if (int.TryParse(((Control)textBoxKey1).Text, out var result) && int.TryParse(((Control)textBoxKey2).Text, out result))
		{
			if (((Control)textBoxKey1).Text == key1 && ((Control)textBoxKey2).Text == key2)
			{
				((Control)button1).BackColor = Color.FromArgb(255, 115, 115);
				((Control)button1).Enabled = false;
			}
			else
			{
				((Control)button1).BackColor = Color.Red;
				((Control)button1).Enabled = true;
			}
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		for (int i = 0; i < chars.Length; i++)
		{
			code[i] = chars[i];
		}
		int j = 0;
		if (textToDecr != null && textToDecr.Length > 3 && int.TryParse(textToDecr[textToDecr.Length - 2], out var result) && int.TryParse(textToDecr[textToDecr.Length - 1], out result))
		{
			string text = textToDecr[textToDecr.Length - 2];
			string text2 = textToDecr[textToDecr.Length - 1];
			((Control)textBoxKey1).Text = text;
			((Control)textBoxKey2).Text = text2;
			key1 = text;
			key2 = text2;
			Thread.Sleep(10);
			text = null;
			text2 = null;
		}
		else
		{
			key1 = ((Control)textBoxKey1).Text;
			key2 = ((Control)textBoxKey2).Text;
		}
		Settings.Default.key1 = key1;
		Settings.Default.key2 = key2;
		((SettingsBase)Settings.Default).Save();
		if (!(((Control)textBoxKey1).Text == key1) || !(((Control)textBoxKey2).Text == key2))
		{
			return;
		}
		string[] array = new string[2] { key1, key2 };
		((TextBoxBase)richTextBox3).AppendText(array[0]);
		((TextBoxBase)richTextBox3).AppendText(array[1]);
		for (; j < array.Length; j++)
		{
			if (int.TryParse(array[j], out result))
			{
				keyNums[j] = int.Parse(array[j]);
			}
		}
		progressBar2.Value = 0;
		int num = 0;
		int k = 0;
		int num2 = 0;
		int l = 0;
		int num3 = 1;
		for (; l < 3; l++)
		{
			num3 *= keyNums[1];
		}
		progressBar2.Maximum = num3;
		while (num2 < num3)
		{
			for (; k + keyNums[0] + num < code.Length; k++)
			{
				temp = code[k];
				code[k] = code[k + keyNums[0] + num];
				code[k + keyNums[0] + num] = temp;
			}
			progressBar2.Value = num2;
			num2++;
			num++;
			if (num > charsLength + 1)
			{
				num -= charsLength;
			}
			k = 0;
		}
		((Control)richTextBox3).Text = (s = new string(code) + "\n \n[" + charsLength + "]");
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (((Control)richTextBox1).Text.Length > 0)
		{
			try
			{
				Clipboard.SetText(((Control)richTextBox1).Text);
			}
			catch
			{
			}
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (((Control)richTextBox2).Text.Length > 0)
		{
			try
			{
				Clipboard.SetText(((Control)richTextBox2).Text);
			}
			catch
			{
			}
		}
	}

	private void button4_MouseEnter(object sender, EventArgs e)
	{
		((Control)button4).BackColor = Color.Red;
	}

	private void button4_MouseLeave(object sender, EventArgs e)
	{
		((Control)button4).BackColor = ((Control)panel1).BackColor;
	}

	private void button4_MouseClick(object sender, MouseEventArgs e)
	{
		Application.Exit();
	}

	private void button5_MouseEnter(object sender, EventArgs e)
	{
		((Control)button5).BackColor = Color.FromArgb(140, 140, 255);
	}

	private void button5_MouseLeave(object sender, EventArgs e)
	{
		((Control)button5).BackColor = ((Control)panel1).BackColor;
	}

	private void button5_Click(object sender, EventArgs e)
	{
		((Form)this).WindowState = (FormWindowState)1;
	}

	private void panel1_MouseDown(object sender, MouseEventArgs e)
	{
		drag = true;
		start_point = new Point(e.X, e.Y);
	}

	private void panel1_MouseUp(object sender, MouseEventArgs e)
	{
		drag = false;
	}

	private void panel1_MouseMove(object sender, MouseEventArgs e)
	{
		if (drag)
		{
			Point point = ((Control)this).PointToScreen(e.Location);
			((Form)this).Location = new Point(point.X - start_point.X, point.Y - start_point.Y);
		}
	}

	private void comboBoxLang_SelectedIndexChanged(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		if (((Control)comboBoxLang).Text == "Русский")
		{
			lang = "ru";
			((Control)label1).Text = "Шифровка";
			((Control)label2).Text = "Дешифровка";
			((Control)button1).Text = "Загрузить ключ";
			((Control)button1).Font = new Font("Tahoma", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((Control)checkBoxDarkTheme).Text = "Тёмная тема";
			toolTip.SetToolTip((Control)(object)labelVer, "Версия 1.20.0, от 09.06.2024");
			toolTip.SetToolTip((Control)(object)textBoxKey1, "Поле ключа");
			toolTip.SetToolTip((Control)(object)textBoxKey2, "Поле ключа");
			toolTip.SetToolTip((Control)(object)button1, "Загрузить этот ключ");
			toolTip.SetToolTip((Control)(object)richTextBox3, "Все зашифрованные символы");
		}
		else if (((Control)comboBoxLang).Text == "English")
		{
			lang = "eng";
			((Control)label1).Text = "Encryption";
			((Control)label2).Text = "Decryption";
			((Control)button1).Text = "Load key";
			((Control)button1).Font = new Font("Tahoma", 11f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
			((Control)checkBoxDarkTheme).Text = "Dark theme";
			toolTip.SetToolTip((Control)(object)labelVer, "Version 1.20.0, of 09.06.2024");
			toolTip.SetToolTip((Control)(object)textBoxKey1, "Field for key");
			toolTip.SetToolTip((Control)(object)textBoxKey2, "Field for key");
			toolTip.SetToolTip((Control)(object)button1, "Load this key");
			toolTip.SetToolTip((Control)(object)richTextBox3, "All encrypted symbols");
		}
	}

	private void textBoxToEnc_TextChanged(object sender, EventArgs e)
	{
		int i = 0;
		string text = "";
		for (textToEncr = ((Control)textBox1).Text.ToCharArray(); i < textToEncr.Length; i++)
		{
			if ((i + 1) % 2 == 0)
			{
				letter = Array.IndexOf(code, textToEncr[i]) * ((i + 2) ^ 2);
			}
			else if ((i + 1) % 3 == 0)
			{
				letter = Array.IndexOf(code, textToEncr[i]) * ((i + 2) ^ 3);
			}
			else
			{
				letter = Array.IndexOf(code, textToEncr[i]) * (i + 2);
			}
			text = text + letter + "/";
		}
		text = text + keyNums[0] + "/" + keyNums[1];
		((Control)richTextBox1).Text = text;
	}

	private void textBoxToDecr_TextChanged(object sender, EventArgs e)
	{
		textToDecr = null;
		int i = 0;
		int num = 0;
		string text = "";
		while (num < ((Control)textBox2).Text.Length)
		{
			textToDecr = ((Control)textBox2).Text.Split(new char[1] { '/' });
			num++;
			for (; i < textToDecr.Length - 2; i++)
			{
				if (textToDecr == null)
				{
					break;
				}
				if (textToDecr[i] != "" && textToDecr[i] != "/" && textToDecr[i] != "." && textToDecr[i] != "," && textToDecr[i] != "|" && textToDecr[i] != "-" && textToDecr[i] != "=")
				{
					if ((i + 1) % 2 == 0)
					{
						try
						{
							text += code[int.Parse(textToDecr[i]) / ((i + 2) ^ 2)];
							((Control)textBox2).BackColor = ((Control)this).BackColor;
							((Control)textBox2).ForeColor = ((Control)label1).ForeColor;
						}
						catch
						{
							((Control)textBox2).BackColor = Color.Red;
							((Control)textBox2).ForeColor = Color.White;
						}
					}
					else if ((i + 1) % 3 == 0)
					{
						try
						{
							text += code[int.Parse(textToDecr[i]) / ((i + 2) ^ 3)];
							((Control)textBox2).BackColor = ((Control)this).BackColor;
							((Control)textBox2).ForeColor = ((Control)label1).ForeColor;
						}
						catch
						{
							((Control)textBox2).BackColor = Color.Red;
							((Control)textBox2).ForeColor = Color.White;
						}
					}
					else
					{
						try
						{
							text += code[int.Parse(textToDecr[i]) / (i + 2)];
							((Control)textBox2).BackColor = ((Control)this).BackColor;
							((Control)textBox2).ForeColor = ((Control)label1).ForeColor;
						}
						catch
						{
							((Control)textBox2).BackColor = Color.Red;
							((Control)textBox2).ForeColor = Color.White;
						}
					}
				}
				else
				{
					textToDecr[i] = "/";
				}
			}
		}
		((Control)richTextBox2).Text = text;
	}

	private void checkBoxDarkTheme_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBoxDarkTheme.Checked)
		{
			darkTheme = true;
			((Control)button4).BackColor = Color.FromArgb(50, 50, 50);
			((Control)button5).BackColor = Color.FromArgb(50, 50, 50);
		}
		else
		{
			darkTheme = false;
			((Control)button4).BackColor = Color.FromArgb(245, 245, 245);
			((Control)button5).BackColor = Color.FromArgb(245, 245, 245);
		}
		Settings.Default.darkTheme = darkTheme;
		((SettingsBase)Settings.Default).Save();
		if (!darkTheme)
		{
			((Control)label1).ForeColor = Color.FromArgb(0, 0, 0);
			((Control)label2).ForeColor = Color.FromArgb(0, 0, 0);
			((Control)label3).ForeColor = Color.FromArgb(0, 0, 0);
			((Control)label4).ForeColor = Color.FromArgb(0, 0, 0);
			((Control)labelVer).ForeColor = Color.FromArgb(0, 0, 0);
			((Control)this).BackColor = Color.FromArgb(230, 230, 230);
			((Control)textBox1).BackColor = ((Control)this).BackColor;
			((Control)textBox2).BackColor = ((Control)this).BackColor;
			((Control)textBox1).ForeColor = ((Control)label1).ForeColor;
			((Control)textBox2).ForeColor = ((Control)label1).ForeColor;
			((Control)textBoxKey1).BackColor = ((Control)this).BackColor;
			((Control)textBoxKey2).BackColor = ((Control)this).BackColor;
			((Control)textBoxKey1).ForeColor = ((Control)label1).ForeColor;
			((Control)textBoxKey2).ForeColor = ((Control)label1).ForeColor;
			((Control)progressBar2).BackColor = ((Control)this).BackColor;
			((Control)progressBar2).ForeColor = ((Control)label1).ForeColor;
			((Control)richTextBox1).BackColor = ((Control)this).BackColor;
			((Control)richTextBox2).BackColor = ((Control)this).BackColor;
			((Control)richTextBox3).BackColor = ((Control)this).BackColor;
			((Control)richTextBox1).ForeColor = ((Control)label1).ForeColor;
			((Control)richTextBox2).ForeColor = ((Control)label1).ForeColor;
			((Control)richTextBox3).ForeColor = ((Control)label1).ForeColor;
			((Control)checkBoxDarkTheme).BackColor = ((Control)this).BackColor;
			((Control)checkBoxDarkTheme).ForeColor = ((Control)label1).ForeColor;
			((Control)button1).ForeColor = ((Control)label1).ForeColor;
			((Control)panel1).BackColor = Color.FromArgb(245, 245, 245);
			((Control)label6).ForeColor = ((Control)label1).ForeColor;
			((Control)button4).ForeColor = ((Control)label1).ForeColor;
			((Control)button5).ForeColor = ((Control)label1).ForeColor;
			((Control)comboBoxLang).BackColor = ((Control)textBox1).BackColor;
			((Control)comboBoxLang).ForeColor = ((Control)textBox1).ForeColor;
		}
		else
		{
			((Control)label1).ForeColor = Color.FromArgb(250, 250, 250);
			((Control)label2).ForeColor = Color.FromArgb(250, 250, 250);
			((Control)label3).ForeColor = Color.FromArgb(250, 250, 250);
			((Control)label4).ForeColor = Color.FromArgb(250, 250, 250);
			((Control)labelVer).ForeColor = Color.FromArgb(250, 250, 250);
			((Control)label6).ForeColor = ((Control)label1).ForeColor;
			((Control)this).BackColor = Color.FromArgb(30, 30, 30);
			((Control)textBox1).BackColor = ((Control)this).BackColor;
			((Control)textBox2).BackColor = ((Control)this).BackColor;
			((Control)textBox1).ForeColor = ((Control)label1).ForeColor;
			((Control)textBox2).ForeColor = ((Control)label1).ForeColor;
			((Control)textBoxKey1).BackColor = ((Control)this).BackColor;
			((Control)textBoxKey2).BackColor = ((Control)this).BackColor;
			((Control)textBoxKey1).ForeColor = ((Control)label1).ForeColor;
			((Control)textBoxKey2).ForeColor = ((Control)label1).ForeColor;
			((Control)progressBar2).BackColor = ((Control)this).BackColor;
			((Control)progressBar2).ForeColor = ((Control)label1).ForeColor;
			((Control)richTextBox1).BackColor = ((Control)this).BackColor;
			((Control)richTextBox2).BackColor = ((Control)this).BackColor;
			((Control)richTextBox3).BackColor = ((Control)this).BackColor;
			((Control)richTextBox1).ForeColor = ((Control)label1).ForeColor;
			((Control)richTextBox2).ForeColor = ((Control)label1).ForeColor;
			((Control)richTextBox3).ForeColor = ((Control)label1).ForeColor;
			((Control)checkBoxDarkTheme).BackColor = ((Control)this).BackColor;
			((Control)checkBoxDarkTheme).ForeColor = ((Control)label1).ForeColor;
			((Control)button1).ForeColor = ((Control)label1).ForeColor;
			((Control)panel1).BackColor = Color.FromArgb(50, 50, 50);
			((Control)button4).ForeColor = ((Control)label1).ForeColor;
			((Control)button5).ForeColor = ((Control)label1).ForeColor;
			((Control)comboBoxLang).BackColor = ((Control)textBox1).BackColor;
			((Control)comboBoxLang).ForeColor = ((Control)textBox1).ForeColor;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Expected O, but got Unknown
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Expected O, but got Unknown
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Expected O, but got Unknown
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Expected O, but got Unknown
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Expected O, but got Unknown
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Expected O, but got Unknown
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Expected O, but got Unknown
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Expected O, but got Unknown
		//IL_09f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a02: Expected O, but got Unknown
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1d: Expected O, but got Unknown
		//IL_0b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b35: Expected O, but got Unknown
		//IL_0b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4d: Expected O, but got Unknown
		//IL_0b6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b78: Expected O, but got Unknown
		//IL_0cb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc0: Expected O, but got Unknown
		//IL_0dc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd0: Expected O, but got Unknown
		//IL_0e47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e51: Expected O, but got Unknown
		//IL_0eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec1: Expected O, but got Unknown
		//IL_10bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c6: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(formMain));
		timer1 = new Timer(components);
		checkBoxDarkTheme = new CheckBox();
		textBox1 = new TextBox();
		label1 = new Label();
		label2 = new Label();
		textBox2 = new TextBox();
		label3 = new Label();
		label4 = new Label();
		richTextBox1 = new RichTextBox();
		richTextBox2 = new RichTextBox();
		textBoxKey1 = new TextBox();
		button1 = new Button();
		richTextBox3 = new RichTextBox();
		progressBar2 = new ProgressBar();
		textBoxKey2 = new TextBox();
		labelVer = new Label();
		panel1 = new Panel();
		label6 = new Label();
		pictureBox1 = new PictureBox();
		button5 = new Button();
		button4 = new Button();
		comboBoxLang = new ComboBox();
		toolTip = new ToolTip(components);
		((Control)panel1).SuspendLayout();
		((ISupportInitialize)pictureBox1).BeginInit();
		((Control)this).SuspendLayout();
		timer1.Enabled = true;
		timer1.Tick += timer1_Tick;
		((Control)checkBoxDarkTheme).AutoSize = true;
		((Control)checkBoxDarkTheme).Cursor = Cursors.Hand;
		((Control)checkBoxDarkTheme).Font = new Font("Tahoma", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)checkBoxDarkTheme).Location = new Point(853, 452);
		((Control)checkBoxDarkTheme).Name = "checkBoxDarkTheme";
		((Control)checkBoxDarkTheme).Size = new Size(112, 20);
		((Control)checkBoxDarkTheme).TabIndex = 0;
		((Control)checkBoxDarkTheme).Text = "Тёмная тема";
		((ButtonBase)checkBoxDarkTheme).UseVisualStyleBackColor = true;
		checkBoxDarkTheme.CheckedChanged += checkBoxDarkTheme_CheckedChanged;
		((Control)textBox1).Font = new Font("Tahoma", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)textBox1).Location = new Point(12, 62);
		((TextBoxBase)textBox1).Multiline = true;
		((Control)textBox1).Name = "textBox1";
		((Control)textBox1).Size = new Size(290, 173);
		((Control)textBox1).TabIndex = 2;
		((Control)textBox1).TextChanged += textBoxToEnc_TextChanged;
		((Control)label1).AutoSize = true;
		((Control)label1).Font = new Font("Tahoma", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)label1).Location = new Point(12, 39);
		((Control)label1).Name = "label1";
		((Control)label1).Size = new Size(99, 19);
		((Control)label1).TabIndex = 4;
		((Control)label1).Text = "Шифровка";
		((Control)label2).AutoSize = true;
		((Control)label2).Font = new Font("Tahoma", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)label2).Location = new Point(12, 249);
		((Control)label2).Name = "label2";
		((Control)label2).Size = new Size(119, 19);
		((Control)label2).TabIndex = 6;
		((Control)label2).Text = "Дешифровка";
		((Control)textBox2).Font = new Font("Tahoma", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)textBox2).Location = new Point(12, 272);
		((TextBoxBase)textBox2).Multiline = true;
		((Control)textBox2).Name = "textBox2";
		((Control)textBox2).Size = new Size(290, 173);
		((Control)textBox2).TabIndex = 5;
		((Control)textBox2).TextChanged += textBoxToDecr_TextChanged;
		((Control)label3).AutoSize = true;
		((Control)label3).Font = new Font("Niagara Engraved", 120.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)label3).Location = new Point(308, 274);
		((Control)label3).Name = "label3";
		((Control)label3).Size = new Size(116, 171);
		((Control)label3).TabIndex = 11;
		((Control)label3).Text = ">";
		((Control)label4).AutoSize = true;
		((Control)label4).Font = new Font("Niagara Engraved", 120.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)label4).Location = new Point(308, 64);
		((Control)label4).Name = "label4";
		((Control)label4).Size = new Size(116, 171);
		((Control)label4).TabIndex = 12;
		((Control)label4).Text = ">";
		((Control)richTextBox1).Font = new Font("Tahoma", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)richTextBox1).Location = new Point(430, 62);
		((Control)richTextBox1).Name = "richTextBox1";
		((Control)richTextBox1).Size = new Size(368, 171);
		((Control)richTextBox1).TabIndex = 13;
		((Control)richTextBox1).Text = "";
		((Control)richTextBox2).Font = new Font("Tahoma", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)richTextBox2).Location = new Point(430, 272);
		((Control)richTextBox2).Name = "richTextBox2";
		((Control)richTextBox2).Size = new Size(368, 171);
		((Control)richTextBox2).TabIndex = 14;
		((Control)richTextBox2).Text = "";
		((Control)textBoxKey1).Font = new Font("Tahoma", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)textBoxKey1).Location = new Point(430, 239);
		((TextBoxBase)textBoxKey1).Multiline = true;
		((Control)textBoxKey1).Name = "textBoxKey1";
		((Control)textBoxKey1).RightToLeft = (RightToLeft)1;
		((Control)textBoxKey1).Size = new Size(26, 27);
		((Control)textBoxKey1).TabIndex = 15;
		((Control)textBoxKey1).Text = "00";
		((Control)button1).BackColor = Color.Red;
		((Control)button1).Cursor = Cursors.Hand;
		((ButtonBase)button1).FlatAppearance.BorderSize = 0;
		((ButtonBase)button1).FlatStyle = (FlatStyle)1;
		((Control)button1).Font = new Font("Tahoma", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)button1).ForeColor = SystemColors.ControlText;
		((Control)button1).Location = new Point(301, 239);
		((Control)button1).Name = "button1";
		((Control)button1).Size = new Size(123, 27);
		((Control)button1).TabIndex = 17;
		((Control)button1).Text = "Загрузить ключ";
		((ButtonBase)button1).UseVisualStyleBackColor = false;
		((Control)button1).Click += button1_Click;
		((Control)richTextBox3).Font = new Font("Tahoma", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)richTextBox3).Location = new Point(804, 62);
		((Control)richTextBox3).Name = "richTextBox3";
		((Control)richTextBox3).Size = new Size(161, 381);
		((Control)richTextBox3).TabIndex = 18;
		((Control)richTextBox3).Text = "";
		((Control)progressBar2).Location = new Point(494, 239);
		progressBar2.MarqueeAnimationSpeed = 50;
		((Control)progressBar2).Name = "progressBar2";
		((Control)progressBar2).Size = new Size(304, 29);
		progressBar2.Step = 1;
		progressBar2.Style = (ProgressBarStyle)1;
		((Control)progressBar2).TabIndex = 19;
		((Control)textBoxKey2).Font = new Font("Tahoma", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)textBoxKey2).Location = new Point(462, 239);
		((TextBoxBase)textBoxKey2).Multiline = true;
		((Control)textBoxKey2).Name = "textBoxKey2";
		((Control)textBoxKey2).RightToLeft = (RightToLeft)1;
		((Control)textBoxKey2).Size = new Size(26, 27);
		((Control)textBoxKey2).TabIndex = 20;
		((Control)textBoxKey2).Text = "00";
		((Control)labelVer).AutoSize = true;
		((Control)labelVer).Cursor = Cursors.Arrow;
		((Control)labelVer).Font = new Font("Tahoma", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((Control)labelVer).Location = new Point(13, 454);
		((Control)labelVer).Name = "labelVer";
		((Control)labelVer).Size = new Size(79, 14);
		((Control)labelVer).TabIndex = 23;
		((Control)labelVer).Text = "VersionNum";
		((Control)panel1).Controls.Add((Control)(object)label6);
		((Control)panel1).Controls.Add((Control)(object)pictureBox1);
		((Control)panel1).Controls.Add((Control)(object)button5);
		((Control)panel1).Controls.Add((Control)(object)button4);
		((Control)panel1).Location = new Point(0, 0);
		((Control)panel1).Name = "panel1";
		((Control)panel1).Size = new Size(977, 28);
		((Control)panel1).TabIndex = 24;
		((Control)panel1).MouseDown += new MouseEventHandler(panel1_MouseDown);
		((Control)panel1).MouseMove += new MouseEventHandler(panel1_MouseMove);
		((Control)panel1).MouseUp += new MouseEventHandler(panel1_MouseUp);
		((Control)label6).AutoSize = true;
		((Control)label6).Font = new Font("Microsoft Tai Le", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)label6).Location = new Point(34, 6);
		((Control)label6).Name = "label6";
		((Control)label6).Size = new Size(126, 19);
		((Control)label6).TabIndex = 28;
		((Control)label6).Text = "Enigma Encryptor";
		((Control)pictureBox1).BackgroundImage = (Image)(object)Resources.encryption_icon_216177_fotor_20240419182913;
		((Control)pictureBox1).Dock = (DockStyle)3;
		pictureBox1.Image = (Image)(object)Resources.encryption_icon_216177_fotor_20240419182913;
		((Control)pictureBox1).Location = new Point(0, 0);
		((Control)pictureBox1).Name = "pictureBox1";
		((Control)pictureBox1).Size = new Size(28, 28);
		pictureBox1.SizeMode = (PictureBoxSizeMode)1;
		pictureBox1.TabIndex = 27;
		pictureBox1.TabStop = false;
		((Control)button5).Cursor = Cursors.Hand;
		((Control)button5).Dock = (DockStyle)4;
		((ButtonBase)button5).FlatAppearance.BorderSize = 0;
		((ButtonBase)button5).FlatStyle = (FlatStyle)0;
		((Control)button5).Font = new Font("Microsoft Sans Serif", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)204);
		((Control)button5).Location = new Point(899, 0);
		((Control)button5).Name = "button5";
		((Control)button5).Size = new Size(39, 28);
		((Control)button5).TabIndex = 26;
		((Control)button5).Text = "—";
		((ButtonBase)button5).UseVisualStyleBackColor = true;
		((Control)button5).Click += button5_Click;
		((Control)button5).MouseEnter += button5_MouseEnter;
		((Control)button5).MouseLeave += button5_MouseLeave;
		((Control)button4).Cursor = Cursors.Hand;
		((Control)button4).Dock = (DockStyle)4;
		((ButtonBase)button4).FlatAppearance.BorderSize = 0;
		((ButtonBase)button4).FlatStyle = (FlatStyle)0;
		((Control)button4).Font = new Font("Microsoft Sans Serif", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)204);
		((Control)button4).Location = new Point(938, 0);
		((Control)button4).Name = "button4";
		((Control)button4).Size = new Size(39, 28);
		((Control)button4).TabIndex = 25;
		((Control)button4).Text = "X";
		((ButtonBase)button4).UseVisualStyleBackColor = true;
		((Control)button4).MouseClick += new MouseEventHandler(button4_MouseClick);
		((Control)button4).MouseEnter += button4_MouseEnter;
		((Control)button4).MouseLeave += button4_MouseLeave;
		((Control)comboBoxLang).Cursor = Cursors.Hand;
		comboBoxLang.DropDownStyle = (ComboBoxStyle)2;
		((Control)comboBoxLang).Font = new Font("Tahoma", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)204);
		((ListControl)comboBoxLang).FormattingEnabled = true;
		((Control)comboBoxLang).Location = new Point(804, 34);
		((Control)comboBoxLang).Name = "comboBoxLang";
		((Control)comboBoxLang).Size = new Size(161, 24);
		((Control)comboBoxLang).TabIndex = 25;
		comboBoxLang.SelectedIndexChanged += comboBoxLang_SelectedIndexChanged;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = SystemColors.ControlLight;
		((Form)this).ClientSize = new Size(977, 484);
		((Control)this).Controls.Add((Control)(object)comboBoxLang);
		((Control)this).Controls.Add((Control)(object)panel1);
		((Control)this).Controls.Add((Control)(object)labelVer);
		((Control)this).Controls.Add((Control)(object)textBoxKey2);
		((Control)this).Controls.Add((Control)(object)progressBar2);
		((Control)this).Controls.Add((Control)(object)richTextBox3);
		((Control)this).Controls.Add((Control)(object)button1);
		((Control)this).Controls.Add((Control)(object)textBoxKey1);
		((Control)this).Controls.Add((Control)(object)richTextBox2);
		((Control)this).Controls.Add((Control)(object)richTextBox1);
		((Control)this).Controls.Add((Control)(object)label4);
		((Control)this).Controls.Add((Control)(object)label3);
		((Control)this).Controls.Add((Control)(object)label2);
		((Control)this).Controls.Add((Control)(object)textBox2);
		((Control)this).Controls.Add((Control)(object)label1);
		((Control)this).Controls.Add((Control)(object)textBox1);
		((Control)this).Controls.Add((Control)(object)checkBoxDarkTheme);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).Name = "formMain";
		((Control)this).Text = "Enigma Code";
		((Control)panel1).ResumeLayout(false);
		((Control)panel1).PerformLayout();
		((ISupportInitialize)pictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
