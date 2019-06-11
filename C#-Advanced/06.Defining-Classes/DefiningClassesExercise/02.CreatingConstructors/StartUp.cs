namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            Person personOne = new Person();
            personOne.Name = "Pesho";
            personOne.Age = 20;

            Person personTwo = new Person("Gosho", 18);
            Person personThree = new Person("Stamat", 43);
        }
    }
}
