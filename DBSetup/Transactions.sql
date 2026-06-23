CREATE TABLE [dbo].[Transactions] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [AccountNumber]   NVARCHAR (20)   NOT NULL,
    [Amount]          DECIMAL (29, 2) NOT NULL,
    [TransactionType] CHAR (1)        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

