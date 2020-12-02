﻿using AoCHelper;
using System.IO;

namespace AdventOfCode
{
    public class Day_05 : BaseDay
    {
        private readonly string _input;

        public Day_05()
        {
            if (File.Exists(InputFilePath))
            {
                _input = File.ReadAllText(InputFilePath);
            }
        }

        public override string Solve_1() => $"Not implemented.. yet";

        public override string Solve_2() => $"Not implemented.. yet";
    }
}
