using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Modelos;
using RNCCI.Enums;
using RNCCI.Excecoes;

namespace RNCCI.Dados
{
    public class UnidadesDeLongaDuracaoEManutencao
    {
        //variaveis
        List<UnidadeDeLongaDuracaoEManutencao> unidadesULDM = new List<UnidadeDeLongaDuracaoEManutencao>();

        public void Add(UnidadeDeLongaDuracaoEManutencao novaUnidade)
        {
            //não pode ser nulo
            if (novaUnidade is null)
                throw new DadosNulosException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Add");

            //nao pode existir
            if (this.unidadesULDM.Exists(ldm => ldm.NumeroULDM.Equals(novaUnidade.NumeroULDM)))
                throw new DadoJaExisteException("RNCCI.Dados.UnidadesDeLongaDuracaoEManutencao.Add");

            //adiciona
        }

        public void Delete(UnidadeDeLongaDuracaoEManutencao unidadeULDM)
        {
            //não pode ser nulo

            //tem de existir

            //encontra na lista

            //apaga
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
