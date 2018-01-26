using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
   public class Sorting
    {

    /* Binary search iteration method */
       public int binarysearch(int[] ar,int k)
       {
           int n = ar.Length;
           if (n == 0) return -1;
           int low = 0, high = n - 1;
           while(low<=high)
           {
               int mid = (low + high) / 2;
               if (ar[mid] == k)
                   return mid;
               else if (ar[mid] > k)
                   high = mid - 1;
               else
                   low = mid + 1;
           }
           return -1;
          
       }

       /* binary search recursive method*/
       public int binarysearchRec(int[] ar,int k)
       {
           return binarysearchRechelp(ar, k, 0, ar.Length - 1);
       }
       public int binarysearchRechelp(int[] ar ,int k,int low,int high)
       {
           if (low > high) return -1;
           int mid = (low + high) / 2;
           if (ar[mid] == k) return mid;
           if (ar[mid] > k)
               return binarysearchRechelp(ar, k, low, mid -1);
           else
               return binarysearchRechelp(ar, k, mid + 1, high);
       }
       /*sorted array insert element
        * thsis too complicated :P
        */

       public int[] insertintoSortedArray(int[] ar,int k)
       {
           int n = ar.Length;
          if (n == -1) return new int[]{} ;
           int low = 0, high = n - 1;
           while(low<=high)
           {
               int mid = (low + high) / 2;
               if (ar[mid] == k)
                  ar= insertintoSortedArrayhelp(ar, k, mid,n);
               if(ar[mid]>k)
               {
                   if (low > (mid - 1))
                   {
                     ar=  insertintoSortedArrayhelp(ar, k, 0, n);
                       break;
                   }
                   else if (ar[mid - 1] < k)
                   {
                      ar= insertintoSortedArrayhelp(ar, k, mid, n);
                       break;
                   }
                   else
                       high = mid - 1;
               }
               else
               {
                   if (high < (mid + 1))
                   {
                     ar=  insertintoSortedArrayhelp(ar, k, n , n);
                       break;
                   }
                   else if (ar[mid + 1] > k)
                   {
                      ar= insertintoSortedArrayhelp(ar, k, mid + 1, n);
                       break;
                   }
                   else
                       low = mid + 1;
               }

           }
           for (int i = 0; i < ar.Length; i++)
               Console.Write(ar[i] + ", ");
           return ar;
       }
        public int[] insertintoSortedArrayhelp(int[] ar,int k,int index,int n)
        {
            Array.Resize<int>(ref ar, ar.Length + 1);
            int temp = -1;
            for(int i=index;i<ar.Length;i++)
            {
                temp = ar[i];
                ar[i] = k;
                k = temp;
            }
            return ar;
        }

        /*sorted array  insert element
          * thsis too simple
          */
       public void insertintoSortedArraysimple(int []ar,int k)
        {
            int n = ar.Length;
            Array.Resize<int>(ref ar, n + 1);
            int i = n - 1;
            for (; (i >= 0 && ar[i] > k); i--)
           {

               ar[i + 1] = ar[i];
           }
           ar[i + 1] = k;
        }
        /*sorted array delete operation*/
       public int[] deletefromsortedarray(int[] ar,int k)
       {
           int n=ar.Length;
          int ind= binarysearchRec(ar, k);
          if (ind == -1) return ar;
          if (ind == n - 1)
          {
              Array.Resize<int>(ref ar, ar.Length - 1);
          }
           for(int i=ind;i<ar.Length;i++)
           {
               ar[i] = ar[i + 1];
           }
         return  ar=ar.Where((val, index) => index != n - 1).ToArray();
         //  return n - 1;
       }

       public void mergesort(int[] ar)
       {
           int n = ar.Length;
           if (n == 0) return;

       }
       public void mergesortrec(int[] ar,int low,int high)
       {
           if (low >= high) return;
           int mid=(low+high)/2;
           mergesortrec(ar, low, mid);
           mergesortrec(ar, mid + 1, high);
           mergetwoarrays(ar, low, mid, high);
       }
       public void mergetwoarrays(int[] ar,int low,int mid,int high)
       {
           int i = low, j = high, m = mid + 1, k = 0, n = high - low + 1;
           int[] temp= new int[n];
           while(i<=mid && m<=high)
           {
               if (ar[i] < ar[m])
               {
                   temp[k] = ar[i];
                   i++;
               }
               else
               {
                   temp[k] = ar[m];
                   m++;
               }
               k++;

           }
           while(i<=mid)
           {

               temp[k++] = ar[i];
               i++;
           }
           while(m<=high)
           {
               
                   temp[k++] = ar[m];
                   m++;
               
           }

           for(int l=0;l<n;l++)
           {
               ar[l + low] = temp[l];
           }
       }

    }
}
