CREATE TABLE [dbo].[Max]
(
[MaxID] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Max] ADD CONSTRAINT [PK_Max] PRIMARY KEY CLUSTERED  ([MaxID]) ON [PRIMARY]
GO
