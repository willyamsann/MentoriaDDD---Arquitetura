using AutoMapper;
using Domain.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;

        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClienteViewModel> GetClientes()
        {
            var clientes = _clienteRepository.GetClientes();
            return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
        }
    }
}
