using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
    public class BinarySearchTrees
    {
        public Node root;
        public BinarySearchTrees()
        {
            root = null;
        }
        public void insertintobst(int x)
        {
            root = insertintobstrec(root, x);
        }
        public Node insertintobstrec(Node rot, int x)
        {
            if (rot == null)
            {
                rot = new Node(x);

            }
            else if (rot.item > x)
                rot.left = insertintobstrec(rot.left, x);
            else
                rot.right = insertintobstrec(rot.right, x);
            return rot;
        }
        public Node insertintobstiterative(int x)
        {
            Node parent = root, cur = root;
            // parent = null; 
            if (cur == null)
            {
                root = new Node(x);
                return root;
            }

            while (cur != null)
            {
                parent = cur;
                if (cur.item > x)
                    cur = cur.left;
                else
                    cur = cur.right;
            }
            if (parent.item > x)
                parent.left = new Node(x);
            else
                parent.right = new Node(x);

            return root;

        }
        /* searching for element in bst
         */
        public Node searcheleinbst(Node root, int x)
        {
            if (root.item == x || root == null)
                return root;
            if (root.item > x)
                searcheleinbst(root.left, x);
            else
                searcheleinbst(root.right, x);
            return root;

            //easy way 
            if (root.item == x || root == null)
                return root;
            if (root.item > x)
                return searcheleinbst(root.left, x);
            return searcheleinbst(root.right, x);
        }

        public void inorder(Node root)
        {
            if (root != null)
            {
                inorder(root.left);
                Console.Write(root.item);
                inorder(root.right);
            }
        }
        public void inorderiteration(Node root)
        {
            if (root == null) return;
            Stack<Node> stack = new Stack<Node>();

            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                if (stack.Count == 0) break;
                Node temp = stack.Pop();
                Console.Write(temp.item + ",");
                root = temp.right;
            }
        }

        public void preorder(Node root)
        {
            if(root!=null)
            {
                Console.Write(root.item);
                preorder(root.left);
                preorder(root.right);
            }
        }
        public void preorderiteration(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            while(true)
            {
                while(root!=null)
                {
                    Console.Write(root.item);
                    root = root.left;
                }
                if (stack.Count == 0) break;
                Node temp = stack.Pop();
                root = temp.right;
            }
        }
        public void postorder(Node root)
        {
            if(root!=null)
            {
                postorder(root.left);
                postorder(root.right);
                Console.Write(root.item + ",");
            }
        }

        public void postorderiteration(Node root)
        {
            if (root == null) return;
            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();
            Node cur = root;
            while (true)
            {
                while (cur != null)
                {
                    stack1.Push(cur);
                    if (cur.right != null) stack2.Push(cur.right);
                    cur = cur.left;
                }
                if (stack1.Count == 0) break;
                Node temp = stack1.Peek();
                if (temp.right != null && stack2.Count != 0 && temp.right.item == stack2.Peek().item)
                {
                    temp = stack2.Pop();
                    cur = temp;
                }
                else
                {
                    stack1.Pop();
                    Console.Write(temp.item + ",");
                }
            }
        }

        public void postorderiterationonestack(Node root)
        {
            if (root == null) return;
            Stack<Node> stack = new Stack<Node>();
            Node cur = root, prev = null;
            while(true)
            {
                while(cur!=null)
                {
                    stack.Push(cur);
                    if (cur.right != null) stack.Push(cur.right);
                    cur = cur.left;
                }
                if (stack.Count == 0) break;
                Node temp = stack.Pop();
                if ((temp.left == null && temp.right == null) || (temp.right != null && prev != null && temp.right.item == prev.item))
                {
                    Console.Write(temp.item + ",");
                    prev = temp;
                }
                else
                    cur = temp;
            }
        }

        public static int preorderindex = 0;
        public   Node binarytreefrominorderpreorder(int[] preorder,int[] inorder)
        {
            Node temp=null;
           
             temp=binarytreefrominorderpreorderrec(preorder, inorder, 0, preorder.Length - 1, temp);
            return temp;
        }

        public  Node binarytreefrominorderpreorderrec(int[] preorder,int[] inorder,int low,int high,Node root)
        {
            if (low > high) return null ;
            int first = preorder[preorderindex];
            int index = findfirstininorder(inorder, first);
            if (root == null)
                root = new Node(inorder[index]);
            preorderindex = preorderindex + 1;
                root.left = binarytreefrominorderpreorderrec(preorder, inorder, low, index - 1,root.left);
                root.right = binarytreefrominorderpreorderrec(preorder, inorder, index + 1, high, root.right);
            return root;
        }
        public  int findfirstininorder(int[] inorder,int first)
        {
            int len=inorder.Length;
            for(int i=0;i<len;i++)
            {
                if (inorder[i] == first)
                    return i;
            }
            return -1;
        }

        //public void postorderfrominorderandpreorderrec(int[] preorder,int[] inorder,int n)
        //{
        //    int index = findfirstininorder(inorder, preorder[0]);
            
        //    if (index !=0)
        //        postorderfrominorderandpreorderrec(preorder+1, inorder, index - 1);
        //    if(index!=n-1)
        //        postorderfrominorderandpreorderrec(n-preorder + 1, inorder+index, n-index - 1);
        //    Console.Write(preorder[0]);
        //}

        public void sortedArraytoBST(int[] ar)
        {
            Node temp = sortArrayBSTrec(ar, 0, ar.Length - 1);
        }
        public Node sortArrayBSTrec(int[] ar,int low,int high)
        {
            if (low > high) return null;
            int mid = (low + high) / 2;
            Node rot = new Node(ar[mid]);
            rot.left = sortArrayBSTrec(ar, low, mid - 1);
            rot.right = sortArrayBSTrec(ar, mid + 1, high);
            return rot;
        }
        public void mergetwoBSTs(Node root1,Node root2)
        {
            if (root1 == null && root2 == null) return;
            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();
            while(true)
            {
                while(root1!=null || root2!=null)
                {
                    if(root1!=null)
                    {
                        stack1.Push(root1);
                        root1 = root1.left;
                    }
                    if(root2!=null)
                    {
                        stack2.Push(root2);
                        root2 = root2.left;
                    }
                }
                if (stack1.Count == 0 && stack2.Count == 0) break;
                Node temp1=null,temp2=null;
                if (stack1.Count > 0)
                    temp1 = stack1.Pop();
                if (stack2.Count > 0)
                    temp2 = stack2.Pop();
                if(temp1!=null && temp2!=null)
                {
                    if (temp1.item < temp2.item)
                    {
                        Console.Write(temp1.item);
                        stack2.Push(temp2);
                        root1 = temp1.right;
                    }
                    else
                    {
                        Console.Write(temp2.item);
                        stack1.Push(temp1);
                        root2 = temp2.right;
                    }
                }
                else if(temp1!=null)
                {
                    Console.Write(temp1.item);
                    root1 = temp1.right;
                }
                else
                {
                    Console.Write(temp2.item);
                    root2 = temp2.right;
                }
                  
            }
        }
        public bool isLeaf(Node root)
        {
            return (root.left == null && root.right == null) ? true : false; 

        }
        ///////////////////////////leetcode//////////////////////
        /// <summary>
        /// traverse eah element. compare each elemnt with root to see if the elemtnt is in right position
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool isValidBST(Node root)
        {

            Node res = root;
           return isValisBSTstart(res,root);
       
        }
        public bool isValisBSTstart(Node root,Node cur)
        {
            if (cur == null) return true;

            return (isValisBSTstart(root,cur.left) &&
            isValisBSTstart(root,cur.right) &&
           isValidBSTHelp(root, cur));


        }
        public bool isValidBSTHelp(Node root,Node cur)
        {
            if (root == null) return false;
            if( root.item == cur.item) return true;
            if (root.item > cur.item)
                root = root.left;
            else if (root.item < cur.item)
                root = root.right;
            return isValidBSTHelp(root, cur);
           
        }

    }

    public class Node
    {
        public  int item;
       public Node left;
       public Node right;
        public Node(int tx)
        {
            item= tx;
            left = null;
            right = null;
        }

    }
}
