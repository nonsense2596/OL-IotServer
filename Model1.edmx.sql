
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/25/2020 14:45:42
-- Generated from EDMX file: E:\prog\C#projects\source\repos\IoTServerV2\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IoTServerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SensorData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataSs] DROP CONSTRAINT [FK_SensorData];
GO
IF OBJECT_ID(N'[dbo].[FK_SensorDataM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataMs] DROP CONSTRAINT [FK_SensorDataM];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sensors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sensors];
GO
IF OBJECT_ID(N'[dbo].[DataSs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataSs];
GO
IF OBJECT_ID(N'[dbo].[DataMs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataMs];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sensors'
CREATE TABLE [dbo].[Sensors] (
    [SensorId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Mode] bit  NOT NULL,
    [IP] nvarchar(max)  NOT NULL,
    [CoordX] nvarchar(max)  NOT NULL,
    [CoordY] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DataSs'
CREATE TABLE [dbo].[DataSs] (
    [DataId] int IDENTITY(1,1) NOT NULL,
    [PM10] int  NOT NULL,
    [SensorId] int  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DataMs'
CREATE TABLE [dbo].[DataMs] (
    [DataId] int IDENTITY(1,1) NOT NULL,
    [PM10] int  NOT NULL,
    [SensorId] int  NOT NULL,
    [CoordX] nvarchar(max)  NOT NULL,
    [CoordY] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SensorId] in table 'Sensors'
ALTER TABLE [dbo].[Sensors]
ADD CONSTRAINT [PK_Sensors]
    PRIMARY KEY CLUSTERED ([SensorId] ASC);
GO

-- Creating primary key on [DataId] in table 'DataSs'
ALTER TABLE [dbo].[DataSs]
ADD CONSTRAINT [PK_DataSs]
    PRIMARY KEY CLUSTERED ([DataId] ASC);
GO

-- Creating primary key on [DataId] in table 'DataMs'
ALTER TABLE [dbo].[DataMs]
ADD CONSTRAINT [PK_DataMs]
    PRIMARY KEY CLUSTERED ([DataId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SensorId] in table 'DataSs'
ALTER TABLE [dbo].[DataSs]
ADD CONSTRAINT [FK_SensorData]
    FOREIGN KEY ([SensorId])
    REFERENCES [dbo].[Sensors]
        ([SensorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SensorData'
CREATE INDEX [IX_FK_SensorData]
ON [dbo].[DataSs]
    ([SensorId]);
GO

-- Creating foreign key on [SensorId] in table 'DataMs'
ALTER TABLE [dbo].[DataMs]
ADD CONSTRAINT [FK_SensorDataM]
    FOREIGN KEY ([SensorId])
    REFERENCES [dbo].[Sensors]
        ([SensorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SensorDataM'
CREATE INDEX [IX_FK_SensorDataM]
ON [dbo].[DataMs]
    ([SensorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------