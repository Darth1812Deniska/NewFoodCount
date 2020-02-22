
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
    public enum Gender
    {
        Male,
        Female
    }

    public enum UserPurpose
    {
        LosingWeight,
        WeightRetention,
        WeightGain
    }

    [Serializable]
    public class User
    {
        private int height = 0;
        private double weight = 0;
        private UserPurpose userPurpose = UserPurpose.LosingWeight;
        private int trainingNumber = 0;
        private double proteinRatePerWeight = 1;

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get => GetAge(); }
        public int Height { get => height; set => height = value; }
        public double Weight { get => weight; set => weight = value; }
        public UserPurpose UserPurpose { get => userPurpose; set => userPurpose = value; }
        public int TrainingNumber { get => trainingNumber; set => trainingNumber = value; }
        public double BaseCalorific { get => GetBaseCalorific(); }
        public double ActivityCalorific { get => GetActivityCalorific(); }
        public double ProteinRatePerWeight { get => proteinRatePerWeight; set => proteinRatePerWeight = value; }
        public double ProteinRate { get => GetProteinRate(); }
        public double CarbohydratesRate { get => GetCarbohydratesRate(); }
        public double FatRate { get => GetFatRate(); }
        public double MinCalorificLimit { get => GetMinCalorificLimit(); }
        public double MaxCalorificLimit { get => GetMaxCalorificLimit(); }
        public double UserDayCalorific { get => GetUserDayCalorific(); }

        private int GetAge()
        {
            int result = 0;
            if (this.BirthDate != null)
            {
                int YearsPassed = DateTime.Now.Year - BirthDate.Year;
                if (DateTime.Now.Month < BirthDate.Month ||
                    (DateTime.Now.Month == BirthDate.Month
                    && DateTime.Now.Day < BirthDate.Day))
                {
                    YearsPassed--;
                }
                result = YearsPassed;
            }
            return result;
        }

        private double GetBaseCalorific()
        {
            double result = 0;

            if (Height > 0 && Weight > 0 && Age > 0)
            {
                switch (this.Gender)
                {
                    case Gender.Male:
                        result = 66.47 + 13.75 * Weight + 5 * Height - 6.74 * Age;
                        break;
                    case Gender.Female:
                        result = 655.1 + (9.6 * Weight) + (1.85 * Height) - (4.68 * Age);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        private double GetActivityCalorific()
        {
            double result = 0;
            Dictionary<int, double> activityСoefficient = new Dictionary<int, double>()
            {
                { 0, 1 },
                { 1, 1.2 },
                { 2, 1.285 },
                { 3, 1.37 },
                { 4, 1.41 },
                { 5, 1.45 },
                { 6, 1.55 },
                { 7, 1.65 }
            };
            result = activityСoefficient[TrainingNumber] * BaseCalorific;
            return result;
        }

        private double GetProteinRate()
        {
            double result = 0;
            if (Weight>0 && ProteinRatePerWeight > 0)
            {
                result = Weight * ProteinRatePerWeight;
            }
            return result;
        }
        
        private double GetCarbohydratesRate()
        {
            double result;
            result = (ProteinRate / 2) * 3;
            return result;
        }

        private double GetFatRate()
        {
            double result;
            result = ProteinRate / 2;
            return result;
        }

        private double GetMinCalorificLimit()
        {
            double result = 0;
            switch (UserPurpose)
            {
                case UserPurpose.LosingWeight:
                    result = ActivityCalorific * 0.75;
                    break;
                case UserPurpose.WeightRetention:
                    result = ActivityCalorific * 0.95;
                    break;
                case UserPurpose.WeightGain:
                    result = ActivityCalorific * 1.2;
                    break;
            }
            return result;
        }

        private double GetMaxCalorificLimit()
        {
            double result = 0;
            switch (UserPurpose)
            {
                case UserPurpose.LosingWeight:
                    result = ActivityCalorific * 0.8;
                    break;
                case UserPurpose.WeightRetention:
                    result = ActivityCalorific * 1.05;
                    break;
                case UserPurpose.WeightGain:
                    result = ActivityCalorific * 1.25;
                    break;
            }
            return result;
        }

        private double GetUserDayCalorific()
        {
            return (3.8 * ProteinRate) + (4.1 * CarbohydratesRate) + (9.3 * FatRate);
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Name == user.Name &&
                   Gender == user.Gender &&
                   BirthDate == user.BirthDate;
        }

        public override int GetHashCode()
        {
            var hashCode = 1577353200;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + BirthDate.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Name;
        }

        public User()
        {

        }

        public User (
            string name, Gender gender, DateTime birthDate, int height,
            double weight, UserPurpose userPurpose, int trainingNumber
            )
        {
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Height = height;
            Weight = weight;
            UserPurpose = userPurpose;
            TrainingNumber = trainingNumber;
        }
    }

    public static class AllUsers
    {
        private static List<User> users;

        public static List<User> Users => users;

        public static void LoadUsers() 
        {
            if (File.Exists("users.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream("users.xml", FileMode.OpenOrCreate))
                using (XmlReader reader = XmlReader.Create(fs))
                {
                    List<User> list = (List<User>)serializer.Deserialize(reader);
                    users = list;
                }
            }
            else
            {
                users = new List<User>();
            }
        }

        public static void SaveUsers() 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream("users.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, users);
            }
        }
    }
}
