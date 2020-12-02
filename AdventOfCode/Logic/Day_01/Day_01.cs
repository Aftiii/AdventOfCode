using AoCHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_01 : BaseDay
    {
        private readonly string _input;
        private readonly List<int> _numbers;

        public Day_01()
        {
            _input = File.ReadAllText(InputFilePath);
            _numbers = _input.Split("\r\n").Select(t => int.Parse(t)).ToList();
        }

        public override string Solve_1()
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                for (int j = 0; j < _numbers.Count; j++)
                {
                    if (_numbers[i] + _numbers[j] == 2020)
                    {
                        return (_numbers[i] * _numbers[j]).ToString();
                    }
                }
            }
            throw new SolvingException();
        }


        public override string Solve_2()
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                for (int j = i; j < _numbers.Count; j++)
                {
                    for (int k = j; k < _numbers.Count; k++)
                    {
                        if (_numbers[i] + _numbers[j] + _numbers[k] == 2020)
                        {
                            return (_numbers[i] * _numbers[j] * _numbers[k]).ToString();
                        }
                    }
                }
            }
            throw new SolvingException();
        }
    }
}
