using RNCCI.Excecoes;
using RNCCI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Dados
{
    public class RegistosClinicos
    {

        List<RegistoClinico> registosClinicos = new List<RegistoClinico>();

        public RegistosClinicos()
        {
            registosClinicos.Add(new RegistoClinico {Diagnostico = Enums.Doencas.Covid, DataAdmissao = new DateOnly(2020,1,1), DataAlta = new DateOnly(2022,3,3)});

        }

        public void Add(RegistoClinico novoRegistoClinico)
        {
            //não pode ser nulo
            if (novoRegistoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Add");

            //nao pode existir
            if (this.registosClinicos.Exists(ldm => ldm.NumeroRegisto.Equals(novoRegistoClinico.NumeroRegisto)))
                throw new DadoJaExisteException("RNCCI.Dados.RegistosClinicos.Add");

            //adiciona
            this.registosClinicos.Add(novoRegistoClinico);
        }

        public void Delete(RegistoClinico registoClinico)
        {
            //não pode ser nulo
            if (registoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Delete");

            //tem de existir
            if (!this.registosClinicos.Exists(ldm => ldm.NumeroRegisto.Equals(registoClinico.NumeroRegisto)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosClinicos.Delete");

            //encontra na lista
            int index = registosClinicos.FindIndex(ldm => ldm.NumeroRegisto.Equals(registoClinico.NumeroRegisto));

            //apaga
            registosClinicos.RemoveAt(index);
        }

        public void Update(RegistoClinico registoClinico)
        {
            //não pode ser nulo
            if (registoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Update");

            //tem de existir
            if (!this.registosClinicos.Exists(ldm => ldm.NumeroRegisto.Equals(registoClinico.NumeroRegisto)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosClinicos.Update");

            //encontra na lista
            int index = registosClinicos.FindIndex(ldm => ldm.NumeroRegisto.Equals(registoClinico.NumeroRegisto));

            //atualiza a unidade
            registosClinicos[index] = registoClinico;
        }

        public void ListarTodosOsRegistosClinicos(List<RegistoClinico> registoClinicos)
        {
            foreach (RegistoClinico registoClinico in registoClinicos)
            {
                Console.WriteLine(registoClinicos.ToString());
            }
        }

    }
}
