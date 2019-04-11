using System.Collections.Generic;

namespace FixturesAndBuilders
{
    public class SandwichMaker : Fixture
    {
        private static readonly SandwichDto HAM_SANDWICH = new SandwichDto
        {
            Name = SandwichNames.HAM_SANDWICH,
            Bread = Breads.MARBLED_RYE,
            Ingredients = new List<IngredientDto> {Meats.HAM, Veggies.LETTUCE, Cheeses.SWISS},
            Condiments = new List<CondimentDto> {Condiements.SPICY_MUSTARD}
        };

        private static readonly Dictionary<string, SandwichDto> SANDWICHES = new Dictionary<string, SandwichDto>
        {
            {SandwichNames.HAM_SANDWICH, HAM_SANDWICH}
        };

        public static SandwichDto Make(string sandwichName)
        {
            return SANDWICHES[sandwichName];
        }
    }
}