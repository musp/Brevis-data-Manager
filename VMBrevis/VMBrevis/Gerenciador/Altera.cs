using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;
using VMBrevis.DadosAcesso;
using VMBrevis.Manipulador;

namespace VMBrevis.Gerenciador
{
    public class Altera : Dados
    {
        /// <summary> @ Propriedade ViraMundo
        /// Altera dados do banco comforme parametrizacao
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dados"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public T AlteraT<T>(T objeto, int conexao)
        {
            List<SqlParameter> parametros = MontaParametros(objeto, Operacao.Alterar);
            var conecoes = XElement.Load(@"C:\Users\musph\OneDrive\Labtrans\VMBrevis\Conecoes.xml");
            string stringDeConexaoCorrente = conecoes.XPathSelectElement(RetornaConexao(conexao).ToString()).Value;
            var acoes = XElement.Load(@"C:\Users\musph\OneDrive\Labtrans\VMBrevis\Acoes.xml");
            string acao = acoes.XPathSelectElement("Alteracao").Value;
            AbreConexao(new DadosConexao() { nome = stringDeConexaoCorrente, stringDeConexao = stringDeConexaoCorrente });
            string comando = acao.Replace("ESQUEMA", parametros.Where(s => s.ParameterName.Contains("esquema")).FirstOrDefault().Value.ToString()).Replace("TABELA", parametros.Where(s => s.ParameterName.Contains("tabela")).FirstOrDefault().Value.ToString()).Replace("COLUNASDADOS", parametros.Where(s => s.ParameterName == "ColunasValores").FirstOrDefault().Value.ToString()).Replace("CLAUSULAS", parametros.Where(s => s.ParameterName == "Parametros").FirstOrDefault().Value.ToString()); 
            return ConverteDeSqlDataReaderParaT(CarregaDadosGenericoT<object>(comando), objeto);
        }
       
    }
}

