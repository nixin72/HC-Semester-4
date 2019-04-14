CREATE TABLE [dbo].[AspNet_SqlCacheTablesForChangeNotification]
(
[tableName] [nvarchar] (450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[notificationCreated] [datetime] NOT NULL CONSTRAINT [DF__AspNet_Sq__notif__59063A47] DEFAULT (getdate()),
[changeId] [int] NOT NULL CONSTRAINT [DF__AspNet_Sq__chang__59FA5E80] DEFAULT ((0))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNet_SqlCacheTablesForChangeNotification] ADD CONSTRAINT [PK__AspNet_SqlCacheT__5812160E] PRIMARY KEY CLUSTERED  ([tableName]) ON [PRIMARY]
GO
