using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime Create { get; set; }

        public DateTime Update { get; set; }
    }
}
