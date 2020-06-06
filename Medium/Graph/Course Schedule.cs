using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    class Course_Schedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int prereq = prerequisites[i][1];
                int course = prerequisites[i][0];
                graph[prereq].Add(course);
            }
            //graph:  prereq      0           1     2
            //        course [[1,2,3,4...],[3,5,6],[5]]
            return TopographicalSort(numCourses, graph);
        }

        private bool TopographicalSort(int numCourses, List<int>[] graph)
        {
            //count each course has how many pre requiste (edge)
            //put courses without prerequsite (element, aka. basic courses) in to q
            //for those courses that have elements (in q) as prerequisite
            //remove their edges (pre-requisite)
            //once a course removes all pre-requisite, make it become element and add in q
            //keep doing it until q is empty
            //check numbers of course without prerequisite VS number of courses
            //if true, we can finish all course
            //if false (<), we can only finish numbers of course without prerequisite
            //so we cannot finish all course
            int numCoursesWithZeroIndegree = 0;

            // Find the indegrees of all nodes
            int[] indegrees = new int[numCourses];
            for (int prereq = 0; prereq < graph.Length; prereq++)
            {
                foreach (var course in graph[prereq])
                {
                    indegrees[course]++;
                }
            }

            // Add all nodes that have indegree zero to the BFS queue
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < indegrees.Length; i++)
            {
                if (indegrees[i] == 0)
                {
                    queue.Enqueue(i);
                    numCoursesWithZeroIndegree++;
                }
            }

            // Bfs starting with indegree 0
            while (queue.Count != 0)
            {
                int course = queue.Dequeue();
                foreach (var subsequentCourse in graph[course])
                {
                    indegrees[subsequentCourse]--;
                    if (indegrees[subsequentCourse] == 0)
                    {
                        numCoursesWithZeroIndegree++;
                        queue.Enqueue(subsequentCourse);
                    }
                }
            }

            return numCoursesWithZeroIndegree == numCourses;
        }

        public bool CanFinish2(int numCourses, int[][] prerequisites)
        {
            // Create an adjacency list
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int prereq = prerequisites[i][1];
                int course = prerequisites[i][0];
                graph[prereq].Add(course);
            }
            //graph:  prereq      0           1     2
            //        course [[1,2,3,4...],[3,5,6],[5]]
            return !IsCycle(numCourses, graph);
        }

        // Visit courses from 0 - N, check if there are cycles starting at i
        // check prereq exists in course
        private bool IsCycle(int numCourses, List<int>[] graph)
        {
            bool[] visited = new bool[numCourses];
            /*
            visited:   prereq(i) 0    1      2
                                false  false   false
            */
            for (int i = 0; i < graph.Length; i++)
            {
                if (IsCycle(visited, graph, i))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsCycle(bool[] visited, List<int>[] graph, int i)
        {
            //course visited
            if (visited[i])
                return true;
            visited[i] = true;
            //check prerequested in course list, if found return false
            // Visit the neighbors, if there is a cycle, one of the neighbors
            // will be a course we've visited before
            foreach (var course in graph[i])
            {
                if (IsCycle(visited, graph, course))
                    return true;
            }

            visited[i] = false;
            return false;

        }
    }
}
