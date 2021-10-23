using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace NewFoodCount
{
    [Serializable]
    public class UserDayMenu
    {
        private User _user;
        private DateTime _date;
        private DishCollection _dishes;

        public User User { get => _user; set => _user = value; }
        public DishCollection Dishes { get => _dishes; set => _dishes = value; }
        DateTime Date { get => _date; set => _date = value; }
        public UserDayMenu()
        {

        }

        public UserDayMenu(User user, DishCollection dishes, DateTime date)
        {
            _user = user;
            _dishes = dishes;
            _date = date;
        }
    }

    public class UserDayMenuCollection : List<UserDayMenu>
    {

    }

    public static class AllUserDayMenu
    {
        private static  UserDayMenuCollection userDayMenus;

        public static UserDayMenuCollection UserDayMenus => userDayMenus;

        public static void SaveMenus()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserDayMenuCollection));
            using (FileStream fs = new FileStream("menus.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, userDayMenus);
            }
        }

        public static void LoadMenus()
        {
            if (File.Exists("menus.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserDayMenuCollection));
                using (FileStream fs = new FileStream("menus.xml", FileMode.OpenOrCreate))
                using (XmlReader reader = XmlReader.Create(fs))
                {
                    UserDayMenuCollection list = (UserDayMenuCollection)serializer.Deserialize(reader);
                    userDayMenus = list;
                }
            }
            else
            {
                userDayMenus = new UserDayMenuCollection();
            }
        }
    }
}
