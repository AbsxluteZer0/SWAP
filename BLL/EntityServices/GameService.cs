using SWAP.DAL.Data;
using SWAP.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.BLL.EntityServices
{
    internal class GameService
    {
        private readonly IApplicationContext context;

        public GameService(IApplicationContext context)
        {
            this.context = context;
        }

        public string ListGames()
        {
            List<Game> games = context.Games.ToList();

            StringBuilder builder = new StringBuilder();

            foreach (var game in games)
            {
                builder.AppendLine(String.Format("{0}.{1}\t\t{2}₴", game.GameId, game.Title, game.Price));
            }

            return builder.ToString();
        }

        public string ListGames(int genreId)
        {
            IEnumerable<Game> games = context.GameGenres.Where(r => r.GenreId == genreId).Select(g => g.Game);

            if (!games.Any())
            {
                return "Нічого не знайдено";
            }

            StringBuilder builder = new StringBuilder();

            foreach (var game in games)
            {
                builder.AppendLine(String.Format("{0}.{1}\t\t{2}₴", game.GameId, game.Title, game.Price));
            }

            return builder.ToString();
        }

        public string Details(int gameId)
        {
            Game game = context.Games.FirstOrDefault(g => g.GameId == gameId);

            if (game == null)
            {
                throw new ApplicationException("Гру не знайдено");
            }

            IEnumerable<Genre> genres = context.GameGenres.Where(g => g.GameId == gameId).Select(g => g.Genre);

            StringBuilder genreBuilder = new StringBuilder();

            foreach (var genre in genres)
            {
                genreBuilder.Append(genre.Name).Append(", ");
            }

            genreBuilder.Remove(genreBuilder.Length - 2, 2);

            return "Назва: " + game.Title +
                "\nЖанри: " + genreBuilder.ToString() +
                "\nОпис: " + game.Description +
                "\nЦіна: " + game.Price + "₴";
        }

        public string ListGenres()
        {
            IEnumerable<Genre> genres = context.Genres;

            if (!genres.Any())
            {
                return "Нічого не знайдено";
            }

            StringBuilder builder = new StringBuilder();

            foreach (var genre in genres)
            {
                builder.AppendLine(String.Format("{0}.{1}", genre.GenreId, genre.Name));
            }

            return builder.ToString();
        }
    }
}
