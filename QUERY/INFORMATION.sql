--�������� ������� INFORMATION
--SESSION_ID - ����� C�����;
--LOGICAL_READS - ���������� ���������� ������;
--CPU_USAGE - ������������� ��;
--LOGIN_ID - ������� ���� �� ������� DIC_LOGINS;
--TIME_IN_OPERATION - ����� � ������;
--ZHURNAL_ID - ������� ���� �� ������� ZHURNAL_ID;
--RAM_USAGE - ������������� ��.
CREATE TABLE PRACTICE.INFORMATION 
(
	SESSION_ID INT,
	LOGICAL_READS INT,
	CPU_USAGE INT,
	LOGIN_ID INT,
	TIME_IN_OPERATION_IN_MINUTES INT,
	ZHURNAL_ID INT,
	RAM_USAGE INT
); 
