USE [IWMS]
GO

/****** Object:  Table [dbo].[CollectorFrequency]    Script Date: 10/24/2015 1:10:36 PM ******/
DROP TABLE [dbo].[CollectorFrequency]
GO

/****** Object:  Table [dbo].[CollectorFrequency]    Script Date: 10/24/2015 1:10:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollectorFrequency](
	[Id] [uniqueidentifier] NOT NULL,
	[PickupFrequency] [int] NOT NULL,
	[FrequencyType] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[LastUpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CollectorFrequency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

