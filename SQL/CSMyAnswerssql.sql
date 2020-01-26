USE [Hackathon]
GO

/****** Object:  Table [dbo].[CSAnswers]    Script Date: 1/25/2020 10:24:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE CSMyAnswers
GO

CREATE TABLE [dbo].[CSMyAnswers](
	[CompanyID]           [int]              NOT NULL,
	[UserDefDataID]       [int]              NOT NULL,
	[UserDefDataLineID]   [int]              NOT NULL,
	[UserResponseID]	  [int]				 NOT NULL,
	[Value]               [nvarchar](255)    NULL
 CONSTRAINT [CSMyAnswers_PK] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[UserDefDataID] ASC,
	[UserDefDataLineID] ASC,
	[UserResponseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

GRANT INSERT,UPDATE,SELECT,DELETE ON CSMyAnswers TO PUBLIC
GO


