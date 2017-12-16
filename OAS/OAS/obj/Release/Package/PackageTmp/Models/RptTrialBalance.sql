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
and DATEPART(mm, b.DtTrx) = '9'
and DATEPART(yy, b.DtTrx) = '2017'
order by c.AccntNo, b.DtTrx
;
