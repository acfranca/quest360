using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuestRep._BackEnd
{
    public class Representante : SQLDataAccess
    {
        public DataTable Selecionar(long pCodigo)
        {
            SqlParameter[] param = new SqlParameter[] {
                 CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Input, pCodigo.Equals(long.MinValue) ? (object)DBNull.Value : pCodigo)};

            return ExecuteDataTable("REPRESENTANTE_SELECT", param);
        }

        public void AlterarSenha(long pCodigo, string pSenha)
        {
            SqlParameter[] param = new SqlParameter[] {
                CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Input, pCodigo)
                ,CreateParameter("pSENHA", SqlDbType.NVarChar, 200, ParameterDirection.Input, string.IsNullOrEmpty(pSenha) ? (object)DBNull.Value : pSenha)
            };

            ExecuteNonQuery("REPRESENTANTE_UPDATE_SENHA", param);
        }

        public DataTable ValidarAcesso(string pEmail)
        {
            SqlParameter[] param = new SqlParameter[] {
                CreateParameter("pEMAIL", SqlDbType.NVarChar, 200, ParameterDirection.Input, pEmail)};

            return ExecuteDataTable("REPRESENTANTE_SELECT_ACESSO", param);
        }

        public string Incluir(string pNome, string pEmail, string pTelefone, string pEndereco, string pCidade, string pUF, string pSenha, char pPessoa, string pCPF, string pCNPJ, char pAtivo, string pPerfil, decimal pPerLicenca, decimal pPerDispositivo)
        {
            long pCodigo = 0;

            SqlParameter[] param = new SqlParameter[] {
                 CreateParameter("pNOME", SqlDbType.NVarChar, 200, ParameterDirection.Input, pNome.ToUpper())
                ,CreateParameter("pEMAIL", SqlDbType.NVarChar, 200, ParameterDirection.Input, pEmail)
                ,CreateParameter("pTELEFONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, pTelefone.ToUpper())
                ,CreateParameter("pENDERECO", SqlDbType.NVarChar, 500, ParameterDirection.Input, pEndereco )
                ,CreateParameter("pCIDADE", SqlDbType.NVarChar, 100, ParameterDirection.Input, pCidade)
                ,CreateParameter("pUF", SqlDbType.NVarChar, 2, ParameterDirection.Input, pUF)
                ,CreateParameter("pSENHA", SqlDbType.NVarChar, 200, ParameterDirection.Input, pSenha)
                ,CreateParameter("pPESSOA", SqlDbType.Char, 1, ParameterDirection.Input, pPessoa)
                ,CreateParameter("pCPF", SqlDbType.NVarChar, 20, ParameterDirection.Input, pCPF)
                ,CreateParameter("pCNPJ", SqlDbType.NVarChar, 20, ParameterDirection.Input, pCNPJ)
                ,CreateParameter("pATIVO", SqlDbType.Char, 1, ParameterDirection.Input, pAtivo)
                ,CreateParameter("pPERFIL", SqlDbType.NVarChar, 15, ParameterDirection.Input, pPerfil)
                ,CreateParameter("pPER_LICENCA", SqlDbType.Decimal, 18, ParameterDirection.Input, pPerLicenca)
                ,CreateParameter("pPER_DISPOSITIVO", SqlDbType.Decimal, 18, ParameterDirection.Input, pPerDispositivo)
                ,CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Output, pCodigo)
            };

            return ExecuteNonQuery("REPRESENTANTE_INSERT", param, "pCODIGO");
        }

        public void Alterar(long pCodigo, string pNome, string pTelefone, string pEndereco, string pCidade, string pUF, char pPessoa, string pCPF, string pCNPJ, char pAtivo, string pPerfil, decimal pPerLicenca, decimal pPerDispositivo)
        {
            SqlParameter[] param = new SqlParameter[] {
                 CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Input, pCodigo)
                ,CreateParameter("pNOME", SqlDbType.NVarChar, 200, ParameterDirection.Input, pNome.ToUpper())
                ,CreateParameter("pTELEFONE", SqlDbType.NVarChar, 50, ParameterDirection.Input, pTelefone.ToUpper())
                ,CreateParameter("pENDERECO", SqlDbType.NVarChar, 500, ParameterDirection.Input, pEndereco )
                ,CreateParameter("pCIDADE", SqlDbType.NVarChar, 100, ParameterDirection.Input, pCidade)
                ,CreateParameter("pUF", SqlDbType.NVarChar, 2, ParameterDirection.Input, pUF)
                ,CreateParameter("pPESSOA", SqlDbType.Char, 1, ParameterDirection.Input, pPessoa)
                ,CreateParameter("pCPF", SqlDbType.NVarChar, 20, ParameterDirection.Input, pCPF)
                ,CreateParameter("pCNPJ", SqlDbType.NVarChar, 20, ParameterDirection.Input, pCNPJ)
                ,CreateParameter("pATIVO", SqlDbType.Char, 1, ParameterDirection.Input, pAtivo)
                ,CreateParameter("pPERFIL", SqlDbType.NVarChar, 15, ParameterDirection.Input, pPerfil)
                ,CreateParameter("pPER_LICENCA", SqlDbType.Decimal, 18, ParameterDirection.Input, pPerLicenca)
                ,CreateParameter("pPER_DISPOSITIVO", SqlDbType.Decimal, 18, ParameterDirection.Input, pPerDispositivo)
            };

            ExecuteNonQuery("REPRESENTANTE_UPDATE", param);
        }
    }
}


