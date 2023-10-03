
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/23/2023 11:28:36
-- Generated from EDMX file: C:\Users\Acer\Desktop\MvcProjeOrnek\MvcProjeOrnek\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MvcTempProjem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_plazalarfirmalar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[firmalarSet] DROP CONSTRAINT [FK_plazalarfirmalar];
GO
IF OBJECT_ID(N'[dbo].[FK_firmalardepartmanlar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[departmanlarSet] DROP CONSTRAINT [FK_firmalardepartmanlar];
GO
IF OBJECT_ID(N'[dbo].[FK_departmanlarcalisanlar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[calisanlarSet] DROP CONSTRAINT [FK_departmanlarcalisanlar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[plazalarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[plazalarSet];
GO
IF OBJECT_ID(N'[dbo].[firmalarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[firmalarSet];
GO
IF OBJECT_ID(N'[dbo].[departmanlarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[departmanlarSet];
GO
IF OBJECT_ID(N'[dbo].[calisanlarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[calisanlarSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'plazalarSet'
CREATE TABLE [dbo].[plazalarSet] (
    [plazaNo] int IDENTITY(1,1) NOT NULL,
    [plazaAdi] nvarchar(max)  NOT NULL,
    [plazaAdres] nvarchar(max)  NOT NULL,
    [plazaTelefon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'firmalarSet'
CREATE TABLE [dbo].[firmalarSet] (
    [firmaNo] int IDENTITY(1,1) NOT NULL,
    [firmaAdi] nvarchar(max)  NOT NULL,
    [firmaAdres] nvarchar(max)  NOT NULL,
    [firmaTelefon] nvarchar(max)  NOT NULL,
    [plazaNo] int  NOT NULL
);
GO

-- Creating table 'departmanlarSet'
CREATE TABLE [dbo].[departmanlarSet] (
    [departmanNo] int IDENTITY(1,1) NOT NULL,
    [Adi] nvarchar(max)  NOT NULL,
    [adres] nvarchar(max)  NOT NULL,
    [telefon] nvarchar(max)  NOT NULL,
    [firmaNo] int  NOT NULL
);
GO

-- Creating table 'calisanlarSet'
CREATE TABLE [dbo].[calisanlarSet] (
    [calisanNo] int IDENTITY(1,1) NOT NULL,
    [adSoyad] nvarchar(max)  NOT NULL,
    [adres] nvarchar(max)  NOT NULL,
    [telefon] nvarchar(max)  NOT NULL,
    [maas] nvarchar(max)  NOT NULL,
    [departmanNo] int  NOT NULL
);
GO

-- Creating table 'KullanicilarSet'
CREATE TABLE [dbo].[KullanicilarSet] (
    [kullaniciId] int IDENTITY(1,1) NOT NULL,
    [kullaniciAdi] nvarchar(max)  NOT NULL,
    [sifre] nvarchar(max)  NOT NULL,
    [role] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [plazaNo] in table 'plazalarSet'
ALTER TABLE [dbo].[plazalarSet]
ADD CONSTRAINT [PK_plazalarSet]
    PRIMARY KEY CLUSTERED ([plazaNo] ASC);
GO

-- Creating primary key on [firmaNo] in table 'firmalarSet'
ALTER TABLE [dbo].[firmalarSet]
ADD CONSTRAINT [PK_firmalarSet]
    PRIMARY KEY CLUSTERED ([firmaNo] ASC);
GO

-- Creating primary key on [departmanNo] in table 'departmanlarSet'
ALTER TABLE [dbo].[departmanlarSet]
ADD CONSTRAINT [PK_departmanlarSet]
    PRIMARY KEY CLUSTERED ([departmanNo] ASC);
GO

-- Creating primary key on [calisanNo] in table 'calisanlarSet'
ALTER TABLE [dbo].[calisanlarSet]
ADD CONSTRAINT [PK_calisanlarSet]
    PRIMARY KEY CLUSTERED ([calisanNo] ASC);
GO

-- Creating primary key on [kullaniciId] in table 'KullanicilarSet'
ALTER TABLE [dbo].[KullanicilarSet]
ADD CONSTRAINT [PK_KullanicilarSet]
    PRIMARY KEY CLUSTERED ([kullaniciId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [plazaNo] in table 'firmalarSet'
ALTER TABLE [dbo].[firmalarSet]
ADD CONSTRAINT [FK_plazalarfirmalar]
    FOREIGN KEY ([plazaNo])
    REFERENCES [dbo].[plazalarSet]
        ([plazaNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_plazalarfirmalar'
CREATE INDEX [IX_FK_plazalarfirmalar]
ON [dbo].[firmalarSet]
    ([plazaNo]);
GO

-- Creating foreign key on [firmaNo] in table 'departmanlarSet'
ALTER TABLE [dbo].[departmanlarSet]
ADD CONSTRAINT [FK_firmalardepartmanlar]
    FOREIGN KEY ([firmaNo])
    REFERENCES [dbo].[firmalarSet]
        ([firmaNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_firmalardepartmanlar'
CREATE INDEX [IX_FK_firmalardepartmanlar]
ON [dbo].[departmanlarSet]
    ([firmaNo]);
GO

-- Creating foreign key on [departmanNo] in table 'calisanlarSet'
ALTER TABLE [dbo].[calisanlarSet]
ADD CONSTRAINT [FK_departmanlarcalisanlar]
    FOREIGN KEY ([departmanNo])
    REFERENCES [dbo].[departmanlarSet]
        ([departmanNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_departmanlarcalisanlar'
CREATE INDEX [IX_FK_departmanlarcalisanlar]
ON [dbo].[calisanlarSet]
    ([departmanNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------