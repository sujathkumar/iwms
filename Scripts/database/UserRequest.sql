USE [IWMS]
GO

/****** Object:  Table [dbo].[UserRequest]    Script Date: 10/24/2015 1:12:26 PM ******/
DROP TABLE [dbo].[UserRequest]
GO

/****** Object:  Table [dbo].[UserRequest]    Script Date: 10/24/2015 1:12:26 PM ******/
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
	[UserAddress] [nvarchar](250) NOT NULL,
	[Quantity] [int] NOT NULL,
	[DonateGarbage] [bit] NOT NULL,
 CONSTRAINT [PK_UserRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

