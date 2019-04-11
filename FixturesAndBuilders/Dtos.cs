using System.Collections.Generic;

namespace FixturesAndBuilders
{
    public interface Food
    {
    }

    public abstract class NutritionalInfoDto : Food
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carb { get; set; }
        public double Sugar { get; set; }
        public double Sodium { get; set; }
        public double ServingSize { get; set; }
        public int CaloricBasis { get; set; }
    }

    public class IngredientDto : NutritionalInfoDto
    {
        public double Weight { get; set; }
    }

    public class CondimentDto : NutritionalInfoDto
    {
        public double Volume { get; set; }
    }

    public class SandwichDto : Food
    {
        public string Name { get; set; }
        public IngredientDto Bread { get; set; }
        public List<IngredientDto> Ingredients;
        public List<CondimentDto> Condiments;
    }
}