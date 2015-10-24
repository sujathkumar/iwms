USE [IWMS]
GO

/****** Object:  Table [dbo].[CollectorSlot]    Script Date: 10/24/2015 1:10:52 PM ******/
DROP TABLE [dbo].[CollectorSlot]
GO

/****** Object:  Table [dbo].[CollectorSlot]    Script Date: 10/24/2015 1:10:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CollectorSlot](
	[Id] [uniqueidentifier] NOT NULL,
	[SlotFrom] [nchar](2) NOT NULL,
	[SlotTo] [nchar](2) NOT NULL,
	[FrequencyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CollectorSlot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

