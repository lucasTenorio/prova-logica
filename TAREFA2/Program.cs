using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;
using TAREFA2.Model;
using System.Linq;
using TAREFA2.Controller;

namespace TAREFA2
{
    class Program
    {
        static void Main(string[] args)
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

                    ControllerMapa.OrdenaBubleSort(ref lista);
                    string[] convertido = lista.Select(t => t.Local.ToString() + ";" + t.popUltimoSenso.ToString()).ToArray();
                    File.WriteAllLines(appConfig.Destino, convertido);

                    Console.WriteLine("Arquivo ordenado e salvo em Arquivo/mapa2.csv.");
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado no caminho "+ appConfig.Caminho);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
