using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace FixturesAndBuilders
{
    public class FoodItem : IEquatable<FoodItem>
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carb { get; set; }
        public int Sugar { get; set; }
        public int Sodium { get; set; }
        public int ServingSize { get; set; }
        public int CaloricBasis { get; set; }

        public bool Equals(FoodItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Calories == other.Calories && Protein == other.Protein &&
                   Carb == other.Carb && Sugar == other.Sugar && Sodium == other.Sodium &&
                   ServingSize == other.ServingSize && CaloricBasis == other.CaloricBasis;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FoodItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Calories;
                hashCode = (hashCode * 397) ^ Protein;
                hashCode = (hashCode * 397) ^ Carb;
                hashCode = (hashCode * 397) ^ Sugar;
                hashCode = (hashCode * 397) ^ Sodium;
                hashCode = (hashCode * 397) ^ ServingSize;
                hashCode = (hashCode * 397) ^ CaloricBasis;
                return hashCode;
            }
        }

        public static bool operator ==(FoodItem left, FoodItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FoodItem left, FoodItem right)
        {
            return !Equals(left, right);
        }
    }

    public class Meal : IEquatable<Meal>
    {
        public List<FoodItem> Foods { get; set; }

        public bool Equals(Meal other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Foods, other.Foods);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Meal) obj);
        }

        public override int GetHashCode()
        {
            return (Foods != null ? Foods.GetHashCode() : 0);
        }

        public static bool operator ==(Meal left, Meal right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Meal left, Meal right)
        {
            return !Equals(left, right);
        }
    }

    public class Foods2
    {
        [Fact]
        public void UseEquals()
        {
            var turkey = new FoodItem {Name = "Turkey", Protein = 4};

            Assert.Equal(new FoodItem {Name = "Turkey", Protein = 4}, turkey);
        }

        [Fact]
        public void ProveEqualsUsesEquals()
        {
            var turkey = new FoodItem {Name = "Turkey", Protein = 4};

            Assert.NotEqual(new FoodItem {Name = "Turki", Protein = 4}, turkey);
        }

        [Fact]
        public void DoesNotWorkForCollections()
        {
            var expected = new Meal
            {
                Foods = new List<FoodItem>
                    {new FoodItem {Name = "Apple"}, new FoodItem {Name = "Carrot"}, new FoodItem {Name = "Bacon"}}
            };

            /* pretend we went and go this from someplace */
            var lunch = new Meal
            {
                Foods = new List<FoodItem>
                    {new FoodItem {Name = "Apple"}, new FoodItem {Name = "Carrot"}, new FoodItem {Name = "Bacon"}}
            };

            Assert.NotEqual(expected, lunch);
        }

        class Snack : IEquatable<Snack>
        {
            public List<FoodItem> Foods { get; set; }

            public bool Equals(Snack other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                /*
                 * return Equals(Foods, other.Foods);  // This code is generated AND wrong!
                 *
                 * The underlying Equals call makes a shallow check for equivalence. Because
                 * What is happening here is that the List<FoodItem> uses the List.Equals method,
                 * which defaults to the static Object.Equals method. That method checks for sameness
                 * (compares the identities) and then equivalence. This causes the non-static version
                 * of Object.Equals to be invoked who in turn uses RuntimeHelpers.Equals. 
                 *
                        public virtual bool Equals(object obj)
                        {
                          return RuntimeHelpers.Equals(this, obj);
                        }
                    
                        public static bool Equals(object objA, object objB)
                        {
                          if (objA == objB)
                            return true;
                          if (objA == null || objB == null)
                            return false;
                          return objA.Equals(objB);
                        }
                        
                 * The RuntimeHelpers.Equals method only checks the identity of the objects referenced,
                 * and because the two lists are not the same instance (same identity) it returns false.
                 *
                 * Note, the rules for RuntimeHelpers.Equals are a little more complicated when null is involved,
                 * but what is happening here is that Equals returns false because the Lists don't have the
                 * same identity.
                 *
                 * See:
                 * https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimehelpers.equals?view=netframework-4.7.2
                 *
                 * We can find our way around this issue by leveraging Linq's All/Contains operations. However, we
                 * also need to validate the length of each collection too because it is possible for one list to
                 * contain every element of the other list AND other things. Using Count solves this problem
                 */
                return this.Foods.All(other.Foods.Contains) && this.Foods.Count == other.Foods.Count;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Snack) obj);
            }

            public override int GetHashCode()
            {
                return (Foods != null ? Foods.GetHashCode() : 0);
            }

            public static bool operator ==(Snack left, Snack right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Snack left, Snack right)
            {
                return !Equals(left, right);
            }
        }

        [Fact]
        public void FixEqualsUsingLinq()
        {
            var expected = new Snack
            {
                Foods = new List<FoodItem>
                    {new FoodItem {Name = "Apple"}, new FoodItem {Name = "Carrot"}, new FoodItem {Name = "Bacon"}}
            };

            /* pretend we went and go this from someplace */
            var lunch = new Snack
            {
                Foods = new List<FoodItem>
                    {new FoodItem {Name = "Apple"}, new FoodItem {Name = "Carrot"}, new FoodItem {Name = "Bacon"}}
            };

            Assert.Equal(expected, lunch);
        }
    }
}