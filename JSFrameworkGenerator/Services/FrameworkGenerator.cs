using StandaloneApp.JSFrameworkGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StandaloneApp.JSFrameworkGenerator.Services
{
    /// <summary>
    /// Calls the markov generators to generate frameworks, and massages the output
    /// a bit (e.g. appends .js to framework name).
    /// </summary
    public sealed class FrameworkGenerator
    {
        private readonly MarkovGenerator nameGenerator;
        private readonly MarkovGenerator descriptionGenerator;

        public FrameworkGenerator(IReadOnlyCollection<Framework> frameworks)
        {
            // framework names are generated character by character
            var inputNames = string.Join(" ", frameworks.Select(framework => framework.Name))
                .ToCharArray()
                .Select(ch => ch.ToString())
                .ToList();
            this.nameGenerator = new MarkovGenerator(inputNames, 2);

            // framework descriptions are generated word by word
            var inputDescriptions = string.Join(" ", frameworks.Select(framework => framework.Description))
                .Split(' ')
                .ToList();
            this.descriptionGenerator = new MarkovGenerator(inputDescriptions, 1);
        }

        public Framework Generate()
        {
            return new Framework(
                GenerateName(),
                GenerateDescription()
            );
        }

        private string GenerateName()
        {
            // a framework name is a random markov chain that terminates in a space.
            IEnumerable<string> generatedName = nameGenerator.Generate();
            var name = string.Join("",
                generatedName.SkipWhile(c => !char.IsLetterOrDigit(c[0])).TakeWhile(c => c != " ")
            );
            return name.IndexOf("js", StringComparison.OrdinalIgnoreCase) == -1
                ? name + ".js"
                : name;
        }

        private string GenerateDescription()
        {
            // a framework name is a random markov chain that terminates in a period or after 20 words.
            IEnumerable<string> generatedDescription = descriptionGenerator.Generate();
            var description = string.Join(" ", generatedDescription.Take(20));
            return ExtractSentence(description);
        }

        private static string ExtractSentence(string description)
        {
            int endOfSentenceIndex = description.LastIndexOf(". ");
            string truncatedDescription = endOfSentenceIndex > 0
                ? description.Substring(0, endOfSentenceIndex)
                : description;
            return Char.ToUpper(truncatedDescription[0]) + truncatedDescription.Substring(1) + ".";
        }
    }
}
