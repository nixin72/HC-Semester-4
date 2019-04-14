CREATE TABLE [dbo].[LineItems]
(
[InvoiceNumber] [int] NOT NULL,
[ProductID] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[UnitPrice] [money] NOT NULL,
[Quantity] [int] NOT NULL,
[Extension] AS ([UnitPrice]*[Quantity]) PERSISTED
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LineItems] ADD CONSTRAINT [PK_LineItems] PRIMARY KEY CLUSTERED  ([InvoiceNumber], [ProductID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LineItems] WITH NOCHECK ADD CONSTRAINT [FK_LineItems_Invoices] FOREIGN KEY ([InvoiceNumber]) REFERENCES [dbo].[Invoices] ([InvoiceNumber])
GO
ALTER TABLE [dbo].[LineItems] WITH NOCHECK ADD CONSTRAINT [FK_LineItems_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
GO
