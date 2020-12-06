using AdventOfCode.Logic.Day_04;
using AoCHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day_04 : BaseDay
    {
        private readonly string _input;
        List<Passport> passports = new List<Passport>();

        public Day_04()
        {
            if (File.Exists(InputFilePath))
            {
                _input = File.ReadAllText(InputFilePath);
                string[] lines = _input.Split("\r\n\r\n");
                foreach (string rawLine in lines)
                {
                    string line = rawLine.Replace($"\r\n", " ");
                    string[] parts = line.Split(null);
                    Passport passport = new Passport();
                    foreach(string part in parts)
                    {
                        string[] keyValue= part.Split(":");
                        KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(keyValue[0], keyValue[1]);
                        switch(kvp.Key)
                        {
                            case "byr":
                                passport.BirthYear = Convert.ToInt16(kvp.Value);
                                break;
                            case "iyr":
                                passport.IssueYear = Convert.ToInt16(kvp.Value);
                                break;
                            case "eyr":
                                passport.ExpirationYear = Convert.ToInt16(kvp.Value);
                                break;
                            case "hgt":
                                passport.Height = new Passport.PassportHeight();
                                passport.Height.RawValue = kvp.Value;
                                passport.Height.HeightValue = Convert.ToInt16(kvp.Value.Replace("cm", "").Replace("in", ""));
                                passport.Height.Measurement = Regex.Replace(kvp.Value, @"\d", string.Empty);
                                break;
                            case "hcl":
                                passport.HairColour = kvp.Value;
                                break;
                            case "ecl":
                                passport.EyeColour = kvp.Value;
                                break;
                            case "pid":
                                passport.PassportId = kvp.Value;
                                break;
                            case "cid":
                                passport.CountryId = kvp.Value;
                                break;
                            default:
                                throw new ArgumentException("Found a value which doesn't match data structure");
                        }
                    }
                    passports.Add(passport);
                }
            }
            
        }

        public override string Solve_1()
        {
            int validPassports = 0;
            foreach(Passport passport in passports)
            {
                if(passport.IsValidSolve1)
                {
                    validPassports++;
                }
            }
            return $"{validPassports}";
        }

        public override string Solve_2()
        {
            int validPassports = 0;
            foreach(Passport passport in passports)
            {
                if(passport.IsValidSolve2)
                {
                    validPassports++;
                }
            }
            return $"{validPassports}";
        }
    }
}
