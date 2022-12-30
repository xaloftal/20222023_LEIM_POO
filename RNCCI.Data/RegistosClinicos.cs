using RNCCI.Enums;
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
        //variaveis
        List<RegistoClinico> registosClinicos = new List<RegistoClinico>();
        RegistosDeMovimentos registosDeMovimentos = new RegistosDeMovimentos();

        /// <summary>
        /// construtor
        /// </summary>
        public RegistosClinicos()
        {
            registosClinicos.Add(new RegistoClinico
            {
                Diagnostico = Enums.Doenca.Covid,
                DataAdmissao = new DateOnly(2020, 1, 1),
                EstadoClinico = Enums.EstadoClinico.Internado,
                UnidadeClinica = new UnidadeClinica
                {
                    Nome = "Vida",
                    Tipologia = Tipologia.UnidadeDeMediaDuracaoEReabilitacao
                },
                Doente = new Doente
                {
                    Nome = "Manel Figueiras",
                    NumeroContribuinte = 4325,
                    NumeroTelemovel = 934656324
                }
            });

        }

        //metodos

        /// <summary>
        /// Adicionar novo registo clinico
        /// </summary>
        /// <param name="novoRegistoClinico">novo registo clinico</param>
        /// <exception cref="DadosNulosException">quando o novoRegistoClinico é nulo</exception>
        /// <exception cref="DadoJaExisteException">quando o novoRegistoClinico não é nulo</exception>
        public void Add(RegistoClinico novoRegistoClinico)
        {
            //não pode ser nulo
            if (novoRegistoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Add");

            //nao pode existir
            if (this.registosClinicos.Exists(rc => rc.NumeroRegisto.Equals(novoRegistoClinico.NumeroRegisto)))
                throw new DadoJaExisteException("RNCCI.Dados.RegistosClinicos.Add");

            //adiciona
            this.registosClinicos.Add(novoRegistoClinico);
        }



        /// <summary>
        /// Eliminar um registo clinico
        /// </summary>
        /// <param name="registoClinico">um registo clinico</param>
        /// <exception cref="DadosNulosException">quando o registoClinico é nulo</exception>
        /// <exception cref="DadoNaoExisteException">quando o registoClinico não é nulo</exception>
        public void Apaga(RegistoClinico registoClinico)
        {
            //não pode ser nulo
            if (registoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Apaga");

            //tem de existir
            if (!this.registosClinicos.Exists(rc => rc.NumeroRegisto.Equals(registoClinico.NumeroRegisto)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosClinicos.Apaga");

            //encontra na lista
            int index = registosClinicos.FindIndex(rc => rc.NumeroRegisto.Equals(registoClinico.NumeroRegisto));

            //apaga
            registosClinicos.RemoveAt(index);
        }



        /// <summary>
        /// Atualizar um registo clinico
        /// </summary>
        /// <param name="registoClinico">um registo clinico</param>
        /// <exception cref="DadosNulosException">quando o registoClinico não existe</exception>
        /// <exception cref="DadoNaoExisteException">quando o registoClinico não é nulo</exception>
        public void Atualiza(RegistoClinico registoClinico)
        {
            //não pode ser nulo
            if (registoClinico is null)
                throw new DadosNulosException("RNCCI.Dados.RegistosClinicos.Atualiza");

            //tem de existir
            if (!this.registosClinicos.Exists(rc => rc.NumeroRegisto.Equals(registoClinico.NumeroRegisto)))
                throw new DadoNaoExisteException("RNCCI.Dados.RegistosClinicos.Atualiza");

            //encontra na lista
            int index = registosClinicos.FindIndex(rc => rc.NumeroRegisto.Equals(registoClinico.NumeroRegisto));

            //atualiza a unidade
            registosClinicos[index] = registoClinico;
        }



        /// <summary>
        /// Lista registos clinicos
        /// </summary>
        /// <param name="registoClinicos"> registos clinicos</param>
        public void ListarRegistosClinicos(List<RegistoClinico> registoClinicos)
        {
            foreach (RegistoClinico registoClinico in registoClinicos)
                Console.WriteLine(registoClinicos.ToString());
        }

        /// <summary>
        /// Cria a lista os doentes, as unidades e tipologias e a quantidade de camas disponíveis nestes
        /// </summary>
        /// <param name="unidadeFiltrada">unidade correspondente à do doente</param>
        /// <returns>lista de todos os doentes filtrados por tipologia</returns>
        public List<RegistoClinico> ListaTodosDoentesTipologia(List<RegistoClinico> registoClinico, Tipologia unidadeFiltrada) => this.registosClinicos
                                                                                                                                .Where(r => r.UnidadeClinica.Tipologia.Equals(unidadeFiltrada))
                                                                                                                                .ToList();


        /// <summary>
        /// usa este metodo para listar todos os registos
        /// </summary>
        /// <param name="registosClinicos">registos clinicos</param>
        public void ListaTodosRegistos(List<RegistoClinico> registosClinicos) => ListarRegistosClinicos(registosClinicos);




        /// <summary>
        /// use este metodo para listar os registos de unidades individuais
        /// </summary>
        /// <param name="registosClinicos">registos clinicos</param>
        /// <param name="tipologiaAFiltrar">unidade a filtrar</param>
        public void ListaRegistosPorTipologia (List<RegistoClinico> registosClinicos, Tipologia tipologiaAFiltrar)
        {
            //filtra a lista
            List<RegistoClinico> registoFiltrado = ListaTodosDoentesTipologia(registosClinicos, tipologiaAFiltrar);

            //Listar os registos ja filtrados
            ListarRegistosClinicos(registoFiltrado);
        }



        /// <summary>
        /// regista a admissao do doente na unidade clinica
        /// </summary>
        /// <param name="registoClinico">registo do doente a ser admitido</param>
        /// <param name="unidadeClinica">unidade a ser admitido</param>
        /// <param name="entrada">data de entrada do doente</param>
        /// <exception cref="DadoNaoPrevistoException">tipologia de resposta nao esperada</exception>
        public void RegistaAdmissao(RegistoClinico registoClinico, UnidadeClinica unidadeClinica, DateTime entrada)
        {
            //mudar unidade clinica
            registoClinico.UnidadeClinica = unidadeClinica;

            //mudar estado clinico do doente
            switch (unidadeClinica.Tipologia)
            {
                case Tipologia.UnidadeDeCovalescenca:
                case Tipologia.UnidadeDeMediaDuracaoEReabilitacao:
                case Tipologia.UnidadeDeLongaDuracaoEManutencao:
                case Tipologia.EquipaDomiciliariaDeCuidadosContinuidadesIntegrados:
                    registoClinico.EstadoClinico = EstadoClinico.Internado;
                    break;

                case Tipologia.UnidadeClinica:
                    registoClinico.EstadoClinico = EstadoClinico.EmEspera;
                    break;

                default:
                    throw new DadoNaoPrevistoException("RNCCI.Dados.RegistosClinicos.RegistaAdmissao");
                    break;
            }

            //inserir no registo de movimentos
            this.registosDeMovimentos.Add( new RegistoDeMovimento { TipoMovimento = Movimento.Entrada, DataMovimento = entrada, Doente = registoClinico.Doente, Destino = unidadeClinica});
        }



        /// <summary>
        /// regista a saida do doente 
        /// </summary>
        /// <param name="registoClinico">registo do doente</param>
        /// <param name="saida">data de saida</param>
        public void RegistaSaida(RegistoClinico registoClinico, DateTime saida)
        {
            //muda a unidade do registo
            registoClinico.UnidadeClinica = null;

            //muda o estado do doente
            registoClinico.EstadoClinico = EstadoClinico.Alta;

            //adiciona aos registos
            this.registosDeMovimentos.Add(new RegistoDeMovimento { TipoMovimento = Movimento.Saida, DataMovimento = saida, Doente = registoClinico.Doente});
        }


        /// <summary>
        /// regista a transferencia entre unidades
        /// </summary>
        /// <param name="registoClinico">registo do doente</param>
        /// <param name="transferencia">data da transferencia</param>
        /// <param name="unidadeOrigem">unidade clinica de onde vai sair</param>
        /// <param name="unidadeDestino">unidade clinica onde vai entrar</param>
        /// <exception cref="DadoNaoPrevistoException">Tipologia de resposta nao esperada</exception>
        public void RegistaTransferencia(RegistoClinico registoClinico, DateTime transferencia, UnidadeClinica unidadeOrigem, UnidadeClinica unidadeDestino)
        {
            //mudar unidade clinica
            registoClinico.UnidadeClinica = unidadeDestino;

            //mudar estado clinico do doente
            switch (unidadeDestino.Tipologia)
            {
                case Tipologia.UnidadeDeCovalescenca:

                case Tipologia.UnidadeDeMediaDuracaoEReabilitacao:

                case Tipologia.UnidadeDeLongaDuracaoEManutencao:

                case Tipologia.EquipaDomiciliariaDeCuidadosContinuidadesIntegrados:
                    registoClinico.EstadoClinico = EstadoClinico.Internado;
                    break;
                case Tipologia.UnidadeClinica:
                    registoClinico.EstadoClinico = EstadoClinico.EmEspera;
                    break;
                default:
                    throw new DadoNaoPrevistoException("RNCCI.Dados.RegistosClinicos.RegistaAdmissao");
                    break;
            }

            //inserir no registo de movimentos
            this.registosDeMovimentos.Add(new RegistoDeMovimento { TipoMovimento = Movimento.Entrada, DataMovimento = transferencia,
                Doente = registoClinico.Doente, Destino = unidadeDestino, Origem = unidadeOrigem });
        }

    }
}
