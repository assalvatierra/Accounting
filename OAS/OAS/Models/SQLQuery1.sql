select a.Id,
a.AccntNo, a.Description,
'0' openDebit,
'0' openCredit,
isnull(b.Debit,0) curDebit,
isnull(b.Credit,0) as curCredit,
d.Id catId,
d.Name catName,
a.fsEntityId 
from fsAccounts a
left join fsTrxDetails b on b.fsAccountId = a.Id
left join fsTrxHdrs c on c.Id = b.fsTrxHdrId
left outer join fsAccntCategories d on d.Id = a.fsAccntCategoryId
where
a.fsEntityId = '1'
and c.Id is null 
OR ( DATEPART(mm, c.DtTrx) = '12' AND DATEPART(yy, c.DtTrx) = '2017' and c.fsTrxStatusId = '2');
