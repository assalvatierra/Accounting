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
OR ( DATEPART(mm, c.DtTrx) = '9' AND DATEPART(yy, c.DtTrx) = '2017' )

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
		( DATEPART(yy, c.DtTrx) < '2017' ) OR
		( DATEPART(mm, c.DtTrx) < '9' AND DATEPART(yy, c.DtTrx) = '2017' )
	)

) as x
group by x.Id
;