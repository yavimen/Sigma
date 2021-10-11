using System;
using System.IO;
using System.Linq;

namespace SiteVisitingStatistic.Classes
{
    class SiteVisiting
    {
        private UserIP[] _users;
        public UserIP[] Users
        {
            get
            {
                return (UserIP[])_users.Clone();
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                _users = (UserIP[])value.Clone();
            }
        }

        public SiteVisiting()
        {
            _users = new UserIP[0];
        }

        public void AddNewIP(UserIP user) 
        {
            UserIP[] temp = new UserIP[_users.Length + 1];
            for (int i = 0; i < _users.Length; i++)
            {
                temp[i] = new UserIP(_users[i]);
            }
            temp[_users.Length] = new UserIP(user);
            _users = temp;
        }

        public UserIP this[int index]
        {
            get 
            {
                if (index >= _users.Length)
                    throw new IndexOutOfRangeException();
                return _users[index];
            }
        }

        public void ReadInfoFromFile(string path) 
        {
            StreamReader file = new StreamReader(@path);
            string tempStr;
            bool existing;
            UserIP tempUser;
            string[] protector;
            while (true) 
            {
                if (file.EndOfStream) 
                    break;

                tempStr = file.ReadLine();
                protector = tempStr.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (protector.Length != 3) 
                    break;

                existing = false;
                tempUser = UserIP.Parse(tempStr);

                for (int i = 0; i < _users.Length; ++i) 
                {
                    if (_users[i].IP.Equals(tempUser.IP))
                    {
                        existing = true;
                        _users[i].AddVisitTime(tempUser.VisitingHistory[0].Item1, tempUser.VisitingHistory[0].Item2);
                        break;
                    }
                }

                if (!existing) 
                {
                    AddNewIP(tempUser);
                }
            }
        }

        public string MostPopularTimeForVisiting() 
        {
            int[] timeArr = new int[24];
            (DateTime, DayOfWeek)[] tempArr;
            for (int i = 0; i < _users.Length; i++)
            {
                tempArr = _users[i].VisitingHistory;

                for (int j = 0; j < _users[i].VisitingHistory.Length; j++)
                {
                    timeArr[tempArr[j].Item1.Hour]++;
                }
            }
            int b = Enumerable.Max(timeArr);
            int time = Array.FindIndex(timeArr, v => v == b);
            return time + ":00-" + (time + 1) + ":00";
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < _users.Length; i++)
            {
                str += _users[i].ToString();
            }

            return str;
        }
    }
}
