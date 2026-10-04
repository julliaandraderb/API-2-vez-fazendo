using APIS___2_VEZ_fazendo.Data;
using APIS___2_VEZ_fazendo.DTOs;
using Microsoft.AspNetCore.Mvc;
using APIS___2_VEZ_fazendo.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace APIS___2_VEZ_fazendo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuariosController : ControllerBase
    {
        private AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuarios = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult Post(UsuariosDTOs UsuariosDTO)
        {
            var cadastrar = new Usuario
            {
                Nome = UsuariosDTO.Nome,
                Idade = UsuariosDTO.Idade,
                Serie = UsuariosDTO.Serie,
                Email = UsuariosDTO.Email,
                Senha = UsuariosDTO.Senha
            };
            _context.Usuarios.Add(cadastrar);
            _context.SaveChanges();
            return Ok(cadastrar);
        }

        [HttpPut]
        public IActionResult Put(int id, UsuariosDTOs usuarios)
        {
            var atualizar = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (atualizar == null)
            {
                return NotFound();
            }
            atualizar.Nome = usuarios.Nome;
            atualizar.Idade = usuarios.Idade;
            atualizar.Serie = usuarios.Serie;
            atualizar.Email = usuarios.Email;
            atualizar.Senha = usuarios.Senha;

            _context.SaveChanges();
            return Ok(usuarios);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var apagar = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (apagar == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(apagar);
            _context.SaveChanges();
            return Ok(apagar);
        }


        [HttpGet("media")]
        public async Task<ActionResult<double>> GetDouble()
        {
            var media = await _context.Usuarios.AverageAsync(u => u.Idade);
            return Ok(media);

        }

        [HttpGet("numero")]
        public async Task<ActionResult<double>> GetNumero(int numero)
        {
            var resultado = (numero % 2 == 0) ? "Par" : "Ímpar";
            return Ok(resultado);

        }

        [HttpGet("ordena")]
        public async Task<ActionResult> ListarOMaior()
        {
            var ordenar = await _context.Usuarios.Where(u => u.Idade > 16).OrderBy(u => u.Idade).Select(u => new
            { u.Idade,
                u.Nome,
                u.Id })
             .ToListAsync();
            return Ok(ordenar);
        }

        [HttpGet("Maior/Menor")]
        public async Task<ActionResult> MaiorMenor()
        {
            var menor = await _context.Usuarios.OrderBy(u => u.Idade).Select(u => new
            {
                u.Idade,
                u.Nome,
                u.Id
            }).FirstOrDefaultAsync();
            var maior = await _context.Usuarios.OrderByDescending(u => u.Idade).Select(u => new
            {
                u.Idade,
                u.Nome,
                u.Id
            }).FirstOrDefaultAsync();
            return Ok(
                new
                {
                    maior,
                    menor
                }
            );
        }

        [HttpGet("idade")]
        public async Task<ActionResult> Idade()
        {
            var Velho = _context.Usuarios.Where(u => u.Idade >= 60 && u.Idade <= 100).Select(u => new
            {
                u.Idade,
                u.Nome,
                u.Id,
                Classificacao = "Velho"
            });
            var Mediano = _context.Usuarios.Where(u => u.Idade >= 30 && u.Idade < 60).Select(u => new
            {
                u.Idade,
                u.Nome,
                u.Id,
                Classificacao = "Mediano"
            });
            var Novo = _context.Usuarios.Where(u => u.Idade >= 1 && u.Idade < 30).Select(u => new
            {
                u.Idade,
                u.Nome,
                u.Id,
                Classificacao = "Novo"
            });

            return Ok(
                new
                {
                    Mediano,
                    Novo,
                    Velho
                }
            );
        }

        [HttpGet("5Primeiros")]
        public async Task<ActionResult> Primeiros()
        {
            var cinco = _context.Usuarios.Take(5).ToList().OrderBy(u => u.Idade).Select(u => new
            {
                u.Idade,
                u.Nome,
                u.Id
            });
            return Ok(cinco);
        }

        [HttpGet("Agrupe")]
        public async Task<ActionResult> Agrupar()
        {
            var agrupe17 = _context.Usuarios.Where(u => u.Idade == 17).Select(u => new
            {
                u.Idade,
                u.Nome,
                u.Id
            }).Count();
            var agrupe18 = _context.Usuarios.Where(u => u.Idade == 18).Count();

            return Ok(new
            {
                agrupe17,
                agrupe18
            });
        }
    }
}