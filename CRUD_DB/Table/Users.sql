﻿CREATE TABLE [dbo].[Users]
(
  [Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [Email] NVARCHAR(200) NOT NULL,
  [Password] NVARCHAR(200) NOT NULL,
  CONSTRAINT UK_Users_Email UNIQUE(Email)
)
