using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;
using TAREFA1.Model;
using System.Collections.Generic;
using System.Linq;
using TAREFA1.Controller;
using System.Text;

namespace TAREFA1
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

                if(File.Exists(appConfig.Caminho))
                {
                    List<Mapa> lista = File.ReadAllLines(appConfig.Caminho)
                                        .Select(l => ControllerMapa.carregaCSV(l))
                                        .ToList();
                    string[] convertido = lista.Select(t => t.Local + ";" + t.popUltimoSenso).ToArray();
                    
                    File.WriteAllLines(appConfig.Destino, convertido);
                    Console.WriteLine("Novo arquivo gerado mapa2.csv");
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado no caminho "+ appConfig.Caminho);
                } 
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
