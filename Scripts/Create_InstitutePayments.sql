-- Create the InstitutePayments Table for Chapa and Local School Revenue Tracking
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InstitutePayments]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[InstitutePayments](
        [PaymentID] [int] IDENTITY(1,1) NOT NULL,
        [InstituteID] [int] NOT NULL,
        [EnrollmentID] [int] NOT NULL,
        [AmountPaid] [smallmoney] NOT NULL,
        [PaymentDate] [datetime] NOT NULL DEFAULT (getdate()),
        [ChapaTransactionRef] [nvarchar](250) NULL,
        [CreatedByUserID] [int] NOT NULL,
     CONSTRAINT [PK_InstitutePayments] PRIMARY KEY CLUSTERED ([PaymentID] ASC)
    );

    ALTER TABLE [dbo].[InstitutePayments]  WITH CHECK ADD  CONSTRAINT [FK_InstitutePayments_DrivingInstitutes] FOREIGN KEY([InstituteID])
    REFERENCES [dbo].[DrivingInstitutes] ([InstituteID]);

    ALTER TABLE [dbo].[InstitutePayments]  WITH CHECK ADD  CONSTRAINT [FK_InstitutePayments_Enrollments] FOREIGN KEY([EnrollmentID])
    REFERENCES [dbo].[Enrollments] ([EnrollmentID]);

    ALTER TABLE [dbo].[InstitutePayments]  WITH CHECK ADD  CONSTRAINT [FK_InstitutePayments_Users] FOREIGN KEY([CreatedByUserID])
    REFERENCES [dbo].[Users] ([UserID]);
END
GO
