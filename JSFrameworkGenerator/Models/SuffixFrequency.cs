using System;
using System.Collections.Generic;
using System.Text;

namespace StandaloneApp.JSFrameworkGenerator.Models
{
    /// <summary>
    /// A pair of string suffix and the frequency of the suffix in some set of tokens.
    /// </summary>
    struct SuffixFrequency
    {
        //TODO: make struct readonly, requires C# 7.2 upgrade
        public string Suffix { get; }
        public int Frequency { get; }

        public SuffixFrequency(string suffix, int frequency)
        {
            Suffix = suffix;
            Frequency = frequency;
        }
    }
}
