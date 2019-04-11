using System;
using System.Collections.Generic;
using System.Security.Principal;
using Xunit;

namespace FixturesAndBuilders
{

    public class FoodsTest
    {
        /* OK but this an an awful way to detect correctness...all those asserts hurt my head */
        [Fact]
        public void OldWay()
        {
            var hamSandwich = SandwichMaker.Make(SandwichNames.HAM_SANDWICH);

            Assert.Equal(SandwichNames.HAM_SANDWICH, hamSandwich.Name);
            Assert.Equal(Breads.MARBLED_RYE, hamSandwich.Bread);
            Assert.Contains(Cheeses.SWISS, hamSandwich.Ingredients);
            Assert.Contains(Meats.HAM, hamSandwich.Ingredients);
            Assert.Contains(Veggies.LETTUCE, hamSandwich.Ingredients);
            Assert.Contains(Condiements.SPICY_MUSTARD, hamSandwich.Condiments);
        }

        /* This works, BUT it relies on SandwichMaker referring to the same instance of the Ham Sandwich*/
        [Fact]
        public void FixtureWay()
        {
            var hamSandwich = SandwichMaker.Make(SandwichNames.HAM_SANDWICH);

            Assert.Equal(SandwichMaker.Make(SandwichNames.HAM_SANDWICH), hamSandwich);
        }

        /* here is proof of the sameness assertion made above */
        [Fact]
        public void FixtureReliesOnSameness()
        {
            var hamSandwich = SandwichMaker.Make(SandwichNames.HAM_SANDWICH);

            Assert.Same(SandwichMaker.Make(SandwichNames.HAM_SANDWICH), hamSandwich);
        }
        
        /* If I got new sandwiches each time, the original test would fail */
        [Fact]
        public void DifferentInstancesAreNotEqual()
        {
            var hamSandwich = UniqueSandwichMaker.Make(SandwichNames.HAM_SANDWICH);

            Assert.NotEqual(UniqueSandwichMaker.Make(SandwichNames.HAM_SANDWICH), hamSandwich);
        }
        
        /* The underlying issue is that there is no Equals Method on the Sandwich and its parts */
        
    }
}