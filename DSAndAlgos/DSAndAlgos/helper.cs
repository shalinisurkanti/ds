using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
   public static class helper
    {
       public static void swap(int[] ar,int i ,int j)
       {
           int temp = ar[i];
           ar[i] = ar[j];
           ar[j] = temp;
       }
    }
}
