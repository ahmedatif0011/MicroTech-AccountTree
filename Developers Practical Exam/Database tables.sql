CREATE TABLE [dbo].[Accounts](
	[Acc_Number] [nchar](10) NOT NULL,
	[ACC_Parent] [nchar](10) NULL,
	[Balance] [decimal](20, 9) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Acc_Number] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Accounts] FOREIGN KEY([ACC_Parent])
REFERENCES [dbo].[Accounts] ([Acc_Number])
GO

ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Accounts]
GO
Insert Into [dbo].[Accounts] values('01', NULL, NULL)
Insert Into [dbo].[Accounts] values('02', '01', 100.0)
Insert Into [dbo].[Accounts] values('03', '01', 0.0)
Insert Into [dbo].[Accounts] values('04', '03', 100.0)
Insert Into [dbo].[Accounts] values('05', NULL, NULL)
Insert Into [dbo].[Accounts] values('06', '05',130.0)
Insert Into [dbo].[Accounts] values('07', '05', 0.0)
Insert Into [dbo].[Accounts] values('08', '07', 0.0)
Insert Into [dbo].[Accounts] values('09', '08', 100.0)
Insert Into [dbo].[Accounts] values('10', NULL, NULL)
Insert Into [dbo].[Accounts] values('11', '10', 100.0)
Insert Into [dbo].[Accounts] values('12', '10', 0.0)
Insert Into [dbo].[Accounts] values('13', '12', 100.0)
