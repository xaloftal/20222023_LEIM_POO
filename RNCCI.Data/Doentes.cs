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
    public class Doentes
    {

        List<Doente> doentes = new List<Doente>();

        public Doentes()
        {
            doentes.Add(new Doente { Nome = "Manel Figueiras", NumeroContribuinte = 4325, NumeroTelemovel = 934656324 });

        }

        public void Add(Doente novoDoente)
        {
            //não pode ser nulo
            if (novoDoente is null)
                throw new DadosNulosException("RNCCI.Dados.Doentes.Add");

            //nao pode existir
            if (this.doentes.Exists(ldm => ldm.NumeroUtente.Equals(novoDoente.NumeroUtente)))
                throw new DadoJaExisteException("RNCCI.Dados.Doentes.Add");

            //adiciona
            this.doentes.Add(novoDoente);
        }

        public void Delete(Doente doente)
        {
            //não pode ser nulo
            if (doente is null)
                throw new DadosNulosException("RNCCI.Dados.Doentes.Delete");

            //tem de existir
            if (!this.doentes.Exists(ldm => ldm.NumeroUtente.Equals(doente.NumeroUtente)))
                throw new DadoNaoExisteException("RNCCI.Dados.Doentes.Delete");

            //encontra na lista
            int index = doentes.FindIndex(ldm => ldm.NumeroUtente.Equals(doente.NumeroUtente));

            //apaga
            doentes.RemoveAt(index);
        }

        public void Update(Doente doente)
        {
            //não pode ser nulo
            if (doente is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Update");

            //tem de existir
            if (!this.doentes.Exists(ldm => ldm.NumeroUtente.Equals(doente.NumeroUtente)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Update");

            //encontra na lista
            int index = doentes.FindIndex(ldm => ldm.NumeroUtente.Equals(doente.NumeroUtente));

            //atualiza a unidade
            doentes[index] = doente;
        }

    }
}
