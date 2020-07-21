using System;
using System.Collections.Generic;
using System.Text;

namespace Medium.Greedy
{
    class Greedy
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            //major logic: if A can't reach B, anypoint between A and B would not be an answer
            //we dont need to start from each every index and calculate the circle
            //we think of the whole picture
            //if total of gas end up positive then we return true
            //tank to be the current gas amout
            var tank = 0;
            var total = 0;
            //station is the position index of the gas station, final result
            var station = 0;

            for (int i = 0; i < gas.Length; i++)
            {

                tank += gas[i] - cost[i];
                //if for the that station we have negative value, it cannot be starting station
                //clear the current tank and record the next station
                if (tank < 0)
                {
                    tank = 0;
                    station = i + 1;
                }
                //record the total to indentify if we can achieve
                total += gas[i] - cost[i];
            }

            return total >= 0 ? station : -1;

        }
    }
}
