using System;
using System.Windows.Forms;
using System.IO;

namespace Полёт_на_другую_планету
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        byte CurrentPassanger = 0;// счетчик текущего пассажира
        public static string result = "";
        string temp;
        public static bool IsResult = false;
        string temp1 = "";
        int j;
        int vzroslie;
        public int orders;

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = String.Format("Добавление пользователя {0}/{1}", CurrentPassanger +1, Form1.PassangersNumber);
            
        }
        Passanger[] passanger = new Passanger[Form1.PassangersNumber]; // создание массива объектов класса Passanger
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentPassanger < Form1.PassangersNumber) // ввод данных каждого пассажира
            {
                passanger[CurrentPassanger] = new Passanger(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToString(comboBox1.SelectedItem));
                CurrentPassanger++;
                if(CurrentPassanger < Form1.PassangersNumber)
                {
                    label1.Text = String.Format("Добавление пользователя {0}/{1}", CurrentPassanger +1, Form1.PassangersNumber);
                }
               
                if (CurrentPassanger == Form1.PassangersNumber) // клик на последнем пользователе
                {
                    button1.Text = "Завершить";
                    for (int i = 0; i < Form1.PassangersNumber; i++) //последовательно вносим в строку result введенные значения
                    {
                        temp = String.Format("{0} пассажир. /Имя:{1}, Возраст:{2}, Пол: {3}, Транспорт:  | \n", i +1, passanger[i].Name, passanger[i].Age, passanger[i].Pol);
                        result += temp;
                    }
                    while (j < Form1.PassangersNumber)
                    {
                        if (passanger[j].Age>18)
                        {
                            vzroslie++;
                        }
                        j++;
                    }
                    Transport spaceship = new Transport();
                    temp1 = String.Format("Взрослых: {0}, детей: {1}\nТранспорт: {2} косм. корабль {3}\n @ ",vzroslie,Form1.PassangersNumber - vzroslie, spaceship.GetTransportType(Form1.PassangersNumber), spaceship.GetTransportSpeedType());
                    result += temp1;
                    IsResult = true; // для появления первого окна формы и вызов Form1.HideInput
                    Form1 form1 = new Form1();
                    form1.Show();
                    Hide();

                    
                    File.AppendAllText("../Data/data.dat", result);

                    string temp2 = File.ReadAllText("../Data/data.dat");
                    char[] tempChar = temp2.ToCharArray();
                    tempChar[1]++;
                    result = new string(tempChar);
                    File.WriteAllText("../Data/data.dat", result);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
