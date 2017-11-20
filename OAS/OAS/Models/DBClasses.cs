using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAS.Models
{
    public class cTrialBalance
    {
        public string AccntNo { get; set; }
        public string AccntTitle { get; set; }
        public string IncreaseCode { get; set; }
        public int SubAccntId { get; set; }
        public string SubAccntName { get; set; }
        public DateTime DtTrx { get; set; }
        public int tMon { get; set; }
        public int tYr { get; set; }
        public int TrxId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }
    }

    public class DBClasses
    {
        Models.OasDBContainer db = new OasDBContainer();

        public List<cTrialBalance> getTrialBalance(int mon, int year)
        {
            string sSQL = @"
                select 
                c.AccntNo, c.AccntTitle, c.IncreaseCode,
                d.Id SubAccntId, d.Name SubAccntName,
                b.DtTrx, DATEPART(mm, b.DtTrx) tMon, DATEPART(yy, b.DtTrx) tYr,
                b.Id TrxId, a.Debit, a.Credit, a.Description 
                from 
                fsTrxDetails a
                left outer join fsTrxHdrs b on b.Id = a.fsTrxHdrId
                left outer join fsAccounts c on c.Id = a.fsAccountId
                left outer join fsSubAccnts d on d.Id = a.fsSubAccntId
                where b.fsTrxStatusId = '3'
                and DATEPART(mm, b.DtTrx) = '" + mon.ToString() + @"'
                and DATEPART(yy, b.DtTrx) = '"+ year.ToString() + @"'
                order by c.AccntNo, b.DtTrx;
            ";

            var data = db.Database.SqlQuery<cTrialBalance>(sSQL);
            return data.ToList();
        }
    }

}