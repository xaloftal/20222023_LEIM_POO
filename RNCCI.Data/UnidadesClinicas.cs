using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Modelos;
using RNCCI.Excecoes;
using RNCCI.Enums;

namespace RNCCI.Dados
{
    public class UnidadesClinicas
    {
        //lista
        List<UnidadeClinica> unidadesC = new List<UnidadeClinica>();

        /// <summary>
        /// constructor
        /// </summary>
        public UnidadesClinicas()
        {
            unidadesC.Add(new UnidadeClinica() { Nome = "Sorriso" });
            unidadesC.Add(new UnidadeClinica() { Nome = "Vida"});
        }

        //metodos

        /// <summary>
        /// Lista todas as unidades
        /// </summary>
        public List<UnidadeClinica> ListaUC => this.unidadesC;

        /// <summary>
        /// usar este metodo para a insersao de novas clinicas
        /// </summary>
        /// <param name="novaClinica">nova clinica a ser inserida no sistema</param>
        /// <exception cref="DadosNulosException">se os dados a serem inseridos sao nulos, a insercao não é possivel</exception>
        /// <exception cref="DadoJaExisteException">se a clinica ja existe no sistema nao pode ser inserida novamente</exception>
        public void Add(UnidadeClinica novaClinica)
        {
            //não pode ser nulo
            if (novaClinica is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesClinicas.Add");

            //verificar se a clinica já existe na clinica
            if (this.unidadesC.Exists(u => u.NumeroClinica.Equals(novaClinica.NumeroClinica)))
                throw new DadoJaExisteException("RNCCI.Dados.UnidadesClinicas.Add");

            //adiciona
            this.unidadesC.Add(novaClinica);
        }

        /// <summary>
        /// eliminar unidades clinicas
        /// </summary>
        /// <param name="unidadeC">unidade clinica a ser eliminada</param>
        /// <exception cref="DadosNulosException">unidadeC e nulo</exception>
        /// <exception cref="DadoNaoExisteException">a unidade a ser eliminada nao existe</exception>
        public void Apaga(UnidadeClinica unidadeC)
        {
            //não pode ser nulo
            if (unidadeC is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesClinicas.Delete");

            //a unidade tem de existir para ser eliminada
            if (!this.unidadesC.Exists(uc => uc.NumeroClinica.Equals(unidadeC.NumeroClinica)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesClinicas.Delete");

            //encontra o index da unidade na lista
            int index = unidadesC.FindIndex(dcci => dcci.NumeroClinica.Equals(unidadeC.NumeroClinica));

            //remove a unidade
            unidadesC.RemoveAt(index);
        }

        /// <summary>
        /// atualiza uma clinica 
        /// </summary>
        /// <param name="unidadeC">clinica com as informacoes novas a serem atualizadas</param>
        /// <exception cref="DadosNulosException">unidadeC e nulo</exception>
        /// <exception cref="DadoNaoExisteException">a clinica a ser atualizada nao existe</exception>
        public void Atualiza(UnidadeClinica unidadeC)
        {
            //não pode ser nulo
            if (unidadeC is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesClinicas.Update");

            //tem de existir
            if (!this.unidadesC.Exists(uc => uc.NumeroClinica.Equals(unidadeC.NumeroClinica)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesClinicas.Update");

            //encontra na lista
            int index = unidadesC.FindIndex(uc => uc.NumeroClinica.Equals(unidadeC.NumeroClinica));

            //atualiza a unidade
            unidadesC[index] = unidadeC;
        }

        /// <summary>
        /// Lista unidades clinicas
        /// </summary>
        /// <param name="unidadesC"></param>
        public void ListarTodosOsUnidadesClínicas(List<UnidadeClinica> unidadesC)
        {
            foreach (UnidadeClinica unidadeC in unidadesC)
            {
                Console.WriteLine(unidadesC.ToString());
            }
        }

        public List<Doente> ListaDoenteEstado(List<RegistoClinico> registo, EstadoClinico estado) => registo.Where(r => r.EstadoClinico.Equals(estado)).Select(r => r.Doente).ToList();


        public List<Doente> ListaTodosOsDoentesTipologia(List<RegistoClinico> registosClinicos, Tipologia unidadeFiltrada) => registosClinicos.Where(r => r.UnidadeClinica.Tipologia.Equals(unidadeFiltrada)).Select(r => r.Doente).ToList();


        public void ImprimeListaEspera(List<RegistoClinico> registo)
        {
            List<Doente> doentes = this.ListaDoenteEstado(registo, EstadoClinico.EmEspera);

            foreach (Doente doente in doentes)
                Console.WriteLine(doentes.ToString());
        }


        public void ImprimeDoentesCamasLivresTipologia (List<RegistoClinico> registosClinicos, Tipologia unidadeFiltrada)
        {
            List<Doente> doentes = this.ListaTodosOsDoentesTipologia(registosClinicos,unidadeFiltrada);

            foreach(Doente doente in doentes)
            {
                Console.WriteLine(doentes.ToString());
            }

            List<RegistoClinico> registosClinicosFiltrados = registosClinicos.Where(r => r.UnidadeClinica.Tipologia.Equals(unidadeFiltrada)).ToList();
            List<UnidadeClinica> unidadesClinicasAgrupadasNumero = registosClinicosFiltrados
                .GroupBy(r => r.UnidadeClinica.NumeroClinica) //agrupamos por n de clinica
                .Select(r => r.First()) //buscar primeiro elemento da lista (o resto n importa pq sao iguais)
                .Select(r => r.UnidadeClinica) //buscar a unidade do registo clinico
                .ToList();

            foreach(UnidadeClinica unidadeClinica in unidadesClinicasAgrupadasNumero)
            {
                Console.WriteLine(unidadeClinica.ToString());
            }

        }


        public UnidadeClinica EscolherUnidade(RegistoClinico registo, Tipologia tipologia)
        {
            //filtrar unidades por tipologia
            //verificar qual unidade 
        }
    }
}
