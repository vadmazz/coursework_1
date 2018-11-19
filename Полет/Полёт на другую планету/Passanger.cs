namespace Полёт_на_другую_планету
{
    class Passanger
    {
        private Transport alignTransport;
        public int Age { get; set; }
        public string Name { get; set; }
        public string Pol { get; set; }

        public Passanger(string name, int age, string pol) // метод, вносящий иноормацию об отдельном пассажире
        {
            Age = age;
            Name = name;
            Pol = pol;
        }
        public void SetAlignTransport(Transport t)
        {
            alignTransport = t;
        }
    }
}
