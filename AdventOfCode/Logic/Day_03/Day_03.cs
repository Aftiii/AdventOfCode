using AoCHelper;
using System.IO;

namespace AdventOfCode
{
    public class Day_03 : BaseDay
    {
        private readonly string _input;
        private readonly string[] lines;
        public Day_03()
        {
            if (File.Exists(InputFilePath))
            {
                _input = File.ReadAllText(InputFilePath);
                lines = _input.Split("\r\n");
            }
        }
        public override string Solve_1()
        {
            return $"{CountTrees(3,1)}";
        }

        public override string Solve_2()
        {
            long first = CountTrees(1, 1);
            long second = CountTrees(3, 1);
            long third = CountTrees(5, 1);
            long fourth = CountTrees(7, 1);
            long fifth = CountTrees(1, 2);

            long total = first * second * third * fourth * fifth;
            return $"{total}";
        }
        private int CountTrees(int right, int down)
        {
            int currentX = 0;
            int trees = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i][currentX].ToString() == "#")
                {
                    trees++;
                }
                currentX += right;

                if (currentX >= lines[i].Length)
                {
                    currentX -= lines[i].Length;
                }

                i += (down - 1);
            }
            return trees;
        }
    }
}
