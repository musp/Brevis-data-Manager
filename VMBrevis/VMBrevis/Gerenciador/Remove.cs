using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using VMBrevis.DadosAcesso;
using VMBrevis.Manipulador;

namespace VMBrevis.Gerenciador
{
    public class Remove : Dados
    {
        /// <summary>
        /// Remoção de dados conforme parametros, cuidado é sempre bom na hora da remoção de infomações.
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dados"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        //public T RemoveT<T>(T dados, long idUsuario)
        //{
        //    FieldInfo dhInicio = dados.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(w => w.Name.Contains("dh_inicio")).Select(s => s).FirstOrDefault();
        //    dhInicio.SetValue(dados, DateTime.Now);
        //    List<SqlParameter> parametros = MontaParametros(dados, Operacao.Exclusao, false, idUsuario);
        //    return ConverteDeSqlDataReaderParaT(ExecucaoGenerica<object>(parametros, Esquemas.dbo), dados);
        //}

        public void RemoveExecucaoGenerica<T>(T objetoUsuario, long id)
        {
            throw new NotImplementedException();
        }
    }
}
