USE [IWMS]
GO

/****** Object:  Table [dbo].[PointConfiguration]    Script Date: 10/25/2015 4:07:52 PM ******/
DROP TABLE [dbo].[PointConfiguration]
GO

/****** Object:  Table [dbo].[PointConfiguration]    Script Date: 10/25/2015 4:07:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PointConfiguration](
	[Id] [uniqueidentifier] NOT NULL,
	[Point] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PointConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

