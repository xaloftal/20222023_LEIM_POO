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

        /// <summary>
        /// adiciona unidades ao sistema
        /// </summary>
        /// <param name="novaUnidade">unidade a adicionar</param>
        /// <exception cref="DadosNulosException">novaUnidade e nulo</exception>
        /// <exception cref="DadoJaExisteException">unidade a adicionar ja existe no sistema</exception>
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


        /// <summary>
        /// elimina unidade do sistema
        /// </summary>
        /// <param name="unidadeDCCI">unidade a eliminar</param>
        /// <exception cref="DadosNulosException">unidadeDCCI e nulo</exception>
        /// <exception cref="DadoNaoExisteException">unidade a eliminar nao existe no sistema</exception>
        public void Apaga(EquipaDomiciliariaDeCuidadosContinuidadesIntegrados unidadeDCCI)
        {
            //não pode ser nulo
            if (unidadeDCCI is null)
                throw new DadosNulosException("RNCCI.Dados.EquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Delete");

            //a unidade tem de existir para ser eliminada
            if (!this.unidadesDCCI.Exists(dcci => dcci.NumeroEDCCI.Equals(unidadeDCCI.NumeroEDCCI)))
                throw new DadoNaoExisteException("RNCCI.Dados.EquipasDominiciliariasDeCuidadosContinuidadesIntegrados.Delete");

            //encontra o index da unidade na lista
            int index = unidadesDCCI.FindIndex(dcci => dcci.NumeroEDCCI.Equals(unidadeDCCI.NumeroEDCCI));

            //remove a unidade
            unidadesDCCI.RemoveAt(index);
        }

        /// <summary>
        /// atualiza a unidade no sistema
        /// </summary>
        /// <param name="unidadeDCCI">unidade com as informacoes novas</param>
        /// <exception cref="DadosNulosException">unidadeDCCI e nulo</exception>
        /// <exception cref="DadoNaoExisteException">unidade nao existe no sistema</exception>
        public void Atualiza(EquipaDomiciliariaDeCuidadosContinuidadesIntegrados unidadeDCCI)
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
