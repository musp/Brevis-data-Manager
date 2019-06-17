using System.ComponentModel;

namespace VMBrevis.DadosAcesso
{
    enum ConexoesAcessos
    {
        ReservasOnline = 1
    }

    enum Esquemas
    {
        [Description("Esquema pricipal")]
        dbo = 1,
        VMP = 2
    }
    enum AcessoProcedure
    {
        [Description("@PRC_")]
        prc = 1
    }
    enum acao
    {
        [Description("SELECT * FROM ")]
        Selecao = 1,
        [Description("UPDATE TABELA SET COLUNAS WHERE CLAUSULAS")]
        Alteracao = 2,
        [Description("INSERT INTO TABELA (COLUNAS) VALUES DADOS")]
        Adicao = 3,
        [Description("DELETE FROM TABELA WHERE CLAUSULAS")]
        RemocaoFisica = 4,
        [Description("UPDATE TABELA SET ativo = 0 WHERE CLAUSULAS")]
        RemocaoLogica = 5
    }


}
