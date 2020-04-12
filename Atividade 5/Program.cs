using System;
using System.IO;
using System.Net;
using System.Text;

namespace Atividade_5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            using (StreamWriter writer = new StreamWriter("AulaFapen.txt"))
            {
                writer.WriteLine("Estamos utilizando a classe StreamWriter para escrever esse código!");
            }

            string linha = "";

            using (StreamReader reader = new StreamReader("AulaFapen.txt"))
            {
                linha = reader.ReadLine();
            }

            Console.WriteLine(linha);
            */
            Post();
        }
        private static void Post()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:44394/api/login/acessar");
            var postData = "{ Login: 'Tiago', senha: '102030' }";
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine("A resposta do método POST é: " + responseString);
        }
    }
}
