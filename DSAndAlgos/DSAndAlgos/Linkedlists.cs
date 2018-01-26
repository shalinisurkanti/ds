using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
    public class Linkedlists
    {
        public linknode head, tail;
        public void insert(int x)
        {
            linknode temp = new linknode(x);
            if (head == null)
            {
                head = temp;
            }
            else
            {
                tail.next = temp;
            }
            tail = temp;
        }
        /* L: L0→L1→…→Ln-1→Ln to  L0→Ln→L1→Ln-1→L2→Ln-2→..*/
        /// <summary>
        /// 1. empty 
        /// 2.only one element 
        /// 3.
        /// </summary>
        /// <param name="node"></param>
        public linknode reorderlist(linknode head)
        {
            if (head == null || head.next == null) return head;
            linknode start = null, res = null;
            start = head;
            res = start;


            while (start != null)
            {
                linknode tail = start, prevtail = null;
                while (tail.next != null)
                {
                    prevtail = tail;
                    tail = tail.next;
                }
                if (start == tail || start.next == tail)
                    break;
                linknode tx = start.next;
                start.next = tail;
                tail.next = tx;
                prevtail.next = null;
                start = tx;
            }
            return res;


        }

        /*
         * follow same as merge sort. 
         * 1. divide the head into tow halves  
         */
        public linknode sortlinkedlist(linknode head)
        {
            if (head == null || head.next==null) return head;
            linknode middle = getmiddle(head);
            linknode nextmiddle = middle.next;
            middle.next = null;
            linknode left = sortlinkedlist(head);
            linknode right = sortlinkedlist(nextmiddle);
            linknode res = mergesortlinkedlist(left, right);
            return res;
        }
        public linknode getmiddle(linknode head)
        {
            if (head == null || head.next==null)
                 return head;
            linknode slow = head, fast = head.next;
            while(fast!=null && fast.next!=null)
            {
               
                    fast = fast.next.next;
                    slow = slow.next;
                
            }
            return slow;
          
        }
        public linknode mergesortlinkedlist(linknode leftstart,linknode righstart)
        {
            linknode res = null;
            if (leftstart == null)
                return righstart;
            if (righstart == null)
                return leftstart;
           if(leftstart.item<= righstart.item)
            {
                res = leftstart;
                res.next = mergesortlinkedlist(leftstart.next, righstart);
            }
           else
            {
                res = righstart;
                righstart.next = mergesortlinkedlist(leftstart, righstart.next);
            }
            return res;

        }
      
    }

    public class linknode
    {
       public int item;

       public linknode next;
        public linknode(int x)
        {
            item = x;
            next = null;
        }
    }
}
