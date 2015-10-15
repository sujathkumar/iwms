USE [IWMS]
GO

/****** Object:  Table [dbo].[CollectorFrequency]    Script Date: 10/15/2015 8:15:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollectorFrequency](
	[Id] [uniqueidentifier] NOT NULL,
	[PickupFrequency] [int] NOT NULL,
	[FrequencyType] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[LastUpdateDate] [datetime] NOT NULL
) ON [PRIMARY]

GO


