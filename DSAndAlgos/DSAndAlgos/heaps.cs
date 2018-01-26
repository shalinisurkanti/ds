using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
   public class heaps
    {

       public int[] heapary;
       int capacity, size;
       public heaps(int cap)
       {
           capacity = cap;
           heapary = new int[cap];
           size = 0;
       }

       public void buildminheap(int[] ar, int index)
       {
           if (index < 0) return;
           int p = 0;
           p = (index % 2 == 0) ? (index / 2) - 1 : index / 2;
           if (p < 0) return;
           if (ar[p] > ar[index])
               swap(ar, p, index);
           buildminheap(ar, p);
       }

       public void insertintoheap(int k)
       {
           
           if(size==capacity)
           {
               Console.Write("heap array is full");
               return;
           }
           size = size + 1;
           heapary[size - 1] = k;
           buildminheap(heapary, size - 1);
       }

       public int getmin()
       {
           if (size == 0) return -1;
           return heapary[0];
       }

       public void minheapfromroot(int index)
       {
           
           int lft = left(index);
           int rght = right(index);
           int smallest=index;
           if (lft < size && heapary[lft] < heapary[index])
               smallest = lft;
           if (rght < size && heapary[rght] < heapary[smallest])
               smallest = rght;
           if(smallest!=index)
           {
               swap(heapary, index, smallest);
               minheapfromroot(smallest);
           }

       }
       public int left(int x)
       {
           return 2 * x + 1;
       }
       public int right(int x)
       {
           return 2 * x + 2;
       }
       public void extramin()
       {
           int temp = heapary[size - 1];
           heapary[size - 1] = heapary[0];
           heapary[0] = temp;
           size = size - 1;
           minheapfromroot(0);
                 
       }
       public void printheap()
       {
           for (int i = 0; i < size; i++)
               Console.Write(heapary[i] + ",");
       }
       public void swap(int[] ar, int i,int j)
       {
           int temp = ar[i];
           ar[i] = ar[j];
           ar[j] = temp;
       }

       /*
        * 
        */
       public void heapsort(int[] ar)
       {

       }
    }
}
