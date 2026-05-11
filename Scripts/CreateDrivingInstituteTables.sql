-- ======================================================
-- Driving Institute Module: Training Batches & Attendance
-- ======================================================

-- 0. Create DrivingInstitutes Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DrivingInstitutes]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[DrivingInstitutes](
        [InstituteID] [int] IDENTITY(1,1) NOT NULL,
        [InstituteName] [nvarchar](150) NOT NULL,
        [Address] [nvarchar](500) NULL,
        [Phone] [nvarchar](20) NULL,
        [Email] [nvarchar](100) NULL,
        [CommercialLicenseNumber] [nvarchar](50) NULL,
        [LicenseExpiryDate] [datetime] NULL,
        [Capacity] [int] NULL,
     CONSTRAINT [PK_DrivingInstitutes] PRIMARY KEY CLUSTERED ([InstituteID] ASC)
    );
END
GO

-- 0.1 Create Enrollments Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollments]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Enrollments](
        [EnrollmentID] [int] IDENTITY(1,1) NOT NULL,
        [PersonID] [int] NOT NULL,
        [InstituteID] [int] NOT NULL,
        [EnrollmentDate] [datetime] NOT NULL DEFAULT (getdate()),
        [Status] [int] NOT NULL DEFAULT (1), -- 1: Active, 0: Completed/Inactive
     CONSTRAINT [PK_Enrollments] PRIMARY KEY CLUSTERED ([EnrollmentID] ASC)
    );

    ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_People] FOREIGN KEY([PersonID])
    REFERENCES [dbo].[People] ([PersonID]);

    ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_DrivingInstitutes] FOREIGN KEY([InstituteID])
    REFERENCES [dbo].[DrivingInstitutes] ([InstituteID]);
END
GO

-- 1. Create TrainingBatches Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TrainingBatches]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TrainingBatches](
        [TrainingBatchID] [int] IDENTITY(1,1) NOT NULL,
        [InstituteID] [int] NOT NULL,
        [BatchName] [nvarchar](100) NOT NULL,
        [StartDate] [datetime] NOT NULL,
        [EndDate] [datetime] NOT NULL,
        [MaxCapacity] [int] NOT NULL,
     CONSTRAINT [PK_TrainingBatches] PRIMARY KEY CLUSTERED ([TrainingBatchID] ASC)
    );

    ALTER TABLE [dbo].[TrainingBatches]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBatches_DrivingInstitutes] FOREIGN KEY([InstituteID])
    REFERENCES [dbo].[DrivingInstitutes] ([InstituteID]);
END
GO

-- 2. Create ApplicantBatch Table (Student Assignments)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicantBatch]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ApplicantBatch](
        [AssignmentID] [int] IDENTITY(1,1) NOT NULL,
        [ApplicationID] [int] NOT NULL,
        [TrainingBatchID] [int] NOT NULL,
        [AssignedDate] [datetime] NOT NULL DEFAULT (getdate()),
     CONSTRAINT [PK_ApplicantBatch] PRIMARY KEY CLUSTERED ([AssignmentID] ASC)
    );

    ALTER TABLE [dbo].[ApplicantBatch]  WITH CHECK ADD  CONSTRAINT [FK_ApplicantBatch_Applications] FOREIGN KEY([ApplicationID])
    REFERENCES [dbo].[Applications] ([ApplicationID]);

    ALTER TABLE [dbo].[ApplicantBatch]  WITH CHECK ADD  CONSTRAINT [FK_ApplicantBatch_TrainingBatches] FOREIGN KEY([TrainingBatchID])
    REFERENCES [dbo].[TrainingBatches] ([TrainingBatchID]);
END
GO

-- 4. Create Attendance Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Attendance](
        [AttendanceID] [int] IDENTITY(1,1) NOT NULL,
        [ApplicationID] [int] NOT NULL,
        [TrainingBatchID] [int] NOT NULL,
        [AttendanceDate] [datetime] NOT NULL,
        [IsPresent] [bit] NOT NULL,
        [MarkedByUserID] [int] NOT NULL,
     CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED ([AttendanceID] ASC)
    );

    ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Applications] FOREIGN KEY([ApplicationID])
    REFERENCES [dbo].[Applications] ([ApplicationID]);

    ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_TrainingBatches] FOREIGN KEY([TrainingBatchID])
    REFERENCES [dbo].[TrainingBatches] ([TrainingBatchID]);

    ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Users] FOREIGN KEY([MarkedByUserID])
    REFERENCES [dbo].[Users] ([UserID]);
END
GO

-- 5. Create InstituteAnnouncements Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InstituteAnnouncements]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[InstituteAnnouncements](
        [AnnouncementID] [int] IDENTITY(1,1) NOT NULL,
        [InstituteID] [int] NOT NULL,
        [BatchID] [int] NULL, -- Optional: Specific class or all
        [Title] [nvarchar](150) NOT NULL,
        [Content] [nvarchar](max) NOT NULL,
        [DateCreated] [datetime] NOT NULL DEFAULT (getdate()),
        [CreatedByUserID] [int] NOT NULL,
     CONSTRAINT [PK_InstituteAnnouncements] PRIMARY KEY CLUSTERED ([AnnouncementID] ASC)
    );

    ALTER TABLE [dbo].[InstituteAnnouncements]  WITH CHECK ADD  CONSTRAINT [FK_Announcements_Institutes] FOREIGN KEY([InstituteID])
    REFERENCES [dbo].[DrivingInstitutes] ([InstituteID]);

    ALTER TABLE [dbo].[InstituteAnnouncements]  WITH CHECK ADD  CONSTRAINT [FK_Announcements_Batches] FOREIGN KEY([BatchID])
    REFERENCES [dbo].[TrainingBatches] ([TrainingBatchID]);
END
GO

PRINT 'Driving Institute: All tables including Announcements created successfully.';
