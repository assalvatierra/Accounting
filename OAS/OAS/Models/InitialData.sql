insert into [dbo].[fsAccntCategories]([Name],[Sort]) values
('Asset Accounts',1),
('Liability Accounts',2),
('Owners Equity Accounts',3),
('Operating Revenue Accounts',4),
('Operating Expense Accounts',5),
('Non-Operating Revenues,Expenses,Gains, and Losses',6);

insert into [dbo].[fsAccounts] ([AccntNo],[AccntTitle],[Description],[IncreaseCode],[fsAccntCategoryId]) values
--#1 Asset Accounts--
('110','CASH','Cash','DB',1),
('120','RECEIVABLES','Products/services owed to the company. performed but not yet paid ','DB',1),
('140','MERCHANDISE','Cost of merchandise purchased but not yet sold','DB',1),
('150','SUPPLIES','Cost of supplies purchased but not yet used','DB',1),
('160','PREPAID INSURANCE','Cost of insurance that are paid in advance','DB',1),
('160','LAND','Cost of Land','DB',1),
('170','BUILDINGS','Cost of purchase/construct building/office for company use, ','DB',1),
('175','FURNITURES','Cost of purchase/construct office furnitures for company use, ','DB',1),
('180','EQUIPMENTS','Cost of purchase of equipments/vehicles for company use, ','DB',1),
('190','DEPRECIATION','Cost of depreciation','CR',1),


--#2 Liability Accounts--
('210','NOTES PAYABLE','Written promise','CR',2),
('215','ACCOUNTS PAYABLE','Amount owed to suppliers','CR',2),
('220','WAGES PAYABLE','Amount owed to employees','CR',2),
('230','INTEREST PAYABLE','Amount owed for interest on notes payable','CR',2),
('240','UNEARNED REVENUES','Amount received in advance of providing service','CR',2),
('250','MORTGAGE LOAN PAYABLE','A formal loan ','CR',2),


--#3 Owners Equity Accounts--
('290','MARY SMITH CAPITAL','Amount of the owner invested in the company','CR',3),
('295','MARY SMITH DRAWING','Amount of the owner withdrawn for personal use','DB',3),


--#4 Operating Revenue Accounts--
('310','SERVICE REVENUES','Amounts earned from providing services','CR',4),

--#5 Operating Expense Accounts--
('500','SALARIES EXPENSE','Expenses for the work by salaried employees','DB',5),
('510','WAGES EXPENSE','Expenses for the work by non-salaried employees','DB',5),
('540','SUPPLIES EXPENSE','Cost of supplies','DB',5),
('560','RENT EXPENSE','Cost of occupying ented facilities','DB',5),
('570','UTILITIES EXPENSE','Cost of electricity, heat, water, and sewer','DB',5),
('576','TELEPHONE EXPENSE','Cost of telephone','DB',5),
('610','ADVERTISING EXPENSE','Cost for ads, promotions, and other selling expenses','DB',5),
('750','DEPRECIATION EXPENSE','Cost of long-term assets','DB',5),

--#6 Non-Operating Revenues and Expenses, Gains, and Losses--
('810','INTEREST REVENUES','Interest and dividends on bank accounts, investments or notes receivable','CR',6),
('910','GAIN ON SALE OF ASSETS','Occurs when company sells one of its assets for more than the value','CR',6),
('960','LOSS ON SALE OF ASSTES','Occurs when company sells one of its assets for less than the value','DB',6);



insert into [dbo].[fsSubAccnts](    [fsAccountId],    [Name],    [Remarks]) values
(2,'Company A', 'Test company - edit name to use'),
(2,'Company BB', 'Test company - edit name to use'),
(2,'Company CCC', 'Test company - edit name to use'),
(9,'Vehicle RNY301', 'MPV: Toyota Innova 2013 Brown'),
(9,'Vehicle AAF8980', 'MPV: Toyota Innova 2015 Silver'),
(9,'Vehicle LHH718', 'SEDAN: Honda City 2013 Titanium'),
(12,'Payable A', 'Test company - edit name to use'),
(12,'Payable B', 'Test company - edit name to use');

insert into [dbo].[fsTrxStatus] ( [Status] ) values
('DRAFT'),('SUBMITTED'),('POSTED');
