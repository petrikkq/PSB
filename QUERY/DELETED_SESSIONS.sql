--�������� ������� DELETED_SESSIONS
--BLOCK_SESSION - ����� ����������� ������;
--BLOCK_LOGIN_ID - ����� ������������ ������������;
--EXCEPTION_TYPE1 - ��� �����������;
--PRIORITY1 - ��������� ������������ ������������;
--SESSION_ID - ����� ����������� ������;
--LOGIN2 - ����� ������������ ������������;
--EXCEPTION_TYPE2 - ��� �����������;
--PRIORITY2 - ��������� ������������ ������������;
--ZHURNAL_ID - ������� ���� �� ������� ZHURNAL;
--ACTION1 - ��������(����������, �������� ��� ���������).
CREATE TABLE PRACTICE.DELETED_SESSIONS
(
	BLOCK_SESSION INT ,
	BLOCK_LOGIN_ID INT ,  
	EXCEPTION_TYPE1 VARCHAR(10), 
	PRIORITY1 INT,
	SESSION_ID INT,
	LOGIN2 INT , 
	EXCEPTION_TYPE2 VARCHAR(10),
	PRIORITY2 INT,
	ZHURNAL_ID INT,
	ACTION1 VARCHAR(50)
); 
