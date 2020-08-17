using System;
using System.Collections.Generic;
using System.Text;
using TAREFA1.Model;

namespace TAREFA1.Controller
{
    public class ControllerMapa
    {

        public static Mapa carregaCSV(string dado)
        {

                string[] valores = dado.Split(";");
                Mapa m = new Mapa();
                m.Local = valores[0];
                int inteiro;
                bool checa = Int32.TryParse(valores[1], out inteiro);
                if (checa)
                    m.popUltimoSenso = (inteiro * 2).ToString();
                else
                    m.popUltimoSenso = valores[1];

                return m;
        }
    }
}
