
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/18/2017 17:28:47
-- Generated from EDMX file: C:\Users\amancebo\Desktop\Fing\TSI_Cerebro14\CerebroBackend\Cerebro14.DAL\Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Ciudad];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_edificio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TABusuarios] DROP CONSTRAINT [fk_edificio];
GO
IF OBJECT_ID(N'[dbo].[FK_Sensor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TABsensorEvento] DROP CONSTRAINT [FK_Sensor];
GO
IF OBJECT_ID(N'[dbo].[Fk_TABevento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TABsensorEvento] DROP CONSTRAINT [Fk_TABevento];
GO
IF OBJECT_ID(N'[dbo].[fk_TABeventos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TABacciones] DROP CONSTRAINT [fk_TABeventos];
GO
IF OBJECT_ID(N'[dbo].[fk_TABusuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TABacciones] DROP CONSTRAINT [fk_TABusuarios];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TABacciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TABacciones];
GO
IF OBJECT_ID(N'[dbo].[TABCiudades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TABCiudades];
GO
IF OBJECT_ID(N'[dbo].[TABedificios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TABedificios];
GO
IF OBJECT_ID(N'[dbo].[TABeventos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TABeventos];
GO
IF OBJECT_ID(N'[dbo].[TABsensor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TABsensor];
GO
IF OBJECT_ID(N'[dbo].[TABsensorEvento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TABsensorEvento];
GO
IF OBJECT_ID(N'[dbo].[TABusuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TABusuarios];
GO
IF OBJECT_ID(N'[dbo].[TABZona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TABZona];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TABacciones'
CREATE TABLE [dbo].[TABacciones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [tipo] int  NOT NULL,
    [parametros] varchar(50)  NULL,
    [FK_Eve_Lat] float  NOT NULL,
    [FK_Eve_Lon] float  NOT NULL,
    [FK_email_usu] varchar(50)  NOT NULL
);
GO

-- Creating table 'TABCiudades'
CREATE TABLE [dbo].[TABCiudades] (
    [RecursoLibre] float  NOT NULL,
    [ID_Ciu_Lat] float  NOT NULL,
    [ID_Ciu_Lon] float  NOT NULL,
    [NameDbSQL] varchar(40)  NOT NULL,
    [UserDb] varchar(40)  NOT NULL,
    [PassDb] varchar(40)  NOT NULL,
    [NameDbM] varchar(40)  NOT NULL,
    [AddressServerDb] varchar(40)  NOT NULL,
    [PortServerDb] float  NOT NULL,
    [NameCiudade] varchar(40)  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TABedificios'
CREATE TABLE [dbo].[TABedificios] (
    [ID_Lat] float  NOT NULL,
    [ID_Lon] float  NOT NULL,
    [nombre] varchar(30)  NOT NULL
);
GO

-- Creating table 'TABeventos'
CREATE TABLE [dbo].[TABeventos] (
    [ID_Lat] float  NOT NULL,
    [ID_Lon] float  NOT NULL,
    [nombre] varchar(30)  NOT NULL
);
GO

-- Creating table 'TABsensor'
CREATE TABLE [dbo].[TABsensor] (
    [ID_Sen_Lat] float  NOT NULL,
    [ID_Sen_Lon] float  NOT NULL,
    [tipo] varchar(30)  NOT NULL,
    [nombre] varchar(30)  NULL
);
GO

-- Creating table 'TABsensorEvento'
CREATE TABLE [dbo].[TABsensorEvento] (
    [id] int IDENTITY(1,1) NOT NULL,
    [umbral] float  NOT NULL,
    [FK_Sensor_Lat] float  NOT NULL,
    [FK_Sensor_Lon] float  NOT NULL,
    [FK_Eveto_Lat] float  NOT NULL,
    [FK_Eveto_Lon] float  NOT NULL
);
GO

-- Creating table 'TABusuarios'
CREATE TABLE [dbo].[TABusuarios] (
    [cedula] int  NOT NULL,
    [nombre] varchar(30)  NOT NULL,
    [apellido] varchar(30)  NOT NULL,
    [fechaN] datetime  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [username] varchar(50)  NOT NULL,
    [pass] varchar(40)  NOT NULL,
    [FK_Edi_Lat] float  NOT NULL,
    [FK_Edi_Lon] float  NOT NULL,
    [telefono] varchar(10)  NOT NULL
);
GO

-- Creating table 'TABZona'
CREATE TABLE [dbo].[TABZona] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Lat_Zona] float  NOT NULL,
    [Lon_Zona] float  NOT NULL,
    [Radio_Zona] float  NOT NULL,
    [Name_Zona] varchar(40)  NULL,
    [Zona_string_extra] varchar(40)  NULL,
    [Zona_num_extra] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'TABacciones'
ALTER TABLE [dbo].[TABacciones]
ADD CONSTRAINT [PK_TABacciones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TABCiudades'
ALTER TABLE [dbo].[TABCiudades]
ADD CONSTRAINT [PK_TABCiudades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID_Lat], [ID_Lon] in table 'TABedificios'
ALTER TABLE [dbo].[TABedificios]
ADD CONSTRAINT [PK_TABedificios]
    PRIMARY KEY CLUSTERED ([ID_Lat], [ID_Lon] ASC);
GO

-- Creating primary key on [ID_Lat], [ID_Lon] in table 'TABeventos'
ALTER TABLE [dbo].[TABeventos]
ADD CONSTRAINT [PK_TABeventos]
    PRIMARY KEY CLUSTERED ([ID_Lat], [ID_Lon] ASC);
GO

-- Creating primary key on [ID_Sen_Lat], [ID_Sen_Lon] in table 'TABsensor'
ALTER TABLE [dbo].[TABsensor]
ADD CONSTRAINT [PK_TABsensor]
    PRIMARY KEY CLUSTERED ([ID_Sen_Lat], [ID_Sen_Lon] ASC);
GO

-- Creating primary key on [id] in table 'TABsensorEvento'
ALTER TABLE [dbo].[TABsensorEvento]
ADD CONSTRAINT [PK_TABsensorEvento]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [email] in table 'TABusuarios'
ALTER TABLE [dbo].[TABusuarios]
ADD CONSTRAINT [PK_TABusuarios]
    PRIMARY KEY CLUSTERED ([email] ASC);
GO

-- Creating primary key on [id] in table 'TABZona'
ALTER TABLE [dbo].[TABZona]
ADD CONSTRAINT [PK_TABZona]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FK_Eve_Lat], [FK_Eve_Lon] in table 'TABacciones'
ALTER TABLE [dbo].[TABacciones]
ADD CONSTRAINT [fk_TABeventos]
    FOREIGN KEY ([FK_Eve_Lat], [FK_Eve_Lon])
    REFERENCES [dbo].[TABeventos]
        ([ID_Lat], [ID_Lon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_TABeventos'
CREATE INDEX [IX_fk_TABeventos]
ON [dbo].[TABacciones]
    ([FK_Eve_Lat], [FK_Eve_Lon]);
GO

-- Creating foreign key on [FK_email_usu] in table 'TABacciones'
ALTER TABLE [dbo].[TABacciones]
ADD CONSTRAINT [fk_TABusuarios]
    FOREIGN KEY ([FK_email_usu])
    REFERENCES [dbo].[TABusuarios]
        ([email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_TABusuarios'
CREATE INDEX [IX_fk_TABusuarios]
ON [dbo].[TABacciones]
    ([FK_email_usu]);
GO

-- Creating foreign key on [FK_Edi_Lat], [FK_Edi_Lon] in table 'TABusuarios'
ALTER TABLE [dbo].[TABusuarios]
ADD CONSTRAINT [fk_edificio]
    FOREIGN KEY ([FK_Edi_Lat], [FK_Edi_Lon])
    REFERENCES [dbo].[TABedificios]
        ([ID_Lat], [ID_Lon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_edificio'
CREATE INDEX [IX_fk_edificio]
ON [dbo].[TABusuarios]
    ([FK_Edi_Lat], [FK_Edi_Lon]);
GO

-- Creating foreign key on [FK_Eveto_Lat], [FK_Eveto_Lon] in table 'TABsensorEvento'
ALTER TABLE [dbo].[TABsensorEvento]
ADD CONSTRAINT [Fk_TABevento]
    FOREIGN KEY ([FK_Eveto_Lat], [FK_Eveto_Lon])
    REFERENCES [dbo].[TABeventos]
        ([ID_Lat], [ID_Lon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'Fk_TABevento'
CREATE INDEX [IX_Fk_TABevento]
ON [dbo].[TABsensorEvento]
    ([FK_Eveto_Lat], [FK_Eveto_Lon]);
GO

-- Creating foreign key on [FK_Sensor_Lat], [FK_Sensor_Lon] in table 'TABsensorEvento'
ALTER TABLE [dbo].[TABsensorEvento]
ADD CONSTRAINT [FK_Sensor]
    FOREIGN KEY ([FK_Sensor_Lat], [FK_Sensor_Lon])
    REFERENCES [dbo].[TABsensor]
        ([ID_Sen_Lat], [ID_Sen_Lon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sensor'
CREATE INDEX [IX_FK_Sensor]
ON [dbo].[TABsensorEvento]
    ([FK_Sensor_Lat], [FK_Sensor_Lon]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------