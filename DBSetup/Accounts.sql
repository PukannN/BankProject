CREATE TABLE [dbo].[Accounts] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [AccountNumber] NVARCHAR (20)   NOT NULL,
    [FirstName]     NVARCHAR (50)   NOT NULL,
    [LastName]      NVARCHAR (50)   NOT NULL,
    [Balance]       DECIMAL (29, 2) NOT NULL,
    [AccountType]   CHAR (1)        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([AccountNumber] ASC)
);

