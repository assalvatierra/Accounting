insert into [dbo].[fsEntities]([Name]) values
('RealBreeze'),('AJ DAVAO');

insert into [dbo].[fsUsers]([LoginName]) values
('abel@yahoo.com');

insert into [dbo].[fsEntityUsers] ([fsEntityId],[fsuserid],[isadmin]) values
(1,1,1),(2,1,1);

insert into [dbo].[fsAccntCategories]([Name],[Sort]) values
('Asset Accounts',1),
('Liability Accounts',2),
('Owners Equity Accounts',3),
('Operating Revenue Accounts',4),
('Operating Expense Accounts',5),
('Non-Operating Revenues,Expenses,Gains, and Losses',6);

insert into [dbo].[fsAccounts] ([AccntNo],[AccntTitle],[Description],[IncreaseCode],[fsAccntCategoryId],[fsEntityId]) values
--#1 Asset Accounts--
('110','CASH','Cash','DB',1,1),
('120','RECEIVABLES','Products/services owed to the company. performed but not yet paid ','DB',1,1),
('140','MERCHANDISE','Cost of merchandise purchased but not yet sold','DB',1,1),
('150','SUPPLIES','Cost of supplies purchased but not yet used','DB',1,1),
('160','PREPAID INSURANCE','Cost of insurance that are paid in advance','DB',1,1),
('160','LAND','Cost of Land','DB',1,1),
('170','BUILDINGS','Cost of purchase/construct building/office for company use, ','DB',1,1),
('175','FURNITURES','Cost of purchase/construct office furnitures for company use, ','DB',1,1),
('180','EQUIPMENTS','Cost of purchase of equipments/vehicles for company use, ','DB',1,1),
('190','DEPRECIATION','Cost of depreciation','CR',1,1),


--#2 Liability Accounts--
('210','NOTES PAYABLE','Written promise','CR',2,1),
('215','ACCOUNTS PAYABLE','Amount owed to suppliers','CR',2,1),
('220','WAGES PAYABLE','Amount owed to employees','CR',2,1),
('230','INTEREST PAYABLE','Amount owed for interest on notes payable','CR',2,1),
('240','UNEARNED REVENUES','Amount received in advance of providing service','CR',2,1),
('250','MORTGAGE LOAN PAYABLE','A formal loan ','CR',2,1),


--#3 Owners Equity Accounts--
('290','MARY SMITH CAPITAL','Amount of the owner invested in the company','CR',3,1),
('295','MARY SMITH DRAWING','Amount of the owner withdrawn for personal use','DB',3,1),


--#4 Operating Revenue Accounts--
('310','SERVICE REVENUES','Amounts earned from providing services','CR',4,1),

--#5 Operating Expense Accounts--
('500','SALARIES EXPENSE','Expenses for the work by salaried employees','DB',5,1),
('510','WAGES EXPENSE','Expenses for the work by non-salaried employees','DB',5,1),
('540','SUPPLIES EXPENSE','Cost of supplies','DB',5,1),
('560','RENT EXPENSE','Cost of occupying ented facilities','DB',5,1),
('570','UTILITIES EXPENSE','Cost of electricity, heat, water, and sewer','DB',5,1),
('576','TELEPHONE EXPENSE','Cost of telephone','DB',5,1),
('610','ADVERTISING EXPENSE','Cost for ads, promotions, and other selling expenses','DB',5,1),
('750','DEPRECIATION EXPENSE','Cost of long-term assets','DB',5,1),

--#6 Non-Operating Revenues and Expenses, Gains, and Losses--
('810','INTEREST REVENUES','Interest and dividends on bank accounts, investments or notes receivable','CR',6,1),
('910','GAIN ON SALE OF ASSETS','Occurs when company sells one of its assets for more than the value','CR',6,1),
('960','LOSS ON SALE OF ASSTES','Occurs when company sells one of its assets for less than the value','DB',6,1);



insert into [dbo].[fsSubAccnts](    [fsAccountId],    [Name],    [Remarks], [fsEntityId] ) values
(1,'Not Applicable', 'Not Applicable',1),
(1,'BDO', 'Banco De Oro',1),
(1,'BPI', 'Bank of the Philippine Islands',1),
(1,'ELVIE', 'COH(Elvie)',1),
(1,'ABEL', 'COH(Abel)',1),
(1,'JOSETTE', 'COH(Josette)',1),
(2,'Company AAA', 'Test company - edit name to use',1),
(2,'Company BBB', 'Test company - edit name to use',1),
(2,'Company CCC', 'Test company - edit name to use',1),
(9,'Innova RNY301', 'MPV: Toyota Innova 2013 Brown',1),
(9,'Innova AAF8980', 'MPV: Toyota Innova 2015 Silver',1),
(9,'Honda LHH718', 'SEDAN: Honda City 2013 Titanium',1),
(9,'Everest ADP2264', 'SUV: Ford Everest 2016',1),
(9,'Fortuner NEO380', 'SUV: Toyota Fortuner 2011',1),
(9,'S.Grandia AOA5108', 'VAN: Toyota Super Grandia 2015',1),
(12,'Payable A', 'Test company - edit name to use',1),
(12,'Payable B', 'Test company - edit name to use',1);

insert into [dbo].[fsTrxStatus] ( [Status] ) values
('DRAFT'),('SUBMITTED'),('POSTED');

insert into [dbo].[fsRptCats] ([RptCatName]) values
('CASH'),('Owners Equity');

insert into [dbo].fsRptCatAccnts ([fsRptCatId],[fsAccountId],[Sort]) values
(1,1,1),(2,17,1),(2,18,2);