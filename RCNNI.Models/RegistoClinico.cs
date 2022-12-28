using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;

namespace RNCCI.Modelos
{
    public class RegistoClinico
    {
        //variaveis
        private int numeroRegisto = 1000;

        /// <summary>
        /// constructor
        /// </summary>
        public RegistoClinico() =>  this.NumeroRegisto += numeroRegisto;
           
    
        

        /// <summary>
        /// Doente 
        /// </summary>
        public Doente Doente { get; set; }

        public int NumeroRegisto { get; private set; }

        /// <summary>
        /// médico responsável
        /// </summary>
        public Medico Medico { get; set; }

        /// <summary>
        /// Diagnostico 
        /// </summary>
        public Doencas Diagnostico { get; set; }

        /// <summary>
        /// Data de admissão do doente
        /// </summary>
        public DateOnly DataAdmissao { get; set; }

        /// <summary>
        /// data da alta
        /// </summary>
        public DateOnly DataAlta { get; set; }  

        /// <summary>
        /// unidade clinica referente
        /// </summary>
        public UnidadeClinica UnidadeClinica { get; set;}

        //metodos

        /// <summary>
        /// override do metodo ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => 
            $"\tRegisto clinico nº{this.NumeroRegisto}\n " +
            $"\nUnidade Clinica: {this.UnidadeClinica.NumeroClinica} {this.UnidadeClinica.Nome}, {this.UnidadeClinica.Morada.Cidade}\n\n " +
            $"Utente: {this.Doente.NumeroUtente} {this.Doente.Nome}\n" +
            $"Diagnostico: {this.Diagnostico}\n" +
            $"Data admissao: {this.DataAdmissao}\n" +
            $"Data alta: {this.DataAlta} \n\n" +
            $"Medico responsavel: {this.Medico.Nome}";
        
    }
}
