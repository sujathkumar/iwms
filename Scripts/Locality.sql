USE [IWMS]
GO

/****** Object:  Table [dbo].[Locality]    Script Date: 10/3/2015 10:36:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Locality](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[WardId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Locality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Locality]  WITH CHECK ADD  CONSTRAINT [FK_Locality_Ward] FOREIGN KEY([WardId])
REFERENCES [dbo].[Ward] ([Id])
GO

ALTER TABLE [dbo].[Locality] CHECK CONSTRAINT [FK_Locality_Ward]
GO


