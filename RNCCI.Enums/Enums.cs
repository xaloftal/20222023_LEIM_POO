using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Enums
{
   public enum Distrito 
    { 
        Braga, Porto, VianaDoCastelo, Braganca,
        CasteloBranco, Guarda, Aveiro, Viseu, Evora, Faro, 
        Beja, Lisboa, Leiria, Setubal, Santarem, Coimbra,
        VilaReal, Portalegre
    };

    public enum Regiao
    {
        Norte, Alentejo, Algarve, LisboaEValeDoTejo, Centro
    };

    public enum EstadoClinico
    {
        Internado, Alta, EmEspera
    };

    public enum Sexo
    {
        Feminino, Masculino, Intersexo
    }

    public enum Tipologia
    {
        UnidadeDeCovalescenca, 
        UnidadeDeMediaDuracaoEReabilitacao, 
        UnidadeDeLongaDuracaoEManutencao,
        EquipaDomiciliariaDeCuidadosContinuidadesIntegrados,
        UnidadeClinica
    }

    public enum Doencas
    {
        Covid, Pneumonia, Cancro, Zika, HIV, Anemia, Hepatite, Osteoporose,
        InsuficienciaCardiaca, Diabetes, Paralisia, Parkinson
    }

    public enum Movimento
    {
        Saida, Entrada, Transferencia
    }
}
