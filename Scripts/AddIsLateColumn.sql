-- ====================================================================
-- T-SQL Script: Add IsLate Column to Attendance Table
-- Purpose: Extend attendance tracking beyond Present/Absent
-- ====================================================================
-- Interpretation:
-- | IsPresent | IsLate | Meaning |
-- |-----------|--------|---------|
-- |     1     |   0    | Present |
-- |     1     |   1    | Late    |
-- |     0     |   0    | Absent  |
-- ====================================================================

USE My_DVLD;
GO

-- Step 1: Add the IsLate column (defaults to 0 = not late)
IF NOT EXISTS (
    SELECT 1
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'Attendance' AND COLUMN_NAME = 'IsLate'
)
BEGIN
    ALTER TABLE Attendance
    ADD IsLate BIT NOT NULL DEFAULT 0;

    PRINT 'Column [IsLate] added to [Attendance] table successfully.';
END
ELSE
BEGIN
    PRINT 'Column [IsLate] already exists in [Attendance] table. No changes made.';
END
GO

-- Step 2: Verify the new schema
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Attendance'
ORDER BY ORDINAL_POSITION;
GO
