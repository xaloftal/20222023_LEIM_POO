using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Modelos;
using RNCCI.Enums;
using RNCCI.Excecoes;


namespace RNCCI.Dados
{
    public class Medicos
    {
        //variaveis
        List<Medico> medicos = new List<Medico>();

        public Medicos()
        {
            medicos.Add(new Medico { Nome = "Jose Maria", NumeroContribuinte = 4325, Especialidade = Tipologia.UnidadeDeMediaDuracaoEReabilitacao});


        }

        /// <summary>
        /// metodo para atribuir o medico a lista das unidades
        /// </summary>
        Action<Medico> AtribuirAUnidade { get; set; } = (medico) =>
        {

            switch (medico.Especialidade)
            {
                case Tipologia.UnidadeDeCovalescenca:
                  //UnidadesDeCovalescenca.Medicos.Add(medico); adicionar medico desta tipologia
                    break;

                case Tipologia.UnidadeDeMediaDuracaoEReabilitacao:

                    break;

                case Tipologia.UnidadeDeLongaDuracaoEManutencao:

                    break;

                case Tipologia.EquipaDomiciliariaDeCuidadosContinuidadesIntegrados:

                    break;

                default:
                    throw new DadoNaoPrevistoException("RNCCI.Data.Medicos.AtribuirAUnidade");
                    
            }
        };

        public void ListarTodosOsMedicos(List<Medico> medicos)
        {
            foreach (Medico medico in medicos)
            {
                Console.WriteLine(medicos.ToString());
            }
        }
    }
}
