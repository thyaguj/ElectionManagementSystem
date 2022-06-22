
GO

/****** Object:  Table [dbo].[VoterDetail]    Script Date: 22-06-2022 19:06:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VoterDetail]') AND type in (N'U'))
DROP TABLE [dbo].[VoterDetail]
GO

/****** Object:  Table [dbo].[VoterDetail]    Script Date: 22-06-2022 19:06:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VoterDetail](
	[VoterUId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[VoterId] [varchar](50) NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[Photos] [varchar](50) NULL,
	[IsApprove] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_voterDetail] PRIMARY KEY CLUSTERED 
(
	[VoterUId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


