using System;
using System.IO;
using System.Windows.Forms;

namespace Полёт_на_другую_планету
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string result = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Transport Ship = new Transport();
            Ship.Name = textBox5.Text;
            Ship.Size = textBox1.Text;
            Ship.Weight = textBox2.Text;
            Ship.MaxSpeed = textBox3.Text;
            Ship.Acceleration = textBox4.Text;

            AdminForm form = new AdminForm();

            result += string.Format("/Имя:{0}", Ship.Name);
            result += string.Format(", Вместительность: {0}", Ship.Size);
            result += string.Format(", Вес: {0}", Ship.Weight);
            result += string.Format(", Макс. скорость: {0}", Ship.MaxSpeed);
            result += string.Format(", Ускорение: {0}", Ship.Acceleration);
            result += string.Format(", Пассажир: |");

            File.AppendAllText("../Data/transport.dat", result);

            string temp2 = File.ReadAllText("../Data/transport.dat");
            char[] tempChar = temp2.ToCharArray();
            tempChar[1]++;
            result = new string(tempChar);
            File.WriteAllText("../Data/transport.dat", result);

            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
