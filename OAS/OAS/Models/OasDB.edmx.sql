
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/13/2017 15:46:36
-- Generated from EDMX file: D:\Data\Real\Apps\GitHub\Accounting\OAS\OAS\Models\OasDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-OAS-20170912094929];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_fsAccntCategoryfsAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[fsAccounts] DROP CONSTRAINT [FK_fsAccntCategoryfsAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_fsAccountfsTrxDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[fsTrxDetails] DROP CONSTRAINT [FK_fsAccountfsTrxDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_fsTrxHdrfsTrxDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[fsTrxDetails] DROP CONSTRAINT [FK_fsTrxHdrfsTrxDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_fsAccountfsSubAccnt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[fsSubAccnts] DROP CONSTRAINT [FK_fsAccountfsSubAccnt];
GO
IF OBJECT_ID(N'[dbo].[FK_fsSubAccntfsTrxDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[fsTrxDetails] DROP CONSTRAINT [FK_fsSubAccntfsTrxDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_fsConfigCodefsAccntSetting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[fsAccntSettings] DROP CONSTRAINT [FK_fsConfigCodefsAccntSetting];
GO
IF OBJECT_ID(N'[dbo].[FK_fsTrxStatusfsTrxHdr]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[fsTrxHdrs] DROP CONSTRAINT [FK_fsTrxStatusfsTrxHdr];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fsAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fsAccounts];
GO
IF OBJECT_ID(N'[dbo].[fsAccntCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fsAccntCategories];
GO
IF OBJECT_ID(N'[dbo].[fsTrxHdrs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fsTrxHdrs];
GO
IF OBJECT_ID(N'[dbo].[fsTrxDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fsTrxDetails];
GO
IF OBJECT_ID(N'[dbo].[fsSubAccnts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fsSubAccnts];
GO
IF OBJECT_ID(N'[dbo].[fsAccntSettings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fsAccntSettings];
GO
IF OBJECT_ID(N'[dbo].[fsConfigCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fsConfigCodes];
GO
IF OBJECT_ID(N'[dbo].[fsTrxStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fsTrxStatus];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'fsAccounts'
CREATE TABLE [dbo].[fsAccounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccntNo] nvarchar(10)  NOT NULL,
    [AccntTitle] nvarchar(150)  NOT NULL,
    [Description] nvarchar(250)  NULL,
    [IncreaseCode] nvarchar(2)  NOT NULL,
    [fsAccntCategoryId] int  NOT NULL
);
GO

-- Creating table 'fsAccntCategories'
CREATE TABLE [dbo].[fsAccntCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Sort] int  NOT NULL
);
GO

-- Creating table 'fsTrxHdrs'
CREATE TABLE [dbo].[fsTrxHdrs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DtTrx] datetime  NOT NULL,
    [trxRemarks] nvarchar(80)  NULL,
    [dtEntry] datetime  NOT NULL,
    [EnteredBy] nvarchar(80)  NOT NULL,
    [dtEdit] datetime  NULL,
    [EditedBy] nvarchar(80)  NULL,
    [fsTrxStatusId] int  NOT NULL
);
GO

-- Creating table 'fsTrxDetails'
CREATE TABLE [dbo].[fsTrxDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fsTrxHdrId] int  NOT NULL,
    [fsAccountId] int  NOT NULL,
    [fsSubAccntId] int  NULL,
    [Description] nvarchar(150)  NOT NULL,
    [Debit] decimal(18,0)  NOT NULL,
    [Credit] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'fsSubAccnts'
CREATE TABLE [dbo].[fsSubAccnts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fsAccountId] int  NOT NULL,
    [Name] nvarchar(80)  NOT NULL,
    [Remarks] nvarchar(180)  NULL
);
GO

-- Creating table 'fsAccntSettings'
CREATE TABLE [dbo].[fsAccntSettings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fsConfigCodeId] int  NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [Value] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'fsConfigCodes'
CREATE TABLE [dbo].[fsConfigCodes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'fsTrxStatus'
CREATE TABLE [dbo].[fsTrxStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'fsAccounts'
ALTER TABLE [dbo].[fsAccounts]
ADD CONSTRAINT [PK_fsAccounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'fsAccntCategories'
ALTER TABLE [dbo].[fsAccntCategories]
ADD CONSTRAINT [PK_fsAccntCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'fsTrxHdrs'
ALTER TABLE [dbo].[fsTrxHdrs]
ADD CONSTRAINT [PK_fsTrxHdrs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'fsTrxDetails'
ALTER TABLE [dbo].[fsTrxDetails]
ADD CONSTRAINT [PK_fsTrxDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'fsSubAccnts'
ALTER TABLE [dbo].[fsSubAccnts]
ADD CONSTRAINT [PK_fsSubAccnts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'fsAccntSettings'
ALTER TABLE [dbo].[fsAccntSettings]
ADD CONSTRAINT [PK_fsAccntSettings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'fsConfigCodes'
ALTER TABLE [dbo].[fsConfigCodes]
ADD CONSTRAINT [PK_fsConfigCodes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'fsTrxStatus'
ALTER TABLE [dbo].[fsTrxStatus]
ADD CONSTRAINT [PK_fsTrxStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [fsAccntCategoryId] in table 'fsAccounts'
ALTER TABLE [dbo].[fsAccounts]
ADD CONSTRAINT [FK_fsAccntCategoryfsAccount]
    FOREIGN KEY ([fsAccntCategoryId])
    REFERENCES [dbo].[fsAccntCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fsAccntCategoryfsAccount'
CREATE INDEX [IX_FK_fsAccntCategoryfsAccount]
ON [dbo].[fsAccounts]
    ([fsAccntCategoryId]);
GO

-- Creating foreign key on [fsAccountId] in table 'fsTrxDetails'
ALTER TABLE [dbo].[fsTrxDetails]
ADD CONSTRAINT [FK_fsAccountfsTrxDetail]
    FOREIGN KEY ([fsAccountId])
    REFERENCES [dbo].[fsAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fsAccountfsTrxDetail'
CREATE INDEX [IX_FK_fsAccountfsTrxDetail]
ON [dbo].[fsTrxDetails]
    ([fsAccountId]);
GO

-- Creating foreign key on [fsTrxHdrId] in table 'fsTrxDetails'
ALTER TABLE [dbo].[fsTrxDetails]
ADD CONSTRAINT [FK_fsTrxHdrfsTrxDetail]
    FOREIGN KEY ([fsTrxHdrId])
    REFERENCES [dbo].[fsTrxHdrs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fsTrxHdrfsTrxDetail'
CREATE INDEX [IX_FK_fsTrxHdrfsTrxDetail]
ON [dbo].[fsTrxDetails]
    ([fsTrxHdrId]);
GO

-- Creating foreign key on [fsAccountId] in table 'fsSubAccnts'
ALTER TABLE [dbo].[fsSubAccnts]
ADD CONSTRAINT [FK_fsAccountfsSubAccnt]
    FOREIGN KEY ([fsAccountId])
    REFERENCES [dbo].[fsAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fsAccountfsSubAccnt'
CREATE INDEX [IX_FK_fsAccountfsSubAccnt]
ON [dbo].[fsSubAccnts]
    ([fsAccountId]);
GO

-- Creating foreign key on [fsSubAccntId] in table 'fsTrxDetails'
ALTER TABLE [dbo].[fsTrxDetails]
ADD CONSTRAINT [FK_fsSubAccntfsTrxDetail]
    FOREIGN KEY ([fsSubAccntId])
    REFERENCES [dbo].[fsSubAccnts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fsSubAccntfsTrxDetail'
CREATE INDEX [IX_FK_fsSubAccntfsTrxDetail]
ON [dbo].[fsTrxDetails]
    ([fsSubAccntId]);
GO

-- Creating foreign key on [fsConfigCodeId] in table 'fsAccntSettings'
ALTER TABLE [dbo].[fsAccntSettings]
ADD CONSTRAINT [FK_fsConfigCodefsAccntSetting]
    FOREIGN KEY ([fsConfigCodeId])
    REFERENCES [dbo].[fsConfigCodes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fsConfigCodefsAccntSetting'
CREATE INDEX [IX_FK_fsConfigCodefsAccntSetting]
ON [dbo].[fsAccntSettings]
    ([fsConfigCodeId]);
GO

-- Creating foreign key on [fsTrxStatusId] in table 'fsTrxHdrs'
ALTER TABLE [dbo].[fsTrxHdrs]
ADD CONSTRAINT [FK_fsTrxStatusfsTrxHdr]
    FOREIGN KEY ([fsTrxStatusId])
    REFERENCES [dbo].[fsTrxStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fsTrxStatusfsTrxHdr'
CREATE INDEX [IX_FK_fsTrxStatusfsTrxHdr]
ON [dbo].[fsTrxHdrs]
    ([fsTrxStatusId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------