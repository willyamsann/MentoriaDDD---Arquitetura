using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MentoriaContext context) : base(context)
        {
        }

        public Cliente GetById(int id)
        {
            var obj = CurrentSet
                    .Include(x => x.User)
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

            return obj;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            var obj = CurrentSet
                .Include(x => x.User)
                .ToList();

            return obj;
        }
    }
}
