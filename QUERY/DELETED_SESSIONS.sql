--янгдюмхе рюакхжш DELETED_SESSIONS
--BLOCK_SESSION - мнлеп акнйхпсчыеи яеяяхх;
--BLOCK_LOGIN_ID - кнцхм акнйхпсчыецн онкэгнбюрекъ;
--EXCEPTION_TYPE1 - рхо нцпюмхвемхъ;
--PRIORITY1 - опхнпхрер акнйхпсчыецн онкэгнбюрекъ;
--SESSION_ID - мнлеп акнйхпселни яеяяхх;
--LOGIN2 - кнцхм акнйхпселнцн онкэгнбюрекъ;
--EXCEPTION_TYPE2 - рхо нцпюмхвемхъ;
--PRIORITY2 - опхнпхрер акнйхпселнцн онкэгнбюрекъ;
--ZHURNAL_ID - бмеьмхи йкчв хг рюакхжш ZHURNAL;
--ACTION1 - деиярбхе(днаюбкемхе, сдюкемхе хкх хглемемхе).
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
