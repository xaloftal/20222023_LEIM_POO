﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    /// <summary>
    /// esta classe representa uma unidade de covalescenca no sistema
    /// </summary>
    public class UnidadeDeCovalescenca : UnidadeClinica
    {
        //variveis
        private int numeroUC = 1000;

        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="camasDisponiveis">camas disponeiveis para a unidade</param>
        public UnidadeDeCovalescenca(int camasDisponiveis)
        {
            this.NumeroUC += numeroUC;
            this.Cama = new Cama[camasDisponiveis];
        }

        /// <summary>
        /// Lista de doentes
        /// </summary>
        public List<Doente> Doentes { get; set; }

        /// <summary>
        /// lista de medicos
        /// </summary>
        public List<Medico> Medicos { get; set; }
        

        /// <summary>
        /// numero da unidade de covalescenca
        /// </summary>
        public int NumeroUC { get; private set; }
    }
}