namespace _05.BorderControl.Models
{
    using _05.BorderControl.Contracts;

    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        
        public string Model { get; set; }

        public string Id { get; private set; }
    }
}
