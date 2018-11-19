using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Полёт_на_другую_планету
{
    public partial class Pas_Transport : Form
    {
        public Pas_Transport()
        {
            InitializeComponent();
        }
        Admin admin = new Admin();
        public string name;
        public int age;
        public string pol;
        public string AlignTransport;
        Passanger passanger;
        Transport transport;

        public string trName;
        public string trSize;
        public string trWeight;
        public string trMaxSpeed;
        public string trAcc;

        private void Pas_Transport_Load(object sender, EventArgs e)
        {
       
            string workString = (admin.GetInfo(AdminForm.number, AdminForm.charr, AdminForm.charr2, AdminForm.wrap) + "\n");

            Regex regTrns = new Regex(@"Транспорт:(.*?),");
            MatchCollection matches0 = regTrns.Matches(workString);
            foreach (Match match in matches0)
            {
                AlignTransport = match.Groups[1].Value;
            }
            if(AlignTransport==null)
            {
                Regex regName = new Regex(@"Имя:(.*?),");
                MatchCollection matches = regName.Matches(workString);
                foreach (Match match in matches)
                {
                    name = match.Groups[1].Value;
                }

                Regex regAge = new Regex(@"Возраст:(.*?),");
                MatchCollection matches2 = regAge.Matches(workString);
                foreach (Match match in matches2)
                {
                    age = Convert.ToInt32(match.Groups[1].Value);
                }

                Regex regPol = new Regex(@"Пол:(.*?),");
                MatchCollection matches3 = regPol.Matches(workString);
                foreach (Match match in matches3)
                {
                    pol = match.Groups[1].Value;
                }

                passanger = new Passanger(name, age, pol);

                comboBox1.Visible = true;
                button1.Visible = true;
                MatchCollection trMatches = regName.Matches(AdminForm.trWrap);
                foreach (Match match2 in trMatches)
                {
                    comboBox1.Items.Add(match2.Groups[1].Value);
                }
                
            } else
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passanger.SetAlignTransport(transport);//Ассоциации =>
            transport.SetAlignPassanger(passanger);// <=
        } // todo: Сделать добавление в текст файлы AlignTrans и AlignPas

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(comboBox1.SelectedIndex) + 1;
            string trWork = (admin.GetInfo(number, AdminForm.tchar, AdminForm.charr2, AdminForm.trWrap) + "\n");


            Regex regName = new Regex(@"Имя:(.*?),");
            MatchCollection matches = regName.Matches(trWork);
            foreach (Match match in matches)
            {
                trName = match.Groups[1].Value;
            }

            Regex regSize = new Regex(@"Вместительность:(.*?),");
            MatchCollection matches2 = regSize.Matches(trWork);
            foreach (Match match in matches2)
            {
                trSize = match.Groups[1].Value;
            }

            Regex regWeight = new Regex(@"Вес:(.*?),");
            MatchCollection matches3 = regWeight.Matches(trWork);
            foreach (Match match in matches3)
            {
                trWeight = match.Groups[1].Value;
            }

            Regex regMaxSpeed = new Regex(@"Макс. скорость:(.*?),");
            MatchCollection matches4 = regMaxSpeed.Matches(trWork);
            foreach (Match match in matches4)
            {
                trMaxSpeed = match.Groups[1].Value;
            }

            Regex regAcc = new Regex(@"Ускорение:(.*?),");
            MatchCollection matches5 = regAcc.Matches(trWork);
            foreach (Match match in matches5)
            {
                trAcc = match.Groups[1].Value;
            }

            transport = new Transport(trName,trSize, trWeight, trMaxSpeed, trAcc);
        }
    }
}
