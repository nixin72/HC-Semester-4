CREATE TABLE [dbo].[Categories]
(
[CategoryID] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ShortName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LongName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE TRIGGER [dbo].[Categories_AspNet_SqlCacheNotification_Trigger] ON [dbo].[Categories]
                       FOR INSERT, UPDATE, DELETE AS BEGIN
                       SET NOCOUNT ON
                       EXEC dbo.AspNet_SqlCacheUpdateChangeIdStoredProcedure N'Categories'
                       END
                       
GO
ALTER TABLE [dbo].[Categories] ADD CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED  ([CategoryID]) ON [PRIMARY]
GO
