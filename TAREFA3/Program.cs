using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TAREFA3.Controller;
using TAREFA3.Model;

namespace TAREFA3
{
    class Program
    {
        static void Main()
        {
            try 
            {
                var construtor = new ConfigurationBuilder()
                                     .SetBasePath(Directory.GetCurrentDirectory())
                                     .AddJsonFile("appsettings.json")
                                     .Build();

                var appConfig = construtor.GetSection("configuracaoCaminho").Get<AplicacaoConfig>();

                List<Endereco> list = File.ReadAllLines(appConfig.Caminho)
                                           .Select(d => EnderecoController.CarregaArquivo(d))
                                           .ToList();
                for (int i = 1; i < list.Count; i++)
                {
                    list[i] = EnderecoController.ConsultaCep(list[i], appConfig.UrlCep).Result;
                }

                string[] convertido = list.Select(t => t.Cep + ";"
                                                       + t.Logradouro + ";"
                                                       + t.Complemento + ";"
                                                       + t.Bairro + ";"
                                                       + t.Localidade + ";"
                                                       + t.Uf + ";"
                                                       + t.Unidade + ";"
                                                       + t.Ibge + ";"
                                                       + t.Gia + ";").ToArray();

                File.WriteAllLines(appConfig.Destino, convertido);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
