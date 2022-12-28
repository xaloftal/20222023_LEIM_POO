using RNCCI.Excecoes;
using RNCCI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Dados
{
    public class Visitantes
    {

        List<Visitante> visitantes = new List<Visitante>();

        public Visitantes()
        {
            visitantes.Add(new Visitante { Nome = "Maria Figueiras", NumeroContribuinte = 4375, NumeroTelemovel = 934659324 });

        }

        public void Add(Visitante novoVisitante)
        {
            //não pode ser nulo
            if (novoVisitante is null)
                throw new DadosNulosException("RNCCI.Dados.Visitantes.Add");

            //nao pode existir
            if (this.visitantes.Exists(ldm => ldm.NumeroVisitante.Equals(novoVisitante.NumeroVisitante)))
                throw new DadoJaExisteException("RNCCI.Dados.Visitantes.Add");

            //adiciona
            this.visitantes.Add(novoVisitante);
        }

        public void Delete(Visitante visitante)
        {
            //não pode ser nulo
            if (visitante is null)
                throw new DadosNulosException("RNCCI.Dados.Visitantes.Delete");

            //tem de existir
            if (!this.visitantes.Exists(ldm => ldm.NumeroVisitante.Equals(visitante.NumeroVisitante)))
                throw new DadoNaoExisteException("RNCCI.Dados.Visitantes.Delete");

            //encontra na lista
            int index = visitantes.FindIndex(ldm => ldm.NumeroVisitante.Equals(visitante.NumeroVisitante));

            //apaga
            visitantes.RemoveAt(index);
        }

        public void Update(Visitante visitante)
        {
            //não pode ser nulo
            if (visitante is null)
                throw new DadosNulosException("RNCCI.Dados.Visitantes.Update");

            //tem de existir
            if (!this.visitantes.Exists(ldm => ldm.NumeroVisitante.Equals(visitante.NumeroVisitante)))
                throw new DadoNaoExisteException("RNCCI.Dados.Visitantes.Update");

            //encontra na lista
            int index = visitantes.FindIndex(ldm => ldm.NumeroVisitante.Equals(visitante.NumeroVisitante));

            //atualiza a unidade
            visitantes[index] = visitante;
        }
    }
}
