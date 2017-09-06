CREATE TABLE [dbo].[Users]
(
	UID Int Identity(1,1) Primary Key Not Null,
	UserID NVarchar(25) Not Null,
	[Password] NVarchar(20) Not Null
)
