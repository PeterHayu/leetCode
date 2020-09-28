using System;
using System.Collections.Generic;
using System.Linq;

namespace Hard
{
    public class SkyLine
    {
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            //logic here is to get the begin height of the building and the end heigh of the building
            // and keep track of maxHeight point
            //if begin, add to height to the set, output the point if maxHeight changes
            //if end, pop the height in the set, output the maxHeight if maxHeight changes
            //and we have 3 edge cases:
            //1, two buildings begin at the same point : higher building height should be ouputed
            //2, two builidngs ends at the same point: lower building height should be outputed
            //3, one building ends at the begin of another: 

            var result = new List<IList<int>>();
            var height = new List<int[]>();

            //mark the height of the beginning point as negative
            //mark the height of the ending point as positive
            //so that all beginning comes first then the ending
            foreach (var b in buildings)
            {
                //first add the beginning with negative height
                height.Add(new int[] { b[0], -b[2] });
                //then add the ending with positive height
                height.Add(new int[] { b[1], b[2] });
            }


            height.Sort((a, b) => {
                //begin comes earlier than end
                if (a[0] != b[0])
                    return a[0] - b[0];
                //else, pick the one with higher height
                return a[1] - b[1];
            });

            //have the sortedDictionary output the one with maxCount (priorityQueue usually output the smallest number, so we change its order)
            //note we cannot use a linked list like prioirty queue
            //although we also want the max value to be ouputed
            //we remove elements in the queue when a specific end has reached, not when a new element is added
            var pq = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => (b - a)));
            pq.Add(0, 0);
            int maxHeight = 0;

            foreach (var h in height)
            {

                //if its the beginning of a building
                if (h[1] < 0)
                {
                    //add the begin height (positive) to the dictionary
                    if (!pq.ContainsKey(-h[1]))
                    {
                        pq[-h[1]] = 0;
                    }
                    //add the count, as there might be multiple building with the height
                    pq[-h[1]]++;
                }
                //if at the end of the building
                else
                {
                    //remove the height count when we reach one of the end of the building of the height
                    pq[h[1]]--;
                    //if all building to this height has reach its end, remove the height completely 
                    if (pq[h[1]] <= 0)
                    {
                        pq.Remove(h[1]);
                    }
                }
                //get the maxHeight
                int tempHeight = pq.First().Key;
                //if maxHeight get updated, add to the final result
                if (maxHeight != tempHeight)
                {
                    result.Add(new List<int> { h[0], tempHeight });
                    maxHeight = tempHeight;
                }
            }
            return result;
        }
    }
}
