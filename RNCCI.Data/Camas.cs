using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Modelos;
using RNCCI.Enums;

namespace RNCCI.Dados
{
    public class Camas
    {


        //metodos

        /// <summary>
        /// usar este método para ocupar a cama
        /// </summary>
        Action<Cama, Doente> Ocupar { get; set; } = (cama, doente) =>
        {
            cama.Doente = doente;
            cama.Livre = false;
        };

        /// <summary>
        /// usar este método para desocupar a cama
        /// </summary>
        Action<Cama> Desocupar { get; set; } = (cama) =>
        {
            cama.Doente = null;
            cama.Livre = true;
        };
    }
}
