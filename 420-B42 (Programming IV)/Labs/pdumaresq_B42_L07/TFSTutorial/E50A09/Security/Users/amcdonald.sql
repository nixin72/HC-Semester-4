IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE loginname = N'amcdonald')
CREATE LOGIN [amcdonald] WITH PASSWORD = 'p@ssw0rd'
GO
CREATE USER [amcdonald] FOR LOGIN [amcdonald]
GO
