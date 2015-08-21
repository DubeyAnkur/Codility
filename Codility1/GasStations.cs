using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class GasStations
    {
        public int solution(int[] D, int[] P, int T)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            int result = 0;

            int j = 0;

            int[] TDist = new int[D.Length+1];
            int[] res = new int[D.Length];

            for (int i = 0; i < TDist.Length-1; i++)
            {
                int temp = 0;
                if (i < TDist.Length-1)
                    temp = D[i];

                TDist[i + 1] = TDist[i] + temp;
                if (D[i] > T)
                    return -1;
            }

            int current = 0;
            while (j < D.Length)
            {

                if (j == D.Length - 1)
                {
                    if (D[j] - current > 0)
                        res[j] = D[j] - current;
                    break;
                }

                if (P[j] > P[j + 1])
                {
                    if (D[j] > current)
                    {
                        res[j] = D[j] - current;
                        current = 0;
                    }
                    else
                        current = current - D[j];
                    
                    j++;
                }
                else
                {
                    int start = j;
                    int end = j;
                    int minP = P[j+1];
                    int minI = j+1;
                    bool flag = false;
                    bool contin = false;
                    while (end < D.Length - 1 && TDist[++end] - TDist[start] < T )
                    {
                        //end++;
                        if(P[start] > P[end])
                        {
                            if (current < TDist[end] - TDist[start])
                                res[j] = TDist[end] - TDist[start] - current;
                            j = end;
                            contin = true;
                            
                            if (current > TDist[end] - TDist[start])
                                current = current - (TDist[end] - TDist[start]);
                            else
                                    current = 0;
                            break;
                        }
                        if (minP > P[end])
                        {
                            minP = P[end];
                            minI = end;
                            flag = true;
                        }
                    }
                    if (contin == false)
                    {
                        if (flag == false) // MinI was not set. Because next to next one is far away.
                        {
                            if (TDist[TDist.Length - 1] - TDist[start] < T)
                            {
                                res[start] = TDist[TDist.Length - 1] - TDist[start] - current;
                                break;
                            }
                            else
                            {
                                res[start] = T - current;
                                j++;
                                current = T - D[start];
                                //j = end;
                                //current = T - (TDist[end] - TDist[start]);
                            }
                        }
                        else //which means MinI was found.
                        {
                            if (TDist[TDist.Length - 1] - TDist[start] < T)
                            {
                                res[j] = TDist[TDist.Length - 1] - TDist[start] - current;
                                break;
                            }
                            else
                                res[j] = T - current;
                            
                            j = minI;
                            current = T - (TDist[minI] - TDist[start]);
                        }
                    }
                }
            }
            double d = 0;
            for (int i = 0; i < res.Length; i++)
            {
                d = d + res[i] * P[i];
                if (d > 1000000000)
                    return -2;
            }
            return Convert.ToInt32(result);
        }
        public int solution_NotComplete(int[] D, int[] P, int T)
        {
            int[] TDist = new int[D.Length + 1];
            int[] res = new int[D.Length + 1];

            for (int i = 1; i < TDist.Length; i++)
            {
                TDist[i] = TDist[i - 1] + D[i - 1];
                res[i] = int.MaxValue;
            }

            int j = 0;
            for (int i = 0; i < TDist.Length; i++)
            {
                while (TDist[i] - TDist[j] > T)
                    j++;
                for (int k = j; k < i; k++)
                {
                    int cost = P[k] * (TDist[i] - TDist[k]) + res[k];
                    res[i] = Math.Min(res[i], cost);
                }
            }

            return res[D.Length];
        }
        public int solution2(int[] D, int[] P, int T)
        {
            //This is where result will be stored
            int cheapestRefillStrategyCost = -1;

            //Sanity check
            if (D != null && D.Length > 0 && P != null && P.Length == D.Length && T > 0)
            {
                int N = D.Length;
                cheapestRefillStrategyCost = 0;

                //For every town we will find farthest reachable town (with full tank).
                int[] farthestReachableTowns = new int[N];
                for (int gas = T, currentTown = 0, farthestReachableTown = 0; currentTown < N; currentTown++)
                {
                    //We will go through towns till the gas runs out
                    while (farthestReachableTown < N && gas >= D[farthestReachableTown])
                        gas -= D[farthestReachableTown++];

                    //If we couldn't reach any town, no valid refill strategy exists
                    if (farthestReachableTown == currentTown)
                    {
                        cheapestRefillStrategyCost = -1;
                        break;
                    }
                        //Otherwise we mark the farthest reachable town and add enough gas to reach next town, we will look if we can reach any further with this gas from there.
                    else
                    {
                        farthestReachableTowns[currentTown] = farthestReachableTown;
                        gas += D[currentTown];
                    }
                }

                //If valid refill strategy exists
                if (cheapestRefillStrategyCost == 0)
                {
                    //For every town we will find next cheaper town
                    int[] cheaperTowns = new int[N];
                    cheaperTowns[N - 1] = N;

                    //We will go back from town one before last
                    for (int currentTown = N - 2; currentTown >= 0; currentTown--)
                    {
                        //If gas price in next town is lower than the current town
                        if (P[currentTown + 1] < P[currentTown])
                            //We mark the next town as next cheaper gas station
                            cheaperTowns[currentTown] = currentTown + 1;
                            //Otherwise
                        else
                        {
                            //We look for cheaper gas station among the ones we have already found
                            cheaperTowns[currentTown] = cheaperTowns[currentTown + 1];
                            while (cheaperTowns[currentTown] != N && P[cheaperTowns[currentTown]] >= P[currentTown])
                                cheaperTowns[currentTown] = cheaperTowns[cheaperTowns[currentTown]];

                        }
                    }

                    //Creating refill strategy
                    for (int gas = 0, gasRefill = 0, currentTown = 0, nextTown = 0;
                         currentTown < N && cheapestRefillStrategyCost != -2;
                         currentTown = nextTown)
                    {
                        //If next cheaper town is not reachable from this town
                        if (cheaperTowns[currentTown] > farthestReachableTowns[currentTown])
                        {
                            //We fill the full tank
                            gasRefill = T - gas;

                            //And move to the next town
                            nextTown = currentTown + 1;
                            gas = T - D[currentTown];
                        }
                            //If next cheaper town is reachable from this town
                        else
                        {
                            //We calculate how much gas we need to reach it
                            int gasNeeded = 0;
                            for (int passedTown = currentTown; passedTown < cheaperTowns[currentTown]; passedTown++)
                                gasNeeded += D[passedTown];

                            //Make the required refill
                            gasRefill = gas < gasNeeded ? gasNeeded - gas : 0;

                            //And move to that town
                            nextTown = cheaperTowns[currentTown];
                            gas += gasRefill - gasNeeded;
                        }

                        if ((ulong) cheapestRefillStrategyCost + (ulong) P[currentTown]*(ulong) gasRefill > 1000000000)
                            cheapestRefillStrategyCost = -2;
                        else
                            cheapestRefillStrategyCost += P[currentTown]*gasRefill;
                    }
                }
            }

            return cheapestRefillStrategyCost;
        }
    }
}
