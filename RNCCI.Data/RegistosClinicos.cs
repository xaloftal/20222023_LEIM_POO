using RNCCI.Enums;
using RNCCI.Excecoes;
using RNCCI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Dados
{
    public class RegistosClinicos
    {

        List<RegistoClinico> registosClinicos = new List<RegistoClinico>();

        /// <summary>
        /// construtor
        /// </summary>
        public RegistosClinicos()
        {

            registosClinicos.Add(new RegistoClinico
            {
                Diagnostico = Enums.Doencas.Covid,
                DataAdmissao = new DateOnly(2020, 1, 1),
                EstadoClinico = Enums.EstadoClinico.Internado,
                UnidadeClinica = new UnidadeClinica
                {
                    Nome = "Vida",
                    Tipologia = Tipologia.UnidadeDeMediaDuracaoEReabilitacao
                },
                Doente = new Doente
                {
                    Nome = "Manel Figueiras",
                    NumeroContribuinte = 4325,
                    NumeroTelemovel = 934656324
                }
            });

        }

        /// <summary>
        /// Adicionar novo registo clinico
        /// </summary>
        /// <param name="novoRegistoClinico">novo registo clinico</param>
        /// <exception cref="DadosNulosException">quando o novoRegistoClinico é nulo</exception>
        /// <exception cref="DadoJaExisteException">quando o novoRegistoClinico não é nulo</exception>
        public void Add(RegistoClinico novoRegistoClinico)
        {
            //não pode ser nulo
            if (novoRegistoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Add");

            //nao pode existir
            if (this.registosClinicos.Exists(ldm => ldm.NumeroRegisto.Equals(novoRegistoClinico.NumeroRegisto)))
                throw new DadoJaExisteException("RNCCI.Dados.RegistosClinicos.Add");

            //adiciona
            this.registosClinicos.Add(novoRegistoClinico);
        }

        /// <summary>
        /// Eliminar um registo clinico
        /// </summary>
        /// <param name="registoClinico">um registo clinico</param>
        /// <exception cref="DadosNulosException">quando o registoClinico é nulo</exception>
        /// <exception cref="DadoNaoExisteException">quando o registoClinico não é nulo</exception>
        public void Delete(RegistoClinico registoClinico)
        {
            //não pode ser nulo
            if (registoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Delete");

            //tem de existir
            if (!this.registosClinicos.Exists(ldm => ldm.NumeroRegisto.Equals(registoClinico.NumeroRegisto)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosClinicos.Delete");

            //encontra na lista
            int index = registosClinicos.FindIndex(ldm => ldm.NumeroRegisto.Equals(registoClinico.NumeroRegisto));

            //apaga
            registosClinicos.RemoveAt(index);
        }

        /// <summary>
        /// Atualizar um registo clinico
        /// </summary>
        /// <param name="registoClinico">um registo clinico</param>
        /// <exception cref="DadosNulosException">quando o registoClinico não existe</exception>
        /// <exception cref="DadoNaoExisteException">quando o registoClinico não é nulo</exception>
        public void Update(RegistoClinico registoClinico)
        {
            //não pode ser nulo
            if (registoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Update");

            //tem de existir
            if (!this.registosClinicos.Exists(ldm => ldm.NumeroRegisto.Equals(registoClinico.NumeroRegisto)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosClinicos.Update");

            //encontra na lista
            int index = registosClinicos.FindIndex(ldm => ldm.NumeroRegisto.Equals(registoClinico.NumeroRegisto));

            //atualiza a unidade
            registosClinicos[index] = registoClinico;
        }

        /// <summary>
        /// Lista todos os registos clinicos
        /// </summary>
        /// <param name="registoClinicos">todos os registos clinicos</param>
        private void ListarRegistosClinicos(List<RegistoClinico> registoClinicos)
        {
            foreach (RegistoClinico registoClinico in registoClinicos)
            {
                Console.WriteLine(registoClinicos.ToString());
            }
        }

        /// <summary>
        /// Cria a lista os doentes, as unidades e tipologias e a quantidade de camas disponíveis nestes
        /// </summary>
        /// <param name="unidadeFiltrada">unidade correspondente à do doente</param>
        /// <returns>retorna a lista de todos os doentes filtrados por tipologia</returns>
        private List<RegistoClinico> ListaTodosOsDoentesTipologia(List<RegistoClinico> registoClinico, Tipologia unidadeFiltrada) => this.registosClinicos.Where(r => r.UnidadeClinica.Tipologia.Equals(unidadeFiltrada)).ToList();


        /// <summary>
        /// usa este metodo para listar todos os registos
        /// </summary>
        /// <param name="registosClinicos">registos clinicos</param>
        public void ListaTodosRegistos(List<RegistoClinico> registosClinicos) => ListarRegistosClinicos(registosClinicos);


        /// <summary>
        /// use este metodo para listar os registos de unidades individuais
        /// </summary>
        /// <param name="registosClinicos">registos clinicos</param>
        /// <param name="tipologiaAFiltrar">unidade a filtrar</param>
        public void ListaRegistosPorTipologia (List<RegistoClinico> registosClinicos, Tipologia tipologiaAFiltrar)
        {
            //filtra a lista
            List<RegistoClinico> registoFiltrado = ListaTodosOsDoentesTipologia(registosClinicos, tipologiaAFiltrar);

            //Listar os registos ja filtrados
            ListarRegistosClinicos(registoFiltrado);
        }

    }
}
