
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/20/2018 23:26:14
-- Generated from EDMX file: C:\Users\Sebastian\Documents\GitHub\panaderiaBellota2\panaderia\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_recetadetalle_receta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_receta] DROP CONSTRAINT [FK_recetadetalle_receta];
GO
IF OBJECT_ID(N'[dbo].[FK_productodetalle_receta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_receta] DROP CONSTRAINT [FK_productodetalle_receta];
GO
IF OBJECT_ID(N'[dbo].[FK_lineafamilia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[familia] DROP CONSTRAINT [FK_lineafamilia];
GO
IF OBJECT_ID(N'[dbo].[FK_familiaproducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[producto] DROP CONSTRAINT [FK_familiaproducto];
GO
IF OBJECT_ID(N'[dbo].[FK_usuarioproducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[producto] DROP CONSTRAINT [FK_usuarioproducto];
GO
IF OBJECT_ID(N'[dbo].[FK_rolusuariousuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[usuario] DROP CONSTRAINT [FK_rolusuariousuario];
GO
IF OBJECT_ID(N'[dbo].[FK_proveedorcompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[compra] DROP CONSTRAINT [FK_proveedorcompra];
GO
IF OBJECT_ID(N'[dbo].[FK_productocompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[compra] DROP CONSTRAINT [FK_productocompra];
GO
IF OBJECT_ID(N'[dbo].[FK_medidadetalle_receta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[detalle_receta] DROP CONSTRAINT [FK_medidadetalle_receta];
GO
IF OBJECT_ID(N'[dbo].[FK_recetaproduccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[produccion] DROP CONSTRAINT [FK_recetaproduccion];
GO
IF OBJECT_ID(N'[dbo].[FK_medidaproducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[producto] DROP CONSTRAINT [FK_medidaproducto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[linea]', 'U') IS NOT NULL
    DROP TABLE [dbo].[linea];
GO
IF OBJECT_ID(N'[dbo].[receta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[receta];
GO
IF OBJECT_ID(N'[dbo].[producto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[producto];
GO
IF OBJECT_ID(N'[dbo].[detalle_receta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[detalle_receta];
GO
IF OBJECT_ID(N'[dbo].[familia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[familia];
GO
IF OBJECT_ID(N'[dbo].[usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usuario];
GO
IF OBJECT_ID(N'[dbo].[rolusuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[rolusuario];
GO
IF OBJECT_ID(N'[dbo].[proveedor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[proveedor];
GO
IF OBJECT_ID(N'[dbo].[compra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[compra];
GO
IF OBJECT_ID(N'[dbo].[produccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[produccion];
GO
IF OBJECT_ID(N'[dbo].[medida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[medida];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'linea'
CREATE TABLE [dbo].[linea] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(45)  NULL
);
GO

-- Creating table 'receta'
CREATE TABLE [dbo].[receta] (
    [Id] int  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [costo_receta] bigint  NOT NULL,
    [estado] bit  NOT NULL,
    [valor_venta] bigint  NOT NULL
);
GO

-- Creating table 'producto'
CREATE TABLE [dbo].[producto] (
    [Id] int  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [formato] int  NOT NULL,
    [familiaId] int  NOT NULL,
    [usuarioId] int  NOT NULL,
    [medidaId] int  NOT NULL,
    [precio] bigint  NOT NULL
);
GO

-- Creating table 'detalle_receta'
CREATE TABLE [dbo].[detalle_receta] (
    [cantidad] decimal(18,0)  NOT NULL,
    [recetaId] int  NOT NULL,
    [productoId] int  NOT NULL,
    [medidaId] int  NOT NULL,
    [estado] bit  NOT NULL
);
GO

-- Creating table 'familia'
CREATE TABLE [dbo].[familia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [lineaId] int  NOT NULL
);
GO

-- Creating table 'usuario'
CREATE TABLE [dbo].[usuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [clave] nvarchar(max)  NOT NULL,
    [rolusuarioId] int  NOT NULL
);
GO

-- Creating table 'rolusuario'
CREATE TABLE [dbo].[rolusuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [rol] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'proveedor'
CREATE TABLE [dbo].[proveedor] (
    [rut] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'compra'
CREATE TABLE [dbo].[compra] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cantidad] int  NOT NULL,
    [precio_neto] smallint  NOT NULL,
    [proveedor_rut] int  NOT NULL,
    [productoId] int  NOT NULL,
    [fecha_compra] datetime  NOT NULL
);
GO

-- Creating table 'produccion'
CREATE TABLE [dbo].[produccion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fecha_produccion] datetime  NOT NULL,
    [recetaId] int  NOT NULL,
    [costo_produccion] smallint  NOT NULL,
    [cantidad] decimal(18,0)  NOT NULL,
    [valor_total_venta] bigint  NOT NULL,
    [rentabilidad_produccion] bigint  NOT NULL,
    [costo_receta_kilo] bigint  NOT NULL,
    [valor_venta_kilo] bigint  NOT NULL
);
GO

-- Creating table 'medida'
CREATE TABLE [dbo].[medida] (
    [Id] int  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'linea'
ALTER TABLE [dbo].[linea]
ADD CONSTRAINT [PK_linea]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'receta'
ALTER TABLE [dbo].[receta]
ADD CONSTRAINT [PK_receta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'producto'
ALTER TABLE [dbo].[producto]
ADD CONSTRAINT [PK_producto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [recetaId], [productoId] in table 'detalle_receta'
ALTER TABLE [dbo].[detalle_receta]
ADD CONSTRAINT [PK_detalle_receta]
    PRIMARY KEY CLUSTERED ([recetaId], [productoId] ASC);
GO

-- Creating primary key on [Id] in table 'familia'
ALTER TABLE [dbo].[familia]
ADD CONSTRAINT [PK_familia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'usuario'
ALTER TABLE [dbo].[usuario]
ADD CONSTRAINT [PK_usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'rolusuario'
ALTER TABLE [dbo].[rolusuario]
ADD CONSTRAINT [PK_rolusuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [rut] in table 'proveedor'
ALTER TABLE [dbo].[proveedor]
ADD CONSTRAINT [PK_proveedor]
    PRIMARY KEY CLUSTERED ([rut] ASC);
GO

-- Creating primary key on [Id] in table 'compra'
ALTER TABLE [dbo].[compra]
ADD CONSTRAINT [PK_compra]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'produccion'
ALTER TABLE [dbo].[produccion]
ADD CONSTRAINT [PK_produccion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'medida'
ALTER TABLE [dbo].[medida]
ADD CONSTRAINT [PK_medida]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [recetaId] in table 'detalle_receta'
ALTER TABLE [dbo].[detalle_receta]
ADD CONSTRAINT [FK_recetadetalle_receta]
    FOREIGN KEY ([recetaId])
    REFERENCES [dbo].[receta]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [productoId] in table 'detalle_receta'
ALTER TABLE [dbo].[detalle_receta]
ADD CONSTRAINT [FK_productodetalle_receta]
    FOREIGN KEY ([productoId])
    REFERENCES [dbo].[producto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productodetalle_receta'
CREATE INDEX [IX_FK_productodetalle_receta]
ON [dbo].[detalle_receta]
    ([productoId]);
GO

-- Creating foreign key on [lineaId] in table 'familia'
ALTER TABLE [dbo].[familia]
ADD CONSTRAINT [FK_lineafamilia]
    FOREIGN KEY ([lineaId])
    REFERENCES [dbo].[linea]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_lineafamilia'
CREATE INDEX [IX_FK_lineafamilia]
ON [dbo].[familia]
    ([lineaId]);
GO

-- Creating foreign key on [familiaId] in table 'producto'
ALTER TABLE [dbo].[producto]
ADD CONSTRAINT [FK_familiaproducto]
    FOREIGN KEY ([familiaId])
    REFERENCES [dbo].[familia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_familiaproducto'
CREATE INDEX [IX_FK_familiaproducto]
ON [dbo].[producto]
    ([familiaId]);
GO

-- Creating foreign key on [usuarioId] in table 'producto'
ALTER TABLE [dbo].[producto]
ADD CONSTRAINT [FK_usuarioproducto]
    FOREIGN KEY ([usuarioId])
    REFERENCES [dbo].[usuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_usuarioproducto'
CREATE INDEX [IX_FK_usuarioproducto]
ON [dbo].[producto]
    ([usuarioId]);
GO

-- Creating foreign key on [rolusuarioId] in table 'usuario'
ALTER TABLE [dbo].[usuario]
ADD CONSTRAINT [FK_rolusuariousuario]
    FOREIGN KEY ([rolusuarioId])
    REFERENCES [dbo].[rolusuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_rolusuariousuario'
CREATE INDEX [IX_FK_rolusuariousuario]
ON [dbo].[usuario]
    ([rolusuarioId]);
GO

-- Creating foreign key on [proveedor_rut] in table 'compra'
ALTER TABLE [dbo].[compra]
ADD CONSTRAINT [FK_proveedorcompra]
    FOREIGN KEY ([proveedor_rut])
    REFERENCES [dbo].[proveedor]
        ([rut])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_proveedorcompra'
CREATE INDEX [IX_FK_proveedorcompra]
ON [dbo].[compra]
    ([proveedor_rut]);
GO

-- Creating foreign key on [productoId] in table 'compra'
ALTER TABLE [dbo].[compra]
ADD CONSTRAINT [FK_productocompra]
    FOREIGN KEY ([productoId])
    REFERENCES [dbo].[producto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productocompra'
CREATE INDEX [IX_FK_productocompra]
ON [dbo].[compra]
    ([productoId]);
GO

-- Creating foreign key on [medidaId] in table 'detalle_receta'
ALTER TABLE [dbo].[detalle_receta]
ADD CONSTRAINT [FK_medidadetalle_receta]
    FOREIGN KEY ([medidaId])
    REFERENCES [dbo].[medida]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_medidadetalle_receta'
CREATE INDEX [IX_FK_medidadetalle_receta]
ON [dbo].[detalle_receta]
    ([medidaId]);
GO

-- Creating foreign key on [recetaId] in table 'produccion'
ALTER TABLE [dbo].[produccion]
ADD CONSTRAINT [FK_recetaproduccion]
    FOREIGN KEY ([recetaId])
    REFERENCES [dbo].[receta]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_recetaproduccion'
CREATE INDEX [IX_FK_recetaproduccion]
ON [dbo].[produccion]
    ([recetaId]);
GO

-- Creating foreign key on [medidaId] in table 'producto'
ALTER TABLE [dbo].[producto]
ADD CONSTRAINT [FK_medidaproducto]
    FOREIGN KEY ([medidaId])
    REFERENCES [dbo].[medida]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_medidaproducto'
CREATE INDEX [IX_FK_medidaproducto]
ON [dbo].[producto]
    ([medidaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------