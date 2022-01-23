# Common-Names-Hadassim

משימה -1 
 מימוש המשימה נעשה בשפת התיכנות 
C#
סביבת העבודה
visual studio 
סוג הפרויקט הוא
console application
יש להוריד את הפרויקט ולהריץ את קובץ ה
ReadFrmoFile.exe
הנמצא כאן בתוך התיקיות 
ReadFrmoFile/bin/Debug/ReadFrmoFile.exe
 
 רעיון התרגיל
 בכדי לפתור את התרגיל בצורה האופטימלית (זמן ריצה אופטימאלי) ממשתי את הפתרון של קבוצות זרות

DisjoinSet:
הוא מבנה נתונים אשר מבצע מעקב 
אחרי קבוצה של עצמים המחולקים למספר של תתי-קבוצות זרות ולא חופפות
אלגוריתם איחוד , חיפוש - Algorithm Find , Union הוא אלגוריתם המבצע את 
שתי הפעולות השימושיות הבאות על מבנה נתונים זה 
• חיפוש Find() 
קביעה איזו קבוצה מכילה עצם ספציפי. פעולה זו יכולה גם לעזור בקביעה האם שני עצמים
שייכים לאותה הקבוצה
•איחוד Union(groupB,groupA) 
איחוד שתי קבוצות לכדי קבוצה אחת

אופן המימוש
מבני הנתונים

namesValues - Dictionary המכיל בתוכו את השם מסוג  
מחרוזת ואת הערך מסוג int
מקבל את הנתונים מהקובץ
בעזרת מבני הנתונים ואלגוריתם קבוצות זרות פתרתי את התרגיל בצורה האופטימאלית
![image](https://user-images.githubusercontent.com/86923031/150659945-7bb6523d-d88c-4900-888d-bfc3122a7d29.png)

namesSynonyms – List
NamesPairs מסוג מחלקת List
המקבלת שתי מחרוזות 
כל איבר ברשימה מורכב משתי מחרוזות מה שמאפשר להכניס זוגות של שמות דומים הנמצאים בקובץ.
![image](https://user-images.githubusercontent.com/86923031/150659937-e5fd6216-a361-489c-b3ac-5e479aefef70.png)

mapsNameLocation –Dictionary המכיל בתוכו את השם מסוג string כל השמות הקיימים בקובץ הנתונים ואת המזהה הייחודי לכל שם מסוג int מספור אוטומטי
![image]((https://user-images.githubusercontent.com/86923031/150659932-41f3bdc3-98d5-40e0-8768-e638949cad43.png))

namesValuesByLoca–NamesValues
 מערך מסוג מחלקת 
המורכבת מ {string name, int value} 
כל איבר במערך מורכב משם וערך המגעים ממבנה הנתונים  
וממוקמים לפי מבנה הנתונים mapsNameLocation ע"י המזהה הייחודי המשותף והזהה (key(name
![image](https://user-images.githubusercontent.com/86923031/150660008-df74c25d-7821-40ec-8bc8-19f4dc5c2e6f.png)

לסיכום מבני בנתונים ותהליך הזרימה:
![image](https://user-images.githubusercontent.com/86923031/150660022-6a7f2a96-dcc9-43f2-aa48-5bb339d8bb8d.png)

דוגמאות להרצה
דוגמא ראשונה

קלט
Jacob 15
Yaakov 12
Yaako 1
Tomer 13
Tommer 4
Sara 19
Sarah 23
Shlomo 5
Synonyms
Jacob,Yaakov
Yaako,Jacob
Yaako,Jacob
Yaakov,Yaacov
Tomer,Tommer
Sara,Sarah
Shalom,Shlomo

פלט
 Jacob(28) ,Tomer(17) ,Sara(42) ,Shlomo(5)
 
 דוגמא נוספת
 
 קלט
Jacob 15
Yaakov 12
Tomer 13
Tommer 4
Sara 19
Synonyms
Jacob,Yaakov
Yaakov,Yaacov
Tomer,Tommer

 פלט
 Jacob(27) ,Tomer(17) ,Sara(19) ,


