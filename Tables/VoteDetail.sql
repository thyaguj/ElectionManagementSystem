
GO

ALTER TABLE [dbo].[VoteDetail] DROP CONSTRAINT [FK__VoteDetai__Voter__36B12243]
GO

ALTER TABLE [dbo].[VoteDetail] DROP CONSTRAINT [FK__VoteDetai__SeatI__3A81B327]
GO

ALTER TABLE [dbo].[VoteDetail] DROP CONSTRAINT [FK__VoteDetai__Party__38996AB5]
GO

/****** Object:  Table [dbo].[VoteDetail]    Script Date: 22-06-2022 19:05:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VoteDetail]') AND type in (N'U'))
DROP TABLE [dbo].[VoteDetail]
GO

/****** Object:  Table [dbo].[VoteDetail]    Script Date: 22-06-2022 19:05:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VoteDetail](
	[VotingSystemUId] [int] IDENTITY(1,1) NOT NULL,
	[VoterUId] [int] NULL,
	[PartyId] [int] NULL,
	[IsVoted] [bit] NULL,
	[SeatId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VoteDetail]  WITH CHECK ADD FOREIGN KEY([PartyId])
REFERENCES [dbo].[PartyDetail] ([PartyId])
GO

ALTER TABLE [dbo].[VoteDetail]  WITH CHECK ADD FOREIGN KEY([SeatId])
REFERENCES [dbo].[MpSeat] ([SeatId])
GO

ALTER TABLE [dbo].[VoteDetail]  WITH CHECK ADD FOREIGN KEY([VoterUId])
REFERENCES [dbo].[VoterDetail] ([VoterUId])
GO


