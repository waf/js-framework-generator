using System;
using System.Collections.Generic;
using System.Linq;

namespace StandaloneApp.JSFrameworkGenerator.Models
{
    /// <summary>
    /// Wrapper around string[] that implements Equals() and GetHashCode() based on string[]'s contents.
    /// </summary>
    struct Prefix : IEquatable<Prefix>
    {
        //TODO: make struct readonly, requires C# 7.2 upgrade

        public string[] Elements { get; }

        public Prefix(string[] elements) =>
            Elements = elements;

        public override bool Equals(object obj) =>
            obj is Prefix && Equals((Prefix)obj);

        public bool Equals(Prefix other) =>
            Elements.SequenceEqual(other.Elements);

        public override int GetHashCode() =>
            Elements.Aggregate(
                37157100,
                (hashCode, currentElement) => hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(currentElement)
            );

        public override string ToString() =>
            string.Join(" ", Elements);
    }
}
