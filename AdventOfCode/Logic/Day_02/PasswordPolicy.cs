using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Logic.Day_02
{
    public class Password
    {
        public PasswordPolicy Policy { get; set; }
        public string PasswordValue { get; set; }
    }
    public class PasswordPolicy
    {
        public Appearances Appearances { get; set; }
        public string Letter { get; set; }
    }
    public class Appearances
    {
        public int High { get; set;}
        public int Low { get; set; }
    }
}
