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

        List<RegistoDeVisitantes> registosDeVisitantes = new List<RegistoDeVisitantes>();

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
                Doente = new Doente
                {
                    Nome = "Manel Figueiras",
                    NumeroContribuinte = 4325,
                    NumeroTelemovel = 934656324
                }
            });

        }

        public void Add(RegistoDeVisitantes novoRegistoDeVisitantes)
        {
            //não pode ser nulo
            if (novoRegistoDeVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeVisitantes.Add");

            //nao pode existir
            if (this.registosDeVisitantes.Exists(ldm => ldm.NumeroRA.Equals(novoRegistoDeVisitantes.NumeroRA)))
                throw new DadoJaExisteException("RNCCI.Dados.RegistosDeVisitantes.Add");

            //adiciona
            this.registosDeVisitantes.Add(novoRegistoDeVisitantes);
        }

        public void Delete(RegistoDeVisitantes registoDeVisitantes)
        {
            //não pode ser nulo
            if (registoDeVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.Doentes.Delete");

            //tem de existir
            if (!this.registosDeVisitantes.Exists(ldm => ldm.NumeroRA.Equals(registoDeVisitantes.NumeroRA)))
                throw new DadoNaoExisteException("RNCCI.Dados.Doentes.Delete");

            //encontra na lista
            int index = registosDeVisitantes.FindIndex(ldm => ldm.NumeroRA.Equals(registoDeVisitantes.NumeroRA));

            //apaga
            registosDeVisitantes.RemoveAt(index);
        }

        public void Update(RegistoDeVisitantes registoDeVisitantes)
        {
            //não pode ser nulo
            if (registoDeVisitantes is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosDeVisitantes.Update");

            //tem de existir
            if (!this.registosDeVisitantes.Exists(ldm => ldm.NumeroRA.Equals(registoDeVisitantes.NumeroRA)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosDeVisitantes.Update");

            //encontra na lista
            int index = registosDeVisitantes.FindIndex(ldm => ldm.NumeroRA.Equals(registoDeVisitantes.NumeroRA));

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


    }
}
