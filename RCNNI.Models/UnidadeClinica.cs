using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;
using RNCCI.Excecoes;

namespace RNCCI.Modelos
{
    public class UnidadeClinica
    {
        //variaveis de estado
        int numeroClinica = 0;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="nome">nome da clinica</param>
        /// <param name="distrito">distrito da clinica</param>
        public UnidadeClinica(Distrito distrito)
        {
            this.NumeroClinica = ++numeroClinica;

            switch (distrito)
            {
                case Distrito.VianaDoCastelo:
                case Distrito.Braga:
                case Distrito.Porto:
                case Distrito.VilaReal:
                case Distrito.Braganca:
                    this.Regiao = Regiao.Norte;
                    break;

                case Distrito.CasteloBranco:                    
                case Distrito.Guarda:                   
                case Distrito.Aveiro:                  
                case Distrito.Viseu:
                case Distrito.Leiria:                      
                case Distrito.Coimbra:
                    this.Regiao = Regiao.Centro;
                    break;

                case Distrito.Faro:
                    this.Regiao = Regiao.Algarve;
                    break;
                
                case Distrito.Lisboa:
                case Distrito.Santarem:
                case Distrito.Setubal:
                    this.Regiao = Regiao.LisboaEValeDoTejo;
                    break;                     
                
                case Distrito.Beja:
                case Distrito.Evora:
                case Distrito.Portalegre:
                    this.Regiao = Regiao.Alentejo;
                    break;

                default:
                    throw new DadoNaoPrevistoException("RNCCI.Modelos.UnidadeClinica.UnidadeClinica");
                    break;
            }
        }


        /// <summary>
        /// camas da unidade
        /// </summary>
        public int[] Cama { get; set; }

        /// <summary>
        /// numero de identificacao da clinica
        /// </summary>
        public int NumeroClinica { get; private set; }

        /// <summary>
        /// nome da clinica
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// regiao da unidade clinica
        /// </summary>
        public Regiao Regiao { get; private set; }

        /// <summary>
        /// distrito da unidade clinica
        /// </summary>
        public Distrito Distrito { get; set; }

        //public Regiao DefinirRegiao(Distrito distrito)
        //{
        //    if (distrito.Equals(Distrito.VianaDoCastelo) || distrito.Equals(Distrito.Braga) ||
        //        distrito.Equals(Distrito.Porto) || distrito.Equals(Distrito.VilaReal) ||
        //        distrito.Equals(Distrito.Braganca))
        //        this.

        //}
    }
}
