
namespace Полёт_на_другую_планету
{
    class Planets
    {
        private bool access;
        public bool GetAccess(string f)
        { // описание возможности полета на планеты
            switch (f)
            {
                case "Сатурн":
                case "Уран":
                case "Нептун":
                    access = false;
                    break;
                case "Меркурий":
                case "Венера":
                case "Марс":
                case "Юпитер":
                    access = true;
                    break;
            }
            return access;
        }
    }
}
