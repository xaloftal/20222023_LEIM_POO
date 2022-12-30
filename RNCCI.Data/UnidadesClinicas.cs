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
        /// Lista de todas as unidades
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
                throw new DadosNulosException("RNCCI.Dados.UnidadesClinicas.Apaga");

            //a unidade tem de existir para ser eliminada
            if (!this.unidadesC.Exists(uc => uc.NumeroClinica.Equals(unidadeC.NumeroClinica)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesClinicas.Apaga");

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
                throw new DadosNulosException("RNCCI.Dados.UnidadesClinicas.Atualiza");

            //tem de existir
            if (!this.unidadesC.Exists(uc => uc.NumeroClinica.Equals(unidadeC.NumeroClinica)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesClinicas.Atualiza");

            //encontra na lista
            int index = unidadesC.FindIndex(uc => uc.NumeroClinica.Equals(unidadeC.NumeroClinica));

            //atualiza a unidade
            unidadesC[index] = unidadeC;
        }



        /// <summary>
        /// Lista unidades clinicas na consola
        /// </summary>
        /// <param name="unidadesC">lista de unidades a imprimir</param>
        public void ImprimeUnidadesClínicas(List<UnidadeClinica> unidadesC)
        {
            foreach (UnidadeClinica unidadeC in unidadesC)
                Console.WriteLine(unidadesC.ToString());
        }


        /// <summary>
        /// filtra os doentes por estado clinico
        /// </summary>
        /// <param name="registo">lista de registos de doentes</param>
        /// <param name="estado">estado a filtrar</param>
        /// <returns>lista de doentes em estado estado</returns>
        public List<Doente> ListaDoenteEstado(List<RegistoClinico> registo, EstadoClinico estado) => registo.Where(r => r.EstadoClinico.Equals(estado)).Select(r => r.Doente).ToList();



        /// <summary>
        /// filtra os doentes por tipologia de resposta atribuida a estes
        /// </summary>
        /// <param name="registosClinicos">registos clinicos dos doentes</param>
        /// <param name="unidadeFiltrada">tipologia de resposta a filtrar</param>
        /// <returns>lista de doentes na tipologia unidadeFiltrada</returns>
        public List<Doente> ListaTodosDoentesTipologia(List<RegistoClinico> registosClinicos, Tipologia unidadeFiltrada) => registosClinicos.Where(r => r.UnidadeClinica.Tipologia.Equals(unidadeFiltrada)).Select(r => r.Doente).ToList();



        /// <summary>
        /// imprime sos doentes que se encontram em lista de espera
        /// </summary>
        /// <param name="registo">registos clinicos de doentes</param>
        public void ImprimeListaEspera(List<RegistoClinico> registo)
        {
            List<Doente> doentes = this.ListaDoenteEstado(registo, EstadoClinico.EmEspera);

            foreach (Doente doente in doentes)
                Console.WriteLine(doentes.ToString());
        }


        /// <summary>
        /// listagem dos doentes internados por tipologia e as camas livres da tipologia
        /// </summary>
        /// <param name="registosClinicos">registos clinicos de doentes</param>
        /// <param name="unidadeFiltrada">tipologia a filtrar</param>
        public void ImprimeDoentesCamasLivresTipologia (List<RegistoClinico> registosClinicos, Tipologia unidadeFiltrada)
        {
            //vai buscar todos os doentes da tipologia
            List<Doente> doentes = this.ListaTodosDoentesTipologia(registosClinicos,unidadeFiltrada);

            //lista os doentes
            foreach(Doente doente in doentes)
                Console.WriteLine(doentes.ToString());

            //lista dos registos clinicos com a tipologia filtrada
            List<RegistoClinico> registosClinicosFiltrados = registosClinicos.Where(r => r.UnidadeClinica.Tipologia.Equals(unidadeFiltrada)).ToList();

            //agrupa as unidades pelo numero
            List<UnidadeClinica> unidadesClinicasAgrupadasNumero = registosClinicosFiltrados
                .GroupBy(r => r.UnidadeClinica.NumeroClinica) //agrupamos por n de clinica
                .Select(r => r.First()) //buscar primeiro elemento da lista (o resto n importa pq sao iguais)
                .Select(r => r.UnidadeClinica) //buscar a unidade do registo clinico
                .ToList();

            //imprime na consola. no ToString() de unidadeClinica tem as camas disponiveis
            foreach(UnidadeClinica unidadeClinica in unidadesClinicasAgrupadasNumero)
                Console.WriteLine(unidadeClinica.ToString());
        }



        /// <summary>
        /// metodo para escolher a unidade de internamento para o doente
        /// </summary>
        /// <param name="unidadesClinicas">lista de todas as unidades clinicas</param>
        /// <param name="registo">registo clinico do doente</param>
        /// <param name="tipologia">tipologia de resposta a ser admitido</param>
        /// <returns>unidade clinica escolhida</returns>
        /// <exception cref="CamasIndisponiveisException">nao ha camas livres na tipologia</exception>
        public UnidadeClinica EscolherUnidade(List<UnidadeClinica> unidadesClinicas, RegistoClinico registo, Tipologia tipologia)
        {
            //filtra as unidades pela tipologia de resposta
            List<UnidadeClinica> unidadeClinicasFiltradas = unidadesClinicas.Where(u => u.Tipologia.Equals(tipologia)).ToList();

            //ordena as unidades por numero de camas livres
            List<UnidadeClinica> ordenadoPorCamaLivre = unidadeClinicasFiltradas.OrderByDescending(u => u.Cama.Where(c => c.Livre).Count()).ToList();

            //lista de unidades candidatas a serem escolhidas
            List<UnidadeClinica> unidadesCandidatas = new List<UnidadeClinica>();

            //se nao houver camas livres
            if(ordenadoPorCamaLivre.Count.Equals(0))
                throw new CamasIndisponiveisException("RNCCI.Dados.UnidadesClinicas.EscolherUnidade");

            //a primeira aparicao sera sempre unidade candidata
            UnidadeClinica unidadeCandidata = ordenadoPorCamaLivre.First();

            //numero maior de camas livres
            int maxCamasLivres = unidadeCandidata.Cama.Where(c => c.Livre).Count(); 

            //variavel
            int start = 0;

            //verifica se o numero de camas livres e igual ou inferior ao numero maximo
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

            //se apenas um for igual
            if (unidadesCandidatas.Count() == 1)
                return unidadesCandidatas.First();

            //se tiver mais que uma unidade com o mesmo numero de camas livres, segue-se a escolha pela proximidade

            //lista com a distancia que tem do doente e a unidade clinica lado a lado
            List<Tuple<double, UnidadeClinica>> distancias = new List<Tuple<double, UnidadeClinica>>(); 


            //vai calcular as distancias entre a unidade clinica e a morada
            foreach (UnidadeClinica unidadeClinica in unidadesCandidatas)
                distancias.Add(new Tuple<double, UnidadeClinica>(
                    GeoCoordinates.DistanciaAte(unidadeClinica.Morada.Coordenadas, registo.Doente.Morada.Coordenadas),
                    unidadeClinica));

            //ordena pela menor distancia ate a maior, retornando a primeira instancia, mas apenas o Item2 do tuplo, sendo a unidade clinica escolhida
            return distancias.OrderBy(tuple => tuple.Item1).First().Item2; //item 1 é a distancia, item 2 é a unidade clinica
        }


        /// <summary>
        /// unidades filtradas pelo distrito
        /// </summary>
        /// <param name="unidades">lista das unidades</param>
        /// <param name="distrito">distrito a filtrar</param>
        /// <returns>lista de unidades clinicas pertencentes ao distrito distrito</returns>
        public List<UnidadeClinica> UnidadesDistrito (List<UnidadeClinica> unidades, Distrito distrito) => unidades.Where(u => u.Morada.Distrito.Equals(distrito)).ToList();



        /// <summary>
        /// unidades filtradas pela regiao
        /// </summary>
        /// <param name="unidades">lista de unidades</param>
        /// <param name="regiao">regiao a filtrar</param>
        /// <returns>lista das unidades da regiao regiao</returns>
        public List<UnidadeClinica> UnidadesRegiao(List<UnidadeClinica> unidades, Regiao regiao) => unidades.Where(u => u.Morada.Regiao.Equals(regiao)).ToList();
        


        /// <summary>
        /// imprime na consola o relatorio de ocupacao por distrito
        /// </summary>
        /// <param name="unidades">lista de unidades</param>
        /// <param name="distrito">distrito a listar</param>
        public void ListarUnidadesDistrito(List<UnidadeClinica> unidades, Distrito distrito)
        {
            //vai buscar a lista das unidades por distrito
            List<UnidadeClinica> unidadesDistrito = UnidadesDistrito(unidades, distrito);

            //variavel
            int camasLivres = 0;

            //adiciona a quantidade de camas livres de cada unidade 
            foreach (UnidadeClinica unidade in unidadesDistrito)
                camasLivres += unidade.Cama.Where(c => c.Livre).Count();

            //imprime na consola
            Console.WriteLine($"Relatorio de ocupacao do distrito {distrito}:\n");
            Console.WriteLine($"Camas disponiveis -> {camasLivres}");
            Console.WriteLine($"Numero de unidades -> {unidadesDistrito.Count}");
        }



        /// <summary>
        /// imprime na consola o relatorio de ocupacao por regiao
        /// </summary>
        /// <param name="unidades">lista de unidades</param>
        /// <param name="regiao">regiao a filtrar</param>
        public void ListarUnidadesRegiao(List<UnidadeClinica> unidades, Regiao regiao)
        {
            //busca a lista das unidades da regiao
            List<UnidadeClinica> unidadesRegiao = UnidadesRegiao(unidades, regiao);

            //variavel
            int camasLivres = 0;

            //numero total de camas livres de todas as unidades
            foreach (UnidadeClinica unidade in unidadesRegiao)
                camasLivres += unidade.Cama.Where(c => c.Livre).Count();

            //imprime na consola
            Console.WriteLine($"Relatorio de ocupacao da regiao {regiao}:\n");
            Console.WriteLine($"Camas disponiveis -> {camasLivres}");
            Console.WriteLine($"Numero de unidades -> {unidadesRegiao.Count}");
        }
    }
}
