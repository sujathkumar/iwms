USE [IWMS]
GO

/****** Object:  Table [dbo].[RecyclerScanInfo]    Script Date: 11/9/2015 5:06:02 PM ******/
DROP TABLE [dbo].[RecyclerScanInfo]
GO

/****** Object:  Table [dbo].[RecyclerScanInfo]    Script Date: 11/9/2015 5:06:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RecyclerScanInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[Tag] [nvarchar](50) NOT NULL,
	[RecyclerId] [uniqueidentifier] NOT NULL,
	[Processed] [bit] NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_RecyclerScanInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

