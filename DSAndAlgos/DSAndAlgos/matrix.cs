using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
   public class matrix
    {

        /*
         * [
  ['A','B','C','E'],
  ['S','F','C','S'],
  ['A','D','E','E']
        ]
        word = "ABCCED", -> returns true,
word = "SEE", -> returns true,
word = "ABCB", -> returns false.

            solve this with DFS. 
            traverse in depth and chcke the isvisted/ while traveersing back 
            flip the isvisisted  
            since the visited elemnt in a path which is true cn be calculate again
            it is replaced with #
         */
        public bool wordsearch(char[,] board,string word)
        {
            int m = board.GetLength(0);
            int n = board.GetLength(1);
            for(int i=0;i<m;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (DFSForWordSearch(board, word, i, j, 0))
                        return true;
                }
            }
            return false;
        }
        public bool DFSForWordSearch(char[,] board,string word, int x,int y,int k)
        {
            if (k >= word.Length  ) return true;
            int m = board.GetLength(0);
            int n = board.GetLength(1);
            if (x < 0 || y < 0 || x >= m || y >= n) return false;
            if(board[x,y]== word[k])
            {
                char temp = board[x, y];
                board[x, y] = '#';

                bool res =
                     DFSForWordSearch(board, word, x + 1, y, k + 1) ||
                     DFSForWordSearch(board, word, x, y + 1, k + 1) ||
                     DFSForWordSearch(board, word, x - 1, y, k + 1) ||
                     DFSForWordSearch(board, word, x, y - 1, k + 1);
                board[x, y] = temp;
                return res;
            }
            return false;
        }

    }
}
