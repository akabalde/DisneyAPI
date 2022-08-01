namespace DisneyAPI.Models
{
    public class CharacterMovie
    {
        public int ID { get; set; }
        public int CharacterID { get; set; }
        public int MovieID { get; set; }

        public Character Character { get; set; }
        public Movie Movie { get; set; }
        
        /*
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }        
        */

    }
}
