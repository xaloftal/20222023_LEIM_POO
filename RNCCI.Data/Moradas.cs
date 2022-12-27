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
    public class Moradas
    {

        //metodos

        /// <summary>
        /// metodo para determinar a regiao
        /// </summary>
        /// <param name="distrito">distrito</param>
        /// <returns>regiao</returns>
        /// <exception cref="DadoNaoPrevistoException">distrito invalido</exception>
        private Regiao DeterminaRegiao(Distrito distrito)
        {
            switch (distrito)
            {
                case Distrito.VianaDoCastelo:
                case Distrito.Braga:
                case Distrito.Porto:
                case Distrito.VilaReal:
                case Distrito.Braganca:
                    return Regiao.Norte;
                    break;

                case Distrito.CasteloBranco:
                case Distrito.Guarda:
                case Distrito.Aveiro:
                case Distrito.Viseu:
                case Distrito.Leiria:
                case Distrito.Coimbra:
                    return Regiao.Centro;
                    break;

                case Distrito.Faro:
                    return Regiao.Algarve;
                    break;

                case Distrito.Lisboa:
                case Distrito.Santarem:
                case Distrito.Setubal:
                    return Regiao.LisboaEValeDoTejo;
                    break;

                case Distrito.Beja:
                case Distrito.Evora:
                case Distrito.Portalegre:
                    return Regiao.Alentejo;
                    break;

                default:
                    throw new DadoNaoPrevistoException("RNCCI.Modelos.UnidadeClinica.UnidadeClinica");

            }
        }
    }
}
