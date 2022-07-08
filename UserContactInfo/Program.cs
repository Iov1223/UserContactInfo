using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserContactInfo
{
    class ipADDR
    {
        public byte[] ip;
        public ipADDR()
        {
            var ip = new byte[4] {0, 0, 0, 0};
        }
        public string Print()
        {
            string result = this.ip[0] + "." + this.ip[1] + "." + this.ip[2] + "." + this.ip[3];
            return result;
        }
    }
    class elPost
    {
        public string _username;
        public char _delimiter = '@';
        public string _domainname;

        public elPost()
        {
            _username = "user";
            _domainname = "mail.ru";
        }
        public bool isCorrect(string _address)
        {
            bool result;
            //string _address = _username + _delimiter + _domainname;
            Regex _regex = new Regex(@"(\w+@\w+\.\w+)");
            MatchCollection _matchCollection = _regex.Matches(_address);
            if (_matchCollection.Count > 0)
            {
                result = true;
            }
            else
            {
                result=false;
            }
            
            return true;
        }
        public bool setPost(string ElAddress)
        {
            bool result = true;
            int index = 0;
            this._username = "";
            this._domainname = "";
            if (isCorrect(ElAddress))
            {
                for (int i = 0; i < ElAddress.Length; i++)
                {
                    if (ElAddress[i] == '@')
                    {
                        index = i;
                    }
                }
                this._username = ElAddress.Substring(0, index);
                this._domainname = ElAddress.Substring(index + 1);

            }
            else
            {
                result = false;
            }

            return result;
        }
        public string getPost()
        {
            string result = this._username + this._delimiter + this._domainname;
            return result;
        }
    }
    class dateTime
    {
        public int _year;
        public int _month;
        public int _day;
    }
    class ClientCard
    {
        public string _login;
        public ipADDR _ip;
        public string _elPost;
        public DateTime _date;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var myMail = new elPost();
            Console.WriteLine("Почта по уморлчанию {0}", myMail.getPost());
            Console.WriteLine("Введите почту");
            myMail.setPost(Console.ReadLine());
            Console.WriteLine("Почта введённая пользователем {0}", myMail.getPost());
        }
    }
}
