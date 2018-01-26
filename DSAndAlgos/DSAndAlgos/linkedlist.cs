using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
   public class linkedlist
    {
       public node root;
       public linkedlist()
       {
           root = null;
       }
       public int getcount(node root)
       {
           if (root == null)
               return 0;
          return 1 + getcount(root.next);
       }
       public void insert(int x,node root)
       {
           if (root == null)
               root = new node(x);
           else
               insert(x, root.next);
       }
    }
    public class node
    {
        public int item;
        public node next;
        public node(int x)
        {
            item = x;
            next = null;
        }
    }
}
