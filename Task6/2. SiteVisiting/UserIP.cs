using System;
using System.Collections.Generic;
using System.Text;

namespace SiteVisitingStatistic.Classes
{
    class UserIP
    {
        private string _ip;
        public string IP 
        {
            get 
            {
                return _ip;
            }
            set 
            {
                string[] temp = value.Split(".", StringSplitOptions.RemoveEmptyEntries);
                int n1 = -1, n2 = -1, n3 = -1, n4 = -1;
                
                if (temp.Length != 4 || !int.TryParse(temp[0], out n1) || !int.TryParse(temp[1], out n2) ||
                    !int.TryParse(temp[2], out n3) || !int.TryParse(temp[3], out n4))  
                    throw new ArgumentException("Wrong ip address!");

                _ip = value;
            }
        }

        private int _visited;
        private int Visited
        {
            get { return _visited; }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Variable (visited) less than zero!");

                _visited = value;
            }
        }

        private (DateTime, DayOfWeek)[] _visitingHistory;
        public (DateTime, DayOfWeek)[] VisitingHistory 
        {
            get 
            {
                return ((DateTime, DayOfWeek)[])_visitingHistory.Clone();
            }
            set 
            {
                if (value == null)
                    throw new ArgumentNullException();

                _visitingHistory = ((DateTime, DayOfWeek)[])value.Clone();//new (DateTime, DayOfWeek)[value.Length];

                //for (int i = 0; i < _visitingHistory.Length; i++)
                //{
                //    _visitingHistory[i].Item1 = value[i].Item1;
                //    _visitingHistory[i].Item2 = value[i].Item2;
                //}

                Visited = _visitingHistory.Length;
            }
        }

        public UserIP(UserIP user)
        {
            IP = user.IP;
            VisitingHistory = user.VisitingHistory;
        }

        public UserIP(string ip = "0.0.0.0", (DateTime, DayOfWeek)[] ps = null)
        {
            IP = ip;
            if (ps == null)
                _visitingHistory = new (DateTime, DayOfWeek)[0];
            else
                VisitingHistory = ps;
            Visited = _visitingHistory.Length;
        }

        public void AddVisitTime(DateTime daytime, DayOfWeek dayOfWeek) 
        {
            (DateTime, DayOfWeek)[] tempArr = new (DateTime, DayOfWeek)[_visitingHistory.Length+1];
            for (int i = 0; i < _visitingHistory.Length; i++)
            {
                tempArr[i].Item1 = _visitingHistory[i].Item1;
                tempArr[i].Item2 = _visitingHistory[i].Item2;
            }
            tempArr[_visitingHistory.Length] = (daytime, dayOfWeek);
            _visitingHistory = tempArr;
            _visited++;
        }

        public void AddVisitTime(string daytime, string dayOfWeek) 
        {
            DateTime time;
            object day;
            if (!Enum.TryParse(typeof(DayOfWeek), dayOfWeek, true, out day) || !DateTime.TryParse(daytime, out time))
                throw new ArgumentException("Wrong variable format");
            AddVisitTime(time, (DayOfWeek)day);
        }

        public DayOfWeek MostPopularDayForVisiting() 
        {
            if (_visitingHistory.Length > 0)
            {
                DayOfWeek day = _visitingHistory[0].Item2;
                int counter = 0;
                int maxcount = 1;
                for (int i = 0; i < 7; i++)
                {
                    counter = 0;
                    for (int j = 0; j < _visitingHistory.Length; j++)
                    {
                        if ((DayOfWeek)Enum.GetValues(typeof(DayOfWeek)).GetValue(i) == _visitingHistory[j].Item2)
                            counter++;
                    }
                    if (counter > maxcount)
                    {
                        maxcount = counter;
                        day = (DayOfWeek)Enum.GetValues(typeof(DayOfWeek)).GetValue(i);
                    }
                }
                return day;
            }
            throw new Exception("Visiting number is zero");
        }

        public string MostPopularTimeForVisiting() 
        {
            if (_visitingHistory.Length > 0)
            {
                int time = _visitingHistory[0].Item1.Hour;
                int counter;
                int maxcont = 1;

                for (int i = 1; i < _visitingHistory.Length - 1; i++)
                {
                    counter = 0;
                    for (int j = i; j < _visitingHistory.Length; j++)
                    {
                        if (_visitingHistory[i].Item1.Hour == _visitingHistory[j].Item1.Hour)
                        {
                            counter++;
                        }
                    }
                    if (counter > maxcont)
                    {
                        maxcont = counter;
                        time = _visitingHistory[i].Item1.Hour;
                    }
                }
                return time + ":00 - " + (time + 1) + ":00";
            }
            throw new Exception("Visiting number is zero");
        }

        public static UserIP Parse(string s) 
        {
            DateTime time;
            object day;
            string[] str = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (str.Length != 3 || !Enum.TryParse(typeof(DayOfWeek), str[2], true, out day)|| !DateTime.TryParse(str[1], out time))
                throw new ArgumentException("Wrong UserIP.Split variable format");

            UserIP user = new UserIP(str[0]);
            user.AddVisitTime(time, (DayOfWeek)day);
            return user;
        }

        public override string ToString() 
        {
            string tempstr;
            tempstr = String.Format("{0,-25}{1, -15}", "IP: "+_ip, $"visited site {_visited} times\n");
            for (int i = 0; i < _visitingHistory.Length; i++)
            {
                tempstr += Enum.GetName(typeof(DayOfWeek), _visitingHistory[i].Item2) + ", "+ _visitingHistory[i].Item1.TimeOfDay.ToString() +"\n";
            }
            return tempstr;
        }
    }
}
