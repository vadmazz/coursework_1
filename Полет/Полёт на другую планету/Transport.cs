
using System.IO;
namespace Полёт_на_другую_планету
{
    class Transport
    {
        string speedtype;
        string transportType;
        static int countTransport;
        private Passanger alignPassanger;//ассоциация
        public string GetTransportType(int numbers) // получение типа транспорта
        {
            if (numbers < 5) transportType = "малый";
            if (numbers >= 5 && numbers < 10) transportType = "средний";
            if (numbers > 10) transportType = "большой";
            return transportType;
        }
        public string GetTransportSpeedType()// получение типа скорости транспорта
        {
            switch (transportType)
            {
                case "малый":
                    speedtype = "быстрый";
                    break;
                case "средний":
                    speedtype = "средний";
                    break;
                case "большой":
                    speedtype = "медленный";
                    break;
            }
            return speedtype;
        }
        public static int GetCountTransport()
        {
            string temp = File.ReadAllText("../Data/transport.dat");
            char[] tempChar = temp.ToCharArray();
            countTransport = tempChar[1];
            return countTransport;
        }
        public string Name { get; set; }
        public string Size { get; set; }
        public Passanger AlignPassanger
        {
            get { return alignPassanger; }
            set { alignPassanger = value; }
        }
        public string Weight { get; set; }
        public string MaxSpeed { get; set; }
        public string Acceleration { get; set; }
        public Transport(string name, string size, string weight, string maxs, string acc)
        {
            Name = name;
            Size = size;
            Weight = weight;
            MaxSpeed = maxs;
            Acceleration = acc;
        }
        public Transport()
        {

        }
        public void SetAlignPassanger(Passanger p)
        {
            alignPassanger = p;
        }
    }
}
