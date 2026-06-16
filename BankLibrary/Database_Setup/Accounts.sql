CREATE TABLE [dbo].[Accounts] (
    [AccountNumber] NVARCHAR (20)   NOT NULL,
    [FirstName]     NVARCHAR (50)   NOT NULL,
    [LastName]      NVARCHAR (50)   NOT NULL,
    [Balance]       DECIMAL (29, 2) NOT NULL,
    [AccountType]   CHAR (1)        NOT NULL,
    PRIMARY KEY CLUSTERED ([AccountNumber] ASC)
);

