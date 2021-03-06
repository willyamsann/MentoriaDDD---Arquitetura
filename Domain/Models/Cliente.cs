using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cliente : BaseEntity
    {
        public string Cpf { get; set; }
        public string Address { get; set; }
        public string CEP { get; set; }
     
        public int UserId { get; set; }
        public User User { get; set; }

        // ARQUIVO
        public string PhotoName { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }

    }
}
