using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuestRep._BackEnd
{
    public class ClienteLicenca : SQLDataAccess
    {
        public DataTable Selecionar(long pCodigo, long pCliente, string pSitLicenca, string pSitPagto, string pSitPagtoComissao, string pVigencia, string pChaveLicenca)
        {
            SqlParameter[] param = new SqlParameter[] {
             CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Input, pCodigo.Equals(long.MinValue) ? (object)DBNull.Value : pCodigo)
            ,CreateParameter("pCLIENTE", SqlDbType.Int, 5, ParameterDirection.Input, pCliente.Equals(long.MinValue) ? (object)DBNull.Value : pCliente)
            ,CreateParameter("pSIT_LICENCA", SqlDbType.NVarChar, 20, ParameterDirection.Input, string.IsNullOrEmpty(pSitLicenca) ? (object)DBNull.Value : pSitLicenca)
            ,CreateParameter("pSIT_PAGAMENTO", SqlDbType.NVarChar, 20, ParameterDirection.Input, string.IsNullOrEmpty(pSitPagto) ? (object)DBNull.Value : pSitPagto)
            ,CreateParameter("pSIT_COMISSAO_PAGTO", SqlDbType.NVarChar, 20, ParameterDirection.Input, string.IsNullOrEmpty(pSitPagtoComissao) ? (object)DBNull.Value : pSitPagtoComissao)
            ,CreateParameter("pVIGENCIA", SqlDbType.NVarChar, 20, ParameterDirection.Input, string.IsNullOrEmpty(pVigencia) ? (object)DBNull.Value : Convert.ToChar(pVigencia))
            ,CreateParameter("pCHAVE_LICENCA", SqlDbType.NVarChar, 50, ParameterDirection.Input, string.IsNullOrEmpty(pChaveLicenca) ? (object)DBNull.Value : pChaveLicenca)
            };

            return ExecuteDataTable("CLIENTE_LICENCA_SELECT", param);
        }
        
        public string Incluir(long pCliente, string pChaveLicenca, DateTime pVigInicio, DateTime pVigTermino, char pVigencia, int pQtdeLicenca, int pQtdeTablet7, int pQtdeSupMesa7, int pQtdeTablet10, int pQtdeSupMesa10, int pQtdeSupChao, decimal pVlrTrimestral, decimal pVlrSemestral, decimal pVlrAnual, decimal pVlrTablet7, decimal pVlrSupMesa7, decimal pVlrTablet10, decimal pVlrSupMesa10, decimal pVlrSupChao, decimal pVlrTotalLicenca, decimal pVlrTotalDispostivo, decimal pVlrTotal, decimal pPerLicenca, decimal pPerDispositivo, decimal pVlrComissaoLicenca, decimal pVlrComissaoDispositivo, string pObsLicenca)
        {
            long pCodigo = 0;

            SqlParameter[] param = new SqlParameter[] {
                 CreateParameter("pCLIENTE", SqlDbType.BigInt, 10, ParameterDirection.Input, pCliente)
                ,CreateParameter("pCHAVE_LICENCA", SqlDbType.NVarChar, 100, ParameterDirection.Input, pChaveLicenca)
                ,CreateParameter("pDTA_VIGENCIA_INICIO", SqlDbType.Date, 10, ParameterDirection.Input, pVigInicio)
                ,CreateParameter("pDTA_VIGENCIA_TERMINO", SqlDbType.Date, 10, ParameterDirection.Input, pVigTermino)
                ,CreateParameter("pVIGENCIA", SqlDbType.Char, 1, ParameterDirection.Input, pVigencia)
                ,CreateParameter("pQTDE_LICENCA", SqlDbType.Int, 5, ParameterDirection.Input, pQtdeLicenca)
                ,CreateParameter("pQTDE_TABLET_7", SqlDbType.Int, 5, ParameterDirection.Input, pQtdeTablet7)
                ,CreateParameter("pQTDE_SUP_MESA_7", SqlDbType.Int, 5, ParameterDirection.Input, pQtdeSupMesa7)
                ,CreateParameter("pQTDE_TABLET_10", SqlDbType.Int, 5, ParameterDirection.Input, pQtdeTablet10)
                ,CreateParameter("pQTDE_SUP_MESA_10", SqlDbType.Int, 5, ParameterDirection.Input, pQtdeSupMesa10)
                ,CreateParameter("pQTDE_SUP_CHAO", SqlDbType.Int, 5, ParameterDirection.Input, pQtdeSupChao)
                ,CreateParameter("pVLR_TRIMESTRAL", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTrimestral)
                ,CreateParameter("pVLR_SEMESTRAL", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrSemestral)
                ,CreateParameter("pVLR_ANUAL", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrAnual)
                ,CreateParameter("pVLR_TABLET_7", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTablet7)
                ,CreateParameter("pVLR_SUP_MESA_7", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrSupMesa7)
                ,CreateParameter("pVLR_TABLET_10", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTablet10)
                ,CreateParameter("pVLR_SUP_MESA_10", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrSupMesa10)
                ,CreateParameter("pVLR_SUP_CHAO", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrSupChao)
                ,CreateParameter("pVLR_TOTAL_LICENCA", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTotalLicenca)
                ,CreateParameter("pVLR_TOTAL_DISPOSITIVO", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTotalDispostivo)
                ,CreateParameter("pVLR_TOTAL", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTotal)
                ,CreateParameter("pPER_LICENCA", SqlDbType.Decimal, 18, ParameterDirection.Input, pPerLicenca)
                ,CreateParameter("pPER_DISPOSITIVO", SqlDbType.Decimal, 18, ParameterDirection.Input, pPerDispositivo)
                ,CreateParameter("pVLR_COMISSAO_LICENCA", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrComissaoLicenca)
                ,CreateParameter("pVLR_COMISSAO_DISPOSITIVO", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrComissaoDispositivo)
                ,CreateParameter("pOBS_LICENCA", SqlDbType.NVarChar, 400, ParameterDirection.Input, pObsLicenca)
                ,CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Output, pCodigo)};

            return ExecuteNonQuery("CLIENTE_LICENCA_INSERT", param, "pCODIGO");
        }

        public void Alterar(long pCodigo, string pSitLicenca, string pSitPagto, DateTime pDtaPagto, string pSitPagtoComissao, DateTime pDtaPagtoComissao, string pObsPagto, long pUser)
        {

            SqlParameter[] param = new SqlParameter[] {
                 CreateParameter("pCODIGO", SqlDbType.BigInt, 10, ParameterDirection.Input, pCodigo)
                ,CreateParameter("pSIT_LICENCA", SqlDbType.NVarChar, 20, ParameterDirection.Input, pSitLicenca)
                ,CreateParameter("pSIT_PAGAMENTO", SqlDbType.NVarChar, 20, ParameterDirection.Input, pSitPagto)
                ,CreateParameter("pDTA_PAGAMENTO", SqlDbType.Date, 10, ParameterDirection.Input, pDtaPagto.Equals(DateTime.MinValue) ? (object)DBNull.Value : pDtaPagto)
                ,CreateParameter("pSIT_COMISSAO_PAGTO", SqlDbType.NVarChar, 20, ParameterDirection.Input, pSitPagtoComissao)
                ,CreateParameter("pDTA_COMISSAO_PAGTO", SqlDbType.Date, 10, ParameterDirection.Input, pDtaPagtoComissao.Equals(DateTime.MinValue) ? (object)DBNull.Value : pDtaPagtoComissao)
                ,CreateParameter("pOBS_PAGAMENTO", SqlDbType.NVarChar, 4000, ParameterDirection.Input, pObsPagto)
                ,CreateParameter("pREPRESENTANTE", SqlDbType.Int, 5, ParameterDirection.Input, pUser)};

            ExecuteNonQuery("CLIENTE_LICENCA_UPDATE", param);
        }
    }
}
