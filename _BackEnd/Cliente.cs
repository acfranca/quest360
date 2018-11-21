using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuestRep._BackEnd
{
    public class Cliente : SQLDataAccess
    {
        public DataTable Selecionar(long pCodigo, int pRepresentante, string pNome, string pResponsavel)
        {
            SqlParameter[] param = new SqlParameter[] {
                  CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Input, pCodigo.Equals(long.MinValue) ? (object)DBNull.Value : pCodigo)
                 ,CreateParameter("pREPRESENTANTE", SqlDbType.Int, 5, ParameterDirection.Input, pRepresentante.Equals(int.MinValue) ? (object)DBNull.Value : pRepresentante)
                 ,CreateParameter("pNOME", SqlDbType.NVarChar, 200, ParameterDirection.Input, string.IsNullOrEmpty(pNome) ? (object)DBNull.Value : pNome)
                 ,CreateParameter("pRESPONSAVEL", SqlDbType.NVarChar, 200, ParameterDirection.Input, string.IsNullOrEmpty(pResponsavel) ? (object)DBNull.Value : pResponsavel)
            };

            return ExecuteDataTable("CLIENTE_SELECT", param);
        }

        public string Incluir(string pNome
            , string pResponsavel
            , int pRepresentante
            , string pEmail
            , string pTelefone
            , string pEndereco
            , string pCidade
            , string pUF
            , string pCEP
            , char pTipoPessoa
            , string pCPF
            , string pCNPJ
            )
        {
            long pCodigo = 0;

            SqlParameter[] param = new SqlParameter[] {
                 CreateParameter("pNOME", SqlDbType.NVarChar, 200, ParameterDirection.Input, pNome.ToUpper())
                ,CreateParameter("pRESPONSAVEL", SqlDbType.NVarChar, 200, ParameterDirection.Input, pResponsavel.ToUpper())
                ,CreateParameter("pREPRESENTANTE", SqlDbType.Int, 5, ParameterDirection.Input, pRepresentante)
                ,CreateParameter("pEMAIL", SqlDbType.NVarChar, 200, ParameterDirection.Input, pEmail.ToLower())
                ,CreateParameter("pTELEFONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, pTelefone)
                ,CreateParameter("pENDERECO", SqlDbType.NVarChar, 500, ParameterDirection.Input, pEndereco)
                ,CreateParameter("pCIDADE", SqlDbType.NVarChar, 100, ParameterDirection.Input, pCidade)
                ,CreateParameter("pUF", SqlDbType.NVarChar, 2, ParameterDirection.Input, pUF)
                ,CreateParameter("pCEP", SqlDbType.NVarChar, 9, ParameterDirection.Input, pCEP)
                ,CreateParameter("pTIPO_PESSOA", SqlDbType.Char, 1, ParameterDirection.Input, pTipoPessoa)
                ,CreateParameter("pCPF", SqlDbType.NVarChar, 20, ParameterDirection.Input, pCPF)
                ,CreateParameter("pCNPJ", SqlDbType.NVarChar, 20, ParameterDirection.Input, pCNPJ)
                ,CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Output, pCodigo)};

            return ExecuteNonQuery("CLIENTE_INSERT", param, "pCODIGO");
        }

        public void Alterar(long pCodigo
            , string pResponsavel
            , string pTelefone
            , string pEndereco
            , string pCidade
            , string pUF
            , string pCEP
            , char pTipoPessoa
            , string pCPF
            , string pCNPJ)
        {
            SqlParameter[] param = new SqlParameter[] {
                 CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Input, pCodigo)
                ,CreateParameter("pRESPONSAVEL", SqlDbType.NVarChar, 200, ParameterDirection.Input, pResponsavel.ToUpper())
                ,CreateParameter("pTELEFONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, pTelefone)
                ,CreateParameter("pENDERECO", SqlDbType.NVarChar, 500, ParameterDirection.Input, pEndereco)
                ,CreateParameter("pCIDADE", SqlDbType.NVarChar, 100, ParameterDirection.Input, pCidade)
                ,CreateParameter("pUF", SqlDbType.NVarChar, 2, ParameterDirection.Input, pUF)
                ,CreateParameter("pCEP", SqlDbType.NVarChar, 9, ParameterDirection.Input, pCEP)
                ,CreateParameter("pTIPO_PESSOA", SqlDbType.Char, 1, ParameterDirection.Input, pTipoPessoa)
                ,CreateParameter("pCPF", SqlDbType.NVarChar, 20, ParameterDirection.Input, pCPF)
                ,CreateParameter("pCNPJ", SqlDbType.NVarChar, 20, ParameterDirection.Input, pCNPJ)
            };

            ExecuteNonQuery("CLIENTE_UPDATE_REP", param);
        }

    }
}