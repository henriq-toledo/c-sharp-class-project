USE EMPLOYEES

CREATE TABLE DEVELOPERS(
	[ID] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[NAME] NVARCHAR(80) NOT NULL,
	[COMPANY_NAME] NVARCHAR(80) NOT NULL
)

CREATE TABLE DEVELOPERS_SKILLS(
	DEVELOPER_ID INT FOREIGN KEY REFERENCES DEVELOPERS(ID) NOT NULL,
	SKILL TINYINT NOT NULL,
	PRIMARY KEY(DEVELOPER_ID, SKILL)
)

CREATE TABLE TESTERS(
	[ID] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[NAME] NVARCHAR(80) NOT NULL,
	[COMPANY_NAME] NVARCHAR(80) NOT NULL,
)

CREATE TABLE TESTERS_SKILLS(
	TESTER_ID INT FOREIGN KEY REFERENCES TESTERS(ID) NOT NULL,
	SKILL TINYINT NOT NULL,
	PRIMARY KEY(TESTER_ID, SKILL)
)