-- 1. Create DriverVehicles Table in My_DVLD to track car history
-- This table links Drivers in My_DVLD to the Vehicle catalog in VehicleMakesDB
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DriverVehicles]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[DriverVehicles](
        [OwnershipID] [int] IDENTITY(1,1) NOT NULL,
        [DriverID] [int] NOT NULL,
        [VehicleID] [int] NOT NULL, -- References VehicleMakesDB.dbo.VehicleMasterDetails (ID)
        [PlateNumber] [nvarchar](20) NOT NULL,
        [VIN] [nvarchar](50) NULL,
        [Color] [nvarchar](30) NULL,
        [PurchaseDate] [datetime] NOT NULL DEFAULT GETDATE(),
        [SaleDate] [datetime] NULL, -- NULL means currently owned
        [PurchasePrice] [smallmoney] NULL,
        [Notes] [nvarchar](max) NULL,
        [CreatedByUserID] [int] NOT NULL,
     CONSTRAINT [PK_DriverVehicles] PRIMARY KEY CLUSTERED ([OwnershipID] ASC)
    );

    ALTER TABLE [dbo].[DriverVehicles]  WITH CHECK ADD  CONSTRAINT [FK_DriverVehicles_Drivers] FOREIGN KEY([DriverID])
    REFERENCES [dbo].[Drivers] ([DriverID]);

    ALTER TABLE [dbo].[DriverVehicles]  WITH CHECK ADD  CONSTRAINT [FK_DriverVehicles_Users] FOREIGN KEY([CreatedByUserID])
    REFERENCES [dbo].[Users] ([UserID]);
END
ELSE
BEGIN
    -- If table exists, ensure VIN and Color columns are present
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[DriverVehicles]') AND name = 'VIN')
    BEGIN
        ALTER TABLE [dbo].[DriverVehicles] ADD [VIN] [nvarchar](50) NULL;
    END

    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[DriverVehicles]') AND name = 'Color')
    BEGIN
        ALTER TABLE [dbo].[DriverVehicles] ADD [Color] [nvarchar](30) NULL;
    END
END
GO
