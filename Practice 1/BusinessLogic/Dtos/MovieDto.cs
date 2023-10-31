using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TicketPrice { get; set; }
        public string? ImageUrl { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }
    }
}
