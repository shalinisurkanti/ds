using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAndAlgos
{
    public class Graphs
    {
        Graphnode[] listofvertices;
        int V;

        public void CreateGraph(int vertices)
        {
            V = vertices;
            listofvertices = new Graphnode[vertices];
            for (int i = 0; i < vertices; i++)
            {
                listofvertices[i] = new Graphnode(i);
            }
        }
        public void AddEdge(int x, int y)
        {
            Graphnode source = listofvertices[x];
            while (source.next != null)
                source = source.next;
            source.next = new Graphnode(y);

            //if undirectd add from dest to source 
            //Graphnode dest = listofvertices[y];
            //while (dest.next != null)
            //    dest = dest.next;
            //dest.next = new Graphnode(x);
        }
        public void PrintGraph()
        {
            for (int i = 0; i < V; i++)

            {
                Console.WriteLine("source{0}", i);
                Graphnode source = listofvertices[i];
                Console.WriteLine("edges:");
                while (source.next != null)
                {
                    Console.WriteLine(source.next.item);
                    source = source.next;
                }
            }
        }

        public void BFS(int startvertex)
        {
            Queue<int> vertexqueue = new Queue<int>();
            //your grpah is already ready in create graph and add edges 
            List<int> processedvertices = new List<int>();
            //if the vertices are just 0,1,2,3 just take bool array;
            //proces each vertex and place them in a queue . 
            vertexqueue.Enqueue(listofvertices[startvertex].item);
            while (vertexqueue.Count != 0)
            {
                int vertex = vertexqueue.Dequeue();
                Console.WriteLine("edges{0}", vertex);
                processedvertices.Add(vertex);
                //get childs of vertex

                Graphnode temp = listofvertices[vertex];
                while (temp.next != null)
                {
                    if (!processedvertices.Contains(temp.next.item))
                        vertexqueue.Enqueue(temp.next.item);
                    temp = temp.next;
                }

            }

        }
        public void DFS(int startvertex)
        {
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
                visited[i] = false;
            DFSUtil(startvertex, visited);
        }
        public void DFSUtil(int startvertex, bool[] visited)
        {
            visited[startvertex] = true;
            Console.WriteLine("DFS" + startvertex);
            Graphnode curnode = listofvertices[startvertex];
            while(curnode.next!=null)
            {
                int x = curnode.next.item;
                if (!visited[x])
                    DFSUtil(x, visited);
                curnode = curnode.next;
            }
        }
       
    }

    public class Graphnode
    {
        public int item;
        public Graphnode next;
        public Graphnode(int x)
        {
            item = x;
            next = null;
        }
       
    }
}
