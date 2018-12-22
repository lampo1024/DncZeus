--重要说明：
--如果在项目中运行了Update-Database命令，请不要再执行此脚本

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncUser]') AND [c].[name] = N'CreatedByUserId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [DncUser] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [DncUser] DROP COLUMN [CreatedByUserId];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncUser]') AND [c].[name] = N'Id');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [DncUser] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [DncUser] DROP COLUMN [Id];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncUser]') AND [c].[name] = N'ModifiedByUserId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [DncUser] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [DncUser] DROP COLUMN [ModifiedByUserId];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncRole]') AND [c].[name] = N'CreatedByUserId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [DncRole] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [DncRole] DROP COLUMN [CreatedByUserId];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncRole]') AND [c].[name] = N'Id');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [DncRole] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [DncRole] DROP COLUMN [Id];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncRole]') AND [c].[name] = N'ModifiedByUserId');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [DncRole] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [DncRole] DROP COLUMN [ModifiedByUserId];

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncPermission]') AND [c].[name] = N'CreatedByUserId');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [DncPermission] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [DncPermission] DROP COLUMN [CreatedByUserId];

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncPermission]') AND [c].[name] = N'Id');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [DncPermission] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [DncPermission] DROP COLUMN [Id];

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncPermission]') AND [c].[name] = N'ModifiedByUserId');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [DncPermission] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [DncPermission] DROP COLUMN [ModifiedByUserId];

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncMenu]') AND [c].[name] = N'CreatedByUserId');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [DncMenu] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [DncMenu] DROP COLUMN [CreatedByUserId];

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncMenu]') AND [c].[name] = N'Id');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [DncMenu] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [DncMenu] DROP COLUMN [Id];

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncMenu]') AND [c].[name] = N'ModifiedByUserId');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [DncMenu] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [DncMenu] DROP COLUMN [ModifiedByUserId];

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncIcon]') AND [c].[name] = N'CreatedByUserId');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [DncIcon] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [DncIcon] DROP COLUMN [CreatedByUserId];

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DncIcon]') AND [c].[name] = N'ModifiedByUserId');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [DncIcon] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [DncIcon] DROP COLUMN [ModifiedByUserId];

GO

ALTER TABLE [DncUser] ADD [CreatedByUserGuid] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

GO

ALTER TABLE [DncUser] ADD [ModifiedByUserGuid] uniqueidentifier NULL;

GO

ALTER TABLE [DncRole] ADD [CreatedByUserGuid] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

GO

ALTER TABLE [DncRole] ADD [ModifiedByUserGuid] uniqueidentifier NULL;

GO

ALTER TABLE [DncPermission] ADD [CreatedByUserGuid] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

GO

ALTER TABLE [DncPermission] ADD [ModifiedByUserGuid] uniqueidentifier NULL;

GO

ALTER TABLE [DncMenu] ADD [CreatedByUserGuid] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

GO

ALTER TABLE [DncMenu] ADD [ModifiedByUserGuid] uniqueidentifier NULL;

GO

ALTER TABLE [DncIcon] ADD [CreatedByUserGuid] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

GO

ALTER TABLE [DncIcon] ADD [ModifiedByUserGuid] uniqueidentifier NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181222084512_Mt_Remove_Identity_Column', N'2.1.4-rtm-31024');

GO

