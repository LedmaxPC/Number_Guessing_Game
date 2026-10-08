using System;
using System.Windows.Forms;

namespace DesktopApp7
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        int num;
        int cehd = 0;

        ErrorProvider xeta = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();

            xeta.ContainerControl = this;
            xeta.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Oyun başlamadan deaktiv olur.
            button1.Enabled = false;
            textBox1.Enabled = false;

            // Yoxla düyməsini düzgün metoda bağlayır.
            button1.Click -= button1_Click;
            button1.Click -= button1_Click_1;
            button1.Click += button1_Click;

            // Yeni oyun düyməsini metoda bağlayır.
            button2.Click -= button2_Click;
            button2.Click += button2_Click;

            // Yazı dəyişdikdə xəbərdarlığı silir.
            textBox1.TextChanged -= textBox1_TextChanged;
            textBox1.TextChanged += textBox1_TextChanged;
        }

        // Yeni oyun
        private void button2_Click(object sender, EventArgs e)
        {
            num = r.Next(0, 101);
            cehd = 0;

            textBox1.Clear();
            listBox1.Items.Clear();
            xeta.SetError(textBox1, "");

            textBox1.Enabled = true;
            button1.Enabled = true;

            listBox1.Items.Add("Oyun başladı!");
            listBox1.Items.Add("0–100 arasında ədəd daxil edin.");
            listBox1.Items.Add("Cəhd sayı: " + cehd);

            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                xeta.SetError(textBox1, "Ədəd daxil edin!");
                textBox1.Focus();
                return;
            }

            int eded;

            if (!int.TryParse(textBox1.Text, out eded))
            {
                xeta.SetError(textBox1, "Tam ədəd daxil edin!");
                textBox1.Focus();
                return;
            }

            if (eded < 0 || eded > 100)
            {
                xeta.SetError(textBox1, "0–100 arasında ədəd daxil edin!");
                textBox1.Focus();
                return;
            }

            xeta.SetError(textBox1, "");

            cehd++;
            listBox1.Items.Clear();

            if (eded < num)
            {
                listBox1.Items.Add("Daxil edilən ədəd yanlışdır.");
                listBox1.Items.Add("Təsadüfi ədəddən kiçikdir.");
            }
            else if (eded > num)
            {
                listBox1.Items.Add("Daxil edilən ədəd yanlışdır.");
                listBox1.Items.Add("Təsadüfi ədəddən böyükdür.");
            }
            else
            {
                listBox1.Items.Add("Oyunu qazandınız!");
                button1.Enabled = false;
                textBox1.Enabled = false;
            }

            listBox1.Items.Add("Cəhd sayı: " + cehd);

            if (textBox1.Enabled)
            {
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            xeta.SetError(textBox1, "");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(
            object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(
                "http://aka.ms/dotnet-get-started-desktop");
        }
    }
}