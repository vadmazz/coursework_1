using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Полёт_на_другую_планету
{
    class Order
    {
        private static int ordersCount;
        private static int transportCount;

        public int GetOrdersCount()
        {
            string temp = File.ReadAllText("../Data/data.dat");
            char[] tempChar = temp.ToCharArray();
            ordersCount = tempChar[1];
            return ordersCount;
        }
        public int GetTransportCount()
        {
            string temp = File.ReadAllText("../Data/transport.dat");
            char[] tempChar = temp.ToCharArray();
            transportCount = tempChar[1];
            return transportCount;
        }
    }
}
