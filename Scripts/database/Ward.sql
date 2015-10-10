USE [IWMS]
GO

/****** Object:  Table [dbo].[Ward]    Script Date: 10/3/2015 10:36:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ward](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ZoneId] [uniqueidentifier] NOT NULL,
	[LeftCordinate] [nvarchar](50) NOT NULL,
	[RightCordinate] [nvarchar](50) NOT NULL,
	[TopCordinate] [nvarchar](50) NOT NULL,
	[BottomCordinate] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ward] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Ward]  WITH CHECK ADD  CONSTRAINT [FK_Ward_Zone] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([Id])
GO

ALTER TABLE [dbo].[Ward] CHECK CONSTRAINT [FK_Ward_Zone]
GO


