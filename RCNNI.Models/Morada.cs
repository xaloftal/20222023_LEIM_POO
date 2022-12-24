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
    public class Morada
    {
        public string Rua { get; set; }
        public string CodigoPostal { get; set; }


        /// <summary>
        /// método para obter as coordenadas apartir do código postal
        /// </summary>
        /// <param name="codigoPostal">código postal</param>
        /// <returns>coordenadas</returns>
        public static double[] ObterCoordenadas(string codigoPostal)
        {
            ////cria o cliente
            //var cliente = new RestClient("htps://nominatim.openstreetmap.org");

            ////criar nova requesicao para procura utilizando o codigo postal
            ////permite preencher o link para ir procurar pelo codigo postal
            //var requesicao = new RestRequest("/search", Method.Get);
            //requesicao.AddParameter("format", "json");
            //requesicao.AddParameter("limit", "1"); //limite de valores de retorno
            //requesicao.AddParameter("q", codigoPostal);
            ////irá ficar um link do tipo https: //nominatim.openstreetmap.org/search?format=json&limit=1&q={codigoPostal}

            ////faz o pedido e tem uma resposta
            //RestResponse resposta = cliente.Execute(requesicao);
            
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
        private static bool CodigoPostalValido (string codigoPostal)
        {
            RestResponse resposta = EnviaRequesicao(codigoPostal);

            if(resposta.IsSuccessful)
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
            RestRequest requesito = new RestRequest("Get");

            return cliente.Execute(requesito);
        }

    }
}
