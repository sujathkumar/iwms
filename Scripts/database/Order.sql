USE [IWMS]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 10/25/2015 1:57:01 PM ******/
DROP TABLE [dbo].[Order]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 10/25/2015 1:57:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[Id] [uniqueidentifier] NOT NULL,
	[DateOrdered] [datetime] NOT NULL,
	[DatePrinted] [datetime] NULL,
	[Printed] [bit] NULL,
	[GarbageId] [uniqueidentifier] NOT NULL,
	[GarbageTypeId] [uniqueidentifier] NOT NULL,
	[QRCodeRequired] [bit] NULL,
	[Promotion] [bit] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

