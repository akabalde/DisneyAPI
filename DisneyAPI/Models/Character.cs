namespace DisneyAPI.Models
{
    public class Character
    {
        public int ID { get; set; }
        //public string ImagePath { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string History { get; set; }

        public ICollection<CharacterMovie> CharacterMovies { get; set; }

    }
}
