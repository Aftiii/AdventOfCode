using AoCHelper;
using System.IO;
using System.Collections.Generic;
using AdventOfCode.Logic.Day_02;
using System;

namespace AdventOfCode
{
    public class Day_2 : BaseDay
    {
        private readonly string _input;
        List<Password> passwords = new List<Password>();
        public Day_2()
        {
            if (File.Exists(InputFilePath))
            {
                _input = File.ReadAllText(InputFilePath);

                string[] lines = _input.Split("\r\n");
                foreach (string line in lines)
                {
                    string[] policyRaw = line.Split(" ");
                    string[] appearancesRaw = policyRaw[0].Split("-");
                    Password p = new Password();
                    p.Policy = new PasswordPolicy();
                    p.PasswordValue = policyRaw[2];
                    p.Policy.Appearances = new Appearances();
                    p.Policy.Appearances.High = Convert.ToInt32(appearancesRaw[1]);
                    p.Policy.Appearances.Low = Convert.ToInt32(appearancesRaw[0]);
                    p.Policy.Letter = policyRaw[1].Substring(0, 1);

                    passwords.Add(p);
                }
            }
        }

        public override string Solve_1()
        {
            int validPasswords = 0;
            foreach(Password password in passwords)
            {
                if(IsValidSolve1(password))
                {
                    validPasswords++;
                }
            }
            return $"{validPasswords}";
        }
        public override string Solve_2()
        {
            string[] lines = _input.Split("\r\n");
            int validPasswords = 0;
            foreach (Password password in passwords)
            {
                if (IsValidSolve2(password))
                {
                    validPasswords++;
                }
            }
            return $"{validPasswords}";
        }
        private bool IsValidSolve1(Password password)
        {
            char[] passwordAsChars = password.PasswordValue.ToCharArray();
            int occurances = 0;
            foreach(char character in passwordAsChars)
            {
                if(character.ToString().Equals(password.Policy.Letter))
                {
                    occurances++;
                }
            }
            if(occurances >= password.Policy.Appearances.Low && occurances <= password.Policy.Appearances.High)
            {
                return true;
            }
            return false;
        }
        private bool IsValidSolve2(Password password)
        {
            char[] passwordAsChars = password.PasswordValue.ToCharArray();
            int positionFirst = password.Policy.Appearances.Low - 1;
            int positionSecond = password.Policy.Appearances.High - 1;
            if(passwordAsChars[positionFirst].ToString().Equals(password.Policy.Letter) ^ passwordAsChars[positionSecond].ToString().Equals(password.Policy.Letter))
            {
                return true;
            }
            return false;
        }

    }
}
