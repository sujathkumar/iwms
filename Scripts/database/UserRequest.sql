USE [IWMS]
GO

/****** Object:  Table [dbo].[UserRequest]    Script Date: 10/15/2015 8:17:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRequest](
	[Id] [uniqueidentifier] NOT NULL,
	[RequestNumber] [nvarchar](50) NOT NULL,
	[GarbageTypeId] [uniqueidentifier] NOT NULL,
	[RequestTime] [datetime] NOT NULL,
	[ScheduleTime] [datetime] NOT NULL,
	[GarbageId] [uniqueidentifier] NOT NULL,
	[CollectorId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserAddress] [nvarchar](250) NOT NULL
) ON [PRIMARY]

GO

