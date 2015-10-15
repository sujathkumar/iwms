USE [IWMS]
GO

/****** Object:  Table [dbo].[CollectorSlot]    Script Date: 10/15/2015 8:17:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollectorSlot](
	[Id] [uniqueidentifier] NOT NULL,
	[SlotFrom] [datetime] NOT NULL,
	[SlotTo] [datetime] NOT NULL,
	[FrequencyId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO

