﻿using System;
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
    public class cBalanceSheet
    {
        public int Id { get; set; }
        public string AccntNo { get; set; }
        public string AccntDesc { get; set; }
        public decimal Openning { get; set; }
        public decimal CurrentTotal { get; set; }
        public decimal AccntTotal { get; set; }
        public int catId { get; set; }
        public string catName { get; set; }
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

        public List<cBalanceSheet> getBalanceSheet(int mon, int year)
        {
            string sSQL = @"
select x.Id, 
max(x.AccntNo) as AccntNo,
max(x.Description) as AccntDesc,
(sum(x.openDebit) - sum(x.openCredit)) as Openning, 
(sum(x.curDebit) - sum(x.curCredit)) as CurrentTotal, 
(sum(x.openDebit) - sum(x.openCredit)) + (sum(x.curDebit) - sum(x.curCredit)) as AccntTotal,
max(x.catId) as catId,
max(x.catName) as catName
from 
(
select a.Id,
a.AccntNo, a.Description,
'0' openDebit,
'0' openCredit,
isnull(b.Debit,0) curDebit,
isnull(b.Credit,0) as curCredit,
d.Id catId,
d.Name catName 
from fsAccounts a
left join fsTrxDetails b on b.fsAccountId = a.Id
left join fsTrxHdrs c on c.Id = b.fsTrxHdrId
left outer join fsAccntCategories d on d.Id = a.fsAccntCategoryId
where
c.Id is null 
OR ( DATEPART(mm, c.DtTrx) = '"+ mon.ToString() +"' AND DATEPART(yy, c.DtTrx) = '"+ year.ToString() +@"' )

union

select a.Id,
a.AccntNo, a.Description,
isnull(b.Debit,0) openDebit,
isnull(b.Credit,0) as openCredit,
'0' curDebit,
'0' curCredit,
d.Id catId,
d.Name catName 
from fsAccounts a
left join fsTrxDetails b on b.fsAccountId = a.Id
left join fsTrxHdrs c on c.Id = b.fsTrxHdrId
left outer join fsAccntCategories d on d.Id = a.fsAccntCategoryId
where
c.Id is null 
OR 
	( 
		( DATEPART(yy, c.DtTrx) < '"+year.ToString()+@"' ) OR
		( DATEPART(mm, c.DtTrx) < '"+mon.ToString()+"' AND DATEPART(yy, c.DtTrx) = '"+year.ToString()+@"' )
	)

) as x
group by x.Id
;

            ";



            var data = db.Database.SqlQuery<cBalanceSheet>(sSQL);
            return data.ToList();


        }
    }

}