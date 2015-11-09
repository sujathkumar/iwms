USE [IWMS]
GO

/****** Object:  Table [dbo].[NonComplaintUsers]    Script Date: 11/9/2015 5:04:57 PM ******/
DROP TABLE [dbo].[NonComplaintUsers]
GO

/****** Object:  Table [dbo].[NonComplaintUsers]    Script Date: 11/9/2015 5:04:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NonComplaintUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[WardId] [uniqueidentifier] NOT NULL,
	[VolunteerId] [uniqueidentifier] NULL,
	[Accepted] [bit] NULL,
	[Processed] [bit] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_NonComplaintUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

