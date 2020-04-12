using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Models;
using ProjetoAPI.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{login}")]
        public String Gets(string login)
        {
            usuarioDAO user = new usuarioDAO();
            if (user.ValidaLogin(login))
            {
                return "OK";
            }
            else
            {
                return "NOK";
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Route("acessar")]
        public string Post([FromForm]Usuario usuario)
        {
            usuarioDAO user = new usuarioDAO();
            var val = user.ValidaUsuario(usuario);
            if (val)
            {
                Response.Redirect("https://fapen.edu.br");
                return "foi";
            }
            else
            {
                return "Usuario incorreto";
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody]Usuario usuario)
        {
            usuarioDAO user = new usuarioDAO();
            if (user.GravaUsuario(usuario) > 0)
            {
                return "Usuario inserido";
            }
            return "Usuario não inserido";
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            usuarioDAO user = new usuarioDAO();
            if (user.DeletaUsuario(id) != 0)
            {
                return "Usuario deletado";
            }
            else
            {
                return "Falha ao deletar";
            }
        }
    }
}
