GO 
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('T_BIZENTITY'))
BEGIN 
DROP TABLE T_BIZENTITY
END 
GO
IF EXISTS (SELECT name FROM sysindexes WHERE name = 'T_BIZENTITY_BizIndex')
DROP INDEX T_BIZENTITY.T_BIZENTITY_BizIndex
GO
CREATE TABLE T_BIZENTITY (
F_ID bigint PRIMARY KEY ,
F_SYSVERSION int not null ,
F_CREATOR BIGINT not null,F_ORGNIZATION BIGINT not null,F_CREATEDATE DATETIME,F_MODIFYDATE DATETIME,F_ORGNIZATIONC BIGINT not null)
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('T_BIZTREEENTITY'))
BEGIN 
DROP TABLE T_BIZTREEENTITY
END 
GO
IF EXISTS (SELECT name FROM sysindexes WHERE name = 'T_BIZTREEENTITY_BizIndex')
DROP INDEX T_BIZTREEENTITY.T_BIZTREEENTITY_BizIndex
GO
CREATE TABLE T_BIZTREEENTITY (
F_ID bigint PRIMARY KEY ,
F_SYSVERSION int not null ,
F_CREATOR BIGINT not null,F_ORGNIZATION BIGINT not null,F_CREATEDATE DATETIME,F_MODIFYDATE DATETIME,F_ORGNIZATIONC BIGINT not null,F_PID BIGINT,F_NAME NVARCHAR(100) not null,F_FULLNAME NVARCHAR(1000) not null,F_LEVEL INT not null,F_ORDERNO INT not null,F_LEAF BIT not null,F_ISDELETE BIT not null)
CREATE INDEX T_BIZTREEENTITY_BizIndex
 ON T_BIZTREEENTITY (F_ORGNIZATION,F_PID,F_NAME,F_LEVEL,F_ISDELETE)
GO
