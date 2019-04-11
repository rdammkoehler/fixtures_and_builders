using System.Collections.Generic;

namespace FixturesAndBuilders
{
    public class SandwichBuilder
    {
        /* by default, return a simple ham sandwich */
        private SandwichDto sandwich = new SandwichDto
        {
            Name = SandwichNames.HAM_SANDWICH,
            Bread = Breads.MARBLED_RYE,
            Ingredients = new List<IngredientDto> {Meats.HAM, Veggies.LETTUCE, Cheeses.SWISS},
            Condiments = new List<CondimentDto> {Condiements.SPICY_MUSTARD}
        };

        public SandwichBuilder WithBread(IngredientDto bread)
        {
            sandwich.Bread = bread;
            return this;
        }

        public SandwichBuilder With(IngredientDto ingredient)
        {
            sandwich.Ingredients.Add(ingredient);
            return this;
        }

        public SandwichBuilder With(CondimentDto condiment)
        {
            sandwich.Condiments.Add(condiment);
            return this;
        }

        public SandwichBuilder WithoutBread()
        {
            sandwich.Bread = null;
            return this;
        }

        public SandwichBuilder Without(IngredientDto ingredient)
        {
            sandwich.Ingredients.Remove(ingredient);
            return this;
        }

        public SandwichBuilder Without(CondimentDto condiment)
        {
            sandwich.Condiments.Remove(condiment);
            return this;
        }

        public SandwichBuilder As(string name)
        {
            sandwich.Name = name;
            return this;
        }
        
        public SandwichDto Build()
        {
            return sandwich;
        }
    }
}