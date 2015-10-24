USE [IWMS]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 10/24/2015 1:09:48 PM ******/
DROP TABLE [dbo].[Address]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 10/24/2015 1:09:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Address](
	[Id] [uniqueidentifier] NOT NULL,
	[HouseNo] [nvarchar](50) NOT NULL,
	[HouseName] [nvarchar](50) NULL,
	[ApartmentName] [nvarchar](50) NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Locality] [nvarchar](50) NOT NULL,
	[WardId] [uniqueidentifier] NOT NULL,
	[Registered] [bit] NOT NULL,
	[PINCODE] [int] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

