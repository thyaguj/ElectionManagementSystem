USE [SampleDB]
GO

/****** Object:  Table [dbo].[PartyContestingDetail]    Script Date: 22-06-2022 19:04:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartyContestingDetail]') AND type in (N'U'))
DROP TABLE [dbo].[PartyContestingDetail]
GO

/****** Object:  Table [dbo].[PartyContestingDetail]    Script Date: 22-06-2022 19:04:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PartyContestingDetail](
	[ContestingUId] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](50) NULL,
	[PartyId] [int] NOT NULL,
	[ContestentName] [nvarchar](50) NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](15) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_PartyContestingDetail] PRIMARY KEY CLUSTERED 
(
	[ContestingUId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


