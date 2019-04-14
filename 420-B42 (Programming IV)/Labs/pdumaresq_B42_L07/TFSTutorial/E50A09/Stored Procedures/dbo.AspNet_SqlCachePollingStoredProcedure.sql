SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCachePollingStoredProcedure] AS
         SELECT tableName, changeId FROM dbo.AspNet_SqlCacheTablesForChangeNotification
         RETURN 0
GO
GRANT EXECUTE ON  [dbo].[AspNet_SqlCachePollingStoredProcedure] TO [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess]
GO
