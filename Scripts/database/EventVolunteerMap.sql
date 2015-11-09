USE [IWMS]
GO

/****** Object:  Table [dbo].[EventVolunteerMap]    Script Date: 11/9/2015 5:04:32 PM ******/
DROP TABLE [dbo].[EventVolunteerMap]
GO

/****** Object:  Table [dbo].[EventVolunteerMap]    Script Date: 11/9/2015 5:04:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventVolunteerMap](
	[Id] [uniqueidentifier] NOT NULL,
	[EventId] [uniqueidentifier] NOT NULL,
	[VolunteerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EventVolunteerMap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


