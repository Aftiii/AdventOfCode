using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Logic.Day_04
{
    public class Passport
    {
        public class PassportHeight
        {
            public int? HeightValue { get; set; }
            public string Measurement { get; set; }
            public string RawValue { get; set; }
        }
        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public PassportHeight Height { get; set; }
        public string HairColour { get; set; }
        public string EyeColour { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }
        public bool IsValidSolve1
        {
            get
            {
                if (BirthYear.HasValue
                    && IssueYear.HasValue
                    && ExpirationYear.HasValue
                    && (Height != null && Height.HeightValue.HasValue)
                    && !string.IsNullOrWhiteSpace(HairColour)
                    && !string.IsNullOrWhiteSpace(EyeColour)
                    && !string.IsNullOrWhiteSpace(PassportId))
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsValidSolve2
        {
            get
            {
                if (IsBirthYearValid()
                    && IsIssueYearValid()
                    && IsExpirationYearValid()
                    && IsHeightValid()
                    && IsHairColourValid()
                    && IsEyeColourValid()
                    && IsPassportIdValid())
                {
                    return true;
                }
                return false;
            }
        }
        private bool IsBirthYearValid()
        {
            if (BirthYear.HasValue)
            {
                if (BirthYear.Value.ToString().Length == 4)
                {
                    if (BirthYear.Value >= 1920 && BirthYear.Value <= 2002)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsIssueYearValid()
        {
            if (IssueYear.HasValue)
            {
                if (IssueYear.Value.ToString().Length == 4)
                {
                    if (IssueYear.Value >= 2010 && IssueYear.Value <= 2020)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsExpirationYearValid()
        {
            if (ExpirationYear.HasValue)
            {
                if (ExpirationYear.Value.ToString().Length == 4)
                {
                    if (ExpirationYear.Value >= 2020 && ExpirationYear.Value <= 2030)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsHeightValid()
        {
            if (Height != null && Height.HeightValue.HasValue)
            {
                if (Regex.IsMatch(Height.RawValue, $@"[0-9]+[cmin]+"))
                {
                    if (Height.Measurement == "cm")
                    {
                        if (Height.HeightValue.Value >= 150 && Height.HeightValue.Value <= 193)
                        {
                            return true;
                        }
                    }
                    else if (Height.Measurement == "in")
                    {
                        if (Height.HeightValue.Value >= 59 && Height.HeightValue.Value <= 76)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool IsHairColourValid()
        {
            if (HairColour != null && HairColour.Length == 7)
            {
                if (Regex.IsMatch(HairColour, @"#([0-9a-f{6}]+)"))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsEyeColourValid()
        {

            if (EyeColour != null && EyeColour.Length == 3)
            {
                List<string> validColours = new List<string>(7) { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                if (validColours.Contains(EyeColour))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsPassportIdValid()
        {
            if (PassportId != null && PassportId.Length == 9)
            {
                if (int.TryParse(PassportId, out int passportIdInt))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
