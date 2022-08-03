using System.ComponentModel.DataAnnotations.Schema;

namespace DisneyAPI.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string ImagePath { get; set; }
        public string Name { get; set; }
        
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
