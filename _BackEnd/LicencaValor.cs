using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuestRep._BackEnd
{
    public class LicencaValor : SQLDataAccess
    {
        public DataTable Selecionar()
        {
            SqlParameter[] param = new SqlParameter[] { };
            return ExecuteDataTable("LICENCA_VALOR_SELECT", param);
        }

        public void Incluir(decimal pVlrTrimestral, decimal pVlrSemestral, decimal pVlrAnual, decimal pVlrTablet_7, decimal pVlrSupMesa_7, decimal pVlrTablet_10, decimal pVlrSupMesa_10, decimal pVlrSupChao, int pRepresentante)
        {
            SqlParameter[] param = new SqlParameter[] {
                 CreateParameter("pVLR_TRIMESTRAL", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTrimestral)
                ,CreateParameter("pVLR_SEMESTRAL", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrSemestral)
                ,CreateParameter("pVLR_ANUAL", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrAnual)
                ,CreateParameter("pVLR_TABLET_7", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTablet_7)
                ,CreateParameter("pVLR_SUP_MESA_7", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrSupMesa_7)
                ,CreateParameter("pVLR_TABLET_10", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrTablet_10)
                ,CreateParameter("pVLR_SUP_MESA_10", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrSupMesa_10)
                ,CreateParameter("pVLR_SUP_CHAO", SqlDbType.Decimal, 18, ParameterDirection.Input, pVlrSupChao)
                ,CreateParameter("pREPRESENTANTE", SqlDbType.BigInt, 10, ParameterDirection.Input, pRepresentante)};

            ExecuteNonQuery("LICENCA_VALOR_INSERT", param);
        }
    }
}


