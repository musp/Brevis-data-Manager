using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using VMBrevis.Manipulador;

namespace VMBrevis.Gerenciador
{   /// <summary>
    ///  @ Propriedade ViraMundo
    /// </summary>
    public class Inclui : Dados 
    {
        public T IncluiT<T>(T objeto, int conexao)
        {
            List<SqlParameter> parametros = MontaParametros(objeto, Operacao.Inserir);
            var conecoes = XElement.Load(@"C:\Users\musph\OneDrive\Labtrans\VMBrevis\Conecoes.xml");
            string stringDeConexaoCorrente = conecoes.XPathSelectElement(RetornaConexao(conexao).ToString()).Value;
            var acoes = XElement.Load(@"C:\Users\musph\OneDrive\Labtrans\VMBrevis\Acoes.xml");
            string acao = acoes.XPathSelectElement("Adicao").Value;
            AbreConexao(new DadosConexao() { nome = stringDeConexaoCorrente, stringDeConexao = stringDeConexaoCorrente });
            string comando = acao.Replace("ESQUEMA", parametros.Where(s => s.ParameterName.Contains("esquema")).FirstOrDefault().Value.ToString()).Replace("TABELA", parametros.Where(s => s.ParameterName.Contains("tabela")).FirstOrDefault().Value.ToString()).Replace("COLUNAS", parametros.Where(s => s.ParameterName == "Colunas").FirstOrDefault().Value.ToString()).Replace("DADOS", parametros.Where(s => s.ParameterName == "Valores").FirstOrDefault().Value.ToString());
            return ConverteDeSqlDataReaderParaT(CarregaDadosGenericoT<object>(comando), objeto);
        }
    }
}
