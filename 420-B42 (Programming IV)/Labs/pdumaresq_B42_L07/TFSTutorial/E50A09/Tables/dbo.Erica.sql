CREATE TABLE [dbo].[Erica]
(
[EricaID] [int] NOT NULL,
[FirstName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Erica] ADD CONSTRAINT [PK_Erica] PRIMARY KEY CLUSTERED  ([EricaID]) ON [PRIMARY]
GO
