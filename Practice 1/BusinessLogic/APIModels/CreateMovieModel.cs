using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.APIModels
{
    public class CreateMovieModel
    {
        public string? Name { get; set; }
        public decimal TicketPrice { get; set; }
        public string? ImageUrl { get; set; }
        public int GenreId { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }
    }
}
