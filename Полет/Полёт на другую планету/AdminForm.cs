using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Полёт_на_другую_планету
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        public string splitter = "@";
        public string splitter2 = "|";
        public static string wrap = File.ReadAllText("../Data/data.dat");
        public static string trWrap = File.ReadAllText("../Data/transport.dat");
        public static char[] charr = wrap.ToCharArray();
        public static int number;
        public static char[] tchar = trWrap.ToCharArray();
        public static List<char> charr2 = new List<char>() ;
        public int j = 0;
        public static string newwrap;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           number = Convert.ToInt32(comboBox1.SelectedIndex)+1;
           Admin admin = new Admin();
           richTextBox1.AppendText(admin.GetInfo(number,charr,charr2,wrap) + "\n");
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Order orders = new Order();
            label3.Text = string.Format("Всего транспорта доступно: {0}", Convert.ToString(Convert.ToChar(orders.GetTransportCount())));
            label1.Text = String.Format("Всего зарегистрировано полётов: {0}", Convert.ToString(Convert.ToChar(orders.GetOrdersCount())));
            Regex reg = new Regex(@"Имя:(.*?),");
            MatchCollection matches = reg.Matches(wrap);
            foreach (Match match in matches)
            {
                comboBox1.Items.Add(match.Groups[1].Value);
            }

            MatchCollection trMatches = reg.Matches(trWrap);
            foreach (Match match2 in trMatches)
            {
                comboBox2.Items.Add(match2.Groups[1].Value);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(comboBox2.SelectedIndex) + 1;
            Admin admin = new Admin();
            richTextBox2.AppendText(admin.GetInfo(number, tchar, charr2, trWrap) + "\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pas_Transport formn = new Pas_Transport();
            formn.Show();
        }
    }
}

