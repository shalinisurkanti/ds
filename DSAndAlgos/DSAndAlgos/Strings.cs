using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
   public  class Strings
    {


        /* leetcode*/
        /// <summary>
        /// largest palindrome made from the product of two n-digit numbers.
        /// Input: 2
        ///Output: 987
        ///Explanation: 99 x 91 = 9009, 9009 % 1337 = 987
        /// idea is to iterate through lowest and highest range values 
        /// </summary>

        public int productoftwodigitstopalindrome(int n)
        {
            uint temp = Convert.ToUInt32(n);
            //int low = getLowestval(n);
            uint high = getHighestval(temp);
            /* other way to calc lowest is */
            uint low = (high + 1) / 10;
            uint max = 0; 
                int maxi = 0, maxj = 0;
            for(uint i=high;i>=low;i--)
            {
                for(uint j=i;j>=low;j--)
                {
                    uint prod = i* j;
                    if (prod < max)
                        break;
                    if (palindrome(prod) && max < prod)
                    {
                        max = prod;
                    }
                }

            }
            Console.WriteLine("maxi{0}" + maxi);
            Console.WriteLine("maxj{0}" + maxj);
            Console.WriteLine(max%1337);
            return (int)(max%1337);
        }
        public bool palindrome(uint n)
        {
            /*convert to string and cal.or reverse it */
            string x = n.ToString();
            int len = x.Length;
            int i = 0, j = len - 1;
            while (i < j)
            {
                if (x[i] != x[j])
                    return false;
                i++; j--;
            }
            return true;
            // return (x == new string(x.Reverse().ToArray())); 
            /*reverse the int and cal */
            //int res = 0,temp=n;
            //while(n>0)
            //{
            //    res = res * 10+ n % 10;
            //    n = n / 10;
               
            //}
            //return res==temp;

        }
        public int getLowestval(int n)
        {
            int res = 1;
            while(n>1)
            {
                res = res * 10;
                n--;
            }
            return res;
        }
        public uint getHighestval(uint n)
        {
            uint res= 0;
            while (n > 0)
            {
                res = res * 10+9;
                n--;
            }
            return res;
        }

        /* convert string to int */
        ///cases: 1) abc => return 0;
        ///2) -123 => -123 
        ///3)+123 => 123 
        ///4)empty string =>0
        ///5) white spaces in the start and end of string 
        ///6) string after integer values are ignored 
        ///7) min and max value check
        /// 
        public int convertstringtoint(string str)
        {
            if (str == "") return 0;
            char op=' ';
            int MAX = 2147483647, MIN = -2147483648;
            int len = 0,res=0;
            str = str.Trim();
            if (str[0] == '+' || str[0] == '-')
                op = str[0];
            int i = (op == '+' || op == '-') ? 1 : 0;
            len = str.Length;
                for(;i<len;i++)
                {
                if (isnumber(str[i]))
                {
                    //check if res*10 is <=min before and cal
                    if (op == '-' && (-res <= MIN || (-res*10)<=MIN || (-res*10-8)<=MIN ||(-res*10-(str[i] - '0')<=MIN)))
                    {
                        res = -MIN;
                        break;
                    }
                    else if (res >= MAX || (res * 10) >= MAX || (res * 10 + 7) >= MAX || (res * 10+ (str[i] - '0') >= MAX))
                    {
                        res = MAX;
                        break;
                    }
                    res = res * 10 + (str[i] - '0');
                   
                    
                }
                else
                    break;
                }
            if (op == '-')
                res = -res;
            return res;

        }
        public string trim(string st)
        {
            if (st == " ") return st;
            int first = 0;
            int len = st.Length;
            for(int i=0;i<len;i++)
            {
                if(st[i]!=' ')
                {
                    first = i;
                    break;
                }
            }
            
            for (int i = len; i >=0; i--)
            {
                if (st[i] != ' ')
                {
                    first = i;
                    break;
                }
            }
            string res = "";
            for(int i=0;i<st.Length;i++)
            {
                if (st[i] != ' ')
                    res = res + st[i];
            }
            return res+'\0';
        }
        public bool isnumber(char i)
        {
            return (i >= '0' && i <= '9')? true : false;
        }

        /* reverse words in a string 'the sky is blue'
         * cases : 1. emoty check
         * 2. trm and again emty check 
         * 3.if 2 spaces are there in the middle.trim to one space 
         */
        public string reversewordsinstring(string str)
        {
            if (str == " ") return str;
            str = str.Trim();
            Stack<string> list = new Stack<string>();
            splitwordsinstring(list, str);
            str=addwordsfromlasttostring(list);
            return str;
        }
        public void splitwordsinstring(Stack<string> list,string str)
        {
            int len = str.Length,startindex=0,i=0;
            for(i=0;i<len;i++)
            {
                if(str[i]==' ')
                {
                    list.Push(str.Substring(startindex, i-startindex));
                    
                    while (str[i+1] == ' ')
                        i++;
                    startindex = i+1;
                 
                }
            }
            list.Push(str.Substring(startindex, i-startindex));
            
        }
        public string addwordsfromlasttostring(Stack<string> list)
        {
            StringBuilder sb = new StringBuilder();
            while(list.Count>1)
            {
                sb.Append(list.Pop());
                sb.Append(" ");
            }
            sb.Append(list.Pop());
            return sb.ToString();
        }

        /* Divide two integers without addition ,mutiplciation or mod operator*/
        /// <summary>
        /// use adition , return the count 
        /// case 1:if divsor =0, max 
        /// 2. if divosr =-1 and divned=min then reutrn max 
        /// 3. do 
        /// </summary>
        public int DivideWithoutammop(int dividend,int divisor)
        {
            
            
            char dividendop, divisorop;
            //operator check
            if (dividend < 0)
            {
                dividendop = '-';
                dividend = -dividend;
            }
            else
                dividendop = '+';

            if (divisor < 0)
            {
                divisorop = '-';
                divisor = -divisor;
            }
            else
                divisorop = '+';
            if (divisor > dividend) return 0;
            int count = 0;
            int temp = divisor;
            while(temp<= dividend)
            {
                count = count + 1;
                temp =  divisor<<temp;
            }

            char op=handleoperatorindivide(divisorop, dividendop);
            int res= (op == '-') ? -count : count;
            return res;
        }
        public char handleoperatorindivide(char a,char b)
        {
            if (a == '+' && b == '+') return '+';
            if (a == '-' && b == '+') return '-';
            if (a == '+' && b == '-') return '-';
            
            return '+';
        }

    }
}
