﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Excecoes
{
    public class ClinicaJaExisteException : Exception
    {
        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="origem">onde a excecao foi atirada</param>
        public ClinicaJaExisteException(string origem) => this.Source = origem;


        /// <summary>
        /// mensagem da excecao
        /// </summary>
        public override string Message => "A clinica ja existe no sistema!";
    }
}
