using DisneyAPI.Models;

namespace DisneyAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(DisneyAPIContext context)
        {
            // Look for any students.
            if (context.Characters.Any())
            {
                return;   // DB has been seeded
            }

            var characters = new Character[]
            {
                new Character{Name="Mr Bad",Age=20,Weight=70},
                new Character{Name="BuzzLight",Age=20,Weight=70},
                new Character{Name="Jony",Age=20,Weight=70},
            };

            context.Characters.AddRange(characters);
            context.SaveChanges();

            var movies = new Movie[]
            {
                new Movie{Title="Tarzan",Rating=Rating.OneStar},
                new Movie{Title="Encanto",Rating=Rating.FiveStars},
                new Movie{Title="Thor",Rating=Rating.ThreeStars},
                new Movie{Title="Los Increibles",Rating=Rating.ThreeStars},
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();

            var characterMovies = new CharacterMovie[]
            {
                new CharacterMovie{CharacterID=1,MovieID=1},
                new CharacterMovie{CharacterID=1,MovieID=2},
                new CharacterMovie{CharacterID=2,MovieID=3},
                new CharacterMovie{CharacterID=3,MovieID=4},
            };

            context.CharacterMovies.AddRange(characterMovies);
            context.SaveChanges();

            var genres = new Genre[]
            {
                new Genre{Name="Action"},
                new Genre{Name="Comedy"},
                new Genre{Name="Drama"},
                new Genre{Name="Kids"},
            };

            context.Genres.AddRange(genres);
            context.SaveChanges();

            var movieGenres = new MovieGenre[]
            {
                new MovieGenre{MovieID=1,GenreID=1},
                new MovieGenre{MovieID=1,GenreID=2},
                new MovieGenre{MovieID=2,GenreID=3},
                new MovieGenre{MovieID=3,GenreID=3},
            };

            context.MovieGenres.AddRange(movieGenres);
            context.SaveChanges();

        }
    }
}
