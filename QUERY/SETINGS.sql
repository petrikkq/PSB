--янгдюмхе рюакхжш SETINGS
--ID - смхйюкэмши хдемрхтхйюрнп;
--ZHURNAL_ID - бмеьмхи йкчв хг рюакхжш ZHURNAL;
--CPU - нцпюмхвемхе хяонкэгнбюмхъ жо(мю ндмс яеяяхч онкэгнбюрекъ);
--CPU_FOR_ALL_SESSIONS - нцпюмхвемхе хяонкэгнбюмхъ жо(мю бяе яеяяхх онкэгнбюрекъ);
--RAM - нцпюмхвемхе хяонкэгнбюмхъ но(мю ндмс яеяяхч онкэгнбюрекъ);
--RAM_FOR_ALL_SESSIONS - нцпюмхвемхе хяонкэгнбюмхъ но(мю бяе яеяяхх онкэгнбюрекъ);
--LOGICAL_READS - нцпюмхвемхе мю йнкхвеярбн кнцхвеяйху времхи(мю ндмс яеяяхч онкэгнбюрекъ);
--LOGICAL_READS_FOR_ALL_SESSIONS - нцпюмхвемхе мю йнкхвеярбн кнцхвеяйху времхи(мю бяе яеяяхх онкэгнбюрекъ).
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
