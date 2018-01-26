using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            #region arraysCollection
            ArraysCollection arc = new ArraysCollection();
            // rotate array 
            int[] rotatearray = { 0, 1, 2, 3, 4 };
            for (int i = 0; i < rotatearray.Length; i++)
                Console.WriteLine("before rotation array" + rotatearray[i]);
            arc.RotateArrayUsingReversingArray(rotatearray, 2);
            for (int i = 0; i < rotatearray.Length; i++)
                Console.WriteLine("roated array" + rotatearray[i]);


            //GCD 
            Console.WriteLine(arc.GCD(8, 12));

            //Rearrange alternative pos and neg elements
            int[] sortedarray = { 1, 2, 3, 4, 5, 6, 7 };
            arc.RearrangeAltPosNeg(sortedarray);

            //sum of consecutive dfferences in an array
            int[] consdiff = { 4, 2, 1, 8 };// 5, 3, 2, 9, 1
            Console.Write("consecutive difference sum " + arc.SumofConsecutiveDiff(consdiff));
            Console.Write("consecutive difference sum in improved solution " + arc.SumofConsecutiveDiffImp(consdiff));

            //segregate 0s and 1s in an array
            int[] segregateary = { 0, 1, 0, 1, 0, 0, 1, 1, 1, 0 };

            arc.Arrange0s1s(segregateary);
            Console.WriteLine("segregat 0s and 1s ");
            for (int i = 0; i < segregateary.Length; i++)
                Console.Write(segregateary[i] + ",");

            arc.Arrange0s1simp(segregateary);
            Console.WriteLine("segregat 0s and 1s ");
            for (int i = 0; i < segregateary.Length; i++)
                Console.Write(segregateary[i] + ",");

            int[] segregateposandneg = { 12, 34, 45, 9, 8, 90, 3 };
            arc.segregateposandnegnumbers(segregateposandneg);


            //bitoni subarray length 
            int[] bitonicarry = { 10, 20, 30, 40 };//12, 4, 78, 90, 45, 23
            Console.WriteLine("bitionic sub array length" + arc.bitonicsubarray(bitonicarry));
            //bitnoic subseqyence dp
            int[] bitonicsub = { 1, 11, 2, 10, 4, 5, 2, 1 };
            Console.WriteLine("bitonic subsqence array length" + arc.bitonicDp(bitonicsub));

            //reorder the index and array value 
            int[] arr = { 50, 40, 70, 60, 90 };
            int[] index = { 3, 0, 4, 1, 2 };
            arc.reorderarryacctoindexes(arr, index);

            //two elements sum 
            int[] twoelementssum = { 1, 4, 45, 6, 10, 8 };
            arc.hasarrayRwoCandicates(twoelementssum, 16);

            //majority element
            int[] majorelem = { 3, 3, 4, 2, 4, 4, 2, 4, 4 };
            arc.majorityelement(majorelem);

            Console.ReadKey();
            #endregion

            #region Sorting 
            Sorting sort = new Sorting();
            int[] sortedary = { 4, 6, 8, 10, 12 };
            Console.WriteLine("Index of the element " + sort.binarysearch(sortedary, 4));
            Console.WriteLine("Index of the element " + sort.binarysearchRec(sortedary, 4));
            sort.insertintoSortedArray(sortedary, 14);
            sort.insertintoSortedArraysimple(sortedary, 7);
            sort.deletefromsortedarray(sortedary, 12);
            #endregion 

            #region BST
            BinarySearchTrees bst = new BinarySearchTrees();
            //bst.root = new Node(12);

            bst.insertintobst(20);
            bst.insertintobst(8);
            bst.insertintobst(4);
            bst.insertintobst(12);
            bst.insertintobst(10);
            bst.insertintobst(14);
            bst.insertintobst(22);

            bst.insertintobstiterative(12);
            bst.insertintobstiterative(9);
            bst.insertintobstiterative(14);
            bst.insertintobstiterative(16);
            //test
            bst.root = new Node(12);
            bst.insertintobstiterative(9);

            bst.inorderiteration(bst.root);
            bst.preorderiteration(bst.root);
            bst.postorderiteration(bst.root);
            bst.postorderiterationonestack(bst.root);
            int[] inorderlist = { 4, 2, 5, 1, 3 };
            int[] preorederlist = { 1, 2, 4, 5, 3 };
            bst.binarytreefrominorderpreorder(preorederlist, inorderlist);
            int[] sortedaryforbst = { 1, 2, 3, 4, 5, 6, 7 };
            bst.sortedArraytoBST(sortedaryforbst);


            //declare bst as in array
            bst.root = new Node(10);
            bst.root.left = new Node(5);
            bst.root.right = new Node(15);
            bst.root.right.left = new Node(6);
            bst.root.right.right = new Node(20);

            bst.root = new Node(2);
            bst.root.left = new Node(1);
            bst.root.right = new Node(3);
            bst.isValidBST(bst.root);

            #endregion


            #region heaps 
            heaps hep = new heaps(4);
            hep.insertintoheap(2);
            hep.insertintoheap(5);
            hep.insertintoheap(3);
            hep.insertintoheap(4);
            hep.printheap();
            hep.extramin();
            hep.printheap();

            #endregion

            #region Graphs
            Graphs graph = new Graphs();
            graph.CreateGraph(4);

            //graph.AddEdge(0, 1);
            //graph.AddEdge(0, 4);
            //graph.AddEdge(1, 2);
            //graph.AddEdge(1, 3);
            //graph.AddEdge(1, 4);
            //graph.AddEdge(2, 3);
            //graph.AddEdge(3, 4);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);


            graph.PrintGraph();

            graph.BFS(2);
            graph.DFS(2);
            #endregion

            #region strings
            Strings ss = new Strings();
            ss.productoftwodigitstopalindrome(5);
            ss.convertstringtoint("2147483648");
            ss.reversewordsinstring("   a   b ");
            ss.DivideWithoutammop(-1, 1);
            #endregion

            #region linkedlists
            Linkedlists ls = new Linkedlists();
            ls.insert(30);
            ls.insert(10);
            ls.insert(2);
            ls.insert(3);
            ls.insert(4);
            ls.reorderlist(ls.head);
           ls.head= ls.sortlinkedlist(ls.head);
            #endregion

            #region matrix
            matrix mt = new matrix();
            char[,] board = new char[,] { { 'A', 'B', 'C', 'E' }, { 'S', 'F', 'C', 'S' }, { 'A', 'D', 'E', 'E' } };
            mt.wordsearch(board, "ABCCED");
            #endregion

        }
     
    }
}
