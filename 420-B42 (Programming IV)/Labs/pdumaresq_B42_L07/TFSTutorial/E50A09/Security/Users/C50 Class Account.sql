IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE loginname = N'c50')
CREATE LOGIN [c50] WITH PASSWORD = 'p@ssw0rd'
GO
CREATE USER [C50 Class Account] FOR LOGIN [c50]
GO
