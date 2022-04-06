--янгдюмхе рюакхжш INFORMATION
--SESSION_ID - мнлеп Cеяяхх;
--LOGICAL_READS - йнкхвеярбн кнцхвеяйху времхи;
--CPU_USAGE - хяонкэгнбюмхе жо;
--LOGIN_ID - бмеьмхи йкчв хг рюакхжш DIC_LOGINS;
--TIME_IN_OPERATION - бпелъ б пюанре;
--ZHURNAL_ID - бмеьмхи йкчв хг рюакхжш ZHURNAL_ID;
--RAM_USAGE - хяонкэгнбюмхе но.
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
