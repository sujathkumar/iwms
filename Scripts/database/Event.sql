USE [IWMS]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 10/24/2015 1:11:27 PM ******/
DROP TABLE [dbo].[Event]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 10/24/2015 1:11:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Event](
	[Id] [uniqueidentifier] NOT NULL,
	[EventName] [nvarchar](50) NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[SpotImageId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

