
GO

/****** Object:  Table [dbo].[MpSeat]    Script Date: 22-06-2022 19:02:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MpSeat]') AND type in (N'U'))
DROP TABLE [dbo].[MpSeat]
GO

/****** Object:  Table [dbo].[MpSeat]    Script Date: 22-06-2022 19:02:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MpSeat](
	[SeatId] [int] IDENTITY(1,1) NOT NULL,
	[Nationality] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[NoOfSeatPerState] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_mpseat] PRIMARY KEY CLUSTERED 
(
	[SeatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


