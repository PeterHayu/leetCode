using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Graph
{
    class Critical_Connection_in_a_Network___Hard
    {
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            var result = new List<IList<int>>();

            var graph = BuildGraph(n, connections);
            //original value of nodes
            var ids = new int[n];
            //lowest possible connection current node can connect to
            var lowlink = new int[n];
            //node being visited or not
            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                    dfs(graph, ids, lowlink, visited, result, i, -1, 0);
            }
            return result;
        }

        private void dfs(List<IList<int>> graph, int[] ids, int[] lowlink, bool[] visited, List<IList<int>> result, int u, int parent, int time)
        {
            ids[u] = time;
            lowlink[u] = time;
            visited[u] = true;
            foreach (var v in graph[u])
            {
                if (v == parent)//if vertex is parent, skip
                    continue;
                if (!visited[v])
                {
                    dfs(graph, ids, lowlink, visited, result, v, u, time + 1);
                    lowlink[u] = Math.Min(lowlink[u], lowlink[v]);
                    //this if is the algorithm to identify critical connection
                    if (ids[u] < lowlink[v])
                    { //critical connections or bridges
                        List<int> bridge = new List<int>();
                        bridge.Add(u);
                        bridge.Add(v);
                        result.Add(bridge);
                    }
                }
                else
                { // v is already traversed. u & v forms a cycle.
                    lowlink[u] = Math.Min(lowlink[u], ids[v]);
                }
            }
        }

        private List<IList<int>> BuildGraph(int n, IList<IList<int>> connections)
        {
            var graph = new List<IList<int>>();

            for (int i = 0; i < n; i++)
            {//add vertices
                graph.Add(new List<int>());
            }

            foreach (var edge in connections)
            { //add edges
                int from = edge[0];
                int to = edge[1];
                graph[from].Add(to);
                graph[to].Add(from);
            }
            return graph;
        }
    }
}
