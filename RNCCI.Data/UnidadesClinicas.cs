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


        public UnidadeClinica EscolherUnidade(List<UnidadeClinica> unidadesClinicas, RegistoClinico registo, Tipologia tipologia)
        {
            List<UnidadeClinica> unidadeClinicasFiltradas = unidadesClinicas.Where(u => u.Tipologia.Equals(tipologia)).ToList();

            List<UnidadeClinica> ordenadoPorCamaLivre = unidadeClinicasFiltradas.OrderByDescending(u => u.Cama.Where(c => c.Livre).Count()).ToList();

            List<UnidadeClinica> unidadesCandidatas = new List<UnidadeClinica>();

            if(ordenadoPorCamaLivre.Count == 0)
                throw new CamasIndisponiveisException("RNCCI.Dados.UnidadesClinicas.EscolherUnidade");

            UnidadeClinica unidadeCandidata = ordenadoPorCamaLivre.First();

            int maxCamasLivres = unidadeCandidata.Cama.Where(c => c.Livre).Count(); 

            unidadesCandidatas.Add(ordenadoPorCamaLivre.First());

            int start = 1;

            while(start < ordenadoPorCamaLivre.Count())
            {
                if (ordenadoPorCamaLivre[start].Cama.Where(c => c.Livre).Count() == maxCamasLivres) 
                {
                    unidadesCandidatas.Add(ordenadoPorCamaLivre[start]);
                    start++;
                }
                else
                    break;
            }

            if (unidadesCandidatas.Count() == 1)
                return unidadesCandidatas.First();

            List<Tuple<double, UnidadeClinica>> distancias = new List<Tuple<double, UnidadeClinica>>(); //lista com a distancia que tem do doente e a unidade clinica lado a lado

            foreach (UnidadeClinica unidadeClinica in unidadesCandidatas)
            {
                distancias.Add(new Tuple<double, UnidadeClinica>(
                    GeoCoordinates.DistanceTo(unidadeClinica.Morada.Coordenadas, registo.Doente.Morada.Coordenadas),
                    unidadeClinica));

            }

            return distancias.OrderBy(tuple => tuple.Item1).First().Item2; //item 1 é a distancia, item 2 é a unidade clinica
        }

        public List<UnidadeClinica> UnidadesDistrito (List<UnidadeClinica> unidades, Distrito distrito) //
        {
           return unidades.Where(u => u.Morada.Distrito.Equals(distrito)).ToList();

        }
        public List<UnidadeClinica> UnidadesRegiao(List<UnidadeClinica> unidades, Regiao regiao) //
        {
           return unidades.Where(u => u.Morada.Regiao.Equals(regiao)).ToList();

        }
        public void ListarUnidadesDistrito(List<UnidadeClinica> unidades, Distrito distrito)
        {

            List<UnidadeClinica> unidadesDistrito = UnidadesDistrito(unidades, distrito);
            int camasLivres = 0;

            foreach (UnidadeClinica unidade in unidadesDistrito)
            {
                camasLivres += unidade.Cama.Where(c => c.Livre).Count();

            }

            Console.WriteLine($"Relatorio de ocupacao do distrito {distrito}:\n");
            Console.WriteLine($"Camas disponiveis -> {camasLivres}");
            Console.WriteLine($"Numero de unidades -> {unidadesDistrito.Count}");
        }

        public void ListarUnidadesRegiao(List<UnidadeClinica> unidades, Regiao regiao)
        {

            List<UnidadeClinica> unidadesRegiao = UnidadesRegiao(unidades, regiao);
            int camasLivres = 0;

            foreach (UnidadeClinica unidade in unidadesRegiao)
            {
                camasLivres += unidade.Cama.Where(c => c.Livre).Count();

            }

            Console.WriteLine($"Relatorio de ocupacao da regiao {regiao}:\n");
            Console.WriteLine($"Camas disponiveis -> {camasLivres}");
            Console.WriteLine($"Numero de unidades -> {unidadesRegiao.Count}");
        }
    }
}
