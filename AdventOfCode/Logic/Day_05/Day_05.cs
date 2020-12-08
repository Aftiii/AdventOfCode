using AoCHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_05 : BaseDay
    {
        private readonly string[] lines;
        private readonly List<int> seatIds = new List<int>();

        public Day_05()
        {
            if (File.Exists(InputFilePath))
            {
                lines = File.ReadAllLines(InputFilePath);

            }
        }

        public override string Solve_1()
        {
            int highestSeatId = 0;
            foreach(string line in lines)
            {
                char[] parts = line.ToCharArray();
                char[] rowParts = parts.Take(7).ToArray();
                char[] columnParts = parts.Skip(7).Take(3).ToArray();

                double high = 127;
                double low = 0;
                double toThePowerOf = 6;
                foreach(char rowChar in rowParts)
                {
                    if(rowChar == 'F')
                    {
                        high -= Math.Pow(2, toThePowerOf);
                    }else if(rowChar == 'B')
                    {
                        low += Math.Pow(2, toThePowerOf);
                    }
                    toThePowerOf--;
                }
                
                int row = Convert.ToInt32(high);

                high = 7;
                low = 0;
                toThePowerOf = 2;
                for(int i = 0; i < columnParts.Length; i++)
                {
                    if(columnParts[i] == 'L')
                    {
                        high -= Math.Pow(2, toThePowerOf);
                    }else if(columnParts[i] == 'R')
                    {
                        low += Math.Pow(2, toThePowerOf);
                    }
                    toThePowerOf--;
                }

                int column = Convert.ToInt32(high);

                int tempSeatId = GetSeatId(row, column);
                seatIds.Add(tempSeatId);
                if(tempSeatId > highestSeatId)
                {
                    highestSeatId = tempSeatId;
                }
            }
            return $"{highestSeatId}";
        }
        private int GetSeatId(int row, int column)
        {
            return row * 8 + column;
        }
        public override string Solve_2()
        {
            for(int i =0; i < 842; i++)
            {
                if(!seatIds.Contains(i))
                {
                    Debug.WriteLine($"Seat ID:{i} not in seatIds list");
                }
            }
            return $"";
        }
    }
}
