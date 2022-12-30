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
        List<RegistoDeVisitantes> registosDeVisitantes = new List<RegistoDeVisitantes>();

        /// <summary>
        /// construtor
        /// </summary>
        public RegistosDeVisitantes()
        {
            registosDeVisitantes.Add(new RegistoDeVisitantes
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

        /// <summary>
        /// adiciona um registo de visitantes
        /// </summary>
        /// <param name="novoRegistoDeVisitantes"></param>
        /// <exception cref="DadosNulosException"></exception>
        /// <exception cref="DadoJaExisteException"></exception>
        public void Add(RegistoDeVisitantes novoRegistoDeVisitantes)
        {
            //não pode ser nulo
            if (novoRegistoDeVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeVisitantes.Add");

            //nao pode existir
            if (this.registosDeVisitantes.Exists(ldm => ldm.NumeroRV.Equals(novoRegistoDeVisitantes.NumeroRV)))
                throw new DadoJaExisteException("RNCCI.Dados.RegistosDeVisitantes.Add");

            //adiciona
            this.registosDeVisitantes.Add(novoRegistoDeVisitantes);
        }

        public void Apaga(RegistoDeVisitantes registoDeVisitantes)
        {
            //não pode ser nulo
            if (registoDeVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.RegistoDeVisitantes.Delete");

            //tem de existir
            if (!this.registosDeVisitantes.Exists(ldm => ldm.NumeroRV.Equals(registoDeVisitantes.NumeroRV)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistoDeVisitantes.Delete");

            //encontra na lista
            int index = registosDeVisitantes.FindIndex(ldm => ldm.NumeroRV.Equals(registoDeVisitantes.NumeroRV));

            //apaga
            registosDeVisitantes.RemoveAt(index);
        }

        public void Atualiza(RegistoDeVisitantes registoDeVisitantes)
        {
            //não pode ser nulo
            if (registoDeVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeVisitantes.Update");

            //tem de existir
            if (!this.registosDeVisitantes.Exists(ldm => ldm.NumeroRV.Equals(registoDeVisitantes.NumeroRV)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosDeVisitantes.Update");

            //encontra na lista
            int index = registosDeVisitantes.FindIndex(ldm => ldm.NumeroRV.Equals(registoDeVisitantes.NumeroRV));

            //atualiza a unidade
            registosDeVisitantes[index] = registoDeVisitantes;
        }


        public void ListarTodosOsRegistoDeVisitantes(List<RegistoDeVisitantes> registosDeVisitantes)
        {
            foreach (RegistoDeVisitantes registoDeVisitantes in registosDeVisitantes)
            {
                Console.WriteLine(registosDeVisitantes.ToString());
            }
        }

        public void RegistarAdmissao(RegistoClinico doente, Visitante visitante, DateTime entrada, DateTime saida)
        {
            bool autorizado = doente.Doente.VisitantesAutorizados.ToList().Exists(v => v.NumeroVisitante.Equals(visitante.NumeroVisitante));

            if (!autorizado)
                throw new VisitanteNaoAutorizadoException("RNCCI.Dados.RegistosDeVisitantes.RegistarAdmissao");

            RegistoDeVisitantes registoDeVisitantes = new RegistoDeVisitantes(visitante, doente, entrada, saida);
            Add(registoDeVisitantes);

        }

        public double TempoMedioHorasPorUnidade (List<RegistoDeVisitantes> registoDeVisitantes, UnidadeClinica unidade)
        {
            //temos que filtrar o registo de visitantes por unidade
            //calcular o tempo total que demorou o visitante
            //Calcular media do tempo que demorou

            List<RegistoDeVisitantes> registosDeVisitantesUnidade = registoDeVisitantes.Where(r => r.UnidadeClinica.Equals(unidade)).ToList();
            List<double> duracaoVisitasHoras = new List<double>();


            foreach (RegistoDeVisitantes registo in registosDeVisitantesUnidade)
            {
                duracaoVisitasHoras.Add(registo.DataSaida.Subtract(registo.DataEntrada).TotalHours);
            }

            return duracaoVisitasHoras.Average();
        }

        public List<Tuple<double, Doencas>> PercentagemVisitasPorDoenca(List<RegistoDeVisitantes> registo)
        {
            int visitasTotais = registo.Count();

            List<List<RegistoDeVisitantes>> visitasAgrupadasDoenca = registo
                .GroupBy(r => r.RegistoClinico.Diagnostico)
                .Select(r => r.ToList())
                .ToList();

            List<Tuple<double,Doencas>> percentagemVisitasPorDoenca = new List<Tuple<double,Doencas>>();    
            

            foreach(List<RegistoDeVisitantes> registosDeDoenca in visitasAgrupadasDoenca) 
            {
                percentagemVisitasPorDoenca.Add(new Tuple<double, Doencas>(((registosDeDoenca.Count() * 100.0) / visitasTotais), registosDeDoenca.First().RegistoClinico.Diagnostico));
            }

            return percentagemVisitasPorDoenca;
            
        }

        public int QuantidadeDeVistitasUnidade (List<RegistoDeVisitantes> registo, UnidadeClinica unidade)
        {
            List<RegistoDeVisitantes> registosDeVisitantesUnidade = registo.Where(r => r.UnidadeClinica.Equals(unidade)).ToList();
            
            return registosDeVisitantesUnidade.Count();
        
        }
    
    }
}
