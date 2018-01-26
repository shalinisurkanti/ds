using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
   public class ArraysCollection
    {
        /*
         *reverse array is similar to rotating of array. smae concept can be used to rotate array to certain 
         * points. 
         * roate d points
         * rotate n-d points 
         * rotate whole array
         */
        public void RotateArrayUsingReversingArray(int[] ar,int d)
        {
            int len = ar.Length-1;
            reverseArray(ar, 0, d-1);
            reverseArray(ar,len - d, len);
            reverseArray(ar, 0, len);
        }
        public void reverseArray(int[] ar,int a ,int b)
        {
            if (a > b)
                return;
            int temp = ar[a];
            ar[a] = ar[b];
            ar[b] = temp;
            reverseArray(ar, a+1, b-1);
        }

        /* GCD of two numbers
         * a=3 , b=12 */
       
        public int GCD(int a ,int b)
        {
            if (a == 0)
                return b ;
            return GCD(b %a, a);
        }

        /*
         * Given a sorted array of positive integers, rearrange the array alternately i.e first element should be maximum value, 
         * second minimum value, third second max, fourth second min and so on.
         * i think reverse of the array would help . let d=1 , that is right most element . then rotate the remaining elements . then rotate the entire array.
         * in first iteration first two elemnts will be set. repeat this until all elements are set
         */
       public void RearrangeAltPosNeg(int[] ar)
        {
            int n = ar.Length - 1;
           
           int i=0;// to keep track of how many have been sorted
           while(i<n)
           {
               //reversearray of last eemtn we are not doing as it is single element
               reverseArray(ar, i, n - 1);
               reverseArray(ar, i, n);
               i = i + 2;
           }
        }
       /*
        * Given an array of n elements. Consider array as circular array i.e element after an is a1. The task is to find maximum sum of the difference between consecutive elements 
        * with rearrangement of array element allowed i.e after rearrangement of element find |a1 – a2| + |a2 – a3| + …… + |an – 1 – an| + |an – a1|.
        * 
        * arang the elements in sorted order. find the diferent of irst and last elements and sum all of them .
        */

       public int SumofConsecutiveDiff(int[] ar)
       {
           int n = ar.Length;
           Array.Sort(ar);
           int i = 0, j = n - 1, sum = 0;
           bool flag = true;
           while(i!=j)
           {
               sum = sum + Math.Abs(ar[i] - ar[j]);
               if (flag) i++;
               else j--;
               flag = !flag;
           }
           sum = sum + Math.Abs(ar[0] - ar[i]);
           return sum;
       }
       /*
        * the above problem in more simple way. dealing with algebra. 
        * a1,a2,a3,a4,a5,a6 are the elements . (a6-a1)+(a6-a2)+(a5-a2)+(a5-a3)+(a4-a3)+(a4-a1). this is simplied form of  2*(a6+a5+a4)-2*(a1+a2+a3).
        */
        public int SumofConsecutiveDiffImp(int[] ar)
       {
           Array.Sort(ar);
           int n = ar.Length, sum = 0;
            for(int i=0;i<n/2;i++)
            {
                sum -= (2 * ar[i]);
                sum += (2 * ar[n - i - 1]);
            }
            return sum;
       }
        /*You are given an array of 0s and 1s in random order. Segregate 0s on left side and 1s on right side of the array. Traverse array only once.
         */
       public void Arrange0s1s(int[] ar)
        {
            int i = 0, j = ar.Length - 1;
           while(i<j)
           {
               if (ar[i] == 0 && ar[j] == 1)
               {
                   i++; j--;
               }
               else if (ar[i] == 1 && ar[j] == 0)
               {
                   ar[i] = 0;
                   ar[j] = 1;
               }
               else if (ar[i] == 1 && ar[j] == 1)
                   j--;
               else if (ar[i] == 0 && ar[j] == 0) i++;
           }
        }
       /*
        * better solution for above problem. you know that if elemt is 0 at left it is corect and elemnt is 1 at right is it correct.so you need to correct only the elemnets which are not in
        * corect order .
        */
       public void Arrange0s1simp(int[] ar)
       {
           int i = 0, j = ar.Length - 1;
           while(i<j)
           {
               while (ar[i] == 0)
                   i++;
               while (ar[j] == 1)
                   j--;
               if(i<j)
               {
                   ar[i] = 0;
                   ar[j] = 1;
                   i++; j--;
               }
           }
       }
       /*segregate postive and negative numbers. if the order doesnot mattter, then the solution is smae as above. if the order matters, then traverse the array, fin the element which is dislcoated. find the right
        * element after that. then rotate the array from dislaocated to right element. continue this for all the elements 
        */
       public void segregateposandnegnumbers(int[] ar)
       {
           int n = ar.Length;
           for(int i=0;i<n;i++)
           {
               while (ar[i] % 2 == 0)
                   i++;
               int temp = i;
               int j = i;
               while(j<n)
               {
                   if (ar[j] % 2 == 0)
                       break;
                   j++;
               }
               if(j<n)
               {
                   //roate array 
                   int x = ar[j];
                   for(int p=temp;p<=j;p++)
                   {
                       int tp = ar[p];
                       ar[p] = x;
                       x = tp;
                   }
               }
              
           }
       }
        /*
         * Given an array A[0 … n-1] containing n positive integers, a subarray A[i … j] is bitonic if there is a k with i <= k <= j such that A[i] <= A[i + 1] ... <= A[k] >= A[k + 1] >= .. A[j – 1] > = A[j].
         * Write a function that takes an array as argument and returns the length of the maximum length bitonic subarray.
         * -- here we need to find for each element, how many elemeber before it are smaller thatn it and how many elements are bigger than after it. so we will maintain two arays 
         * one arryas which calculate for each elemts, how many are smaller thatn it before . '
         * second array calculates for each eelemt, how many are bigger thatn it after. 
         * so when we make sum of each eelmtnt, we will get how many elements are there in such bitonic order
         */
       public int bitonicsubarray(int[] ar)
       {
           int n = ar.Length;
           int[] inc = new int[n];
           int[] dec = new int[n];
           inc[0] = 1;
           dec[n - 1] = 1;
           for(int i=1;i<n;i++)
           {
               inc[i] = (ar[i] > ar[i - 1]) ? inc[i - 1] + 1 : 1;
           }
           for(int i=n-2;i>=0;i--)
           {
               dec[i] = (ar[i] > ar[i + 1]) ? dec[i + 1] + 1 : 1;
           }
           int maxsum = 0; // no of max elements in bitonic order
           for(int i=0;i<n;i++)
           {
               if (maxsum < (inc[i] + dec[i] - 1))
                   maxsum = inc[i] + dec[i] - 1;
           }
           return maxsum;
       }

        /*
         * Given an array arr[0 … n-1] containing n positive integers, a subsequence of arr[] is called Bitonic if it is first increasing, then decreasing. 
         * Write a function that takes an array as argument and returns the length of the longest bitonic subsequence.
         * so here , we know if the sub aray , maintain the inc and dec arrays. 
         * similariy, in the inc order, also consider not jsut the neightbour elemetns, but before elements as well. 
         */
       public int bitonicDp(int[] ar)
       {
           int n = ar.Length;
           int[] inc = new int[n];
           int[] dec = new int[n];
           inc[0] = 1;
           dec[n - 1] = 1;
           for(int i=1;i<n;i++)
           {
               for(int j=0;j<i;j++)
               {
                   if (ar[i] > ar[j] && inc[i] < inc[j] + 1)
                       inc[i] = inc[j] + 1;
               }
           }

           for(int i=n-2;i>=0;i--)
           {
               for(int j=n-1;j>i;j--)
               {
                   if (ar[i] > ar[j] && dec[i] < dec[j] + 1)
                       dec[i] = dec[j] + 1;
               }
           }
           int maxsum = 0; // no of max elements in bitonic order
           for (int i = 0; i < n; i++)
           {
               if (maxsum < (inc[i] + dec[i] - 1))
                   maxsum = inc[i] + dec[i] - 1;
           }
           return maxsum;

       }

       public void randomizeArray(int[] ar)
       {
           int n=ar.Length;
           Random rd = new Random();
           for(int i=n-1;i>0;i--)
           {
               int ran = rd.Next(0, i + 1);
               helper.swap(ar, i, ran);
           }
       }
       /*
        * Given an array of integers, update every element with multiplication of previous and next elements with following exceptions. 
        a) First element is replaced by multiplication of first and second.
        b) Last element is replaced by multiplication of last and second last.
        */
       public void replaceiwthmutiplication(int[] ar)
       {
           int n = ar.Length;
           if (n < 1) return;
           int prev = ar[0];
           ar[0] = prev * ar[1];
           for(int i=1;i<n-1;i++)
           {
               int cur = ar[i];
               ar[i] = prev * ar[i + 1];
               prev = cur;
           }
           ar[n - 1] = prev * ar[n - 1];
       }
       /*Given two integer arrays of same size, “arr[]” and “index[]”, reorder elements in “arr[]” according to given index array. It is not allowed to given array arr’s length.
        * loop through index; 
        * take back up of both index and value
        */
       public void reorderarryacctoindexes(int[] ar,int[] index)
       {
           int n = ar.Length;
           for(int i=0;i<n;i++)
           {
               int oldindex = index[index[i]];
               int oldvalue = ar[index[i]];

               //update the values 
               ar[index[i]] = ar[i];
               index[index[i]] = index[i];

               //cpy old valuees 
               ar[i] = oldvalue;
               index[i] = oldindex;
           }
         
       }

        /*
         * given an array A[] of n numbers and another number x, determines whether or not there exist two elements in S whose sum is exactly x.
         * so  for eache lement , subtract the sum and chelc if the remaining sum elemnt exist. store it in hasmap
         */
       public void hasarrayRwoCandicates(int[] ar,int sum)
       {
           int n = ar.Length;
           if (n == 0) return;
           HashSet<int> hash = new HashSet<int>();
           for(int i=0;i<n;i++)
           {
               int temp = sum - ar[i];
               if (hash.Contains(temp))
               {
                   Console.WriteLine("two elements of sum " + ar[i] + "," + temp);
                   break;
               }
               else
                   hash.Add(ar[i]);
           }
       }

        /*
         * A majority element in an array A[] of size n is an element that appears more than n/2 times (and hence there is at most one such element).
         * so to find such element , for each set , see if that element can meet majoirty criteria. if its no meetin reduce the count. at the end you get one element. then traverse throguh
         * the aray again and see if that can be the potential majority element or not
         */
       public bool majorityelement(int[] ar)
       {
           int n = ar.Length;
         int ele=  findcandidate(ar, n);
           //check if its majoirty element;
         return ismajority(ar, n, ele); 
       }
       public int findcandidate(int[] ar,int n)
       {
           int maxindex = 0, count = 0;
           for(int i=0;i<n;i++)
           {
               if (ar[maxindex] == ar[i])
                   count++;
               else
                   count--;
               if(count==0)
               {
                   maxindex = i;
                   count = 1;
               }
           }
           return ar[maxindex];
       }
       public bool ismajority(int[] ar,int n,int ele)
       {
            
           int count=0;
           for (int i = 0; i < n; i++)
           {
               if (ar[i] == ele)
                   count++;
           }
           return (count>n/2)?true:false;
       }

        /* 
         * Given an array of positive integers. All numbers occur even number of times except one number which occurs odd number of times. 
         * the best sltuon would be xor operator when eve/odd kind of problems are there 
         */
       public int Segregateoddcount(int[] ar)
       {
           int res = 0, n = ar.Length;
           for(int i=0;i<n;i++)
           {
               res = res ^ ar[i];
           }
           return res;
       }
        /*
         * You are given a list of n-1 integers and these integers are in the range of 1 to n. There are no duplicates in list. One of the integers is missing in the list. 
         * n=(n+1)2 =sum ; minus from the given element sum . the resul would be the mising number 
         * xor all the givn eekemnts . xor (n+1) elements. xor both the results. 
         */
       public int Findmissingelement(int[] ar)
       {
           int n = ar.Length,x1=0,x2=ar[0];
          //cor of all n+1;
           for (int i = 1; i <= n + 1; i++)
               x1 ^= i;
           for (int i = 1; i < n; i++)
               x2 ^= ar[i];
           return x1 ^ x2;
       }
        /*
         * Given an array of integers, find the first repeating element in it. We need to find the element that occurs more than once and whose index of first occurrence is smallest.
         *use has, since you need to find first repreting number, if you travers from frist to last, you also need to amintain indiex of number repated. but if you travel from right to left
         *the last number repated would be the first repeated number
         */
       public int firstreapatednumber(int[] ar)
       {
           int index = 0,n=ar.Length;
           HashSet<int> hash = new HashSet<int>();
           for(int i=n-1;i>=0;i--)
           {
               if (hash.Contains(ar[i]))
                   index = i;
               else
                   hash.Add(ar[i]);
           }
           return index;
       }
       /*Suppose you have a sorted array of infinite numbers, how would you search an element in the array?
        *if you don the array leenght. start with low=0 hight=1 .see if the key is greater than high value. if yes  then make low=hight and high as doule the hgh . then you cna aply binary seach.
        * */
       public void findpositionininfintenumebers(int[] ar,int key)
       {
           int low = 0, high = 1;
           int val = ar[high];
           if(val<key)
           {
               low = high;
               high = 2 * high;
               val = ar[high];
           }
           Sorting s = new Sorting();
           s.binarysearchRechelp(ar, key, low, high);
       }

        /*
         * Given nums1 = [1,7,11], nums2 = [2,4,6],  k = 3

            Return: [1,2],[1,4],[1,6]

            The first 3 pairs are returned from the sequence:
            [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
            always the first two digits sum will be the smalles pair. 
            then keep i as it is and move j, take the next two smallest numbers.
         */
        public void KsmallestPairs(int[] a,int[] b)
        {

        }

    }
}
