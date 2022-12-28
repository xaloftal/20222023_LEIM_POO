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
    public class EquipasDomiciliariasDeCuidadosContinuidadesIntegrados
    {
        //variaveis
        List<EquipaDomiciliariaDeCuidadosContinuidadesIntegrados> unidadesDCCI = new List<EquipaDomiciliariaDeCuidadosContinuidadesIntegrados>();


        public void Add(EquipaDomiciliariaDeCuidadosContinuidadesIntegrados novaUnidade)
        {
            //não pode ser nulo
            if (novaUnidade is null)
                throw new DadosNulosException("RNCCI.Dados.EquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Add");

            if (this.unidadesDCCI.Exists(dcci => dcci.NumeroEDCCI.Equals(novaUnidade.NumeroEDCCI)))
                throw new DadoJaExisteException("RNCCI.Dados.UnidadesClinicas.Add");

            //adiciona
            this.unidadesDCCI.Add(novaUnidade);
        }

        public void Delete(EquipaDomiciliariaDeCuidadosContinuidadesIntegrados unidadeDCCI)
        {
            //não pode ser nulo
            if (unidadeDCCI is null)
                throw new DadosNulosException("RNCCI.Dados.EquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Delete");

            //a unidade tem de existir para ser eliminada
            if (!this.unidadesDCCI.Exists(dcci => dcci.NumeroEDCCI.Equals(unidadeDCCI.NumeroEDCCI)))
                throw new DadoNaoExisteException("RNCCI.Dados.EquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Delete");

            //encontra o index da unidade na lista
            int index = unidadesDCCI.FindIndex(dcci => dcci.NumeroEDCCI.Equals(unidadeDCCI.NumeroUC));

            //remove a unidade
            unidadesDCCI.RemoveAt(index);
        }

        public void Update(EquipaDomiciliariaDeCuidadosContinuidadesIntegrados unidadeDCCI)
        {
            //não pode ser nulo
            if (unidadeDCCI is null)
                throw new DadosNulosException("RNCCI.Dados.EquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Update");

            //tem de existir
            if (!this.unidadesDCCI.Exists(dcci => dcci.NumeroEDCCI.Equals(unidadeDCCI.NumeroEDCCI)))
                throw new DadoNaoExisteException("RNCCI.Dados.UnidadeEquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Update");

            //encontra na lista
            int index = unidadesDCCI.FindIndex(dcci => dcci.NumeroEDCCI.Equals(unidadeDCCI.NumeroEDCCI));

            //atualiza a unidade
            unidadesDCCI[index] = unidadeDCCI;
        }
    }
}
