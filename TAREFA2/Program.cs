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

                List<Mapa> lista = File.ReadAllLines(appConfig.Caminho)
                                       .Select(l => ControllerMapa.carregaCSV(l))
                                       .ToList();

                ControllerMapa.OrdenaBubleSort(ref lista);
                string[] convertido = lista.Select(t => t.Local.ToString() + ";" + t.popUltimoSenso.ToString()).ToArray();
                File.WriteAllLines(appConfig.Destino, convertido);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
