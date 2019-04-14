CREATE TABLE [dbo].[Invoices]
(
[InvoiceNumber] [int] NOT NULL IDENTITY(1000, 1),
[CustEmail] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[OrderDate] [datetime] NOT NULL,
[Subtotal] [money] NOT NULL,
[ShipMethod] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Shipping] [money] NOT NULL,
[SalesTax] [money] NOT NULL,
[Total] [money] NOT NULL,
[CreditCardType] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CardNumber] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ExpirationMonth] [smallint] NOT NULL,
[ExpirationYear] [smallint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Invoices] ADD CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED  ([InvoiceNumber]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Invoices] ADD CONSTRAINT [FK_Invoices_Customers] FOREIGN KEY ([CustEmail]) REFERENCES [dbo].[Customers] ([Email]) ON UPDATE CASCADE
GO
