﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCCI.Enums;
using RestSharp;
using Newtonsoft.Json.Linq;
using RNCCI.Excecoes;

namespace RNCCI.Modelos
{
    public abstract class Morada
    {
        //variaveis
        

        /*
        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="codigoPostal">codigo postal</param>
        /// <param name="distrito">distrito</param>
        public Morada(/*string codigoPostal, Distrito distrito)
        {
            /*
            bool valido = CodigoPostalValido(codigoPostal);

            if (valido)
            {
                this.CodigoPostal = codigoPostal;
                this.Coordenadas = ObterCoordenadas(codigoPostal);
            }
            else
                throw new CodigoPostalInvalidoException("RNCCI.Modelos.Morada.Morada");            
            

            this.Distrito = distrito;
            this.Regiao = Moradas.DeterminaRegiao(distrito);
            
        }
    */
    
        //propriedades

        /// <summary>
        /// Rua
        /// </summary>
        public string Rua { get; set; }

        /// <summary>
        /// Numero da porta
        /// </summary>
        public int NumeroPorta { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// Distrito
        /// </summary>
        public Distrito Distrito { get; set; }

        /// <summary>
        /// codigo postal
        /// </summary>
        public string CodigoPostal { get; set; }

        /// <summary>
        /// Regiao
        /// </summary>
        public Regiao Regiao { get; private set;}

        /// <summary>
        /// coordenadas
        /// </summary>
        public double[] Coordenadas { get; private set; }
        


        //metodos

        
        /*
        
        /// <summary>
        /// método para obter as coordenadas apartir do código postal
        /// </summary>
        /// <param name="codigoPostal">código postal</param>
        /// <returns>coordenadas</returns>
        public double[] ObterCoordenadas(string codigoPostal)
        {
            //vai fazer o requesito
            RestResponse resposta = EnviaRequesicao(codigoPostal);

            //vê se o pedido foi aceite
            if (resposta.IsSuccessful)
            {
                //cria um array Json com os resultados da requesicao
                JArray resultados = JArray.Parse(resposta.Content);

                //se não houver resultados, então atira uma excecao
                if (resultados.Count.Equals(0))
                    throw new JSonArrayVazioException("RNCCI.Modelos.Morada.ObterCoordenadas");

                //obtem o primeiro valor da Json Array
                JObject resultado = (JObject)resultados[0];

                //obter a latitude e longitude do resultado
                double latitude = (double)resultado["lat"];
                double longitude = (double)resultado["lon"];

                return new double[] { latitude, longitude };                
            }

            else
                throw new RequesicaoHTTPFalhouException("RNCCI.Modelos.Morada.ObterCoordenadas");
        }


        /// <summary>
        /// verifica se o código postal é valido na biblioteca do Nominatim
        /// </summary>
        /// <param name="codigoPostal">codigo postal</param>
        /// <returns>true se for valido, false se não for válido</returns>
        private static bool CodigoPostalValido(string codigoPostal)
        {
            RestResponse resposta = EnviaRequesicao(codigoPostal);

            if (resposta.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //cria um array Json com os resultados da requesicao
                JArray resultados = JArray.Parse(resposta.Content);

                //se houver pelo menos um valor no array, entao o codigo postal e valido
                return resultados.Count > 0;
            }

            else
                return false;
        }


        /// <summary>
        /// envia requesito http
        /// </summary>
        /// <param name="postalCode">codigo postal</param>
        /// <returns>resposta do envio</returns>
        private static RestResponse EnviaRequesicao(string postalCode)
        {
            //cria o link que usa o codigo postal
            string requesitoUrl = $"https://nominatim.openstreetmap.org/search?format=json&limit=1&postalcode={postalCode}";

            //cria o cliente com o link do requesito
            RestClient cliente = new RestClient(requesitoUrl);

            //cria um objeto de requesito
            RestRequest requesito = new RestRequest("GET");

            RestResponse resposta = cliente.Execute(requesito);
            return resposta;   
        }

        */

       
    }
}
