DELETE FROM tblUsers WHERE userId = 2; -- delete  a row

DBCC CHECKIDENT ('tblUsers', RESEED, 0); -- reset identity column to 1