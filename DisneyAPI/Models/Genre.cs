namespace DisneyAPI.Models
{
    public class Genre
    {
        public int ID { get; set; }
        //public string ImagePath { get; set; }
        public string Name { get; set; }
        
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
