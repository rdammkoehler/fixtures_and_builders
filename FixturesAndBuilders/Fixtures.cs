namespace FixturesAndBuilders
{
    class Breads
    {
        public static readonly IngredientDto MARBLED_RYE = new IngredientDto
        {
            Name = "Marbled Rye",
            Weight = 40.0,
            Calories = 100,
            Protein = 3,
            Carb = 18,
            Sugar = 1,
            Sodium = 200,
            ServingSize = 40,
            CaloricBasis = 2000
        };

        public static readonly IngredientDto WHITE = new IngredientDto {Name = "White Bread"};
        public static readonly IngredientDto WHEAT = new IngredientDto {Name = "Wheat Bread"};
    }

    class Meats
    {
        public static readonly IngredientDto HAM = new IngredientDto {Name = "Ham"};
        public static readonly IngredientDto PASTRAMI = new IngredientDto {Name = "Pastrami"};
        public static readonly IngredientDto BACON = new IngredientDto {Name = "Bacon"};
    }

    class Veggies
    {
        public static readonly IngredientDto LETTUCE = new IngredientDto {Name = "Lettuce"};
        public static readonly IngredientDto TOMATO = new IngredientDto {Name = "Tomato"};
    }

    class Cheeses
    {
        public static readonly IngredientDto SWISS = new IngredientDto {Name = "Swiss", Weight = 30};
        public static readonly IngredientDto CHEDDAR = new IngredientDto {Name = "Cheddar", Weight = 30};
    }

    class Condiements
    {
        public static readonly CondimentDto SPICY_MUSTARD = new CondimentDto {Name = "Spicy Mustard", Volume = 1.0};
        public static readonly CondimentDto KETCHUP = new CondimentDto {Name = "Ketchup", Volume = 1.0};
        public static readonly CondimentDto MAYONAISE = new CondimentDto {Name = "Mayonaise", Volume = 1.0};
    }

    class SandwichNames
    {
        public const string HAM_SANDWICH = "Ham Sandwich";
    }
}