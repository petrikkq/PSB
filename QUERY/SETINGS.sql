--�������� ������� SETINGS
--ID - ���������� �������������;
--ZHURNAL_ID - ������� ���� �� ������� ZHURNAL;
--CPU - ����������� ������������� ��(�� ���� ������ ������������);
--CPU_FOR_ALL_SESSIONS - ����������� ������������� ��(�� ��� ������ ������������);
--RAM - ����������� ������������� ��(�� ���� ������ ������������);
--RAM_FOR_ALL_SESSIONS - ����������� ������������� ��(�� ��� ������ ������������);
--LOGICAL_READS - ����������� �� ���������� ���������� ������(�� ���� ������ ������������);
--LOGICAL_READS_FOR_ALL_SESSIONS - ����������� �� ���������� ���������� ������(�� ��� ������ ������������).
CREATE TABLE PRACTICE.SETINGS
(
	ID INT IDENTITY(1,1),
	ZHURNAL_ID INT,
	CPU INT,
	CPU_FOR_ALL_SESSIONS INT,
	RAM INT,
	RAM_FOR_ALL_SESSIONS INT,
	LOGICAL_READS INT,
	LOGICAL_READS_FOR_ALL_SESSIONS INT
); 
