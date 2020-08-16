using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TAREFA3.Model;
using System.Linq;
using Newtonsoft.Json;

namespace TAREFA3.Controller
{
    public class EnderecoController 
    {
        private static readonly HttpClient client = new HttpClient();
        public static Endereco CarregaArquivo(string dados)
        {
            Endereco end = new Endereco();
            var arrayDados = dados.Split(";");
            end.Cep = arrayDados[0];
            end.Logradouro = arrayDados[1];
            end.Complemento = arrayDados[2];
            end.Bairro = arrayDados[3];
            end.Localidade = arrayDados[4];
            end.Uf = arrayDados[5];
            end.Unidade = arrayDados[6];
            end.Ibge = arrayDados[7];
            end.Gia = arrayDados[8];

            return end;
        }

        public static async Task<Endereco> ConsultaCep(Endereco end, string path)
        {
            end.Cep = end.Cep.Replace(" ", "");
            end.Cep = end.Cep.Replace("-", "");
            if (end.Cep.Length == 8 && end.Cep.Any(l => !char.IsLetter(l)))
            {
                HttpResponseMessage response = await client.GetAsync(path+end.Cep+"/json");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    end = JsonConvert.DeserializeObject<Endereco>(res);
                    return end;
                }
                else
                {
                    Console.WriteLine("Erro");
                    return end;
                }
            }
            else
            {
                return end;
            }
        }
    }
}
