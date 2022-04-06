--янгдюмхе рюакхжш EXCEPTION_LOG
--ID - смхйюкэмши хдемрхтхйюрнп;
--EXCEPTION_ID - бмеьмхи йкчв хг рюакхжш EXCEPTION;
--LOGIN_ID - бмеьмхи йкчв хг рюакхжш DIC_LOGINS;
--TIME_FROM - бпелъ мювюкю нцпюмхвемхъ;
--TIME_TO - бпелъ нйнмвюмхъ нцпюмхвемхъ;
--DATE_FROM - дюрю мювюкю нцпюмхвемхъ;
--DATE_TO - дюрю нйнмвюмхъ нцпюмхвемхъ;
--EXCEPTION_TYPE - рхо нцпюмхвемхъ;
--DATE_CHANGE - дюрю х бпелъ днаюбкемхъ хкх хглемхъ хяйчвемхи;
--ACTION1 - деиярбхе(днаюбкемхе, сдюкемхе хкх хглемемхе).
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
