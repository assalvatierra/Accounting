insert into [dbo].[fsAccntCategories]([Name],[Sort]) values
('Asset Accounts',1),
('Liability Accounts',2),
('Owners Equity Accounts',3),
('Operating Revenue Accounts',4),
('Operating Expense Accounts',5),
('Non-Operating Revenues,Expenses,Gains, and Losses',6);

insert into [dbo].[fsAccounts] ([AccntNo],[AccntTitle],[Description],[IncreaseCode],[fsAccntCategoryId]) values
--Assets--
('110','CASH','Cash','DB',1),
('120','RECEIVABLES','Products/services owed to the company. performed but not yet paid ','DB',1),
('140','MERCHANDISE','Cost of merchandise purchased but not yet sold','DB',1),
('150','SUPPLIES','Cost of supplies purchased but not yet used','DB',1),
('160','PREPAID INSURANCE','Cost of insurance that are paid in advance','DB',1),
('160','LAND','Cost of Land','DB',1),
('170','BUILDINGS','Cost of purchase/construct building/office for company use, ','DB',1),
('175','FURNITURES','Cost of purchase/construct office furnitures for company use, ','DB',1),
('180','EQUIPMENTS','Cost of purchase of equipments/vehicles for company use, ','DB',1),
('190','DEPRECIATION','Cost of depreciation','CR',1);


