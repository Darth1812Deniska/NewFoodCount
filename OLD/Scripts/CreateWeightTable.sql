CREATE TABLE dbo.FCP_CurUserWeight
	(
		UserID		INT
	  , Weight		FLOAT
	  , AddDateTime DATETIME
	  , CONSTRAINT PK_FCP_CurUserWeight
			PRIMARY KEY ( UserID, AddDateTime )
	  , CONSTRAINT FK_FCP_CurUserWeight_UserID
			FOREIGN KEY ( UserID )
			REFERENCES dbo.FCP_Users ( ID ) ON DELETE CASCADE
	);