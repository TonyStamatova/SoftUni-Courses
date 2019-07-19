namespace _03.WildFarm.Contracts
{
    using _03.WildFarm.Models.Food;

    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string AskForFood();

        void Eat(IFood food);
    }
}
