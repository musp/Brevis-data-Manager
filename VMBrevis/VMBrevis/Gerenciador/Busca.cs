using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VMBrevis.Manipulador;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Linq;

namespace VMBrevis.Gerenciador
{
    public class Busca : Dados
    {

        /// <summary> @ Propriedade ViraMundo
        /// Busca dados genericos por parametro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dados"></param>
        /// <returns></returns>
        /// 
        public T BuscaT<T>(T dados, int conexao)
        {
            try
            {
                List<SqlParameter> parametros = MontaParametros(dados, Operacao.Carregar);
                var conecoes = XElement.Load(@"D:\FWViraMundo\FOLLOWDOCS\VMBrevis\Conecoes.xml");
                string stringDeConexaoCorrente = conecoes.XPathSelectElement(RetornaConexao(conexao).ToString()).Value;
                var acoes = XElement.Load(@"D:\FWViraMundo\FOLLOWDOCS\VMBrevis\Acoes.xml");
                string acao = acoes.XPathSelectElement("Selecao").Value;
                AbreConexao(new DadosConexao() { nome = stringDeConexaoCorrente, stringDeConexao = stringDeConexaoCorrente });
                string comando = acao.Replace("ESQUEMA", parametros.Where(s => s.ParameterName.Contains("esquema")).FirstOrDefault().Value.ToString())
                                     .Replace("TABELA", parametros.Where(s => s.ParameterName.Contains("tabela")).FirstOrDefault().Value + "s")
                                     .Replace("CLAUSULAS", parametros.Where(s => s.ParameterName == "Parametros").FirstOrDefault().Value.ToString());
                return ConverteDeSqlDataReaderParaT(CarregaDadosGenericoT<object>(comando), dados);
            }
            catch (Exception ex)
            {
                FechaConexao();
                throw;
            }
            finally
            {
                FechaConexao();
            }
        }

        public List<T> PesquisaT<T>(T dados, int conexao, bool buscaSemParametro = false)
        {
            try
            {
                List<SqlParameter> parametros = MontaParametros(dados, Operacao.Carregar, null, null, buscaSemParametro);
                var conecoes = XElement.Load(@"C:\Users\musph\OneDrive\Labtrans\VMBrevis\Conecoes.xml");
                string stringDeConexaoCorrente = conecoes.XPathSelectElement(RetornaConexao(conexao).ToString()).Value;
                var acoes = XElement.Load(@"C:\Users\musph\OneDrive\Labtrans\VMBrevis\Acoes.xml");
                string acao = acoes.XPathSelectElement("Selecao").Value;
                AbreConexao(new DadosConexao() { nome = "", stringDeConexao = stringDeConexaoCorrente });
                acao = acao
                    .Replace("ESQUEMA", parametros.Where(s => s.ParameterName.Contains("esquema")).FirstOrDefault().Value.ToString())
                    .Replace("TABELA", parametros.Where(s => s.ParameterName.Contains("tabela")).FirstOrDefault().Value.ToString());
                if(!buscaSemParametro)
                    acao = acao.Replace("CLAUSULAS", parametros.Where(s => s.ParameterName == "Parametros").FirstOrDefault().Value.ToString());
                else
                    acao = acao.Replace("CLAUSULAS", "");
                //string juncao = acoes.XPathSelectElement("Juncao").Value;
                //string comando = "";
                return ConverteDeSqlListaDataReaderParaT<T>(CarregaDadosGenericoT<object>(acao));
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                FechaConexao();
            }
        }

        //public List<T> BuscaListaT<T>(T dados)
        //{
        //    try
        //    {
        //        List<SqlParameter> parametros = MontaParametros(dados, Operacao.Carregar);
        //        var doc = XElement.Load("D:\\FWViraMundo\\FOLLOWDOCS\\VMBrevis\\Conecoes.xml");
        //        string stringDeConexaoCorrente = doc.XPathSelectElement(ConexoesAcessos.ViraMundoLojaVirtual.ToString()).Value.Remove(0, 6).Remove(114);
        //        AbreConexao(new DadosConexao() { nome = ConexoesAcessos.ViraMundoBrevis.ToString(), stringDeConexao = stringDeConexaoCorrente });
        //        SqlDataReader datareader = ExecucaoGenerica<object>(parametros, Esquemas.VMP);
        //        return ConverteDeSqlListaDataReaderParaT<T>(datareader);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<T>();

        //        throw;
        //    }
        //    finally
        //    {
        //        FechaConexao();
        //    }
        //}
    }


}
