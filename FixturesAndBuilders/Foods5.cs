using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FixturesAndBuilders
{
    class SandwichComparator : IEqualityComparer<SandwichDto>
    {
        public bool Equals(SandwichDto x, SandwichDto y)
        {
            return x.Name.Equals(y.Name) &&
                   x.Bread == y.Bread &&
                   x.Ingredients.All(y.Ingredients.Contains) &&
                   x.Ingredients.Count == y.Ingredients.Count &&
                   x.Condiments.All(y.Condiments.Contains) &&
                   x.Condiments.Count == y.Condiments.Count;
        }

        public int GetHashCode(SandwichDto obj)
        {
            return (obj.Name != null ? obj.Name.GetHashCode() : 0);
        }
    }

    public class Foods5
    {
        [Fact]
        public void WithBuilders()
        {
            var samich1 = new SandwichBuilder().Build();
            var samich2 = new SandwichBuilder().Build();

            Assert.Equal(samich1, samich2, new SandwichComparator());
            Assert.NotSame(samich1, samich2);
        }

        [Fact]
        public void MoreWithBuilders()
        {
            var samich1 = new SandwichBuilder().WithoutBread().Build();
            var samich2 = new SandwichBuilder().Build();

            Assert.NotEqual(samich1, samich2, new SandwichComparator());           
        }

        [Fact]
        public void AddsBacon()
        {
            var samich = new SandwichBuilder().With(Meats.BACON).Build();

            Assert.True(samich.Ingredients.Contains(Meats.BACON));
        }

        [Fact]
        public void SadSamich()
        {
            var samich = new SandwichBuilder().Without(Meats.BACON).Build();

            Assert.False(samich.Ingredients.Contains(Meats.BACON));
        }
    }
}