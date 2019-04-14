CREATE TABLE [dbo].[Cameron]
(
[CameronID] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[firstName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[lastName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cameron] ADD CONSTRAINT [PK_Cameron] PRIMARY KEY CLUSTERED  ([CameronID]) ON [PRIMARY]
GO
