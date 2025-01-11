using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Enigma_Code
{
    public partial class formMain : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        string localVer = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

        // все символы алфавита
        public char[] chars = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
        'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э',
        'ю', 'я', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '.', ',', ' ', 'a',
        'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
        't', 'u', 'v', 'w', 'x', 'y', 'z', '/', '|', '(', ')', '+', '-', '=', 'А', 'Б', 'В', 'Г',
        'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
        'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
        'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
        'Z', '*', '\n','\r', '\\', '_', '"', '%', '#', '@', '$', ';', ':', '^', '>', '<', '&', '[', ']',
        '{', '}', '`'};

        // исходный массив шифра
        public char[] code = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
        'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э',
        'ю', 'я', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?', '!', '.', ',', ' ', 'a',
        'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
        't', 'u', 'v', 'w', 'x', 'y', 'z', '/', '|', '(', ')', '+', '-', '=', 'А', 'Б', 'В', 'Г',
        'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
        'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
        'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 
        'Z', '*', '\n','\r', '\\', '_', '"', '%', '#', '@', '$', ';', ':', '^', '>', '<', '&', '[', ']',
        '{', '}', '`'};

        // символы-разделители
        public char[] splitChars = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
        'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э',
        'ю', 'я', '?', '!', '.', ',', ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 
        'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
        't', 'u', 'v', 'w', 'x', 'y', 'z', '/', '|', '(', ')', '+', '-', '=', 'А', 'Б', 'В', 'Г',
        'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
        'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
        'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
        'Z', '*', '_', '"', '%', '#', '@', '$', ';', ':', '^', '>', '<', '&', '[', ']',
        '{', '}', '`'};

        public string[] languages = {"English", "Русский"};
        int charsLength;
        string key1;
        string key2;
        char temp;
        string[] textToDecr;
        int[] keyNums = new int[2]; // [0] - Ширина отступа между заменяемых элементов массива    [1] - Сколько раз нужно повторить цикл


        public formMain()
        {
            InitializeComponent();
            textBoxKey1.MaxLength = 2;
            textBoxKey2.MaxLength = 2;
            charsLength = chars.Length;

            textBoxKey1.Text = Properties.Settings.Default.key1;
            textBoxKey2.Text = Properties.Settings.Default.key2;
            checkBoxDarkTheme.Checked = Properties.Settings.Default.darkTheme;
            comboBoxLang.DataSource = languages; // 0-Eng, 1-Рус, 
            comboBoxLang.Text = languages[Properties.Settings.Default.Language];
            label5.Text = "V-" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            comboBoxLang_SelectedIndexChanged(null, null);
            checkBoxDarkTheme_CheckedChanged(null, null);
        }

        private void buttonKeyLoad_Click(object sender, EventArgs e)
        {
            int q = 0; // сброс алфавита
            while (q < chars.Length)
            {
                code[q] = chars[q];
                q++;
            }

            int i = 0;

            string tempKey1;
            string tempKey2;

            if (textToDecr != null && textToDecr.Length > 3 && int.TryParse(textToDecr[textToDecr.Length - 2], out int number) && int.TryParse(textToDecr[textToDecr.Length - 1], out number))
            {
                tempKey1 = textToDecr[textToDecr.Length - 2];
                tempKey2 = textToDecr[textToDecr.Length - 1];


                textBoxKey1.Text = tempKey1;
                textBoxKey2.Text = tempKey2;

                key1 = tempKey1;
                key2 = tempKey2;

                Thread.Sleep(10);
                tempKey1 = null;
                tempKey2 = null;
            }
            else
            {
                key1 = textBoxKey1.Text;
                key2 = textBoxKey2.Text;
            }



            Properties.Settings.Default.key1 = key1;
            Properties.Settings.Default.key2 = key2;
            Properties.Settings.Default.Save();

            if (textBoxKey1.Text == key1 && textBoxKey2.Text == key2)
            {
                string[] keyArr = new string[2];
                keyArr[0] = key1;
                keyArr[1] = key2;



                richTextBoxChars.AppendText(keyArr[0]);
                richTextBoxChars.AppendText(keyArr[1]);

                while (i < keyArr.Length)
                {
                    if (int.TryParse(keyArr[i], out number))
                    {
                        keyNums[i] = int.Parse(keyArr[i]);
                    }
                    i++;
                }

                progressBar2.Value = 0;

                int u = 0;
                int j = 0;
                int k = 0;
                int y = 0;
                int key_2_modded = 1;

                while (y < 3)
                {
                    key_2_modded = key_2_modded * keyNums[1];
                    y++;
                }

                progressBar2.Maximum = key_2_modded;

                while (k < key_2_modded) // Шифровка алфавита
                {

                    while (j + keyNums[0] + u < code.Length)
                    {
                        temp = code[j];
                        code[j] = code[j + keyNums[0] + u];
                        code[j + keyNums[0] + u] = temp;
                        j++;
                    }

                    progressBar2.Value = k;

                    k++;
                    u++;


                    if (u > charsLength + 1)
                    {
                        u = u - charsLength;
                    }

                    j = 0;
                }

                richTextBoxChars.Text = new string(code) + "\n \n[" + charsLength + "]";
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = panel1.BackColor;
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(140,140,255);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = panel1.BackColor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void comboBoxLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lang = Properties.Settings.Default.Language;
            if (lang == 1)
            {
                label1.Text = "Шифровка";
                label2.Text = "Дешифровка";

                buttonKeyLoad.Text = "Загрузить ключ";
                buttonKeyLoad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                checkBoxDarkTheme.Text = "Тёмная тема";

                toolTip.SetToolTip(progressBar1, "Ключ в полях соответствует загруженному");
                toolTip.SetToolTip(label5, "Версия " + localVer + ", от 09.06.2024");

                toolTip.SetToolTip(textBoxKey1, "Поле ключа");
                toolTip.SetToolTip(textBoxKey2, "Поле ключа");

                toolTip.SetToolTip(buttonKeyLoad, "Загрузить этот ключ");

                toolTip.SetToolTip(richTextBoxChars, "Все зашифрованные символы");
            }
            else if(lang == 0)
            {
                label1.Text = "Encryption";
                label2.Text = "Decryption";

                buttonKeyLoad.Text = "Load key";
                buttonKeyLoad.Font = new System.Drawing.Font("Tahoma", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                checkBoxDarkTheme.Text = "Dark theme";

                toolTip.SetToolTip(progressBar1, "The key in the fields same with the loaded key");
                toolTip.SetToolTip(label5, "Version " + localVer + ", of 09.06.2024");

                toolTip.SetToolTip(textBoxKey1, "Field for key");
                toolTip.SetToolTip(textBoxKey2, "Field for key");

                toolTip.SetToolTip(buttonKeyLoad, "Load this key");

                toolTip.SetToolTip(richTextBoxChars, "All encrypted symbols");
            }
        }

        private void textBoxToEncr_TextChanged(object sender, EventArgs e) // Изменение текста в боксе -> перешифровка текста
        {
            int i = 0;
            string txtEncrypted = ""; // Переменная готового зашифрованного текста
            char[] textToEncr = textBoxToEncr.Text.ToCharArray();
            Random random = new Random();

            while (i < textToEncr.Length)
            {
                string letter;

                if ((i + 1) % 2 == 0)
                {
                    letter = (Array.IndexOf(code, textToEncr[i]) * ((i + 2) ^ 2)).ToString();
                }
                else if ((i + 1) % 3 == 0)
                {
                    letter = (Array.IndexOf(code, textToEncr[i]) * ((i + 2) ^ 3)).ToString();
                }
                else
                {
                    letter = (Array.IndexOf(code, textToEncr[i]) * (i + 2)).ToString();
                }


                txtEncrypted = txtEncrypted + letter + splitChars[random.Next(0, splitChars.Length - 1)];
                i++;
            }
            txtEncrypted = txtEncrypted + keyNums[0] + splitChars[random.Next(0, splitChars.Length - 1)] + keyNums[1];
            richTextBoxEncr.Text = txtEncrypted;
        }

        private void textBoxToDecr_TextChanged(object sender, EventArgs e)
        {
            richTextBoxDecr.Clear(); // Дешифровка текста
            textToDecr = null;

            int j = 0;
            int k = 0;
            string txtDecrypted = "";

            while (k < textBoxToDecr.Text.Length)
            {
                textToDecr = textBoxToDecr.Text.Split(splitChars);
                k++;

                while (j < textToDecr.Length - 2 && textToDecr != null)
                {
                    if (textToDecr[j] != "" || textToDecr[j] != null)
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            txtDecrypted = txtDecrypted + code[int.Parse(textToDecr[j]) / ((j + 2) ^ 2)];
                        }
                        else if ((j + 1) % 3 == 0)
                        {
                            txtDecrypted = txtDecrypted + code[int.Parse(textToDecr[j]) / ((j + 2) ^ 3)];
                        }
                        else
                        {
                            txtDecrypted = txtDecrypted + code[int.Parse(textToDecr[j]) / (j + 2)];
                        }
                    }
                    else
                    {
                        textToDecr[j] = "/";
                    }
                    j++;
                }
            }

            richTextBoxDecr.Text = txtDecrypted;
        }

        private void checkBoxDarkTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDarkTheme.Checked == false)
            {
                label1.ForeColor = Color.FromArgb(0, 0, 0);
                label2.ForeColor = Color.FromArgb(0, 0, 0);
                label3.ForeColor = Color.FromArgb(0, 0, 0);
                label4.ForeColor = Color.FromArgb(0, 0, 0);
                label5.ForeColor = Color.FromArgb(0, 0, 0);

                BackColor = Color.FromArgb(230, 230, 230);

                textBoxToEncr.BackColor = BackColor;
                textBoxToDecr.BackColor = BackColor;

                textBoxToEncr.ForeColor = label1.ForeColor;
                textBoxToDecr.ForeColor = label1.ForeColor;

                textBoxKey1.BackColor = BackColor;
                textBoxKey2.BackColor = BackColor;

                textBoxKey1.ForeColor = label1.ForeColor;
                textBoxKey2.ForeColor = label1.ForeColor;

                progressBar1.BackColor = BackColor;
                progressBar2.BackColor = BackColor;

                progressBar1.ForeColor = label1.ForeColor;
                progressBar2.ForeColor = label1.ForeColor;

                richTextBoxEncr.BackColor = BackColor;
                richTextBoxDecr.BackColor = BackColor;
                richTextBoxChars.BackColor = BackColor;

                richTextBoxEncr.ForeColor = label1.ForeColor;
                richTextBoxDecr.ForeColor = label1.ForeColor;
                richTextBoxChars.ForeColor = label1.ForeColor;

                checkBoxDarkTheme.BackColor = BackColor;
                checkBoxDarkTheme.ForeColor = label1.ForeColor;

                buttonKeyLoad.ForeColor = label1.ForeColor;

                panel1.BackColor = Color.FromArgb(245, 245, 245);

                label6.ForeColor = label1.ForeColor;

                button4.ForeColor = label1.ForeColor;
                button5.ForeColor = label1.ForeColor;

                comboBoxLang.BackColor = textBoxToEncr.BackColor;
                comboBoxLang.ForeColor = textBoxToEncr.ForeColor;
            }
            else
            {
                label1.ForeColor = Color.FromArgb(250, 250, 250);
                label2.ForeColor = Color.FromArgb(250, 250, 250);
                label3.ForeColor = Color.FromArgb(250, 250, 250);
                label4.ForeColor = Color.FromArgb(250, 250, 250);
                label5.ForeColor = Color.FromArgb(250, 250, 250);
                label6.ForeColor = label1.ForeColor;

                BackColor = Color.FromArgb(30, 30, 30);

                textBoxToEncr.BackColor = BackColor;
                textBoxToDecr.BackColor = BackColor;

                textBoxToEncr.ForeColor = label1.ForeColor;
                textBoxToDecr.ForeColor = label1.ForeColor;

                textBoxKey1.BackColor = BackColor;
                textBoxKey2.BackColor = BackColor;

                textBoxKey1.ForeColor = label1.ForeColor;
                textBoxKey2.ForeColor = label1.ForeColor;

                progressBar1.BackColor = BackColor;
                progressBar2.BackColor = BackColor;

                progressBar1.ForeColor = label1.ForeColor;
                progressBar2.ForeColor = label1.ForeColor;

                richTextBoxEncr.BackColor = BackColor;
                richTextBoxDecr.BackColor = BackColor;
                richTextBoxChars.BackColor = BackColor;

                richTextBoxEncr.ForeColor = label1.ForeColor;
                richTextBoxDecr.ForeColor = label1.ForeColor;
                richTextBoxChars.ForeColor = label1.ForeColor;

                checkBoxDarkTheme.BackColor = BackColor;
                checkBoxDarkTheme.ForeColor = label1.ForeColor;

                buttonKeyLoad.ForeColor = label1.ForeColor;

                panel1.BackColor = Color.FromArgb(50, 50, 50);

                button4.ForeColor = label1.ForeColor;
                button5.ForeColor = label1.ForeColor;

                comboBoxLang.BackColor = textBoxToEncr.BackColor;
                comboBoxLang.ForeColor = textBoxToEncr.ForeColor;
            }
            Properties.Settings.Default.darkTheme = checkBoxDarkTheme.Checked;
            Properties.Settings.Default.Save();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxKey1.Text, out int number) && int.TryParse(textBoxKey2.Text, out number))
            {
                if (textBoxKey1.Text == key1 && textBoxKey2.Text == key2)
                {
                    progressBar1.Value = 1;
                }
                else
                {
                    progressBar1.Value = 0;
                }
            }

            Properties.Settings.Default.Language = Array.IndexOf(languages, comboBoxLang.Text);
            Properties.Settings.Default.Save();
        }
    }
}
