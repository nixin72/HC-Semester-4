CREATE TABLE [dbo].[Products]
(
[ProductID] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ShortDescription] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LongDescription] [varchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CategoryID] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ImageFile] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UnitPrice] [money] NOT NULL,
[OnHand] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED  ([ProductID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] WITH NOCHECK ADD CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]) ON UPDATE CASCADE
GO
