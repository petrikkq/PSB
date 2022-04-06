--�������� ������� EXCEPTION_LOG
--ID - ���������� �������������;
--EXCEPTION_ID - ������� ���� �� ������� EXCEPTION;
--LOGIN_ID - ������� ���� �� ������� DIC_LOGINS;
--TIME_FROM - ����� ������ �����������;
--TIME_TO - ����� ��������� �����������;
--DATE_FROM - ���� ������ �����������;
--DATE_TO - ���� ��������� �����������;
--EXCEPTION_TYPE - ��� �����������;
--DATE_CHANGE - ���� � ����� ���������� ��� ������� ���������;
--ACTION1 - ��������(����������, �������� ��� ���������).
CREATE TABLE PRACTICE.EXCEPTION_LOG
(
	ID INT IDENTITY(1,1),
	EXCEPTION_ID INT ,
	LOGIN_ID INT,
	TIME_FROM TIME,
	TIME_TO TIME,
	DATE_FROM DATE,
	DATE_TO DATE,
	EXCEPTION_TYPE VARCHAR(10),
	DATE_CHANGE DATETIME CONSTRAINT DF_PRACTICE_EXCEPTION_LOG_DATE_CHANGE DEFAULT (GETDATE()),
	ACTION1 VARCHAR(10)
);
