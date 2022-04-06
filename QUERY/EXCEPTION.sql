--�������� ������� EXCEPTION
--ID - ���������� �������������;
--LOGIN_ID - ������� ���� �� ������� DIC_LOGINS;
--TIME_FROM - ����� ������ �����������;
--TIME_TO - ����� ��������� �����������;
--DATE_FROM - ���� ������ �����������;
--DATE_TO - ���� ��������� �����������;
--EXCEPTION_TYPE - ��� �����������;
--ZHURNAL_ID - ������� ���� �� ������� ZHURNAL;
--PRIORITY1 - ���������.
CREATE TABLE PRACTICE.EXCEPTION
(
	ID INT IDENTITY(1,1),
	LOGIN_ID INT NOT NULL,
	TIME_FROM TIME,
	TIME_TO TIME,
	DATE_FROM DATE,
	DATE_TO DATE,
	EXCEPTION_TYPE VARCHAR(10) NOT NULL,
	ZHURNAL_ID INT,
	PRIORITY1 INT
);

--������� �� ���������� ������ � ������� PRACTICE.EXCEPTION 
CREATE TRIGGER PRACTICE.INSERT_EXCEPTION
ON PRACTICE.EXCEPTION
INSTEAD OF INSERT
AS
BEGIN
--�������� �� ������������ ����� �����������
	IF NOT EXISTS
		(
		SELECT * FROM INSERTED
		WHERE 1=1
		AND ((EXCEPTION_TYPE = 'TIME' AND (TIME_FROM IS NULL OR TIME_TO IS NULL OR DATE_TO IS NOT NULL OR DATE_FROM IS NOT NULL))
		OR (EXCEPTION_TYPE = 'DATE' AND (TIME_FROM IS NOT NULL OR TIME_TO IS NOT NULL OR DATE_TO IS NULL OR DATE_FROM IS NULL))
		OR (EXCEPTION_TYPE = 'EXCLUSIVE' AND (TIME_FROM IS NOT NULL OR TIME_TO IS NOT NULL OR DATE_TO IS NOT NULL OR DATE_FROM IS NOT NULL)))
		)
	BEGIN
--���������� ������ � ������� EXCEPTION
		INSERT INTO PRACTICE.EXCEPTION (LOGIN_ID,TIME_FROM,TIME_TO,DATE_FROM,DATE_TO,EXCEPTION_TYPE,ZHURNAL_ID,PRIORITY1)
		OUTPUT INSERTED.ID,INSERTED.LOGIN_ID,INSERTED.TIME_FROM,INSERTED.TIME_TO,INSERTED.DATE_FROM,INSERTED.DATE_TO,INSERTED.EXCEPTION_TYPE,GETDATE(),'����������' 
--���������� ������ � ������� EXCEPTION_LOG
		INTO PRACTICE.EXCEPTION_LOG (EXCEPTION_ID, LOGIN_ID,TIME_FROM,TIME_TO,DATE_FROM,DATE_TO,EXCEPTION_TYPE,DATE_CHANGE,ACTION1)
		SELECT LOGIN_ID,TIME_FROM,TIME_TO,DATE_FROM,DATE_TO,EXCEPTION_TYPE,ZHURNAL_ID,PRIORITY1  FROM INSERTED
	END
	ELSE 
		RAISERROR ('������! �������� ���� ������', 16,1)
END;
GO

--������� �� ���������� ������ � ������� EXCEPTION
CREATE TRIGGER PRACTICE.UPDATE_EXCEPTION
ON PRACTICE.EXCEPTION
INSTEAD OF UPDATE
AS
BEGIN
--�������� �� ������������ ����� �����������
	IF NOT EXISTS 
		(
			SELECT * FROM INSERTED
			WHERE 1=1
			AND ((EXCEPTION_TYPE = 'TIME' AND (TIME_FROM IS NULL OR TIME_TO IS NULL OR DATE_TO IS NOT NULL OR DATE_FROM IS NOT NULL))
			OR (EXCEPTION_TYPE = 'DATE' AND (TIME_FROM IS NOT NULL OR TIME_TO IS NOT NULL OR DATE_TO IS NULL OR DATE_FROM IS NULL))
			OR (EXCEPTION_TYPE = 'EXCLUSIVE' AND (TIME_FROM IS NOT NULL OR TIME_TO IS NOT NULL OR DATE_TO IS NOT NULL OR DATE_FROM IS NOT NULL)))
		)
	BEGIN
		UPDATE A
		SET 
		LOGIN_ID			= B.LOGIN_ID
		, TIME_FROM			= B.TIME_FROM
		, TIME_TO			= B.TIME_TO
		, DATE_FROM			= B.DATE_FROM
		, DATE_TO			= B.DATE_TO
		, EXCEPTION_TYPE 	= B.EXCEPTION_TYPE 
		FROM PRACTICE.EXCEPTION A 
		JOIN INSERTED B ON A.ID = B.ID 

--���������� ������ � ������� EXCEPTION_LOG
		INSERT INTO PRACTICE.EXCEPTION_LOG (EXCEPTION_ID, LOGIN_ID,TIME_FROM,TIME_TO,DATE_FROM,DATE_TO,EXCEPTION_TYPE,DATE_CHANGE,ACTION1)
		SELECT ID,LOGIN_ID,TIME_FROM,TIME_TO,DATE_FROM,DATE_TO,EXCEPTION_TYPE, GETDATE(),'����������'  FROM INSERTED

--���������� ������ � ������� EXCEPTION_LOG
		INSERT INTO PRACTICE.EXCEPTION_LOG (EXCEPTION_ID, LOGIN_ID,TIME_FROM,TIME_TO,DATE_FROM,DATE_TO,EXCEPTION_TYPE,DATE_CHANGE,ACTION1)
		SELECT ID,LOGIN_ID,TIME_FROM,TIME_TO,DATE_FROM,DATE_TO,EXCEPTION_TYPE, GETDATE(),'��������'  FROM DELETED
	END
	ELSE 
	RAISERROR ('������! �������� ���� ������ (UPDATE)', 16,1)
END;