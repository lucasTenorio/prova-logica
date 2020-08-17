using System;
using System.Collections.Generic;
using System.Text;
using TAREFA2.Model;

namespace TAREFA2.Controller
{
    public class ControllerMapa
    {

        public static Mapa carregaCSV(string dado)
        {      
                string[] valores = dado.Split(";");
                Mapa m = new Mapa();
                m.Local = valores[0];
                m.popUltimoSenso = valores[1];

                return m;
            
        }

        public static void OrdenaBubleSort(ref List<Mapa> mapas)
        {
            for (int i = 1; i< mapas.Count; i++)
            {
                for (int t = 1; t < mapas.Count - 1; t++)
                {
                    if (Convert.ToInt32(mapas[t].popUltimoSenso) > Convert.ToInt32(mapas[t + 1].popUltimoSenso))
                    {
                        Mapa temp = mapas[t + 1];
                        mapas[t + 1] = mapas[t];
                        mapas[t] = temp;
                    }
                }
            }
        }
    }
}
