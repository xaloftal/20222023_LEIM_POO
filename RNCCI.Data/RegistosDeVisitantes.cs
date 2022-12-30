using Newtonsoft.Json.Bson;
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
    public class RegistosDeVisitantes
    {
        //variaveis
        List<RegistoDeVisitantes> registosVisitantes = new List<RegistoDeVisitantes>();

        /// <summary>
        /// construtor
        /// </summary>
        public RegistosDeVisitantes()
        {
            registosVisitantes.Add(new RegistoDeVisitantes
            {
                Visitante = new Visitante
                {
                    Nome = "Maria Figueiras",
                    NumeroContribuinte = 4375,
                    NumeroTelemovel = 934659324
                },
                RegistoClinico = new RegistoClinico
                {
                    Doente = new Doente
                    {
                        Nome = "Manel Figueiras",
                        NumeroContribuinte = 4325,
                        NumeroTelemovel = 934656324
                    }
                }
            });

        }

        //metodos


        /// <summary>
        /// adiciona um registo de visitantes
        /// </summary>
        /// <param name="novoRegistoDeVisitantes"></param>
        /// <exception cref="DadosNulosException"></exception>
        /// <exception cref="DadoJaExisteException"></exception>
        public void Add(RegistoDeVisitantes novoRegistoVisitantes)
        {
            //não pode ser nulo
            if (novoRegistoVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeVisitantes.Add");

            //nao pode existir
            if (this.registosVisitantes.Exists(rv => rv.NumeroRV.Equals(novoRegistoVisitantes.NumeroRV)))
                throw new DadoJaExisteException("RNCCI.Dados.RegistosDeVisitantes.Add");

            //adiciona
            this.registosVisitantes.Add(novoRegistoVisitantes);
        }


        /// <summary>
        /// apaga um registo do sistema
        /// </summary>
        /// <param name="registoVisitantes">registo a eliminar</param>
        /// <exception cref="DadosNulosException">registoVisitantes e nulo</exception>
        /// <exception cref="DadoNaoExisteException">registo a eliminar nao existe no sistema</exception>
        public void Apaga(RegistoDeVisitantes registoVisitantes)
        {
            //não pode ser nulo
            if (registoVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.RegistoDeVisitantes.Apaga");

            //tem de existir
            if (!this.registosVisitantes.Exists(rv => rv.NumeroRV.Equals(registoVisitantes.NumeroRV)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistoDeVisitantes.Apaga");

            //encontra na lista
            int index = registosVisitantes.FindIndex(rv => rv.NumeroRV.Equals(registoVisitantes.NumeroRV));

            //apaga
            registosVisitantes.RemoveAt(index);
        }


        /// <summary>
        /// atualiza um registo no sistema
        /// </summary>
        /// <param name="registoVisitantes">registo com as informacoes atualizadas</param>
        /// <exception cref="DadosNulosException">registoVisitantes e nulo</exception>
        /// <exception cref="DadoNaoExisteException">registo a atualizar nao existe no sistema</exception>
        public void Atualiza(RegistoDeVisitantes registoVisitantes)
        {
            //não pode ser nulo
            if (registoVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeVisitantes.Update");

            //tem de existir
            if (!this.registosVisitantes.Exists(rv => rv.NumeroRV.Equals(registoVisitantes.NumeroRV)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosDeVisitantes.Update");

            //encontra na lista
            int index = registosVisitantes.FindIndex(rv => rv.NumeroRV.Equals(registoVisitantes.NumeroRV));

            //atualiza a unidade
            registosVisitantes[index] = registoVisitantes;
        }


        /// <summary>
        /// lista registos na consola 
        /// </summary>
        /// <param name="registosVisitantes">lista de registos a imprimir</param>
        public void ListarRegistoVisitantes(List<RegistoDeVisitantes> registosVisitantes)
        {
            foreach (RegistoDeVisitantes registo in registosVisitantes)
                Console.WriteLine(registosVisitantes.ToString());
        }



        /// <summary>
        /// regista a admissao de um visitante
        /// </summary>
        /// <param name="doente">doente a visitar</param>
        /// <param name="visitante">visitante</param>
        /// <param name="entrada">data e hora que entra</param>
        /// <param name="saida">data e hora que sai</param>
        /// <exception cref="VisitanteNaoAutorizadoException"></exception>
        public void RegistarAdmissao(RegistoClinico doente, Visitante visitante, DateTime entrada, DateTime saida)
        {
            //verifica se o visitante pertence a lista de visitantes autorizados do doente
            if (!doente.Doente.VisitantesAutorizados.ToList().Exists(v => v.NumeroVisitante.Equals(visitante.NumeroVisitante)))
                throw new VisitanteNaoAutorizadoException("RNCCI.Dados.RegistosDeVisitantes.RegistarAdmissao");

            //cria um novo registo
            RegistoDeVisitantes registoVisitantes = new RegistoDeVisitantes(visitante, doente, entrada, saida);

            //adiciona a lista
            Add(registoVisitantes);
        }


        /// <summary>
        /// tempo medio em horas das visitas por unidade
        /// </summary>
        /// <param name="registoDeVisitantes">registo de visitantes</param>
        /// <param name="unidade">unidade a filtrar</param>
        /// <returns>numero de horas</returns>
        public double TempoMedioHorasPorUnidade (List<RegistoDeVisitantes> registoDeVisitantes, UnidadeClinica unidade)
        {
            //filtrar o registo de visitantes por unidade
            List<RegistoDeVisitantes> registosDeVisitantesUnidade = registoDeVisitantes.Where(r => r.UnidadeClinica.Equals(unidade)).ToList();
            List<double> duracaoVisitasHoras = new List<double>();

            //calcular o tempo total que demorou o visitante
            foreach (RegistoDeVisitantes registo in registosDeVisitantesUnidade)
                duracaoVisitasHoras.Add(registo.DataSaida.Subtract(registo.DataEntrada).TotalHours);

            //Calcular media do tempo que demorou
            return duracaoVisitasHoras.Average();            
        }


        /// <summary>
        /// calculo da percetagem de visitas por doenca
        /// </summary>
        /// <param name="registo">lista de registo de visitantes</param>
        /// <returns>lista de tuplos de percentagem e o tipo de doenca correspondente</returns>
        public List<Tuple<double, Doenca>> PercentagemVisitasPorDoenca(List<RegistoDeVisitantes> registo)
        {
            //conta o total de visitas
            int visitasTotais = registo.Count();

            //agrupa por doenca
            List<List<RegistoDeVisitantes>> visitasAgrupadasDoenca = registo
                .GroupBy(r => r.RegistoClinico.Diagnostico)
                .Select(r => r.ToList())
                .ToList();

            //cria a lista de tuplas
            List<Tuple<double,Doenca>> percentagemVisitasDoenca = new List<Tuple<double,Doenca>>();    
            
            //em cada instancia da lista, ira calcular a percentagem de cada uma das listas agrupadas, devolvendo a percetagem e o tipo de doenca correspondente
            foreach(List<RegistoDeVisitantes> registosDeDoenca in visitasAgrupadasDoenca) 
                percentagemVisitasDoenca.Add(new Tuple<double, Doenca>(((registosDeDoenca.Count() * 100.0) / visitasTotais), registosDeDoenca.First().RegistoClinico.Diagnostico));

            //retorna a lista de tuplos
            return percentagemVisitasDoenca;            
        }


        /// <summary>
        /// quantidade de visitas por unidade
        /// </summary>
        /// <param name="registo">registo de visitantes</param>
        /// <param name="unidade">unidade a filtrar</param>
        /// <returns>numero de visitas</returns>
        public int QuantidadeVistitasUnidade(List<RegistoDeVisitantes> registo, UnidadeClinica unidade) => registo.Where(r => r.UnidadeClinica.Equals(unidade)).ToList().Count();
    }
}
