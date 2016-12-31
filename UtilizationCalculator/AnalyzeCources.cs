using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilizationCalculator
{
    class courceInfo
    {
        
        public string courcename = "";
        public string courcetype = "";
        public string classname = "";
        public string timestr = "";
        public int weeks = 0;
    }
    class AnalyzeCource
    {
        public courceInfo info = new courceInfo();
        public bool isValid(string str)
        {
            if (str.IndexOf('◇') == -1) return false;
            return true;
        }

        public string[] analyzeTimeList(string str)
        {
            int index = 0;
            string[] retstr = new string[1];

            //System.Collections.ArrayList list = new System.Collections.ArrayList();

            index = str.IndexOf("节/周");
            if (index != -1)
            {
                int leftBracketsIndex = str.IndexOf('(');
                int rightBracketsIndex = str.IndexOf(')');
                retstr[0] = str.Substring(leftBracketsIndex + 1, rightBracketsIndex - leftBracketsIndex - 1);
            }
            else
            {
                index = str.IndexOf('(');
                retstr = str.Substring(0, index).Split(',');
            }

            return retstr;
        }
        public int Week(string str)
        {
            int weeks = 0;
            int index = 0;
            string substr = str;

            index = str.IndexOf("单") + str.IndexOf("双");
            if (index > -1)
            {
                substr = str.Substring(0, index+1);
            }

            string[] weekstr = substr.Split('-');
            if(weekstr.Length == 1)
            {
                weeks = 1;
            }
            else
            {
                int startTime = int.Parse(weekstr[0]);
                int endTime = int.Parse(weekstr[1]);
                weeks = endTime - startTime;    
                 
                if (index > -1)
                {
                    weeks = weeks / 2;
                }

                weeks += 1;
            }

            return weeks;
        }

        public int cakcWeeks(string timestr)
        {
            int weeks = 0;
            string[] strlist = analyzeTimeList(timestr);

            foreach (string str in strlist)
            {
                weeks += Week(str);
            }

            return weeks;
        }

        public string ClassNames(string str)
        {
            if (isValid(str) == false) return null;
            string[] names = str.Split(new Char[] { '◇' });
            return names[2];
        }

        public string CourceName(string str)
        {
            if (isValid(str) == false) return null;
            string[] courcessplit = str.Split(new Char[] { '◇' });
            return courcessplit[0];
        }

        public string courceType(string str)
        {
            string retstr = "实验";

            if (isValid(str) == false) return null;

            string[] courcessplit = str.Split(new Char[] { '◇' });
            int index = courcessplit[0].IndexOf("实践") + courcessplit[0].IndexOf("实训");
            if (index > -1)
            {
                retstr = "实践";
            }

            return retstr;
        }
        public string Timestr(string str)
        {
            if (isValid(str) == false) return null;
            string[] time = str.Split(new Char[] { '◇' });
            return time[1];
        }

        public courceInfo analyze(string cource)
        {
            info.courcename = CourceName(cource);
            info.courcetype = courceType(cource);
            info.classname = ClassNames(cource);
            info.timestr = Timestr(cource);
            info.weeks = cakcWeeks(info.timestr);

            return info;
        }

    }
}
