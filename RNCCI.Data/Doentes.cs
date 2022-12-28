using RNCCI.Enums;
using RNCCI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Dados
{
    public class Doentes
    {

        List<Doente> doentes = new List<Doente>();

        public Doentes()
        {
            doentes.Add(new Doente { Nome = "Manel Figueiras", NumeroContribuinte = 4325, });


        }
    }
}
