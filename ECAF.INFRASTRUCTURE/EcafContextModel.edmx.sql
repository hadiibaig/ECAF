
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2024 04:31:54
-- Generated from EDMX file: C:\Users\HP\source\repos\ECAF\ECAF.INFRASTRUCTURE\EcafContextModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ECAF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Comments_Forms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Forms];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerFinances_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerFinances] DROP CONSTRAINT [FK_CustomerFinances_Customers];
GO
IF OBJECT_ID(N'[dbo].[FK_Customers_SiteCards]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_Customers_SiteCards];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_EcafForms_Forms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EcafForms] DROP CONSTRAINT [FK_EcafForms_Forms];
GO
IF OBJECT_ID(N'[dbo].[FK_FacilitiesManagers_SiteCards]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacilitiesManagers] DROP CONSTRAINT [FK_FacilitiesManagers_SiteCards];
GO
IF OBJECT_ID(N'[dbo].[FK_Forms_Forms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Forms] DROP CONSTRAINT [FK_Forms_Forms];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteCardAmounts_SiteCards]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SiteCardAmounts] DROP CONSTRAINT [FK_SiteCardAmounts_SiteCards];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteCardCharges_SiteCards]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SiteCardCharges] DROP CONSTRAINT [FK_SiteCardCharges_SiteCards];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteCardDatas_SiteCards]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SiteCardDatas] DROP CONSTRAINT [FK_SiteCardDatas_SiteCards];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteCards_SiteCards]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SiteCards] DROP CONSTRAINT [FK_SiteCards_SiteCards];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[CustomerFinances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerFinances];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[EcafForms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EcafForms];
GO
IF OBJECT_ID(N'[dbo].[FacilitiesManagers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacilitiesManagers];
GO
IF OBJECT_ID(N'[dbo].[Forms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Forms];
GO
IF OBJECT_ID(N'[dbo].[SiteCardAmounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SiteCardAmounts];
GO
IF OBJECT_ID(N'[dbo].[SiteCardCharges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SiteCardCharges];
GO
IF OBJECT_ID(N'[dbo].[SiteCardDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SiteCardDatas];
GO
IF OBJECT_ID(N'[dbo].[SiteCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SiteCards];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] bigint  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserId] bigint  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] bigint  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] bigint  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [CommentId] bigint IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NULL,
    [FormId] bigint  NULL
);
GO

-- Creating table 'CustomerFinances'
CREATE TABLE [dbo].[CustomerFinances] (
    [CustomerFinanceId] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NULL,
    [Number] nvarchar(50)  NULL,
    [CustomerId] bigint  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [InvoiceAddress] nvarchar(50)  NULL,
    [PostCode] nvarchar(50)  NULL,
    [CustomerType] int  NULL,
    [FinanceName] nvarchar(50)  NULL,
    [FinanceNumber] nvarchar(50)  NULL,
    [FinanceContactEmail] nvarchar(50)  NULL,
    [SiteCardId] bigint  NULL
);
GO

-- Creating table 'EcafForms'
CREATE TABLE [dbo].[EcafForms] (
    [EcafFormId] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [PinNumber] nvarchar(50)  NULL,
    [NewContract] bit  NULL,
    [SiteName] nvarchar(50)  NULL,
    [Position] nvarchar(50)  NULL,
    [Promotion] bit  NULL,
    [WeeklyHours] int  NULL,
    [Salary] int  NULL,
    [BranchManager] bit  NULL,
    [HolidayManager] bit  NULL,
    [HolidayYear] nvarchar(50)  NULL,
    [HolidayRule] nvarchar(50)  NULL,
    [HolidayEntitlement] int  NULL,
    [EffectiveDate] datetime  NULL,
    [FormId] bigint  NULL
);
GO

-- Creating table 'FacilitiesManagers'
CREATE TABLE [dbo].[FacilitiesManagers] (
    [FacilitiesManagerId] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Number] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [SiteCardId] bigint  NULL
);
GO

-- Creating table 'Forms'
CREATE TABLE [dbo].[Forms] (
    [FormId] bigint IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NULL,
    [Status] int  NULL,
    [AssignedToMe] bit  NULL,
    [DueDate] datetime  NULL,
    [SiteCardId] bigint  NULL,
    [EcafFormId] bigint  NULL,
    [UserId] bigint  NULL
);
GO

-- Creating table 'SiteCardAmounts'
CREATE TABLE [dbo].[SiteCardAmounts] (
    [SiteCardAmountId] bigint IDENTITY(1,1) NOT NULL,
    [BillingType] int  NULL,
    [AnnualCharge] int  NULL,
    [AnnualBHCharge] int  NULL,
    [TotalAnnual] int  NULL,
    [ChargePerPeriod] int  NULL,
    [SiteCardId] bigint  NULL
);
GO

-- Creating table 'SiteCardCharges'
CREATE TABLE [dbo].[SiteCardCharges] (
    [SiteCardChargesId] bigint IDENTITY(1,1) NOT NULL,
    [Position] nvarchar(50)  NULL,
    [WeeklyHours] int  NULL,
    [ChargeRate] int  NULL,
    [PayRate] int  NULL,
    [AdHocChargeRate] int  NULL,
    [EffectiveDate] datetime  NULL,
    [SiteCardId] bigint  NULL
);
GO

-- Creating table 'SiteCardDatas'
CREATE TABLE [dbo].[SiteCardDatas] (
    [SiteCardDataId] bigint IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(50)  NULL,
    [Name] nvarchar(50)  NULL,
    [SiteCardId] bigint  NULL
);
GO

-- Creating table 'SiteCards'
CREATE TABLE [dbo].[SiteCards] (
    [SiteCardId] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [PostCode] nvarchar(50)  NULL,
    [Address] nvarchar(max)  NULL,
    [SiteCardType] int  NULL,
    [ReferenceNumber] nvarchar(max)  NULL,
    [TerminationDate] datetime  NULL,
    [IsAdHocCardsAttatched] bit  NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedDate] datetime  NULL,
    [IsDeleted] bit  NULL,
    [FormId] bigint  NULL,
    [SiteCardAmountId] bigint  NULL,
    [CustomerId] bigint  NULL,
    [FacilitiesManagerId] bigint  NULL,
    [UserId] bigint  NULL,
    [CategoryId] int  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] bigint  NOT NULL,
    [AspNetUsers_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CategoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [CommentId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([CommentId] ASC);
GO

-- Creating primary key on [CustomerFinanceId] in table 'CustomerFinances'
ALTER TABLE [dbo].[CustomerFinances]
ADD CONSTRAINT [PK_CustomerFinances]
    PRIMARY KEY CLUSTERED ([CustomerFinanceId] ASC);
GO

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [EcafFormId] in table 'EcafForms'
ALTER TABLE [dbo].[EcafForms]
ADD CONSTRAINT [PK_EcafForms]
    PRIMARY KEY CLUSTERED ([EcafFormId] ASC);
GO

-- Creating primary key on [FacilitiesManagerId] in table 'FacilitiesManagers'
ALTER TABLE [dbo].[FacilitiesManagers]
ADD CONSTRAINT [PK_FacilitiesManagers]
    PRIMARY KEY CLUSTERED ([FacilitiesManagerId] ASC);
GO

-- Creating primary key on [FormId] in table 'Forms'
ALTER TABLE [dbo].[Forms]
ADD CONSTRAINT [PK_Forms]
    PRIMARY KEY CLUSTERED ([FormId] ASC);
GO

-- Creating primary key on [SiteCardAmountId] in table 'SiteCardAmounts'
ALTER TABLE [dbo].[SiteCardAmounts]
ADD CONSTRAINT [PK_SiteCardAmounts]
    PRIMARY KEY CLUSTERED ([SiteCardAmountId] ASC);
GO

-- Creating primary key on [SiteCardChargesId] in table 'SiteCardCharges'
ALTER TABLE [dbo].[SiteCardCharges]
ADD CONSTRAINT [PK_SiteCardCharges]
    PRIMARY KEY CLUSTERED ([SiteCardChargesId] ASC);
GO

-- Creating primary key on [SiteCardDataId] in table 'SiteCardDatas'
ALTER TABLE [dbo].[SiteCardDatas]
ADD CONSTRAINT [PK_SiteCardDatas]
    PRIMARY KEY CLUSTERED ([SiteCardDataId] ASC);
GO

-- Creating primary key on [SiteCardId] in table 'SiteCards'
ALTER TABLE [dbo].[SiteCards]
ADD CONSTRAINT [PK_SiteCards]
    PRIMARY KEY CLUSTERED ([SiteCardId] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [FormId] in table 'Forms'
ALTER TABLE [dbo].[Forms]
ADD CONSTRAINT [FK_Forms_Forms]
    FOREIGN KEY ([FormId])
    REFERENCES [dbo].[Forms]
        ([FormId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [FormId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_Forms]
    FOREIGN KEY ([FormId])
    REFERENCES [dbo].[Forms]
        ([FormId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_Forms'
CREATE INDEX [IX_FK_Comments_Forms]
ON [dbo].[Comments]
    ([FormId]);
GO

-- Creating foreign key on [CustomerId] in table 'CustomerFinances'
ALTER TABLE [dbo].[CustomerFinances]
ADD CONSTRAINT [FK_CustomerFinances_Customers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerFinances_Customers'
CREATE INDEX [IX_FK_CustomerFinances_Customers]
ON [dbo].[CustomerFinances]
    ([CustomerId]);
GO

-- Creating foreign key on [SiteCardId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_Customers_SiteCards]
    FOREIGN KEY ([SiteCardId])
    REFERENCES [dbo].[SiteCards]
        ([SiteCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Customers_SiteCards'
CREATE INDEX [IX_FK_Customers_SiteCards]
ON [dbo].[Customers]
    ([SiteCardId]);
GO

-- Creating foreign key on [FormId] in table 'EcafForms'
ALTER TABLE [dbo].[EcafForms]
ADD CONSTRAINT [FK_EcafForms_Forms]
    FOREIGN KEY ([FormId])
    REFERENCES [dbo].[Forms]
        ([FormId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EcafForms_Forms'
CREATE INDEX [IX_FK_EcafForms_Forms]
ON [dbo].[EcafForms]
    ([FormId]);
GO

-- Creating foreign key on [SiteCardId] in table 'FacilitiesManagers'
ALTER TABLE [dbo].[FacilitiesManagers]
ADD CONSTRAINT [FK_FacilitiesManagers_SiteCards]
    FOREIGN KEY ([SiteCardId])
    REFERENCES [dbo].[SiteCards]
        ([SiteCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacilitiesManagers_SiteCards'
CREATE INDEX [IX_FK_FacilitiesManagers_SiteCards]
ON [dbo].[FacilitiesManagers]
    ([SiteCardId]);
GO

-- Creating foreign key on [SiteCardId] in table 'SiteCardAmounts'
ALTER TABLE [dbo].[SiteCardAmounts]
ADD CONSTRAINT [FK_SiteCardAmounts_SiteCards]
    FOREIGN KEY ([SiteCardId])
    REFERENCES [dbo].[SiteCards]
        ([SiteCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteCardAmounts_SiteCards'
CREATE INDEX [IX_FK_SiteCardAmounts_SiteCards]
ON [dbo].[SiteCardAmounts]
    ([SiteCardId]);
GO

-- Creating foreign key on [SiteCardId] in table 'SiteCardCharges'
ALTER TABLE [dbo].[SiteCardCharges]
ADD CONSTRAINT [FK_SiteCardCharges_SiteCards]
    FOREIGN KEY ([SiteCardId])
    REFERENCES [dbo].[SiteCards]
        ([SiteCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteCardCharges_SiteCards'
CREATE INDEX [IX_FK_SiteCardCharges_SiteCards]
ON [dbo].[SiteCardCharges]
    ([SiteCardId]);
GO

-- Creating foreign key on [SiteCardId] in table 'SiteCardDatas'
ALTER TABLE [dbo].[SiteCardDatas]
ADD CONSTRAINT [FK_SiteCardDatas_SiteCards]
    FOREIGN KEY ([SiteCardId])
    REFERENCES [dbo].[SiteCards]
        ([SiteCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteCardDatas_SiteCards'
CREATE INDEX [IX_FK_SiteCardDatas_SiteCards]
ON [dbo].[SiteCardDatas]
    ([SiteCardId]);
GO

-- Creating foreign key on [SiteCardId] in table 'SiteCards'
ALTER TABLE [dbo].[SiteCards]
ADD CONSTRAINT [FK_SiteCards_SiteCards]
    FOREIGN KEY ([SiteCardId])
    REFERENCES [dbo].[SiteCards]
        ([SiteCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------