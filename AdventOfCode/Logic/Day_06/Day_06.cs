using AdventOfCode.Logic.Day_06;
using AoCHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_06 : BaseDay
    {
        private string[] lines;
        private readonly List<string> linesAsList = new List<string>();
        public Day_06()
        {
            if (File.Exists(InputFilePath))
            {
                lines = File.ReadAllText(InputFilePath).Split("\r\n\r\n");
                foreach (string line in lines)
                {
                    linesAsList.Add(line.Replace("\r\n", ""));
                }
            }
        }

        public override string Solve_1()
        {
            int runningGroupSum = 0;
            foreach (string line in linesAsList)
            {
                char[] lineExplode = line.ToCharArray();
                List<char> uniqChars = new List<char>();
                foreach (char character in lineExplode)
                {
                    if (!uniqChars.Contains(character))
                    {
                        uniqChars.Add(character);
                    }
                }
                runningGroupSum += uniqChars.Count;

            }
            return $"{runningGroupSum}";
        }

        public override string Solve_2()
        {
            lines = File.ReadAllText(InputFilePath).Split("\r\n\r\n");
            

            int runningGroupSum = 0;
            foreach (string line in lines)
            {
                int groupCount = line.Split("\r\n").Length;
                List<KeyVal<char, int>> answers = new List<KeyVal<char, int>>();
                char[] lineExplode = line.Replace("\r\n","").ToCharArray();
                foreach (char character in lineExplode)
                {
                    KeyVal<char, int> exists = answers.Where(x => x.Id == character).FirstOrDefault();
                    if (exists == null)
                    {
                        answers.Add(new KeyVal<char, int>(character, 1));
                    }
                    else
                    {
                        for( int i = 0; i< answers.Count(); i++)
                        {
                            if(answers[i].Id == character)
                            {
                                answers[i] = new KeyVal<char, int>(answers[i].Id, ++answers[i].Value);
                            }
                        }
                    }
                }
                runningGroupSum += answers.Where(x => x.Value == groupCount).Count();
            }
            return $"{runningGroupSum}";
        }
    }
}
