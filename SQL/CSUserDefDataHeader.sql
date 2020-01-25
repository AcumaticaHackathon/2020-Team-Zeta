DROP TABLE CSUserDefDataHeader


/****** Object:  Table [dbo].[CSAttribute]    Script Date: 01/25/2020 02:52:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CSUserDefDataHeader](
	[CompanyID]              [int]              NOT NULL,
	[UserDefDataID]          [nvarchar](10)     NOT NULL,
	[Description]            [nvarchar](80)     NOT NULL,
	[tstamp]                 [timestamp]        NOT NULL,
	[CreatedByID]            [uniqueidentifier] NOT NULL,
	[CreatedByScreenID]      [char](8)          NOT NULL,
	[CreatedDateTime]        [datetime]         NOT NULL,
	[LastModifiedByID]       [uniqueidentifier] NOT NULL,
	[LastModifiedByScreenID] [char](8)          NOT NULL,
	[LastModifiedDateTime] [datetime]           NOT NULL,
	[NoteID] [uniqueidentifier]                 NOT NULL,
 CONSTRAINT [CSUserDefDataHeader_PK] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[UserDefDataID] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

GRANT INSERT, UPDATE, SELECT, DELETE ON CSUserDefDataHeader to PUBLIC
GO

-- ---------------------------------------------------------------------------------------------------------------------
DROP TABLE CSUserDefDataDetail


/****** Object:  Table [dbo].[CSUserDefDataDetail]    Script Date: 01/25/2020 02:52:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CSUserDefDataDetail](
	[CompanyID]              [int]              NOT NULL,
	[UserDefDataID]          [nvarchar](10)     NOT NULL,
	[UserDefDataLineID]      [int]              NOT NULL IDENTITY,
	[DataElementName]        [nvarchar](30)     NOT NULL,
	[DataElementType]        [nvarchar](20)     NOT NULL, 
	[ControlType]            [nvarchar] (20)    NOT NULL,
	[SequenceNo]             [int]              NOT NULL,
	[tstamp]                 [timestamp]        NOT NULL,
	[CreatedByID]            [uniqueidentifier] NOT NULL,
	[CreatedByScreenID]      [char](8)          NOT NULL,
	[CreatedDateTime]        [datetime]         NOT NULL,
	[LastModifiedByID]       [uniqueidentifier] NOT NULL,
	[LastModifiedByScreenID] [char](8)          NOT NULL,
	[LastModifiedDateTime] [datetime]           NOT NULL,
	[NoteID] [uniqueidentifier]                 NOT NULL,
 CONSTRAINT [CSUserDefDataDetail_PK] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[UserDefDataID] ASC,
	[UserDefDataLineID] ASC
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
GO

GRANT INSERT, UPDATE, SELECT, DELETE ON CSUserDefDataDetail to PUBLIC
GO


