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
            medicos.Add(new Medico { Nome = "Jose Maria", NumeroContribuinte = 4325});


        }

        //metodos


        /// <summary>
        /// adiciona um medico novo ao sistema
        /// </summary>
        /// <param name="novoMedico">medico novo a adicionar</param>
        /// <exception cref="DadosNulosException">novoMedico nulo</exception>
        /// <exception cref="DadoJaExisteException">medico ja existe</exception>
        public void Add(Medico novoMedico)
        {
            //não pode ser nulo
            if (novoMedico is null)
                throw new DadosNulosException("RNCCI.Dados.Medicos.Add");

            //nao pode existir
            if (this.medicos.Exists(m => m.CodigoMedico.Equals(novoMedico.CodigoMedico)))
                throw new DadoJaExisteException("RNCCI.Dados.Medicos.Add");

            //adiciona
            this.medicos.Add(novoMedico);
        }

        /// <summary>
        /// eliminar um medico
        /// </summary>
        /// <param name="medico"></param>
        /// <exception cref="DadosNulosException">medico a eliminar nulo</exception>
        /// <exception cref="DadoNaoExisteException">medico nao existe no sistema</exception>
        public void Apaga(Medico medico)
        {
            //não pode ser nulo
            if (medico is null)
                throw new DadosNulosException("RNCCI.Dados.Medicos.Delete");

            //tem de existir
            if (!this.medicos.Exists(m => m.CodigoMedico.Equals(medico.CodigoMedico)))
                throw new DadoNaoExisteException("RNCCI.Dados.Medicos.Delete");

            //encontra na lista
            int index = medicos.FindIndex(m => m.CodigoMedico.Equals(medico.CodigoMedico));

            //apaga
            medicos.RemoveAt(index);
        }


        /// <summary>
        /// atualizar a informacao de um medico 
        /// </summary>
        /// <param name="medico">medico com os dados atualizados</param>
        /// <exception cref="DadosNulosException">medico nulo</exception>
        /// <exception cref="DadoNaoExisteException">medico a atualizar nao existe</exception>
        public void Atualiza(Medico medico)
        {
            //não pode ser nulo
            if (medico is null)
                throw new DadosNulosException("RNCCI.Dados.Medicos.Update");

            //tem de existir
            if (!this.medicos.Exists(m => m.CodigoMedico.Equals(medico.CodigoMedico)))
                throw new DadoNaoExisteException("RNCCI.Dados.Medicos.Update");

            //encontra na lista
            int index = medicos.FindIndex(m => m.CodigoMedico.Equals(medico.CodigoMedico));

            //atualiza a unidade
            medicos[index] = medico;
        }



        /// <summary>
        /// lista todos os medicos do sistema
        /// </summary>
        /// <param name="medicos">medicos do sistema</param>
        public void ListarTodosOsMedicos(List<Medico> medicos)
        {
            foreach (Medico medico in medicos)
            {
                Console.WriteLine(medicos.ToString());
            }
        }


        public Tipologia EscolherTipologia(RegistoClinico registo)
        {
            switch (registo.Diagnostico)
            {
                case Doencas.Covid:
                case Doencas.Pneumonia:
                case Doencas.Anemia:
                    return Tipologia.UnidadeDeCovalescenca;

                case Doencas.Zika:
                case Doencas.HIV:
                case Doencas.Cancro:
                    return Tipologia.UnidadeDeLongaDuracaoEManutencao;

                case Doencas.Hepatite:
                case Doencas.Osteoporose:
                case Doencas.Diabetes:
                    return Tipologia.EquipaDomiciliariaDeCuidadosContinuidadesIntegrados;


                case Doencas.InsuficienciaCardiaca:
                case Doencas.Paralisia:
                case Doencas.Parkinson:
                    return Tipologia.UnidadeDeMediaDuracaoEReabilitacao;
                   
                default:
                    throw new DadoNaoPrevistoException("RNCCI.Dados.Medicos.EscolherTipologia");
            }
        }
    }
}
