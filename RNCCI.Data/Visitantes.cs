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

        List<Doente> doentes = new List<Doente>();

        public Doentes()
        {
            doentes.Add(new Doente { Nome = "Manel Figueiras", NumeroContribuinte = 4325, NumeroTelemovel = 934656324 });

        }

        public void Add(UnidadeDeLongaDuracaoEManutencao novaUnidade)
        {
            //não pode ser nulo
            if (novaUnidade is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Add");

            //nao pode existir
            if (this.unidadesULDM.Exists(ldm => ldm.NumeroULDM.Equals(novaUnidade.NumeroULDM)))
                throw new DadoJaExisteException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Add");

            //adiciona
            this.unidadesULDM.Add(novaUnidade);
        }

        public void Delete(UnidadeDeLongaDuracaoEManutencao unidadeULDM)
        {
            //não pode ser nulo
            if (unidadeULDM is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Delete");

            //tem de existir
            if (!this.unidadesULDM.Exists(ldm => ldm.NumeroULDM.Equals(unidadeULDM.NumeroULDM)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Delete");

            //encontra na lista
            int index = unidadesULDM.FindIndex(ldm => ldm.NumeroULDM.Equals(unidadeULDM.NumeroULDM));

            //apaga
            unidadesULDM.RemoveAt(index);
        }

        public void Update(UnidadeDeLongaDuracaoEManutencao unidadeULDM)
        {
            //não pode ser nulo

            //tem de existir

            //encontra na lista

            //atualiza a unidade
        }
    }
}
