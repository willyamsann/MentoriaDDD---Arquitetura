using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class ClienteViewModel
    {
        [JsonPropertyName("CPF")]
        public string Cpf { get; set; }

        [JsonPropertyName("Endereço")]
        public string Address { get; set; }

        [JsonPropertyName("Id Usuario")]
        public int UserId { get; set; }

        [JsonPropertyName("Usuario")]
        public UserViewModel User { get; set; }
    }
}
