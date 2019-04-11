using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace FixturesAndBuilders
{
    class FoodItemInfo
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carb { get; set; }
        public int Sugar { get; set; }
        public int Sodium { get; set; }
        public int ServingSize { get; set; }
        public int CaloricBasis { get; set; }

        public int Fiber { get; set; }
    }

    class FoodItemInfoComparer : IEqualityComparer<FoodItemInfo>
    {
        public bool Equals(FoodItemInfo x, FoodItemInfo y)
        {
            return ((x.Name == null && y.Name == null) || x.Name.Equals(y.Name)) &&
                   x.Calories == y.Calories &&
                   x.Protein == y.Protein &&
                   x.Carb == y.Carb &&
                   x.Sugar == y.Sugar &&
                   x.Sodium == y.Sodium &&
                   x.ServingSize == y.ServingSize &&
                   x.CaloricBasis == y.CaloricBasis &&
                   x.Fiber == y.Fiber;
        }

        public int GetHashCode(FoodItemInfo obj)
        {
            unchecked
            {
                var hashCode = (obj.Name != null ? obj.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ obj.Calories;
                hashCode = (hashCode * 397) ^ obj.Protein;
                hashCode = (hashCode * 397) ^ obj.Carb;
                hashCode = (hashCode * 397) ^ obj.Sugar;
                hashCode = (hashCode * 397) ^ obj.Sodium;
                hashCode = (hashCode * 397) ^ obj.ServingSize;
                hashCode = (hashCode * 397) ^ obj.CaloricBasis;
                hashCode = (hashCode * 397) ^ obj.Fiber;
                return hashCode;
            }
        }
    }

    public class Foods3
    {
        /*
         * So the upside here is that I didn't have to implement Equals/Hashcode methods
         * on the underlying dto, I externalized all of the comparison to another class
         * that I can pass to the Assert.Equal method. This has all kinds of utility. This
         * is also a very simple 'Matcher' type implementation. 
         */
        [Fact]
        public void HowAboutComparators()
        {
            var bacon1 = new FoodItemInfo {Name = "BAKON!", Calories = 300, Carb = 0, Fiber = 30};
            var bacon2 = new FoodItemInfo {Name = "BAKON!", Calories = 300, Carb = 0, Fiber = 30};

            Assert.Equal(bacon1, bacon2, new FoodItemInfoComparer());
        }
    }
}