using System;
using System.Windows.Forms;

namespace Полёт_на_другую_планету
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static byte PassangersNumber;
        public string Planet; // название выбранной  планеты

        public void HideInput() // Метод скрывает элементы, ненужные для отображения результата
        {
            richTextBox1.Visible = true;
            richTextBox1.Text = Form2.result;
            label2.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Planets userPlanet = new Planets();
            if (userPlanet.GetAccess(Convert.ToString(comboBox1.SelectedItem))) { // если возможен полет
                PassangersNumber = Convert.ToByte(textBox2.Text);
                Planet = Convert.ToString(comboBox1.SelectedItem);
                Form2 form2 = new Form2(); // переход на вторую форму
                form2.Show();
                Hide();
            } else
            {
                Form2.result = String.Format("Полёт на планету {0} временно невозможен!", Planet);
                HideInput();
            }  
        }

        private void Form1_Activated(object sender, EventArgs e) 
        {
            if(Form2.IsResult == true) // повторное появление формы
            {
                HideInput();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm(); // переход на вторую форму
            form.Show();
        }
    }
}
