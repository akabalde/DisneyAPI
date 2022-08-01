using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Models
{
    public enum Rating
    {
        OneStar = 1 , TwoStars = 2, ThreeStars = 3, FourStars = 4, FiveStars = 5
    }

    public class Movie
    {
        public int ID { get; set; }
        //public string ImagePath { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        [DisplayFormat(NullDisplayText = "No rating")]
        public Rating? Rating { get; set; } // ? --> Nullable
        
        public ICollection<CharacterMovie> CharacterMovies { get; set; }
        
    }
}
