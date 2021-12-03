using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IBaseService<Cliente> _baseClientService;
        private IClienteService _clienteService;
        private readonly ILogger<UserController> _logger;

        public ClienteController(IBaseService<Cliente> baseClientService, IClienteService clienteService
            , ILogger<UserController> logger)
        {
            _baseClientService = baseClientService;
            _clienteService = clienteService;
            _logger = logger;
        }

        [HttpPost]
        [Route("CreateCliente")]
        public IActionResult Create([FromBody] Cliente cliente)
        {

            if (cliente == null)
                return NotFound();

            return Execute(() => _baseClientService.Add<ClienteValidator>(cliente).Id);
        }
        
        [HttpPost]
        [Route("Upload/{id}")]
        public async Task<string> SendUpload([FromForm] IFormFile arquivo,int id)
        {
            if(arquivo.Length > 0)
            {

                try
                {
                    if (!Directory.Exists("C:\\images\\"))
                    {
                        Directory.CreateDirectory("C:\\images\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create("C:\\images\\" + arquivo.FileName))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        fileStream.Flush();

                        var objCliente = _baseClientService.GetById(id);
                        objCliente.Path = "C:\\images\\";
                        objCliente.Type = "image/jpg";
                        objCliente.PhotoName = arquivo.FileName;

                        _baseClientService.Update<ClienteValidator>(objCliente);
                        return "C:\\images\\" + arquivo.FileName;
                    }
                }
                catch(Exception e){
                    return e.ToString();
                }
            }
            else
            {
                return "Arquivo com falha.....";
            }
        }

        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> Download(string arquivo)
        {
            var path = "C:\\images\\";
            var filepath = path + arquivo;

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, "image/png", Path.GetFileName(filepath));
        }

            [HttpPut]
        public IActionResult Update([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return NotFound();

            return Execute(() => _baseClientService.Update<ClienteValidator>(cliente));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseClientService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Execute(() => _clienteService.GetClientes());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseClientService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string UploadImage(IFormFile arquivo)
        {
            if (arquivo.Length > 0)
            {
                try
                {
                    if (!Directory.Exists("C:\\images\\"))
                    {
                        Directory.CreateDirectory("C:\\images\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create("C:\\images\\" + arquivo.FileName))
                    {
                        arquivo.CopyTo(fileStream);
                        fileStream.Flush();
                        return "C:\\images\\" + arquivo.FileName;
                    }
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            else
            {
                return "Arquivo com falha.....";
            }
        }
    }
}
