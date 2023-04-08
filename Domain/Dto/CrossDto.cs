using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CrossDto
    {
        public string ActorName { get; set; }

        public string MovieTitle { get; set; }
        public int MovieRelease_year { get; set; }
        public string MovieGenre { get; set; }
        public string MovieDirector { get; set; }
    }
}
