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

        /// <summary>
        /// construtor
        /// </summary>
        public Medicos() => medicos.Add(new Medico { Nome = "Jose Maria", NumeroContribuinte = 4325 });


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
                throw new DadosNulosException("RNCCI.Dados.Medicos.Apaga");

            //tem de existir
            if (!this.medicos.Exists(m => m.CodigoMedico.Equals(medico.CodigoMedico)))
                throw new DadoNaoExisteException("RNCCI.Dados.Medicos.Apaga");

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
                throw new DadosNulosException("RNCCI.Dados.Medicos.Atualiza");

            //tem de existir
            if (!this.medicos.Exists(m => m.CodigoMedico.Equals(medico.CodigoMedico)))
                throw new DadoNaoExisteException("RNCCI.Dados.Medicos.Atualiza");

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
                Console.WriteLine(medicos.ToString());
        }


        /// <summary>
        /// permite escolher a tipologia do doente conforme o seu diagnostico
        /// </summary>
        /// <param name="registo">registo do doente</param>
        /// <returns>tipologia a que o doente vai ser encaminhado</returns>
        /// <exception cref="DadoNaoPrevistoException">diagnostico nao for um dos previstos</exception>
        public Tipologia EscolherTipologia(RegistoClinico registo)
        {
            switch (registo.Diagnostico)
            {
                case Doenca.Covid:
                case Doenca.Pneumonia:
                case Doenca.Anemia:
                    return Tipologia.UnidadeDeCovalescenca;

                case Doenca.Zika:
                case Doenca.HIV:
                case Doenca.Cancro:
                    return Tipologia.UnidadeDeLongaDuracaoEManutencao;

                case Doenca.Hepatite:
                case Doenca.Osteoporose:
                case Doenca.Diabetes:
                    return Tipologia.EquipaDomiciliariaDeCuidadosContinuidadesIntegrados;


                case Doenca.InsuficienciaCardiaca:
                case Doenca.Paralisia:
                case Doenca.Parkinson:
                    return Tipologia.UnidadeDeMediaDuracaoEReabilitacao;
                   
                default:
                    throw new DadoNaoPrevistoException("RNCCI.Dados.Medicos.EscolherTipologia");
            }
        }
    }
}
