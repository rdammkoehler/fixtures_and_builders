using System.Collections.Generic;

namespace FixturesAndBuilders
{
    public class UniqueSandwichMaker : Fixture
    {
        private static SandwichDto HamSandwich()
        {
            return new SandwichDto
            {
                Name = SandwichNames.HAM_SANDWICH,
                Bread = Breads.MARBLED_RYE,
                Ingredients = new List<IngredientDto> {Meats.HAM, Veggies.LETTUCE, Cheeses.SWISS},
                Condiments = new List<CondimentDto> {Condiements.SPICY_MUSTARD}
            };
        }

        public static SandwichDto Make(string sandwichName)
        {
            switch (sandwichName)
            {
                case SandwichNames.HAM_SANDWICH: return HamSandwich();
            }

            return null;
        }
    }
}