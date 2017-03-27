
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/27/2017 11:23:53
-- Generated from EDMX file: D:\Projects\C#\GameStore\GameStore.UIWeb\DataBase\GameStoreModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GameStoreDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PublisherGame]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameSet] DROP CONSTRAINT [FK_PublisherGame];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersGame_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersGame] DROP CONSTRAINT [FK_UsersGame_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersGame_Game]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersGame] DROP CONSTRAINT [FK_UsersGame_Game];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UsersRole];
GO
IF OBJECT_ID(N'[dbo].[FK_GamePurchases]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchasesSet] DROP CONSTRAINT [FK_GamePurchases];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPurchases]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchasesSet] DROP CONSTRAINT [FK_UserPurchases];
GO
IF OBJECT_ID(N'[dbo].[FK_UserComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentsSet] DROP CONSTRAINT [FK_UserComments];
GO
IF OBJECT_ID(N'[dbo].[FK_GameComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentsSet] DROP CONSTRAINT [FK_GameComments];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[GameSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameSet];
GO
IF OBJECT_ID(N'[dbo].[PublisherSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PublisherSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[RoleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleSet];
GO
IF OBJECT_ID(N'[dbo].[PurchasesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchasesSet];
GO
IF OBJECT_ID(N'[dbo].[CommentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentsSet];
GO
IF OBJECT_ID(N'[dbo].[UsersGame]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersGame];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GameSet'
CREATE TABLE [dbo].[GameSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Category] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Requirements] nvarchar(max)  NOT NULL,
    [Discount] float  NOT NULL,
    [Picture] varbinary(max)  NOT NULL,
    [Publisher_Id] int  NOT NULL
);
GO

-- Creating table 'PublisherSet'
CREATE TABLE [dbo].[PublisherSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Logo] varbinary(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Balance] int  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'RoleSet'
CREATE TABLE [dbo].[RoleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Privileges] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PurchasesSet'
CREATE TABLE [dbo].[PurchasesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Game_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'CommentsSet'
CREATE TABLE [dbo].[CommentsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [User_Id] int  NOT NULL,
    [Game_Id] int  NOT NULL
);
GO

-- Creating table 'UsersGame'
CREATE TABLE [dbo].[UsersGame] (
    [User_Id] int  NOT NULL,
    [Game_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [PK_GameSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PublisherSet'
ALTER TABLE [dbo].[PublisherSet]
ADD CONSTRAINT [PK_PublisherSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoleSet'
ALTER TABLE [dbo].[RoleSet]
ADD CONSTRAINT [PK_RoleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PurchasesSet'
ALTER TABLE [dbo].[PurchasesSet]
ADD CONSTRAINT [PK_PurchasesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommentsSet'
ALTER TABLE [dbo].[CommentsSet]
ADD CONSTRAINT [PK_CommentsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [Game_Id] in table 'UsersGame'
ALTER TABLE [dbo].[UsersGame]
ADD CONSTRAINT [PK_UsersGame]
    PRIMARY KEY CLUSTERED ([User_Id], [Game_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Publisher_Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [FK_PublisherGame]
    FOREIGN KEY ([Publisher_Id])
    REFERENCES [dbo].[PublisherSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublisherGame'
CREATE INDEX [IX_FK_PublisherGame]
ON [dbo].[GameSet]
    ([Publisher_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UsersGame'
ALTER TABLE [dbo].[UsersGame]
ADD CONSTRAINT [FK_UsersGame_Users]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Game_Id] in table 'UsersGame'
ALTER TABLE [dbo].[UsersGame]
ADD CONSTRAINT [FK_UsersGame_Game]
    FOREIGN KEY ([Game_Id])
    REFERENCES [dbo].[GameSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersGame_Game'
CREATE INDEX [IX_FK_UsersGame_Game]
ON [dbo].[UsersGame]
    ([Game_Id]);
GO

-- Creating foreign key on [Role_Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UsersRole]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[RoleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersRole'
CREATE INDEX [IX_FK_UsersRole]
ON [dbo].[UserSet]
    ([Role_Id]);
GO

-- Creating foreign key on [Game_Id] in table 'PurchasesSet'
ALTER TABLE [dbo].[PurchasesSet]
ADD CONSTRAINT [FK_GamePurchases]
    FOREIGN KEY ([Game_Id])
    REFERENCES [dbo].[GameSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GamePurchases'
CREATE INDEX [IX_FK_GamePurchases]
ON [dbo].[PurchasesSet]
    ([Game_Id]);
GO

-- Creating foreign key on [User_Id] in table 'PurchasesSet'
ALTER TABLE [dbo].[PurchasesSet]
ADD CONSTRAINT [FK_UserPurchases]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPurchases'
CREATE INDEX [IX_FK_UserPurchases]
ON [dbo].[PurchasesSet]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'CommentsSet'
ALTER TABLE [dbo].[CommentsSet]
ADD CONSTRAINT [FK_UserComments]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserComments'
CREATE INDEX [IX_FK_UserComments]
ON [dbo].[CommentsSet]
    ([User_Id]);
GO

-- Creating foreign key on [Game_Id] in table 'CommentsSet'
ALTER TABLE [dbo].[CommentsSet]
ADD CONSTRAINT [FK_GameComments]
    FOREIGN KEY ([Game_Id])
    REFERENCES [dbo].[GameSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GameComments'
CREATE INDEX [IX_FK_GameComments]
ON [dbo].[CommentsSet]
    ([Game_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------