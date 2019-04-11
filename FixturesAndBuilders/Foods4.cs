using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FixturesAndBuilders
{
    class FoodInfo
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carb { get; set; }
        public int Sugar { get; set; }
        public int Sodium { get; set; }
        public int ServingSize { get; set; }
        public int CaloricBasis { get; set; }
    }

    class FoodCollection
    {
        public List<FoodInfo> Foods { get; set; }
    }

    public class Foods4
    {
        [Fact]
        public void FluentlyCompare()
        {
            var samich1 = new FoodCollection
            {
                Foods = new List<FoodInfo>
                    {new FoodInfo {Name = "Lettuce"}, new FoodInfo {Name = "Bacon"}, new FoodInfo {Name = "Tomato"}}
            };
            var samich2 = new FoodCollection
            {
                Foods = new List<FoodInfo>
                    {new FoodInfo {Name = "Lettuce"}, new FoodInfo {Name = "Bacon"}, new FoodInfo {Name = "Tomato"}}
            };

            samich1.Should().BeEquivalentTo(samich2);
        }

        [Fact]
        public void VerifyFluentDidMagic()
        {
            var samich1 = new FoodCollection
            {
                Foods = new List<FoodInfo>
                    {new FoodInfo {Name = "Lettuce"}, new FoodInfo {Name = "Bacon"}, new FoodInfo {Name = "Tomato"}}
            };
            var samich2 = new FoodCollection
            {
                Foods = new List<FoodInfo>
                    {new FoodInfo {Name = "Lettuce"}, new FoodInfo {Name = "Bakon"}, new FoodInfo {Name = "Tomato"}}
            };

            /* Fluent doesn't give us a way to show the negation here */
//            samich1.Should().BeEquivalentTo(samich2);
        }
    }
}