﻿CREATE TABLE [dbo].[UserRole] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

