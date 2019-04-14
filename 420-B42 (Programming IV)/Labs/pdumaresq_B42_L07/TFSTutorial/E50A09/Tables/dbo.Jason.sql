CREATE TABLE [dbo].[Jason]
(
[JasonID] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FirstName] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Jason] ADD CONSTRAINT [PK_Jason] PRIMARY KEY CLUSTERED  ([JasonID]) ON [PRIMARY]
GO
