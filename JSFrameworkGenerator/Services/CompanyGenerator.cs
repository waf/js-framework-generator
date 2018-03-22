using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandaloneApp.JSFrameworkGenerator.Services
{
    public class CompanyGenerator
    {
        private readonly MarkovGenerator companyGenerator;

        public CompanyGenerator(IReadOnlyCollection<string> companies)
        {
            var companyCharacters = string.Join("/", companies)
                .ToCharArray()
                .Select(ch => ch.ToString())
                .ToList();
            this.companyGenerator = new MarkovGenerator(companyCharacters, 3);
        }

        public IEnumerable<string> Generate()
        {
            while(true)
            {
                yield return GenerateCompany();
            }
        }

        private string GenerateCompany()
        {
            var generatedName = companyGenerator.Generate();
            var name = string.Join("",
                generatedName.SkipWhile(c => !char.IsLetterOrDigit(c[0])).TakeWhile(c => c != "/")
            );
            return name;
        }
    }
}
