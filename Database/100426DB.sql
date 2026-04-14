USE [vishalcommmonDB]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorId] [bigint] IDENTITY(1,1) NOT NULL,
	[ApplicationName] [varchar](100) NOT NULL,
	[ControllerName] [varchar](200) NULL,
	[ErrorMessage] [varchar](max) NOT NULL,
	[ErrorType] [varchar](200) NULL,
	[StackTrace] [varchar](max) NULL,
	[RequestUrl] [varchar](500) NULL,
	[RequestPayload] [varchar](max) NULL,
	[UserAgent] [varchar](500) NULL,
	[UserId] [bigint] NULL,
	[ClientIP] [varchar](50) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ForgetPassword]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForgetPassword](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[OTP] [nvarchar](10) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ExpiryDate] [datetime] NULL,
	[IsUsed] [bit] NOT NULL,
 CONSTRAINT [PK__ForgetPa__3214EC07FF297A4A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOV_MASTER]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOV_MASTER](
	[LOV_Column] [nvarchar](max) NOT NULL,
	[LOV_Code] [nvarchar](max) NOT NULL,
	[LOV_Desc] [nvarchar](max) NOT NULL,
	[DisplayOrder] [int] NULL,
	[CreatedBy] [bigint] NULL,
	[LastModifiedBy] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedDate] [datetime] NULL,
	[Display_Text] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentId] [bigint] NOT NULL,
	[Area] [nvarchar](max) NULL,
	[Controller] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Icon] [nvarchar](max) NULL,
	[DisplayOrder] [int] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [bigint] NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[IsSuperAdmin] [bit] NULL,
	[IsAdmin] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenuAccess]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenuAccess](
	[RoleId] [bigint] NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[IsCreate] [bit] NOT NULL,
	[IsUpdate] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [bigint] NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [bigint] NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMenuAccess]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMenuAccess](
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[IsCreate] [bit] NOT NULL,
	[IsUpdate] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [bigint] NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleMapping]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleMapping](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [bigint] NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoleMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [bigint] NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[Email] [nvarchar](250) NULL,
	[MobileNumber] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ErrorLog] ON 
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (1, N'BACKEND', N'Auth_Login', N'Procedure or function ''CheckUserAuthenticationForUserMaster'' expects parameter ''@response12345'', which was not supplied.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Procedure or function ''CheckUserAuthenticationForUserMaster'' expects parameter ''@response12345'', which was not supplied.
   at CommonForReact.Infra.RepositoryBase`1.ExecuteStoredProcedure(String query, SqlParameter[] parameters) in D:\VishalGami\GitClone\CommonForReact\Infra\RepositoryWrapper.cs:line 83
   at CommonForReact.Controllers.AuthController.Login(String userName, String password) in D:\VishalGami\GitClone\CommonForReact\Controllers\AuthController.cs:line 57
ClientConnectionId:f2c0ceee-8915-43dc-b431-aa93391b75b0
Error Number:201,State:4,Class:16', N'https://localhost:7281/api/Auth/Login?userName=rgf&password=hnhgnh', N'"rgf"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36', NULL, N'::1', CAST(N'2026-04-10T10:52:09.4066667' AS DateTime2), N'rgf')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (2, N'string', N'string', N'string', N'string', N'string', N'string', N'string', N'string', 0, N'string', CAST(N'2026-04-10T11:03:52.0833333' AS DateTime2), N'string')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (3, N'React', N'User', N'Request failed with status code 404', N'Error', N'', N'/User/Save', N'{"id":2,"userName":"demo456","isDeleted":false,"email":"demo456@gmail.com","mobileNumber":"9545284596","roleId":1}', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 0, N'', CAST(N'2026-04-10T11:31:23.2966667' AS DateTime2), NULL)
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (4, N'React', N'User', N'Request failed with status code 404', N'Error', N'', N'/User/Save', N'{"id":2,"userName":"demo456","isDeleted":false,"email":"demo456@gmail.com","mobileNumber":"9545284596","roleId":1}', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 0, N'', CAST(N'2026-04-10T11:31:30.4466667' AS DateTime2), NULL)
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (5, N'BACKEND', N'User_Add', N'Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.AddOrUpdateUser(User user) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 82
   at CommonForReact.Controllers.UserController.Add(User user) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 98
ClientConnectionId:4011635d-b6f0-4571-bc73-d1e745c9bbe8
Error Number:201,State:4,Class:16', N'https://localhost:7281/api/User/Add', N'{"Id":0,"UserName":"strdfvdding","Password":"string","IsActive":true,"IsDeleted":true,"Email":"string@gamil.com","MobileNumber":"1234568521","RoleId":1,"Rolename":"1","CreatedBy":0,"CreatedDate":"2026-04-10T06:08:52.587Z","LastModifiedBy":0,"LastModifiedDate":"2026-04-10T06:08:52.587Z"}', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36', 1, N'::1', CAST(N'2026-04-10T11:40:31.0566667' AS DateTime2), N'Admin')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (6, N'BACKEND', N'User_Add', N'Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.AddOrUpdateUser(User user) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 82
   at CommonForReact.Controllers.UserController.Add(User user) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 98
ClientConnectionId:0404c2d7-7149-4fea-baef-1e3b8fc62441
Error Number:201,State:4,Class:16', N'https://localhost:7281/api/User/Add', N'{"Id":2,"UserName":"demo456","Password":null,"IsActive":null,"IsDeleted":false,"Email":"demo456@gmail.com","MobileNumber":"9545284596","RoleId":1,"Rolename":null,"CreatedBy":null,"CreatedDate":null,"LastModifiedBy":null,"LastModifiedDate":null}', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T11:43:20.4900000' AS DateTime2), N'Admin')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (7, N'React', N'User.Update', N'Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.', N'Error', N'Error: Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.
    at handleSubmit (http://localhost:3000/main.aa563acfce1ce0a3f5fb.hot-update.js:780:13)', N'/User/Update', N'{"id":2,"userName":"demo456","isDeleted":false,"email":"demo456@gmail.com","mobileNumber":"9545284596","roleId":1}', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 0, N'', CAST(N'2026-04-10T11:43:22.9000000' AS DateTime2), NULL)
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (8, N'BACKEND', N'User_Add', N'Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.AddOrUpdateUser(User user) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 82
   at CommonForReact.Controllers.UserController.Add(User user) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 98
ClientConnectionId:0404c2d7-7149-4fea-baef-1e3b8fc62441
Error Number:201,State:4,Class:16', N'https://localhost:7281/api/User/Add', N'{"Id":2,"UserName":"demo456","Password":null,"IsActive":null,"IsDeleted":false,"Email":"demo456@gmail.com","MobileNumber":"9545284596","RoleId":1,"Rolename":null,"CreatedBy":null,"CreatedDate":null,"LastModifiedBy":null,"LastModifiedDate":null}', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T11:44:16.5766667' AS DateTime2), N'Admin')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (9, N'React', N'User.Update', N'Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.', N'Error', N'Error: Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.
    at handleSubmit (http://localhost:3000/main.aa563acfce1ce0a3f5fb.hot-update.js:780:13)', N'/User/Update', N'{"id":2,"userName":"demo456","isDeleted":false,"email":"demo456@gmail.com","mobileNumber":"9545284596","roleId":1}', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 0, N'', CAST(N'2026-04-10T11:44:20.3266667' AS DateTime2), NULL)
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (10, N'BACKEND', N'User_Add', N'Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Procedure or function ''sp_User_Save'' expects parameter ''@demo'', which was not supplied.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.AddOrUpdateUser(User user) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 82
   at CommonForReact.Controllers.UserController.Add(User user) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 98
ClientConnectionId:0404c2d7-7149-4fea-baef-1e3b8fc62441
Error Number:201,State:4,Class:16', N'https://localhost:7281/api/User/Add', N'{"Id":2,"UserName":"demo456","Password":null,"IsActive":null,"IsDeleted":false,"Email":"demo456@gmail.com","MobileNumber":"9545284596","RoleId":1,"Rolename":null,"CreatedBy":null,"CreatedDate":null,"LastModifiedBy":null,"LastModifiedDate":null}', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T11:50:01.1766667' AS DateTime2), N'Admin')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (11, N'BACKEND', N'User_ResetPassword', N'Could not find stored procedure ''ResetPasswordByUsername''.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Could not find stored procedure ''ResetPasswordByUsername''.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 259
ClientConnectionId:41524d21-5b24-4237-bebf-f8fc59d84f53
Error Number:2812,State:62,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=zxdvxdvdsxvdsf', N'"zxdvxdvdsxvdsf"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36', 1, N'::1', CAST(N'2026-04-10T15:52:30.9100000' AS DateTime2), N'Admin')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (12, N'BACKEND', N'User_ResetPassword', N'Could not find stored procedure ''ResetPasswordByUsername''.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Could not find stored procedure ''ResetPasswordByUsername''.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username)
   at CommonForReact.Controllers.UserController.ResetPassword(String username)
ClientConnectionId:6aecbffd-0a9c-42f5-bb7e-0e9716e71ebf
Error Number:2812,State:62,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=dfgdfgdfdf', N'"dfgdfgdfdf"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:06:46.2066667' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (13, N'BACKEND', N'Common_SendEmail', N'The specified string is not in the form required for an e-mail address.', N'System.FormatException', N'System.FormatException: The specified string is not in the form required for an e-mail address.
   at System.Net.Mail.MailAddressParser.TryReadCfwsAndThrowIfIncomplete(String data, Int32 index, Int32& outIndex, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddressParser.TryParseDomain(String data, Int32& index, String& domain, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddressParser.TryParseAddress(String data, Boolean expectMultipleAddresses, Int32& index, ParseAddressInfo& parseAddressInfo, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddressParser.TryParseAddress(String data, ParseAddressInfo& parsedAddress, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddress.TryParse(String address, String displayName, Encoding displayNameEncoding, ValueTuple`4& parsedData, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddress..ctor(String address)
   at CommonForReact.Infra.Common.SendEmail(String subject, String recipient_mails, Boolean isBodyHtml, String body, String templateFile, String templateData) in D:\VishalGami\GitClone\CommonForReact\Infra\Common.cs:line 165', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'subject:Your Password, recipients:0', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:23:03.1600000' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (14, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 261
ClientConnectionId:754a22ce-50cb-4942-b884-4df5eea7ef02
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:33:28.3300000' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (15, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 261
ClientConnectionId:754a22ce-50cb-4942-b884-4df5eea7ef02
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:33:28.3300000' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (16, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 261
ClientConnectionId:754a22ce-50cb-4942-b884-4df5eea7ef02
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:34:18.3200000' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (17, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 261
ClientConnectionId:feeb4671-2bfc-4337-b9af-5f6a0e96f167
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:35:19.8800000' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (18, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 261
ClientConnectionId:feeb4671-2bfc-4337-b9af-5f6a0e96f167
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:35:20.0733333' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (19, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 259
ClientConnectionId:ac81e799-c1c5-483d-a194-8d01373b501d
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:40:12.5166667' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (20, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 259
ClientConnectionId:ac81e799-c1c5-483d-a194-8d01373b501d
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:40:12.5633333' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (21, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 259
ClientConnectionId:d26a4517-b6de-4e78-9b3e-c96baa4c6168
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36 Edg/146.0.0.0', 1, N'::1', CAST(N'2026-04-10T16:42:51.3100000' AS DateTime2), N'Admin34')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (22, N'BACKEND', N'User_ResetPassword', N'Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.', N'Microsoft.Data.SqlClient.SqlException', N'Microsoft.Data.SqlClient.SqlException (0x80131904): Conversion failed when converting the varchar value ''S|Record updated successfully|'' to data type int.
   at CommonForReact.ServiceRepository.UserRepository.UserRepository.ResetPasswordByUsername(String username) in D:\VishalGami\GitClone\CommonForReact\ServiceRepository\UserRepository\UserRepository.cs:line 191
   at CommonForReact.Controllers.UserController.ResetPassword(String username) in D:\VishalGami\GitClone\CommonForReact\Controllers\UserController.cs:line 259
ClientConnectionId:d26a4517-b6de-4e78-9b3e-c96baa4c6168
Error Number:245,State:1,Class:16', N'https://localhost:7281/api/User/ResetPassword?username=demo456', N'"demo456"', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36', 1, N'::1', CAST(N'2026-04-10T16:45:15.6733333' AS DateTime2), N'Admin')
GO
INSERT [dbo].[ErrorLog] ([ErrorId], [ApplicationName], [ControllerName], [ErrorMessage], [ErrorType], [StackTrace], [RequestUrl], [RequestPayload], [UserAgent], [UserId], [ClientIP], [CreatedDate], [CreatedBy]) VALUES (23, N'BACKEND', N'Common_SendEmail', N'The specified string is not in the form required for an e-mail address.', N'System.FormatException', N'System.FormatException: The specified string is not in the form required for an e-mail address.
   at System.Net.Mail.MailAddressParser.TryReadCfwsAndThrowIfIncomplete(String data, Int32 index, Int32& outIndex, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddressParser.TryParseDomain(String data, Int32& index, String& domain, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddressParser.TryParseAddress(String data, Boolean expectMultipleAddresses, Int32& index, ParseAddressInfo& parseAddressInfo, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddressParser.TryParseAddress(String data, ParseAddressInfo& parsedAddress, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddress.TryParse(String address, String displayName, Encoding displayNameEncoding, ValueTuple`4& parsedData, Boolean throwExceptionIfFail)
   at System.Net.Mail.MailAddress..ctor(String address)
   at CommonForReact.Infra.Common.SendEmail(String subject, String recipient_mails, Boolean isBodyHtml, String body, String templateFile, String templateData) in D:\VishalGami\GitClone\CommonForReact\Infra\Common.cs:line 165', N'https://localhost:7281/api/User/ResetPassword?username=Dhaval', N'subject:Your Password, recipients:Dhaval', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/146.0.0.0 Safari/537.36', 1, N'::1', CAST(N'2026-04-10T17:07:49.2266667' AS DateTime2), N'Admin')
GO
SET IDENTITY_INSERT [dbo].[ErrorLog] OFF
GO
SET IDENTITY_INSERT [dbo].[ForgetPassword] ON 
GO
INSERT [dbo].[ForgetPassword] ([Id], [Email], [OTP], [CreatedAt], [ExpiryDate], [IsUsed]) VALUES (1, N'vmgami2001@gmail.com', N'865679', CAST(N'2026-04-10T17:38:28.280' AS DateTime), CAST(N'2026-04-10T17:48:28.280' AS DateTime), 1)
GO
INSERT [dbo].[ForgetPassword] ([Id], [Email], [OTP], [CreatedAt], [ExpiryDate], [IsUsed]) VALUES (2, N'vmgami2001@gmail.com', N'475298', CAST(N'2026-04-10T17:42:58.667' AS DateTime), CAST(N'2026-04-10T17:52:58.667' AS DateTime), 1)
GO
INSERT [dbo].[ForgetPassword] ([Id], [Email], [OTP], [CreatedAt], [ExpiryDate], [IsUsed]) VALUES (3, N'vmgami2001@gmail.com', N'130001', CAST(N'2026-04-10T17:47:55.943' AS DateTime), CAST(N'2026-04-10T17:57:55.943' AS DateTime), 1)
GO
INSERT [dbo].[ForgetPassword] ([Id], [Email], [OTP], [CreatedAt], [ExpiryDate], [IsUsed]) VALUES (4, N'vmgami2001@gmail.com', N'714771', CAST(N'2026-04-10T18:10:24.333' AS DateTime), CAST(N'2026-04-10T18:20:24.333' AS DateTime), 1)
GO
INSERT [dbo].[ForgetPassword] ([Id], [Email], [OTP], [CreatedAt], [ExpiryDate], [IsUsed]) VALUES (5, N'vmgami2001@gmail.com', N'984590', CAST(N'2026-04-10T18:26:57.993' AS DateTime), CAST(N'2026-04-10T18:36:57.993' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[ForgetPassword] OFF
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'Status', N'1', N'Isactive', 1, 0, 1, 1, 0, CAST(N'2026-04-09T15:43:38.683' AS DateTime), CAST(N'2026-04-09T17:12:02.653' AS DateTime), N'5')
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'Number', N'Number', N'Number', NULL, 0, 1, 1, 0, CAST(N'2026-04-09T15:40:06.220' AS DateTime), CAST(N'2026-04-09T17:11:53.050' AS DateTime), N'10')
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'Status', N'2', N'Isdelete', 2, 0, 1, 1, 0, CAST(N'2026-04-09T15:44:55.610' AS DateTime), CAST(N'2026-04-09T17:12:02.653' AS DateTime), N'5')
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'Testing', N'Testing', N'Testing', NULL, 1, 1, 1, 0, CAST(N'2026-04-09T16:17:03.320' AS DateTime), CAST(N'2026-04-09T17:11:40.187' AS DateTime), N'11')
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'column-101', N'column-101', N'column-101', NULL, 1, 1, 1, 0, CAST(N'2026-04-09T16:42:45.370' AS DateTime), CAST(N'2026-04-09T16:52:01.400' AS DateTime), N'10')
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'column-102', N'column-102', N'column-102', NULL, 1, 1, 1, 0, CAST(N'2026-04-09T17:02:59.267' AS DateTime), NULL, N'10')
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'Status', N'3', N'new', 5, 0, 0, 0, 0, CAST(N'2026-04-09T17:10:45.243' AS DateTime), CAST(N'2026-04-09T17:26:41.507' AS DateTime), N'5')
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'Status', N'4', N'new34', 2, 0, NULL, 1, 0, CAST(N'2026-04-09T17:26:30.150' AS DateTime), NULL, N'5')
GO
INSERT [dbo].[LOV_MASTER] ([LOV_Column], [LOV_Code], [LOV_Desc], [DisplayOrder], [CreatedBy], [LastModifiedBy], [IsActive], [IsDeleted], [CreatedDate], [LastModifiedDate], [Display_Text]) VALUES (N'gnhgng', N'gnhgng', N'gnhgng', NULL, 1, 1, 1, 0, CAST(N'2026-04-09T17:26:57.403' AS DateTime), NULL, N'10')
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Area], [Controller], [Url], [Name], [Icon], [DisplayOrder], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsSuperAdmin], [IsAdmin], [IsActive], [IsDeleted]) VALUES (1, 2, N'Ad', N'Menu', N'string', N'Menu', N' mdi-account-cog-outline', 0, 0, CAST(N'2026-01-16T18:54:21.2533333' AS DateTime2), 1, CAST(N'2026-04-09T19:07:50.0866667' AS DateTime2), 1, 1, 1, 0)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Area], [Controller], [Url], [Name], [Icon], [DisplayOrder], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsSuperAdmin], [IsAdmin], [IsActive], [IsDeleted]) VALUES (2, 0, N'Ad', N'', N'string', N'Config', N'ion ion-ios-settings', 0, 1, CAST(N'2026-04-08T16:07:43.4333333' AS DateTime2), 1, CAST(N'2026-04-09T19:05:41.8733333' AS DateTime2), 1, 1, 1, 0)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Area], [Controller], [Url], [Name], [Icon], [DisplayOrder], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsSuperAdmin], [IsAdmin], [IsActive], [IsDeleted]) VALUES (3, 2, N'Ad', N'User', N'string', N'Users', N'mdi-account-outline', 0, 1, CAST(N'2026-04-08T16:08:07.5400000' AS DateTime2), 1, CAST(N'2026-04-09T19:06:34.2933333' AS DateTime2), 1, 1, 1, 0)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Area], [Controller], [Url], [Name], [Icon], [DisplayOrder], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsSuperAdmin], [IsAdmin], [IsActive], [IsDeleted]) VALUES (4, 2, N'Ad', N'Role', N'string', N'Roles', N'mdi-account-key-outline', 0, 1, CAST(N'2026-04-08T16:08:19.2033333' AS DateTime2), 1, CAST(N'2026-04-09T19:06:56.3066667' AS DateTime2), 1, 1, 1, 0)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Area], [Controller], [Url], [Name], [Icon], [DisplayOrder], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsSuperAdmin], [IsAdmin], [IsActive], [IsDeleted]) VALUES (5, 2, N'', N'Lov', N'', N'Lov_master', N'mdi-form-select', 0, 1, CAST(N'2026-04-09T15:46:22.2633333' AS DateTime2), 1, CAST(N'2026-04-09T19:07:08.4433333' AS DateTime2), 0, 0, 1, 0)
GO
INSERT [dbo].[Menu] ([Id], [ParentId], [Area], [Controller], [Url], [Name], [Icon], [DisplayOrder], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsSuperAdmin], [IsAdmin], [IsActive], [IsDeleted]) VALUES (6, 0, N'', N'', N'', N'Admin', N'', 0, 1, CAST(N'2026-04-10T10:29:59.5900000' AS DateTime2), 1, NULL, 0, 0, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (2, 1, 1, 1, 1, 1, 0, CAST(N'2026-04-08T11:14:31.4900000' AS DateTime2), 1, NULL, 0, 1)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (2, 2, 1, 1, 1, 1, 0, CAST(N'2026-04-08T11:14:31.4900000' AS DateTime2), 1, NULL, 0, 1)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (2, 3, 1, 1, 1, 1, 0, CAST(N'2026-04-08T11:14:31.4900000' AS DateTime2), 1, NULL, 0, 1)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (5, 1, 1, 1, 1, 1, 1, CAST(N'2026-04-08T18:20:46.8100000' AS DateTime2), 1, NULL, 0, 1)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (5, 2, 1, 1, 1, 1, 1, CAST(N'2026-04-08T18:20:46.8100000' AS DateTime2), 1, NULL, 0, 1)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (3, 1, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T14:41:21.3033333' AS DateTime2), 1, 0)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (3, 2, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T14:41:21.3033333' AS DateTime2), 1, 0)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (1, 1, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T11:09:01.3866667' AS DateTime2), 1, 0)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (1, 2, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T11:09:01.3866667' AS DateTime2), 1, 0)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (1, 3, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T11:09:01.3866667' AS DateTime2), 1, 0)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (1, 4, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T11:09:01.3866667' AS DateTime2), 1, 0)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (1, 5, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T11:09:01.3866667' AS DateTime2), 1, 0)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (6, 0, 1, 1, 1, 1, 1, CAST(N'2026-04-09T13:48:19.4000000' AS DateTime2), 1, NULL, 0, 1)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (3, 3, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T14:41:21.3033333' AS DateTime2), 1, 0)
GO
INSERT [dbo].[RoleMenuAccess] ([RoleId], [MenuId], [IsRead], [IsCreate], [IsUpdate], [IsDelete], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (3, 4, 1, 1, 1, 1, 1, NULL, NULL, CAST(N'2026-04-09T14:41:21.3033333' AS DateTime2), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Name], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [IsAdmin]) VALUES (1, N'Admin', 0, CAST(N'2026-01-16T18:46:29.0000000' AS DateTime2), 1, CAST(N'2026-04-09T11:09:01.3866667' AS DateTime2), 1, 0, 1)
GO
INSERT [dbo].[Roles] ([Id], [Name], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [IsAdmin]) VALUES (2, N'Demo304', 0, CAST(N'2026-04-08T11:14:31.4866667' AS DateTime2), 1, NULL, 0, 1, NULL)
GO
INSERT [dbo].[Roles] ([Id], [Name], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [IsAdmin]) VALUES (3, N'Testing', 1, CAST(N'2026-04-08T11:22:42.2533333' AS DateTime2), 1, CAST(N'2026-04-09T14:41:21.3000000' AS DateTime2), 1, 0, 0)
GO
INSERT [dbo].[Roles] ([Id], [Name], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [IsAdmin]) VALUES (4, N'string', 1, CAST(N'2026-04-08T18:19:45.7000000' AS DateTime2), 1, NULL, 0, 1, NULL)
GO
INSERT [dbo].[Roles] ([Id], [Name], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [IsAdmin]) VALUES (5, N'SuperAdmin', 1, CAST(N'2026-04-08T18:20:46.8100000' AS DateTime2), 1, NULL, 0, 1, NULL)
GO
INSERT [dbo].[Roles] ([Id], [Name], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [IsAdmin]) VALUES (6, N'', 1, CAST(N'2026-04-09T13:48:19.3900000' AS DateTime2), 1, NULL, 0, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoleMapping] ON 
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (1, 1, 1, 0, CAST(N'2026-01-16T18:47:31.1233333' AS DateTime2), 1, CAST(N'2026-04-10T15:50:24.4533333' AS DateTime2), 1, 0)
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (2, 2, 1, 0, CAST(N'2026-04-07T18:31:20.4400000' AS DateTime2), 1, CAST(N'2026-04-10T16:21:38.9466667' AS DateTime2), 1, 0)
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (3, 3, 1, 0, CAST(N'2026-04-07T18:38:25.9500000' AS DateTime2), 0, CAST(N'2026-04-07T18:45:11.0333333' AS DateTime2), 1, 0)
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (4, 4, 1, 1, CAST(N'2026-04-08T17:10:22.5166667' AS DateTime2), 0, NULL, 1, 0)
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (5, 5, 3, 1, CAST(N'2026-04-09T12:28:46.2200000' AS DateTime2), 0, NULL, 1, 0)
GO
INSERT [dbo].[UserRoleMapping] ([Id], [UserId], [RoleId], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted]) VALUES (6, 6, 3, 1, CAST(N'2026-04-10T11:13:29.9500000' AS DateTime2), 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[UserRoleMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [UserName], [Password], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [Email], [MobileNumber]) VALUES (1, N'Admin', N'5Wfljolh0qw=', 0, CAST(N'2026-01-16T18:47:31.1233333' AS DateTime2), 1, CAST(N'2026-04-10T16:09:21.3566667' AS DateTime2), 1, 0, N'admin34csdcsdfc@gmail.com', N'1234567890')
GO
INSERT [dbo].[Users] ([Id], [UserName], [Password], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [Email], [MobileNumber]) VALUES (2, N'demo456', N'niQZhjtRSmq/a6Yl4y7QoQ==', 0, CAST(N'2026-04-07T18:31:20.4366667' AS DateTime2), 2, CAST(N'2026-04-10T17:56:18.0600000' AS DateTime2), 1, 0, N'vmgami2001@gmail.com', N'9545284596')
GO
INSERT [dbo].[Users] ([Id], [UserName], [Password], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [Email], [MobileNumber]) VALUES (4, N'Gamivishal', N'5Wfljolh0qw=', 1, CAST(N'2026-04-08T17:10:22.5166667' AS DateTime2), 1, NULL, 0, 1, N'Gamivishal@gmail.com', N'9589584586')
GO
INSERT [dbo].[Users] ([Id], [UserName], [Password], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [Email], [MobileNumber]) VALUES (5, N'Dhaval', N'niQZhjtRSmq/a6Yl4y7QoQ==', 1, CAST(N'2026-04-09T12:28:46.2133333' AS DateTime2), 5, CAST(N'2026-04-10T17:07:39.3666667' AS DateTime2), 0, 1, N'Dhaval', N'9428011036')
GO
INSERT [dbo].[Users] ([Id], [UserName], [Password], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [IsActive], [IsDeleted], [Email], [MobileNumber]) VALUES (6, N'dfbvdf', N'5Wfljolh0qw=', 1, CAST(N'2026-04-10T11:13:29.9466667' AS DateTime2), 0, NULL, 1, 0, N'ashishfbfgb86.mca@gmail.com', N'9545284596')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[ErrorLog] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ForgetPassword] ADD  CONSTRAINT [DF__ForgetPas__Creat__6A50C1DA]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ForgetPassword] ADD  CONSTRAINT [DF__ForgetPas__IsUse__6B44E613]  DEFAULT ((0)) FOR [IsUsed]
GO
ALTER TABLE [dbo].[LOV_MASTER] ADD  CONSTRAINT [DF__LOV_MASTE__IsAct__0D99FE17]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[LOV_MASTER] ADD  CONSTRAINT [DF__LOV_MASTE__IsDel__0E8E2250]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserMenuAccess] ADD  CONSTRAINT [DF_UserMenuAccess_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserRoleMapping] ADD  CONSTRAINT [DF_UserRoleMapping_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[UserRoleMapping] ADD  CONSTRAINT [DF_UserRoleMapping_LastModifiedBy]  DEFAULT ((0)) FOR [LastModifiedBy]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LastModifiedBy]  DEFAULT ((0)) FOR [LastModifiedBy]
GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[ChangePassword]

@OldPassword nvarchar(max)='',
@NewPassword nvarchar(max)='',
@ConfirmPassword nvarchar(max)='',
@Operated_By bigint = 0,
@IsActive bit = 0,
@response varchar(100) out
AS
BEGIN
	SET NOCOUNT ON;
	SET @response = 'E|' + 'Contact System Administration|0';
	
	
	declare @getoldpassfromuser varchar(max)=''
	declare @username nvarchar(max)=''
	set @getoldpassfromuser = (SELECT  [Password] from Users where  Id = @Operated_By)
	IF(@getoldpassfromuser = @OldPassword)
	begin
		UPDATE Users
		SET Password = @ConfirmPassword
		WHERE Id = @Operated_By
		SET @response = 'S|' + 'Password Updated Successfully|' + CONVERT(NVARCHAR(MAX),@Operated_By);
	END
	Else
	BEGIN
		SET @response =  'E|' + 'Old password is not match.|0'; 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[CheckUserAuthentication]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckUserAuthentication]
    @puserid VARCHAR(50),
	@password VARCHAR(50),
    @response NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Id INT,
            @UserNameDb NVARCHAR(100),
            @PasswordHash NVARCHAR(500),
            @RoleId BIGINT;

    IF NOT EXISTS (SELECT 1 FROM Users WHERE UPPER(UserName) = UPPER(@puserid) AND UPPER(Password)=UPPER(@password))
    BEGIN
        SET @Response = 'E|User not found';
        RETURN;
    END

    SELECT 
        @Id           = U.Id,
        @UserNameDb   = U.UserName,
        @PasswordHash = U.Password,
        @RoleId       = UR.RoleId
    FROM Users U
    LEFT JOIN UserRoleMapping UR ON UR.UserId = U.Id
    WHERE UPPER(U.UserName) = UPPER(@puserid);

    IF @Id IS NULL
    BEGIN
        SET @Response = 'E|User retrieval failed';
        RETURN;
    END

    -- Build response: S|Message|UserId|RoleId|PasswordHash
    SET @Response = CONCAT('S|User fetched successfully|', @Id, '|', ISNULL(CAST(@RoleId AS NVARCHAR(20)),''), '|', @UserNameDb);
END;
GO
/****** Object:  StoredProcedure [dbo].[CheckUserAuthenticationForUserMaster]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[CheckUserAuthenticationForUserMaster]
    @puserid  VARCHAR(50),
    @password VARCHAR(50),
    @response NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Id BIGINT,
            @UserNameDb NVARCHAR(100),
            @PasswordHash NVARCHAR(200),
			 @RoleId BIGINT,
            @RoleName NVARCHAR(100);

    
    IF NOT EXISTS (
        SELECT 1 
        FROM Users
        WHERE UPPER(UserName) = UPPER(@puserid)
          AND UPPER(Password) = UPPER(@password)
          AND IsActive = 1
    )
    BEGIN
        SET @response = 'E|Invalid username or password';
        RETURN;
    END

    -- ✅ Get user details
    SELECT 
        @Id           = Id,
        @UserNameDb   = UserName,
        @PasswordHash = [Password]
    FROM Users
    WHERE UPPER(UserName) = UPPER(@puserid)
      AND IsActive = 1;

	      SELECT 
        @RoleId = R.Id,
        @RoleName = R.Name
    FROM UserRoleMapping UR
    INNER JOIN Roles R ON UR.RoleId = R.Id
    WHERE UR.UserId = @Id AND UR.IsActive = 1;

    -- ✅ Build response: S|Message|UserId|UserName
    SET @response = CONCAT('S|User fetched successfully|', @Id, '|', @UserNameDb,'|', @RoleId, '|', @RoleName);
END




GO
/****** Object:  StoredProcedure [dbo].[forgotpassword]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[forgotpassword]
    @Username NVARCHAR(256),
    @NewPasswordHash NVARCHAR(512),
    @response NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserId INT;
	DEclare @Email Nvarchar(250);

    -- Step 1: Check if user exists
    SELECT @UserId = Id ,@Email=Email FROM Users WHERE Username = @Username;

    IF @UserId IS NULL
    BEGIN
        SET @response = 'E|Invalid User Name|0';
        RETURN;
    END

    -- If email is null or empty/whitespace -> error
    IF (@Email IS NULL) OR (LTRIM(RTRIM(@Email)) = N'')
    BEGIN
        SET @response = N'E|User Does Not Have Email|0';
        RETURN;
    END

    -- Step 2: Update password
    UPDATE Users
    SET Password = @NewPasswordHash,
       LastModifiedDate = GETDATE()
    WHERE Id = @UserId;

    -- Step 3: Success message
    SET @response = 'S|Record updated successfully|' + @Email;

END
GO
/****** Object:  StoredProcedure [dbo].[ResetPasswordByUsername]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ALTER PROCEDURE [dbo].[ResetPasswordByUsername]
--    @Username NVARCHAR(256),
--    @NewPasswordHash NVARCHAR(512),
--    @response NVARCHAR(MAX) OUTPUT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    DECLARE @UserId INT;
--	DEclare @Email Nvarchar(250);

--    -- Step 1: Check if user exists
--    SELECT @UserId = Id ,@Email=Email FROM Users WHERE Username = @Username;

--    IF @UserId IS NULL
--    BEGIN
--        SET @response = 'E|Invalid User Name|0';
--        RETURN;
--    END


--    -- Step 2: Update password
--    UPDATE Users
--    SET Password = @NewPasswordHash,
--       LastModifiedDate = GETDATE(),
--	   LastModifiedBy=@UserId
--    WHERE Id = @UserId;

--    -- Step 3: Success message
--    SET @response = 'S|Record updated successfully|' + CAST(@UserId AS NVARCHAR) + '|' + ISNULL(@Email, '');

--END
CREATE PROCEDURE [dbo].[ResetPasswordByUsername]
    @Username NVARCHAR(256),
    @NewPasswordHash NVARCHAR(512),
    @response NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserId INT;
    DECLARE @Email NVARCHAR(250);

    -- Step 1: Check if user exists
    SELECT TOP 1 
        @UserId = Id,
        @Email = Email
    FROM Users
    WHERE Username = LTRIM(RTRIM(@Username));

    IF @UserId IS NULL
    BEGIN
        SET @response = 'E|Invalid User Name|0';
        RETURN;
    END

    -- Step 2: Update password
    UPDATE Users
    SET Password = @NewPasswordHash,
        LastModifiedDate = GETDATE(),
        LastModifiedBy = @UserId
    WHERE Id = @UserId;

    IF @@ROWCOUNT = 0
    BEGIN
        SET @response = 'E|Failed to update password|0';
        RETURN;
    END

    -- Step 3: Success message
    SET @response = 
        'S|Record updated successfully|' 
        + CAST(@UserId AS NVARCHAR) 
        + '|' 
        + ISNULL(@Email, '');
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AddRoleMenuAccess]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_AddRoleMenuAccess]
    @RoleId BIGINT,
    @MenuIds NVARCHAR(MAX), -- comma separated MenuIds
    @IsRead BIT,
    @IsCreate BIT,
    @IsUpdate BIT,
    @IsDelete BIT,
    @CreatedBy BIGINT,       -- bigint for FK
    @Response NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Role validation
    IF NOT EXISTS (SELECT 1 FROM roles WHERE Id = @RoleId AND IsActive = 1)
    BEGIN
        SET @Response = 'E|Invalid RoleId, cannot add menu access.';
        RETURN;
    END

    DELETE FROM RoleMenuAccess WHERE RoleId = @RoleId;

    ;WITH MenuSplit AS
    (
        SELECT DISTINCT CAST(value AS BIGINT) AS MenuId
        FROM STRING_SPLIT(@MenuIds, ',')
    )
    INSERT INTO RoleMenuAccess
    (
        RoleId, MenuId, IsRead, IsCreate, IsUpdate, IsDelete, 
        IsActive, IsDeleted, CreatedBy, CreatedDate,LastModifiedBy
    )
    SELECT 
        @RoleId,
        MenuId,
        ISNULL(@IsRead, 1),    -- Default 1 if null
        ISNULL(@IsCreate, 1),  -- Default 1 if null
        ISNULL(@IsUpdate, 1),  -- Default 1 if null
        ISNULL(@IsDelete, 1), 
        1,
        0,
        @CreatedBy, 
		GETDATE(),
		0
    FROM MenuSplit;

    SET @Response = 'S|Role menu access added successfully.';
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteMenu]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_DeleteMenu]
    @MenuId BIGINT,
    @Response VARCHAR(200) OUT
AS
BEGIN
    BEGIN TRY
        UPDATE [dbo].[Menu]
        SET IsActive = 0, IsDeleted = 1, LastModifiedDate = GETDATE()
        WHERE Id = @MenuId AND IsActive = 1 AND IsDeleted = 0;

        IF @@ROWCOUNT > 0
            SET @Response = 'S|Record deleted successfully';
        ELSE
            SET @Response = 'E|Menu ID not found';
    END TRY
    BEGIN CATCH
        SET @Response = 'E|' + ERROR_MESSAGE();
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ForgotPassword_GenerateOTP]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ForgotPassword_GenerateOTP]
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserId INT;
    DECLARE @OTP INT;

    -- Check Email Exists
    SELECT @UserId = Id
    FROM Users
    WHERE Email = @Email;

    IF (@UserId IS NULL)
    BEGIN
        SELECT 0 AS Status, 'Email not found' AS Message;
        RETURN;
    END

    -- Mark all old OTPs as used
    UPDATE ForgetPassword
    SET IsUsed = 1
    WHERE Email = @Email
      AND IsUsed = 0;

    -- Generate 6-digit OTP
    SET @OTP = ABS(CHECKSUM(NEWID())) % 900000 + 100000;

    -- Insert new OTP with 10 min expiry
    INSERT INTO ForgetPassword
    (
        Email,
        OTP,
        CreatedAt,
        ExpiryDate,
        IsUsed
    )
    VALUES
    (
        
        @Email,
        @OTP,
        GETDATE(),
        DATEADD(MINUTE, 10, GETDATE()),
        0
    );

    -- Success response
    SELECT 
        1 AS Status,
        'OTP generated successfully' AS Message,
        @OTP AS OTP; -- remove in production
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ForgotPassword_ResetPassword]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ForgotPassword_ResetPassword]
    @Email NVARCHAR(100),
    @NewPassword NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserId INT;

    -- Check Email Exists
    SELECT @UserId = Id
    FROM Users
    WHERE Email = @Email;

    IF (@UserId IS NULL)
    BEGIN
        SELECT 0 AS Status, 'Email not found' AS Message;
        RETURN;
    END

    
    

    -- Update Password
    UPDATE Users
    SET Password = @NewPassword
    WHERE Id = @UserId;

    SELECT 1 AS Status, 'Password reset successfully' AS Message;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ForgotPassword_VerifyOTP]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ForgotPassword_VerifyOTP]
    @Email NVARCHAR(100),
    @OTP INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DB_OTP INT;
    DECLARE @CreatedAt DATETIME;
    DECLARE @IsUsed BIT;

    -- Get latest OTP (last inserted)
    SELECT TOP 1 
        @DB_OTP = OTP,
        @CreatedAt = CreatedAt,
        @IsUsed = IsUsed
    FROM ForgetPassword
    WHERE Email = @Email
    ORDER BY CreatedAt DESC;

    -- 1. Check OTP exists
    IF (@DB_OTP IS NULL)
    BEGIN
        SELECT 0 AS Status, 'OTP expired or not found.' AS Message;
        RETURN;
    END

    -- 2. Check already used
    IF (@IsUsed = 1)
    BEGIN
        SELECT 0 AS Status, 'OTP already used.' AS Message;
        RETURN;
    END

    -- 3. Check expiry (10 minutes)
    IF (DATEDIFF(MINUTE, @CreatedAt, GETDATE()) > 10)
    BEGIN
        SELECT 0 AS Status, 'OTP expired (valid only 10 minutes).' AS Message;
        RETURN;
    END

    -- 4. Check OTP match
    IF (@DB_OTP <> @OTP)
    BEGIN
        SELECT 0 AS Status, 'Invalid OTP.' AS Message;
        RETURN;
    END

    -- 5. Mark OTP as used
    UPDATE ForgetPassword
    SET IsUsed = 1
    WHERE Email = @Email
      AND OTP = @OTP
      AND IsUsed = 0;

    SELECT 1 AS Status, 'OTP verified successfully' AS Message;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetMenuList]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_GetMenuList]
AS
BEGIN
   
        SELECT Id,NAme
        FROM Menu
        WHERE IsActive = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetRoleList]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_GetRoleList]
AS
BEGIN
    SELECT 
        Id AS Id,
        [Name] AS [Name]
    FROM Roles
    WHERE IsActive = 1 AND IsDeleted = 0
    ORDER BY [Name];
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetusersList]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetusersList]
AS
BEGIN
    SELECT 
        Id AS Id,
        UserName AS [Name]
    FROM Users
    WHERE IsActive = 1 AND IsDeleted = 0
    ORDER BY UserName;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LOV_Get]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LOV_Get]
	-- Add the parameters for the stored procedure here
	@Lov_Column varchar(30)='',
	@Lov_Code varchar(50)='',
	@Flag varchar(30)=''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@Flag = 'LI')-- LI = bind Lov Index data
	begin
		select distinct ISNULL(Lov_Column,'')Lov_Column,ISNULL(Display_Text,'')Display_Text from LOV_MASTER
	end
	else if(@Flag = 'LE') -- LE = bind Lov Edit data
	begin
		select distinct ISNULL(Lov_Column,'')Lov_Column,ISNULL(Display_Text,'')Display_Text from LOV_MASTER where Lov_Column = @Lov_Column
	end
	else if(@Flag = 'LDI') -- LDI = bind Lov details Index data
	begin
		select ISNULL(Lov_Column,'')Lov_Column,ISNULL(Lov_Code,'')Lov_Code,ISNULL(Lov_Desc,'')Lov_Desc,ISNULL(Display_Text,'')Display_Text,ISNULL(IsActive,0)IsActive,
		ISNULL(DisplayOrder,0)DisplayOrder,((select MAX(DisplayOrder) from LOV_MASTER where Lov_Column = @Lov_Column)+1)MaxDisplay_Seq_No,ISNULL(CreatedBy,'')CreatedBy,ISNULL(CreatedDate,'')CreatedDate,ISNULL(LastModifiedBy,'')LastModifiedBy,
		ISNULL(LastModifiedDate,'')LastModifiedDate,ISNULL(IsActive,0)IsActive,ISNULL(IsDeleted,0)IsDeleted
		FROM LOV_MASTER where Lov_Column =@Lov_Column  AND Lov_Column != Lov_Code
	end
	else if(@Flag = 'LDE') --bind Lov details Edit data
	begin
		select ISNULL(Lov_Column,'')Lov_Column,ISNULL(Lov_Code,'')Lov_Code,ISNULL(Lov_Desc,'')Lov_Desc,ISNULL(Display_Text,'')Display_Text,ISNULL(IsActive,0)IsActive,
		ISNULL(DisplayOrder,0)DisplayOrder,0 As MaxDisplay_Seq_No ,ISNULL(CreatedBy,'')CreatedBy,ISNULL(LastModifiedBy,'')LastModifiedBy,ISNULL(LastModifiedBy,'')LastModifiedBy,
		ISNULL(LastModifiedDate,'')LastModifiedDate,ISNULL(IsActive,0)IsActive,ISNULL(IsDeleted,0)IsDeleted 
		FROM LOV_MASTER where Lov_Column =@Lov_Column and Lov_Code =@Lov_Code
	end
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Lov_Save]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[SP_Lov_Save]
	-- Add the parameters for the stored procedure here
	@Lov_Column varchar(30)='',
	@Display_Text varchar(50)='',
	@Operated_By bigint=0,
	@Action   varchar(10)='',          
	@Response   varchar(100) out 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @Response = 'E|' + 'Contact system administrator|0';

    IF(@Action = 'INSERT')
	begin

		IF EXISTS(SELECT 1 FROM LOV_MASTER WITH(NOLOCK) WHERE Upper(trim([Lov_Column])) = Upper(trim(@Lov_Column)))
		BEGIN
			SET @Response =  'E|' + 'Column name is already exists|0';
		END
		ELSE
		BEGIN
				insert into LOV_MASTER([Lov_Column],[Display_Text],[Lov_Code],[Lov_Desc],[IsActive], [IsDeleted], [CreatedBy], [CreatedDate],LastModifiedBy)          
				values(trim(@Lov_Column),trim(@Display_Text),trim(@Lov_Column),trim(@Lov_Column), 1, 0, @Operated_By, getdate() , @Operated_By)

				SET @Response =  'S|' + 'Record saved successfully|0' ;
		END
	end
	else IF(@Action = 'UPDATE')
	--IF EXISTS(SELECT 1 FROM Lov_Master WITH(NOLOCK) WHERE Upper(trim([Lov_Column])) = Upper(trim(@Lov_Column)))
	--	BEGIN
	--		SET @response =  'E|' + 'Lov Column is already exists|0';
	--	END
	--	ELSE
	begin 
		update LOV_MASTER set Display_Text = trim(@Display_Text), IsActive = 1, LastModifiedBy = @Operated_By, LastModifiedDate = getdate()
				where  Lov_Column = @Lov_Column
		
		SET @response =  'S|' + 'Record updated successfully|0'
	end
	

     --Insert statements for procedure here
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LovDtl_Delete]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LovDtl_Delete]
	-- Add the parameters for the stored procedure here
	@Lov_Column varchar(30),
	@Lov_Code varchar(50)=null,	
	@Operated_By BIGINT = NULL,
	@response varchar(100) out
AS
BEGIN
declare @count int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SET @response =  'E|' + 'You can not delete the record|0';


	--update LOV_MASTER set IsActive = 0, [IsDeleted] = 1, LastModifiedBy = @Operated_By, LastModifiedDate = getdate() where Lov_Column = @Lov_Column and Lov_Code =@Lov_Code
	-- First log or update audit (optional)
UPDATE LOV_MASTER
SET LastModifiedBy = @Operated_By,
    LastModifiedDate = GETDATE()
WHERE Lov_Column = @Lov_Column
  AND Lov_Code = @Lov_Code;

-- Then permanently delete
DELETE FROM LOV_MASTER WHERE Lov_Column = @Lov_Column
  AND (@Lov_Code IS NULL OR Lov_Code = @Lov_Code);
--WHERE Lov_Column = @Lov_Column
--  AND Lov_Code = @Lov_Code;

	SET @response = 'S|' + 'Record deleted successfully|0';

    
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LovDtl_Save]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LovDtl_Save]
	-- Add the parameters for the stored procedure here
	@Lov_Column varchar(30)='',
	@Display_Text varchar(50)='',
	@Lov_Code varchar(50)='',
	@Lov_Desc varchar(50)='',
	@DisplayOrder int =0,
	@IsActive bit = 0,
	@Operated_By varchar(20)='',
	@Action   varchar(20)='',          
	@response   varchar(100) out 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @response = 'E|' + 'Contact system administrator|0';

    IF(@Action = 'INSERT')
	begin

		-- DELETE DEFAULT RECORD GENERATED AT TIME OF ADD LOV COLUMN MASTER REC
		

		IF EXISTS(SELECT 1 FROM LOV_MASTER WITH(NOLOCK) WHERE Upper(trim([Lov_Column])) = Upper(trim(@Lov_Column)) and Upper(trim([Lov_Desc])) = Upper(trim(@Lov_Desc)) and IsDeleted = 0)
		BEGIN
			SET @response =  'E|' + 'Description is already exists|0';
		END
		ELSE
		BEGIN
				DELETE FROM LOV_MASTER WHERE Upper(trim([Lov_Column])) = Upper(trim(@Lov_Column)) AND Lov_Column = Lov_Code
				declare @count int
				declare @codename varchar(30)
				select @count = COUNT(*) + 1 from LOV_MASTER where Lov_Column = @Lov_Column
				set @codename = convert(varchar,@count)

				insert into LOV_MASTER([Lov_Column],[Display_Text],[Lov_Code],[Lov_Desc],[DisplayOrder],[IsActive], [IsDeleted], [CreatedBy], [CreatedDate])          
				values(trim(@Lov_Column),trim(@Display_Text),trim(@codename),trim(@Lov_Desc),@DisplayOrder, 1, 0, @Operated_By, getdate())

				SET @response =  'S|' + 'Record saved successfully|0' ;
		END
	end
	else IF(@Action = 'UPDATE')
	begin 
	IF EXISTS(SELECT 1 FROM LOV_MASTER WITH(NOLOCK) WHERE Upper(trim([Lov_Column])) = Upper(trim(@Lov_Column)) and Upper(trim([Lov_Desc])) = Upper(trim(@Lov_Desc)) and Lov_Code != @Lov_Code and IsDeleted = 0)
		BEGIN
			SET @response =  'E|' + 'Description is already exists|0';
		END
		else
		BEGIN
		update LOV_MASTER set Lov_Desc=@Lov_Desc,DisplayOrder =@DisplayOrder, 
		IsActive = @IsActive, LastModifiedBy = @Operated_By, LastModifiedDate = getdate()
				where  Lov_Column = @Lov_Column and Lov_Code=@Lov_Code
		
		SET @response =  'S|' + 'Record updated successfully|0' ;
		END
	end
	
     --Insert statements for procedure here
	
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Love_Combo]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Love_Combo]
(
@LOV_Column varchar(max)=null
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT LOV_Code as Code,LOV_Desc as [Name] FROM [dbo].[LOV_MASTER] WHERE LTRIM(RTRIM(LOV_Column)) = LTRIM(RTRIM(@LOV_Column));
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Menu_Delete]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Menu_Delete]
     @Id BIGINT
    ,@Operated_By BIGINT = NULL
    ,@Response VARCHAR(200) OUT
AS
BEGIN
    BEGIN TRY

        UPDATE Menu
        SET 
             IsActive = 0
            ,IsDeleted = 1
            ,LastModifiedBy = @Operated_By
        WHERE Id = @Id AND IsActive = 1;

        IF @@ROWCOUNT > 0
            SET @Response = 'S|Record deleted successfully';
        ELSE
            SET @Response = 'E|Menu ID not found';

    END TRY
    BEGIN CATCH
        SET @Response = 'E|' + ERROR_MESSAGE();
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Menu_Get]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Menu_Get]
    @Id BIGINT = NULL
AS
BEGIN
    IF @Id > 0
        SELECT *
        FROM Menu
        WHERE Id = @Id AND IsActive = 1;
    ELSE
        SELECT *
        FROM Menu
        WHERE IsActive = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Menu_Save]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Menu_Save]
     @Id BIGINT = NULL
    ,@ParentId BIGINT = NULL
    ,@Area NVARCHAR(MAX) = NULL
    ,@Controller NVARCHAR(MAX) = NULL
    ,@Url NVARCHAR(MAX) = NULL
    ,@Name NVARCHAR(MAX) = NULL
    ,@Icon NVARCHAR(MAX) = NULL
    ,@DisplayOrder INT = NULL
    ,@IsSuperAdmin BIT = NULL
    ,@IsAdmin BIT = NULL
    ,@Operated_By BIGINT = NULL
    ,@Action VARCHAR(10) = NULL
    ,@response NVARCHAR(MAX) OUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @response = 'E|Opps!... Something went wrong. Please contact system administrator|0';

    -- ParentId Validation
    IF @ParentId IS NULL OR @ParentId < 0
    BEGIN
        SET @response = 'E|Invalid ParentId|0';
        RETURN;
    END

    -- Duplicate Validation (Name + Parent)
    IF @Action = 'INSERT'
    BEGIN
        IF EXISTS (
            SELECT 1 FROM Menu
            WHERE UPPER(TRIM(Name)) = UPPER(TRIM(@Name))
            AND ParentId = @ParentId
            AND IsDeleted = 0
        )
        BEGIN
            SET @response = 'E|This Menu already exists|0';
            RETURN;
        END

        INSERT INTO Menu
        (
            ParentId, Area, Controller, Url, Name, Icon,
            DisplayOrder, CreatedBy, CreatedDate,
            IsSuperAdmin, IsAdmin, IsActive, IsDeleted
        )
        VALUES
        (
            @ParentId, @Area, @Controller, @Url, @Name, @Icon,
            @DisplayOrder, @Operated_By, GETDATE(),
            @IsSuperAdmin, @IsAdmin, 1, 0
        );

        SET @Id = SCOPE_IDENTITY();
        SET @response = 'S|Record saved successfully|' + CONVERT(NVARCHAR(MAX), @Id);
    END

    IF @Action = 'UPDATE'
    BEGIN
        IF EXISTS (
            SELECT 1 FROM Menu
            WHERE Id != @Id
            AND UPPER(TRIM(Name)) = UPPER(TRIM(@Name))
            AND ParentId = @ParentId
            AND IsDeleted = 0
        )
        BEGIN
            SET @response = 'E|This Menu already exists|0';
            RETURN;
        END

        UPDATE Menu SET
             ParentId = @ParentId
            ,Area = @Area
            ,Controller = @Controller
            ,Url = @Url
            ,Name = @Name
            ,Icon = @Icon
            ,DisplayOrder = @DisplayOrder
            ,IsSuperAdmin = @IsSuperAdmin
            ,IsAdmin = @IsAdmin
            ,LastModifiedBy = @Operated_By
            ,LastModifiedDate = GETDATE()
        WHERE Id = @Id;

        SET @response = 'S|Record updated successfully|' + CONVERT(NVARCHAR(MAX), @Id);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_MenuAccess]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[sp_MenuAccess]
    @userId BIGINT = NULL
AS
BEGIN
    SET NOCOUNT ON;
SELECT 
    m.Id,
    m.ParentId,
    p.Name AS ParentMenuName,
    m.Area,
    m.Controller,
    m.Url,
    m.Name,
    m.Icon,
    m.DisplayOrder,
    m.IsSuperAdmin,
    m.IsAdmin,
    m.IsActive,
    m.IsDeleted
FROM dbo.Menu m
LEFT JOIN dbo.Menu p ON m.ParentId = p.Id
WHERE 
(
    -- Original selected menus
    m.Id IN (
        SELECT MenuId 
        FROM RoleMenuAccess 
        WHERE RoleId IN (
            SELECT RoleId 
            FROM UserRoleMapping 
            WHERE UserId = @userId 
            AND IsDeleted = 0
        )
    )

    OR

    -- Add parents of selected menus
    m.Id IN (
        SELECT ParentId 
        FROM Menu 
        WHERE Id IN (
            SELECT MenuId 
            FROM RoleMenuAccess 
            WHERE RoleId IN (
                SELECT RoleId 
                FROM UserRoleMapping 
                WHERE UserId = @userId 
                AND IsDeleted = 0
            )
        )
    )
)
AND m.IsDeleted = 0
ORDER BY m.Id;
END


GO
/****** Object:  StoredProcedure [dbo].[SP_MenuPermissino]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SP_MenuPermissino]
	@UserId BIGINT = NULL
AS
BEGIN
    SET NOCOUNT ON;

		SELECT [Id] ,[ParentId] ,(SELECT [NAME] FROM Menu WHERE [ParentId] = [Id]) [ParentMenuName] ,[Area] 
		,[Controller] ,[Url] ,[Name] ,[Icon] ,[DisplayOrder] ,[IsSuperAdmin] ,[IsAdmin] ,[IsActive] ,[IsDeleted] 
		FROM [dbo].[Menu] 
		WHERE ID in (SELECT MenuId FROM RoleMenuAccess 
		WHERE RoleId IN (SELECT RoleId FROM UserRoleMapping 
		WHERE UserId = @UserId and [ISDELETED] = 0)) and [ISDELETED] = 0 order by DisplayOrder;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Role_Delete]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[sp_Role_Delete]
    @RoleId BIGINT,
	@Operated_By [bigint] = NULL,
    @Response VARCHAR(200) OUT
AS
BEGIN
    BEGIN TRY

	      -- DELETE FROM [Roles] WHERE Id = @RoleId;
			 
		--DELETE FROM RoleMenuAccess WHERE RoleId = @RoleId;
		 UPDATE Roles
        SET IsActive = 0,IsDeleted =1,[LastModifiedBy] = @Operated_By
        WHERE Id = @RoleId
          AND IsActive = 1;

		UPDATE RoleMenuAccess
        SET IsActive = 0,IsDeleted =1,[LastModifiedBy] = @Operated_By
        WHERE RoleId = @RoleId
          AND IsActive = 1;


        IF @@ROWCOUNT > 0
            SET @Response = 'S|' + 'Record deleted successfully';
        ELSE
            SET @Response = 'E|' + 'Role ID not found';
    END TRY
    BEGIN CATCH
        SET @Response = 'E|' + ERROR_MESSAGE();
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Role_Get]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[sp_Role_Get]
    @role_id BIGINT =NULL
AS
BEGIN
 -- IF @role_id>0
 --  SELECT role_id, role_name, is_active, IsAdmin, DisplayOrder FROM roles WHERE role_id=@role_id and is_active=1;
 --ELSE
 --   SELECT role_id, role_name, is_active, IsAdmin, DisplayOrder FROM roles WHERE  is_active=1;
 	IF @role_id > 0
		BEGIN
		SELECT Id ,[Name] , (SELECT STRING_AGG(MenuId, ',') FROM RoleMenuAccess WHERE RoleId = @role_id) SelectedMenu ,IsActive  ,[IsAdmin]
		FROM [dbo].[Roles]
		WHERE id = @role_id; 
		END
	ELSE 
		BEGIN
		--SELECT role_id ,role_name , '' Menus, [DisplayOrder] , is_active ,IsAdmin
		--SELECT Id ,[Name] , (SELECT STRING_AGG(MenuId, ',') FROM RoleMenuAccess WHERE RoleId = Id) SelectedMenu , IsActive ,IsAdmin
		--FROM [dbo].[Roles] WHERE IsActive = 1;
				SELECT 
    r.Id,
    r.Name,
    (
        SELECT STRING_AGG(m.Name, ', ')
        FROM RoleMenuAccess rm
        INNER JOIN Menu m ON rm.MenuId = m.Id
        WHERE rm.RoleId = r.Id --AND m.ParentId != 0 
    ) AS SelectedMenu,
    r.IsActive,
    r.IsAdmin
FROM dbo.Roles r
WHERE r.IsActive = 1;
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Role_Save]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Role_Save]
    @RoleId         BIGINT = 0,                    
    @RoleName       VARCHAR(50),
    @IsAdmin        BIT = 0
    ,@Operated_By BIGINT = NULL
	,@Action VARCHAR(10) = NULL
    ,@Response       VARCHAR(200) OUT,
	@SelectedMenu nvarchar(max) = NULL	
AS

BEGIN

	SET NOCOUNT ON;
	declare @USEREMPID varchar(20) = (select [Name] from [Roles] where Id = @RoleId)
	SET @response = 'E|' + 'Contact system administrator|0';
	

	-- UPDATE
	IF @Action = 'UPDATE'
		
		IF EXISTS(SELECT 1 FROM [Roles] WITH(NOLOCK) WHERE  Id !=  @RoleId and UPPER(trim([Name])) = UPPER(trim(@RoleName))AND IsActive = 1)   
		  BEGIN 
	  
		   SET @response =  'E|' + 'Role name already Exists|0';  
	   
		  END		 
		ELSE
		  BEGIN 
			
		   UPDATE [dbo].[Roles]
			   SET [Name] = @RoleName	 
					 
					--,is_active = @Isactive
				   ,IsAdmin=@IsAdmin
				   ,LastModifiedBy = @Operated_By
				   ,LastModifiedDate = GETDATE()
			 WHERE Id =  @RoleId;
			 
			 IF @SelectedMenu IS NOT NULL
			 BEGIN
				 DELETE RoleMenuAccess WHERE RoleId =  @RoleId;
						--AND MenuId IN (SELECT value FROM STRING_SPLIT(@SelectedMenu, ','));
				INSERT INTO RoleMenuAccess (RoleId, MenuId, LastModifiedDate,IsActive,IsRead, IsCreate, IsUpdate, IsDelete,IsDeleted,CreatedBy)
				SELECT  @RoleId, value, GETDATE(),1,1,1,1,1,0,@Operated_By
				FROM STRING_SPLIT(@SelectedMenu, ',')WHERE NOT EXISTS (
					SELECT 1 
					FROM RoleMenuAccess 
					WHERE RoleId =  @RoleId AND MenuId = value);
			 END
			

			 SET @response = 'S|' + 'Record updated successfully|'+CONVERT(VARCHAR(MAX),  @RoleId);
	   
		  END
		 

  -- INSERT
	IF @Action = 'INSERT'
	IF EXISTS (
    SELECT 1
    FROM [Roles] WITH (NOLOCK)
    WHERE UPPER(TRIM([Name])) = UPPER(TRIM(@RoleName))
      AND IsActive = 1) 
		  BEGIN 
	  
		   SET @response =  'E|' + 'Role name already Exists|0';  
	   
		  END
    ELSE
		  BEGIN 
			INSERT INTO [dbo].[Roles]
			   ([Name]
			   ,IsAdmin
			   ,IsActive
			   
			   ,CreatedBy
			   ,CreatedDate,IsDeleted)
		 VALUES
			   (@RoleName,
			  @IsAdmin,
			   1,
			   @Operated_By, GETDATE(),0)
			   DECLARE @user_SR_NO int=(select SCOPE_IDENTITY())		   

			IF @SelectedMenu IS NOT NULL
			 BEGIN 
				INSERT INTO RoleMenuAccess (RoleId, MenuId,CreatedBy,CreatedDate,IsActive,IsRead, IsCreate, IsUpdate, IsDelete,IsDeleted)
				SELECT @user_SR_NO, TRY_CAST(value AS BIGINT), @Operated_By, GETDATE(),1,1,1,1,1,0
				FROM STRING_SPLIT(@SelectedMenu, ',');
			 END

			SET @response =  'S|' + 'Record saved successfully|'+CONVERT(VARCHAR(MAX), @user_SR_NO); 
		  END
			
		--END
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RolesList]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RolesList]
AS
BEGIN
    SELECT 
        Id AS Id,
        [Name] AS [Name]
    FROM Roles
    WHERE IsActive = 1 AND IsDeleted = 0
    ORDER BY [Name];
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Delete]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_User_Delete]
    @UserId BIGINT,
	@Operated_By [bigint] = NULL,
    @Response VARCHAR(200) OUT
AS
BEGIN
    BEGIN TRY
         UPDATE Users
        SET IsActive = 0,IsDeleted =1,[LastModifiedBy] = @Operated_By
        WHERE Id = @UserId
          AND IsActive = 1;

        IF @@ROWCOUNT > 0
            SET @Response = 'S|' + 'Record deleted successfully';
        ELSE
            SET @Response = 'E|' + 'User ID not found';
    END TRY
    BEGIN CATCH
        SET @Response = 'E|' + ERROR_MESSAGE();
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_User_Save]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_User_Save]
    @UserId BIGINT = 0,
    @username VARCHAR(50),
    @password_hash VARCHAR(255),    
    @Mobile_No VARCHAR(10) = NULL,
	@Email_id VARCHAR(max),
    @Operated_By BIGINT = null,
	@Operated_RoleId [bigint] = NULL,
	@Action VARCHAR(10) = NULL,
	@Response VARCHAR(200) OUT
AS
BEGIN

	SET NOCOUNT ON;

	SET @response = 'E|' + 'Opps!... Something went wrong. Please contact system administrator|0';
				IF NOT EXISTS (SELECT 1 FROM Roles WHERE @Operated_RoleId = Id AND IsDeleted = 0)
    BEGIN
        SET @response = 'E|Invalid RoleId. RoleId does not exist|0';
        RETURN;
    END

	
		--INSERT
		IF @Action = 'INSERT'
		  BEGIN
		   IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE UPPER(TRIM([UserName])) = UPPER(TRIM(@UserName)) and IsActive = 1)
				BEGIN SET @response =  'E|' + 'Username is already exists|0'; END
			else IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE UPPER(TRIM([Email])) = UPPER(TRIM(@Email_id)) and IsActive = 1)
				BEGIN SET @response =  'E|' + 'Email is already exists|0'; END
			ELSE
			BEGIN
				INSERT INTO [Users]( username, [Password], MobileNumber,Email, IsActive, CreatedDate,IsDeleted,CreatedBy)
			        VALUES (
                          @username, @password_hash, @Mobile_No,@Email_id, 1, GETDATE(),0,@Operated_By
                          );
 
				SET @UserId = SCOPE_IDENTITY();


				INSERT INTO UserRoleMapping (UserId, RoleId, CreatedDate,IsDeleted,IsActive,CreatedBy) 
				VALUES(@UserId, @Operated_RoleId, GETDATE(),0,1,@Operated_By)
				SET @response =  'S|' + 'Record saved successfully|' + CONVERT(NVARCHAR(MAX), @UserId);
			END
		  END
 
		  	IF @Action = 'UPDATE'
		  BEGIN
		   IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE UPPER(TRIM([UserName])) = UPPER(TRIM(@UserName)) AND [Id] != @UserId and IsDeleted = 0)
				BEGIN SET @response =  'E|' + 'Username is already exists|0'; END
			else IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE UPPER(TRIM([Email])) = UPPER(TRIM(@Email_id)) AND [Id] != @UserId and IsDeleted = 0)
				BEGIN SET @response =  'E|' + 'Email is already exists|0'; END
			ELSE
			BEGIN
				UPDATE [dbo].[Users] SET 
				username=@username , 
		--		[Password]=@password_hash, 
				MobileNumber=@Mobile_No,
				Email=@Email_id, 
				LastModifiedBy = @Operated_By,
				LastModifiedDate = GETDATE()
				WHERE Id= @UserId;
				UPDATE UserRoleMapping SET UserId = @UserId,LastModifiedBy=@Operated_By , RoleId = @Operated_RoleId, LastModifiedDate = GETDATE() WHERE [UserId]= @UserId;

				SET @response =  'S|' + 'Record saved successfully|' + CONVERT(NVARCHAR(MAX), @UserId);
			END
		  END			
END


GO
/****** Object:  StoredProcedure [dbo].[SP_UserMenuAccess_Delete]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UserMenuAccess_Delete]
	-- Add the parameters for the stored procedure here
	@UserId BIGINT = 0,
	@RoleId BIGINT = 0,
	@MenuId BIGINT = 0,
	--@Operated_By [bigint] = NULL,
	@response varchar(200) out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF (@UserId > 0 AND @RoleId > 0)
	BEGIN
		  UPDATE [dbo].[UserMenuAccess]
			   SET IsDeleted = 1
				 --  ,[LastModifiedBy] = @Operated_By
				   ,LastModifiedDate = GETDATE()
			 WHERE UserId = @UserId AND RoleId = @RoleId AND MenuId = @MenuId;			  
			 SET @response = 'S|' + 'Record deleted successfully';
	END 

END
GO
/****** Object:  StoredProcedure [dbo].[SP_UserMenuAccess_GET]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UserMenuAccess_GET]
	@UserId BIGINT = 0,
	@RoleId BIGINT = 0,
	@MenuId BIGINT = 0
AS
BEGIN

	SET NOCOUNT ON;

	IF @UserId > 0 AND @RoleId > 0
	
		SELECT [UserId] ,[RoleId] ,[MenuId], NULL PARENT_MENU
		,(SELECT [NAME] FROM MENU WHERE ID = [UserMenuAccess].[MenuId]) MENU_NAME, [IsRead] ,[IsCreate] ,[IsUpdate] ,[IsDelete] ,[IsActive] ,[IsDeleted]
		FROM [dbo].[UserMenuAccess]
		WHERE [UserId] = @UserId AND [RoleId] = @RoleId;

	ELSE IF @UserId = 0 AND @RoleId = 0

		SELECT [UserId] ,[RoleId] ,[MenuId], NULL PARENT_MENU
		,(SELECT [NAME] FROM MENU WHERE ID = [UserMenuAccess].[MenuId]) MENU_NAME,[IsRead] ,[IsCreate] ,[IsUpdate] ,[IsDelete] ,[IsActive] ,[IsDeleted]
		FROM [dbo].[UserMenuAccess];
		
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UserMenuAccess_Save]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UserMenuAccess_Save]
	-- Add the parameters for the stored procedure here		
	@UserId bigint = 0,	
	@RoleId bigint = 0,	
	@MenuId bigint = 0,    
	@IsRead bigint = 0,   
	@IsCreate bigint = 0,   
	@IsUpdate bigint = 0,   
	@IsDelete bigint = 0,  
	@IsActive bigint = 0,
	@Operated_By bigint = NULL,
	@response varchar(200) out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--declare @USEREMPID varchar(20) = (select Name from [Roles] where Id = @Id)
	SET @response = 'E|' + 'Contact system administrator|0';
	

	IF (@UserId > 0 AND @RoleId > 0)
		
		--IF EXISTS(SELECT 1 FROM [Roles] WITH(NOLOCK) WHERE  Id != @Id and UPPER(trim(Name)) = UPPER(trim(@Name)))   
		--  BEGIN 
	  
		--   SET @response =  'E|' + 'Record already Exists|0';  
	   
		--  END		 
		--ELSE
		  BEGIN 
			
		   UPDATE [dbo].[UserMenuAccess]
			   SET UserId = @UserId	 
					,RoleId = @RoleId	
					,MenuId = @MenuId	
					,IsRead = @IsRead
					,IsCreate = @IsCreate	
					,IsUpdate = @IsUpdate
					,IsDelete = @IsDelete		 
					,[IsActive] = @IsActive
				   ,LastModifiedBy = @Operated_By
				   ,LastModifiedDate = GETDATE()
			 WHERE UserId = @UserId AND RoleId = @RoleId;

			 SET @response = 'S|' + 'Record updated successfully';
	   
		  END
		 

	ELSE IF (@UserId = 0 AND @RoleId = 0)
		  
		  BEGIN 
			INSERT INTO [dbo].[UserMenuAccess]
			   (UserId,RoleId,MenuId,IsRead,IsCreate,IsUpdate
			   ,IsDelete,IsActive,IsDeleted,CreatedBy,CreatedDate)
		 VALUES
			   (@UserId,@RoleId,@MenuId,@IsRead,@IsCreate,@IsUpdate,
			   @IsDelete,@IsActive,0,
			   @Operated_By, GETDATE())
			   --DECLARE @user_SR_NO int=(select SCOPE_IDENTITY())

			SET @response =  'S|' + 'Record saved successfully'; 
		  END
			
		--END
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UserRoleMapping_GET]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UserRoleMapping_GET]
	@Id nvarchar(max) = NULL
AS
BEGIN

	SET NOCOUNT ON;

	IF @Id IS NOT NULL AND @Id > 0

	SELECT [Id],[UserId], (SELECT UserName FROM USERS WHERE ID = [UserRoleMapping].[UserId]) AS UserName
	, [RoleId], (SELECT [Name] FROM ROLES WHERE ID = [UserRoleMapping].[RoleId]) AS RoleName, [IsActive]
	,[IsDeleted] FROM [dbo].[UserRoleMapping] WHERE [RoleId] = @Id;
	ELSE IF @Id = 0
	SELECT [Id],[UserId], (SELECT UserName FROM USERS WHERE ID = [UserRoleMapping].[UserId]) AS UserName
	, [RoleId], (SELECT [Name] FROM ROLES WHERE ID = [UserRoleMapping].[RoleId]) AS RoleName, [IsActive]
	,[IsDeleted] FROM [dbo].[UserRoleMapping] WHERE [IsDeleted] = 0;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Users_Get]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_Users_Get]
    @user_id BIGINT=null
AS
BEGIN
  	IF @user_id > 0

     BEGIN
        SELECT  
            u.Id,
            ur.RoleId,
            r.[Name] AS Rolename,     
            u.UserName,
            u.[Password],
            u.MobileNumber,
            u.IsActive,
            u.Email
        FROM Users u
        LEFT JOIN UserRoleMapping ur 
            ON ur.UserId = u.Id 
           --AND ur.IsActive = 1 
           --AND ur.IsDeleted = 0
        LEFT JOIN Roles r 
            ON r.Id = ur.RoleId 
           --AND r.IsActive = 1 
           --AND r.IsDeleted = 0
        WHERE u.Id = @user_id 
          AND u.IsActive = 1;
    END
    ELSE
    BEGIN
        SELECT  
            u.Id,
            ur.RoleId,
            r.[Name] AS RoleName,    
            u.UserName,
            u.[Password],
            u.MobileNumber,
            u.IsActive,
            u.Email
        FROM Users u
        INNER JOIN UserRoleMapping ur 
            ON ur.UserId = u.Id 
           --AND ur.IsActive = 1 
           --AND ur.IsDeleted = 0
        INNER JOIN Roles r 
            ON r.Id = ur.RoleId 
           --AND r.IsActive = 1 
           --AND r.IsDeleted = 0
        WHERE u.IsActive = 1;
    END
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ErrorLog_Insert]    Script Date: 10/04/2026 6:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_ErrorLog_Insert]
(
    @ApplicationName   VARCHAR(100),
    @ControllerName    VARCHAR(200) = NULL,
    @ErrorMessage      VARCHAR(MAX),
    @ErrorType         VARCHAR(200) = NULL,
    @StackTrace        VARCHAR(MAX) = NULL,
    @RequestUrl        VARCHAR(500) = NULL,
    @RequestPayload    VARCHAR(MAX) = NULL,
    @UserAgent         VARCHAR(500) = NULL,
    @UserId            BIGINT = NULL,
    @ClientIP          VARCHAR(50) = NULL,
    @CreatedBy         VARCHAR(100) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ErrorLog
    (
        ApplicationName,
        ControllerName,
        ErrorMessage,
        ErrorType,
        StackTrace,
        RequestUrl,
        RequestPayload,
        UserAgent,
        UserId,
        ClientIP,
        CreatedBy ,
		CreatedDate)
    VALUES
    (
        @ApplicationName,
        @ControllerName,
        @ErrorMessage,
        @ErrorType,
        @StackTrace,
        @RequestUrl,
        @RequestPayload,
        @UserAgent,
        @UserId,
        @ClientIP,
        @CreatedBy,
		GETDATE()
    );

    -- Return the newly created ErrorId
    SELECT SCOPE_IDENTITY() AS NewErrorId;
END;
GO
