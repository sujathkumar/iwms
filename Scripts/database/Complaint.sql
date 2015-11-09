USE [IWMS]
GO

/****** Object:  Table [dbo].[Complaint]    Script Date: 11/9/2015 5:04:25 PM ******/
DROP TABLE [dbo].[Complaint]
GO

/****** Object:  Table [dbo].[Complaint]    Script Date: 11/9/2015 5:04:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Complaint](
	[Id] [uniqueidentifier] NOT NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[Description] [ntext] NOT NULL,
	[ReferenceNumber] [int] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Complaint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

