```markdown
# مشاكل البرمجة باستخدام C++ - الحلول الكاملة والمنظمة

---

## المشكلة 1: تحويل الرقم إلى نص (Number To Text)

### وصف المشكلة
برنامج يقوم بقراءة رقم وطباعة نص هذا الرقم باللغة الإنجليزية.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

string NumberToText(int Number) {
    if (Number == 0) {
        return "";
    }
    if (Number >= 1 && Number <= 19) {
        string arr[] = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Nineteen" };
        return arr[Number] + " ";
    }
    if (Number >= 20 && Number <= 99) {
        string arr[] = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        return arr[Number / 10] + " " + NumberToText(Number % 10);
    }
    if (Number >= 100 && Number <= 199) {
        return "One Hundred " + NumberToText(Number % 100);
    }
    if (Number >= 200 && Number <= 999) {
        return NumberToText(Number / 100) + "Hundreds " + NumberToText(Number % 100);
    }
    if (Number >= 1000 && Number <= 1999) {
        return "One Thousand " + NumberToText(Number % 1000);
    }
    if (Number >= 2000 && Number <= 999999) {
        return NumberToText(Number / 1000) + "Thousands " + NumberToText(Number % 1000);
    }
    if (Number >= 1000000 && Number <= 1999999) {
        return "One Million " + NumberToText(Number % 1000000);
    }
    if (Number >= 2000000 && Number <= 999999999) {
        return NumberToText(Number / 1000000) + "Millions " + NumberToText(Number % 1000000);
    }
    if (Number >= 1000000000 && Number <= 1999999999) {
        return "One Billion " + NumberToText(Number % 1000000000);
    }
    else {
        return NumberToText(Number / 1000000000) + "Billions " + NumberToText(Number % 1000000000);
    }
}

int ReadNumber() {
    int Num = 0;
    cout << "\nPlease enter Number ? ";
    cin >> Num;
    return Num;
}

int main() {
    int Number = ReadNumber();
    cout << NumberToText(Number);
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter Number ? 546780834
Five Hundreds Forty Six Millions Seven Hundreds Eighty Thousands Eight Hundreds Thirty Four
```

---

## المشكلة 2: التحقق من السنة الكبيسة (Leap Year)

### وصف المشكلة
برنامج يقوم بالتحقق مما إذا كانت السنة المدخلة سنة كبيسة أم لا.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    if (Year % 400 == 0) {
        return true;
    }
    else if (Year % 100 == 0) {
        return false;
    }
    else if (Year % 4 == 0) {
        return true;
    }
    else {
        return false;
    }
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

int main() {
    short Year = ReadYear();
    if (IsLeapYear(Year))
        cout << "Yes, Year [" << Year << "] is a leap year.\n";
    else
        cout << "No, Year [" << Year << "] is NOT a leap year.\n";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a year to check? 2000
Yes, Year [2000] is a leap year.

Please enter a year to check? 1900
No, Year [1900] is NOT a leap year.
```

---

## المشكلة 3: التحقق من السنة الكبيسة (سطر واحد)

### وصف المشكلة
نفس المشكلة السابقة ولكن باستخدام سطر واحد من الكود.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

int main() {
    short Year = ReadYear();
    if (IsLeapYear(Year))
        cout << "Yes, Year [" << Year << "] is a leap year.\n";
    else
        cout << "No, Year [" << Year << "] is NOT a leap year.\n";
    system("pause>0");
    return 0;
}
```

---

## المشكلة 4: عدد الأيام والساعات والدقائق والثواني في السنة

### وصف المشكلة
برنامج يقوم بحساب وطباعة عدد الأيام والساعات والدقائق والثواني في سنة معينة.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAYear(short Year) {
    return IsLeapYear(Year) ? 366 : 365;
}

short NumberOfHoursInAYear(short Year) {
    return NumberOfDaysInAYear(Year) * 24;
}

int NumberOfMinutesInAYear(short Year) {
    return NumberOfHoursInAYear(Year) * 60;
}

int NumberOfSecondsInAYear(short Year) {
    return NumberOfMinutesInAYear(Year) * 60;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

int main() {
    short Year = ReadYear();
    cout << "\nNumber of Days in Year [" << Year << "] is " << NumberOfDaysInAYear(Year);
    cout << "\nNumber of Hours in Year [" << Year << "] is " << NumberOfHoursInAYear(Year);
    cout << "\nNumber of Minutes in Year [" << Year << "] is " << NumberOfMinutesInAYear(Year);
    cout << "\nNumber of Seconds in Year [" << Year << "] is " << NumberOfSecondsInAYear(Year);
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a year to check? 1900
Number of Days in Year [1900] is 365
Number of Hours in Year [1900] is 8760
Number of Minutes in Year [1900] is 525600
Number of Seconds in Year [1900] is 31536000

Please enter a year to check? 2000
Number of Days in Year [2000] is 366
Number of Hours in Year [2000] is 8784
Number of Minutes in Year [2000] is 527040
Number of Seconds in Year [2000] is 31622400
```

---

## المشكلة 5: عدد الأيام والساعات والدقائق والثواني في الشهر

### وصف المشكلة
برنامج يقوم بحساب وطباعة عدد الأيام والساعات والدقائق والثواني في شهر معين من سنة معينة.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    if (Month == 2) {
        return IsLeapYear(Year) ? 29 : 28;
    }
    short arr31Days[7] = { 1, 3, 5, 7, 8, 10, 12 };
    for (short i = 1; i <= 7; i++) {
        if (arr31Days[i - 1] == Month)
            return 31;
    }
    return 30;
}

short NumberOfHoursInAMonth(short Month, short Year) {
    return NumberOfDaysInAMonth(Month, Year) * 24;
}

int NumberOfMinutesInAMonth(short Month, short Year) {
    return NumberOfHoursInAMonth(Month, Year) * 60;
}

int NumberOfSecondsInAMonth(short Month, short Year) {
    return NumberOfMinutesInAMonth(Month, Year) * 60;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

int main() {
    short Year = ReadYear();
    short Month = ReadMonth();
    cout << "\nNumber of Days in Month [" << Month << "] is " << NumberOfDaysInAMonth(Month, Year);
    cout << "\nNumber of Hours in Month [" << Month << "] is " << NumberOfHoursInAMonth(Month, Year);
    cout << "\nNumber of Minutes in Month [" << Month << "] is " << NumberOfMinutesInAMonth(Month, Year);
    cout << "\nNumber of Seconds in Month [" << Month << "] is " << NumberOfSecondsInAMonth(Month, Year);
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a year to check? 1999
Please enter a Month to check? 12
Number of Days in Month [12] is 31
Number of Hours in Month [12] is 744
Number of Minutes in Month [12] is 44640
Number of Seconds in Month [12] is 2678400
```

---

## المشكلة 6: عدد الأيام في الشهر (بطريقة مختصرة)

### وصف المشكلة
نفس المشكلة السابقة ولكن باستخدام مصفوفة لتخزين عدد الأيام في كل شهر.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

short NumberOfHoursInAMonth(short Month, short Year) {
    return NumberOfDaysInAMonth(Month, Year) * 24;
}

int NumberOfMinutesInAMonth(short Month, short Year) {
    return NumberOfHoursInAMonth(Month, Year) * 60;
}

int NumberOfSecondsInAMonth(short Month, short Year) {
    return NumberOfMinutesInAMonth(Month, Year) * 60;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

int main() {
    short Year = ReadYear();
    short Month = ReadMonth();
    cout << "\nNumber of Days in Month [" << Month << "] is " << NumberOfDaysInAMonth(Month, Year);
    cout << "\nNumber of Hours in Month [" << Month << "] is " << NumberOfHoursInAMonth(Month, Year);
    cout << "\nNumber of Minutes in Month [" << Month << "] is " << NumberOfMinutesInAMonth(Month, Year);
    cout << "\nNumber of Seconds in Month [" << Month << "] is " << NumberOfSecondsInAMonth(Month, Year);
    system("pause>0");
    return 0;
}
```

---

## المشكلة 7: اسم اليوم

### وصف المشكلة
برنامج يقرأ تاريخ (يوم، شهر، سنة) ويقوم بطباعة اسم اليوم من الأسبوع.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short DayOfWeekOrder(short Day, short Month, short Year) {
    short a, y, m;
    a = (14 - Month) / 12;
    y = Year - a;
    m = Month + (12 * a) - 2;
    return (Day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;
}

string DayShortName(short DayOfWeekOrder) {
    string arrDayNames[7] = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    return arrDayNames[DayOfWeekOrder];
}

int main() {
    short Year = ReadYear();
    short Month = ReadMonth();
    short Day = ReadDay();
    short DayOrder = DayOfWeekOrder(Day, Month, Year);
    cout << "\n\nDate : " << Day << "/" << Month << "/" << Year << endl;
    cout << "Day Order : " << DayOrder << endl;
    cout << "Day Name : " << DayShortName(DayOrder) << endl;
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a year to check? 2023
Please enter a Month to check? 8
Please enter a Day to check? 12
Date : 12/8/2023
Day Order : 6
Day Name : Sat
```

---

## المشكلة 8: تقويم الشهر (Month Calendar)

### وصف المشكلة
برنامج يقوم بطباعة تقويم شهر معين من سنة معينة.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short DayOfWeekOrder(short Day, short Month, short Year) {
    short a, y, m;
    a = (14 - Month) / 12;
    y = Year - a;
    m = Month + (12 * a) - 2;
    return (Day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;
}

string DayShortName(short DayOfWeekOrder) {
    string arrDayNames[7] = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    return arrDayNames[DayOfWeekOrder];
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

string MonthShortName(short MonthNumber) {
    string Months[12] = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    return (Months[MonthNumber - 1]);
}

void PrintMonthCalendar(short Month, short Year) {
    int NumberOfDays;
    int current = DayOfWeekOrder(1, Month, Year);
    NumberOfDays = NumberOfDaysInAMonth(Month, Year);
    printf("\n _______________%s__________________\n\n", MonthShortName(Month).c_str());
    printf(" Sun Mon Tue Wed Thu Fri Sat\n");
    int i;
    for (i = 0; i < current; i++)
        printf("    ");
    for (int j = 1; j <= NumberOfDays; j++) {
        printf("%5d", j);
        if (++i == 7) {
            i = 0;
            printf("\n");
        }
    }
    printf("\n ____________________________________\n");
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

int main() {
    short Year = ReadYear();
    short Month = ReadMonth();
    PrintMonthCalendar(Month, Year);
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a year to check? 2023
Please enter a Month to check? 8

_______________Aug__________________

 Sun Mon Tue Wed Thu Fri Sat
                   1   2   3   4
   5   6   7   8   9  10  11
  12  13  14  15  16  17  18
  19  20  21  22  23  24  25
  26  27  28  29  30  31

____________________________________
```

---

## المشكلة 9: تقويم السنة (Year Calendar)

### وصف المشكلة
برنامج يقوم بطباعة تقويم كامل لسنة معينة.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short DayOfWeekOrder(short Day, short Month, short Year) {
    short a, y, m;
    a = (14 - Month) / 12;
    y = Year - a;
    m = Month + (12 * a) - 2;
    return (Day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;
}

string DayShortName(short DayOfWeekOrder) {
    string arrDayNames[7] = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    return arrDayNames[DayOfWeekOrder];
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

string MonthShortName(short MonthNumber) {
    string Months[12] = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    return (Months[MonthNumber - 1]);
}

void PrintMonthCalendar(short Month, short Year) {
    int NumberOfDays;
    int current = DayOfWeekOrder(1, Month, Year);
    NumberOfDays = NumberOfDaysInAMonth(Month, Year);
    printf("\n _______________%s__________________\n\n", MonthShortName(Month).c_str());
    printf(" Sun Mon Tue Wed Thu Fri Sat\n");
    int i;
    for (i = 0; i < current; i++)
        printf("    ");
    for (int j = 1; j <= NumberOfDays; j++) {
        printf("%5d", j);
        if (++i == 7) {
            i = 0;
            printf("\n");
        }
    }
    printf("\n ____________________________________\n");
}

void PrintYearCalendar(short Year) {
    printf("\n _________________________________\n\n");
    printf("        Calendar - %d\n", Year);
    printf(" _________________________________\n");
    for (short i = 1; i <= 12; i++) {
        PrintMonthCalendar(i, Year);
    }
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

int main() {
    PrintYearCalendar(ReadYear());
    system("pause>0");
    return 0;
}
```

---

## المشكلة 10: حساب عدد الأيام من بداية السنة

### وصف المشكلة
برنامج يقوم بحساب عدد الأيام المنقضية من بداية السنة حتى تاريخ معين.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

short NumberOfDaysFromTheBeginingOfTheYear(short Day, short Month, short Year) {
    short TotalDays = 0;
    for (int i = 1; i <= Month - 1; i++) {
        TotalDays += NumberOfDaysInAMonth(i, Year);
    }
    TotalDays += Day;
    return TotalDays;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

int main() {
    short Day = ReadDay();
    short Month = ReadMonth();
    short Year = ReadYear();
    cout << "\n\nNumber of Days from beginning of the Year Is : " << NumberOfDaysFromTheBeginingOfTheYear(Day, Month, Year);
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 13
Please enter a Month to check? 8
Please enter a year to check? 2023

Number of Days from beginning of the Year Is : 225
```

---

## المشكلة 11: استخراج التاريخ من رقم اليوم

### وصف المشكلة
برنامج يقوم بتحويل عدد الأيام المنقضية من بداية السنة إلى تاريخ فعلي.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

short NumberOfDaysFromTheBeginingOfTheYear(short Day, short Month, short Year) {
    short TotalDays = 0;
    for (int i = 1; i <= Month - 1; i++) {
        TotalDays += NumberOfDaysInAMonth(i, Year);
    }
    TotalDays += Day;
    return TotalDays;
}

sDate GetDateFromDayOrderInYear(short DateOrderInYear, short Year) {
    sDate Date;
    short RemainingDays = DateOrderInYear;
    short MonthDays = 0;
    Date.Year = Year;
    Date.Month = 1;
    while (true) {
        MonthDays = NumberOfDaysInAMonth(Date.Month, Year);
        if (RemainingDays > MonthDays) {
            RemainingDays -= MonthDays;
            Date.Month++;
        }
        else {
            Date.Day = RemainingDays;
            break;
        }
    }
    return Date;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

int main() {
    short Day = ReadDay();
    short Month = ReadMonth();
    short Year = ReadYear();
    short DaysOrderInYear = NumberOfDaysFromTheBeginingOfTheYear(Day, Month, Year);
    cout << "\n\nNumber of Days from beginning of the Year Is : " << DaysOrderInYear << endl;
    sDate Date;
    Date = GetDateFromDayOrderInYear(DaysOrderInYear, Year);
    cout << "\nDate for [" << DaysOrderInYear << "] is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 13
Please enter a Month to check? 8
Please enter a year to check? 2023

Number of Days from beginning of the Year Is : 225
Date for [225] is: 13/8/2023
```

---

## المشكلة 12: إضافة أيام إلى تاريخ

### وصف المشكلة
برنامج يقوم بإضافة عدد معين من الأيام إلى تاريخ معين.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

short NumberOfDaysFromTheBeginingOfTheYear(short Day, short Month, short Year) {
    short TotalDays = 0;
    for (int i = 1; i <= Month - 1; i++) {
        TotalDays += NumberOfDaysInAMonth(i, Year);
    }
    TotalDays += Day;
    return TotalDays;
}

sDate DateAddDays(short Days, sDate Date) {
    short RemainingDays = Days + NumberOfDaysFromTheBeginingOfTheYear(Date.Day, Date.Month, Date.Year);
    short MonthDays = 0;
    Date.Month = 1;
    while (true) {
        MonthDays = NumberOfDaysInAMonth(Date.Month, Date.Year);
        if (RemainingDays > MonthDays) {
            RemainingDays -= MonthDays;
            Date.Month++;
            if (Date.Month > 12) {
                Date.Month = 1;
                Date.Year++;
            }
        }
        else {
            Date.Day = RemainingDays;
            break;
        }
    }
    return Date;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

short ReadDaysToAdd() {
    short Days;
    cout << "\nHow many days to add? ";
    cin >> Days;
    return Days;
}

int main() {
    sDate Date = ReadFullDate();
    short Days = ReadDaysToAdd();
    Date = DateAddDays(Days, Date);
    cout << "\nDate after adding [" << Days << "] days is: ";
    cout << Date.Day << "/" << Date.Month << "/" << Date.Year;
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 14
Please enter a Month to check? 8
Please enter a year to check? 2023

How many days to add? 2500

Date after adding [2500] days is: 18/6/2030
```

---

## المشكلة 13: التحقق مما إذا كان التاريخ الأول أقل من الثاني

### وصف المشكلة
برنامج يقوم بالمقارنة بين تاريخين ومعرفة ما إذا كان التاريخ الأول أقل من الثاني.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsDate1BeforeDate2(sDate Date1, sDate Date2) {
    return (Date1.Year < Date2.Year) ? true :
           ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true :
           (Date1.Month == Date2.Month ? Date1.Day < Date2.Day : false)) : false);
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

int main() {
    sDate Date1 = ReadFullDate();
    cout << "\n\n";
    sDate Date2 = ReadFullDate();
    if (IsDate1BeforeDate2(Date1, Date2))
        cout << "\nYes, Date1 is Less than Date2.";
    else
        cout << "\nNo, Date1 is NOT Less than Date2.";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 15
Please enter a Month to check? 8
Please enter a year to check? 2023

Please enter a Day to check? 15
Please enter a Month to check? 9
Please enter a year to check? 2023

Yes, Date1 is Less than Date2.
```

---

## المشكلة 14: التحقق من تساوي تاريخين

### وصف المشكلة
برنامج يقوم بالمقارنة بين تاريخين ومعرفة ما إذا كان التاريخ الأول يساوي الثاني.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsDate1EqualDate2(sDate Date1, sDate Date2) {
    return (Date1.Year == Date2.Year) ? ((Date1.Month == Date2.Month) ?
           ((Date1.Day == Date2.Day) ? true : false) : false) : false;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

int main() {
    sDate Date1 = ReadFullDate();
    cout << "\n\n";
    sDate Date2 = ReadFullDate();
    if (IsDate1EqualDate2(Date1, Date2))
        cout << "\nYes, Date1 is Equal to Date2.";
    else
        cout << "\nNo, Date1 is NOT Equal to Date2.";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 15
Please enter a Month to check? 8
Please enter a year to check? 2023

Please enter a Day to check? 15
Please enter a Month to check? 8
Please enter a year to check? 2023

Yes, Date1 is Equal to Date2.
```

---

## المشكلة 15: التحقق من آخر يوم وآخر شهر

### وصف المشكلة
برنامج يقوم بالتحقق مما إذا كان اليوم هو آخر يوم في الشهر، وما إذا كان الشهر هو آخر شهر في السنة.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

bool IsLastDayInMonth(sDate Date) {
    return (Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year));
}

bool IsLastMonthInYear(short Month) {
    return (Month == 12);
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

int main() {
    sDate Date = ReadFullDate();
    if (IsLastDayInMonth(Date))
        cout << "\nYes, Day is Last In Month.";
    else
        cout << "\nNo, Day is NOT Last In Month.";
    if (IsLastMonthInYear(Date.Month))
        cout << "\nYes, Month is Last In Year.";
    else
        cout << "\nNo, Month is NOT Last In Year.";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 31
Please enter a Month to check? 8
Please enter a year to check? 2023

Yes, Day is Last In Month.
No, Month is NOT Last In Year.
```

---

## المشكلة 16: زيادة التاريخ بيوم واحد

### وصف المشكلة
برنامج يقوم بزيادة تاريخ معين بيوم واحد.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

bool IsLastDayInMonth(sDate Date) {
    return (Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year));
}

bool IsLastMonthInYear(short Month) {
    return (Month == 12);
}

sDate IncreaseDateByOneDay(sDate Date) {
    if (IsLastDayInMonth(Date)) {
        if (IsLastMonthInYear(Date.Month)) {
            Date.Month = 1;
            Date.Day = 1;
            Date.Year++;
        }
        else {
            Date.Day = 1;
            Date.Month++;
        }
    }
    else {
        Date.Day++;
    }
    return Date;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

int main() {
    sDate Date = ReadFullDate();
    Date = IncreaseDateByOneDay(Date);
    cout << "\nDate after adding one Day is : " << Date.Day << "/" << Date.Month << "/" << Date.Year;
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 31
Please enter a Month to check? 12
Please enter a year to check? 2023

Date after adding one Day is : 1/1/2024
```

---

## المشكلة 17: الفرق بين تاريخين بالأيام

### وصف المشكلة
برنامج يقوم بحساب الفرق بالأيام بين تاريخين.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

bool IsDate1BeforeDate2(sDate Date1, sDate Date2) {
    return (Date1.Year < Date2.Year) ? true :
           ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true :
           (Date1.Month == Date2.Month ? Date1.Day < Date2.Day : false)) : false);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

bool IsLastDayInMonth(sDate Date) {
    return (Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year));
}

bool IsLastMonthInYear(short Month) {
    return (Month == 12);
}

sDate IncreaseDateByOneDay(sDate Date) {
    if (IsLastDayInMonth(Date)) {
        if (IsLastMonthInYear(Date.Month)) {
            Date.Month = 1;
            Date.Day = 1;
            Date.Year++;
        }
        else {
            Date.Day = 1;
            Date.Month++;
        }
    }
    else {
        Date.Day++;
    }
    return Date;
}

int GetDifferenceInDays(sDate Date1, sDate Date2, bool IncludeEndDay = false) {
    int Days = 0;
    while (IsDate1BeforeDate2(Date1, Date2)) {
        Days++;
        Date1 = IncreaseDateByOneDay(Date1);
    }
    return IncludeEndDay ? ++Days : Days;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

int main() {
    sDate Date1 = ReadFullDate();
    cout << "\n\n";
    sDate Date2 = ReadFullDate();
    cout << "\nDifference is: " << GetDifferenceInDays(Date1, Date2) << " Day(s).";
    cout << "\nDifference (Including End Day) is: " << GetDifferenceInDays(Date1, Date2, true) << " Day(s).";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 1
Please enter a Month to check? 1
Please enter a year to check? 2023

Please enter a Day to check? 16
Please enter a Month to check? 8
Please enter a year to check? 2023

Difference is: 227 Day(s).
Difference (Including End Day) is: 228 Day(s).
```

---

## المشكلة 18: حساب العمر بالأيام

### وصف المشكلة
برنامج يقوم بحساب عمر المستخدم بالأيام بناءً على تاريخ ميلاده.

### الكود
```cpp
#pragma warning(disable : 4996)
#include <iostream>
#include <string>
#include <iomanip>
#include <ctime>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

bool IsDate1BeforeDate2(sDate Date1, sDate Date2) {
    return (Date1.Year < Date2.Year) ? true :
           ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true :
           (Date1.Month == Date2.Month ? Date1.Day < Date2.Day : false)) : false);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

bool IsLastDayInMonth(sDate Date) {
    return (Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year));
}

bool IsLastMonthInYear(short Month) {
    return (Month == 12);
}

sDate IncreaseDateByOneDay(sDate Date) {
    if (IsLastDayInMonth(Date)) {
        if (IsLastMonthInYear(Date.Month)) {
            Date.Month = 1;
            Date.Day = 1;
            Date.Year++;
        }
        else {
            Date.Day = 1;
            Date.Month++;
        }
    }
    else {
        Date.Day++;
    }
    return Date;
}

int GetDifferenceInDays(sDate Date1, sDate Date2, bool IncludeEndDay = false) {
    int Days = 0;
    while (IsDate1BeforeDate2(Date1, Date2)) {
        Days++;
        Date1 = IncreaseDateByOneDay(Date1);
    }
    return IncludeEndDay ? ++Days : Days;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

sDate GetSystemDate() {
    sDate Date;
    time_t t = time(0);
    tm* now = localtime(&t);
    Date.Year = now->tm_year + 1900;
    Date.Month = now->tm_mon + 1;
    Date.Day = now->tm_mday;
    return Date;
}

int main() {
    cout << "\nPlease Enter Your Date of Birth:\n";
    sDate Date1 = ReadFullDate();
    sDate Date2 = GetSystemDate();
    cout << "\nYour Age is : " << GetDifferenceInDays(Date1, Date2, true) << " Day(s).";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please Enter Your Date of Birth:
Please enter a Day to check? 13
Please enter a Month to check? 12
Please enter a year to check? 1999

Your Age is : 8648 Day(s).
```

---

## المشكلة 19: الفرق بين تاريخين (مع الأيام السالبة)

### وصف المشكلة
نفس المشكلة 17 ولكن مع دعم الأيام السالبة إذا كان التاريخ الثاني أقل من الأول.

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

bool IsDate1BeforeDate2(sDate Date1, sDate Date2) {
    return (Date1.Year < Date2.Year) ? true :
           ((Date1.Year == Date2.Year) ? (Date1.Month < Date2.Month ? true :
           (Date1.Month == Date2.Month ? Date1.Day < Date2.Day : false)) : false);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

bool IsLastDayInMonth(sDate Date) {
    return (Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year));
}

bool IsLastMonthInYear(short Month) {
    return (Month == 12);
}

sDate IncreaseDateByOneDay(sDate Date) {
    if (IsLastDayInMonth(Date)) {
        if (IsLastMonthInYear(Date.Month)) {
            Date.Month = 1;
            Date.Day = 1;
            Date.Year++;
        }
        else {
            Date.Day = 1;
            Date.Month++;
        }
    }
    else {
        Date.Day++;
    }
    return Date;
}

void SwapDates(sDate& Date1, sDate& Date2) {
    sDate TempDate;
    TempDate.Year = Date1.Year;
    TempDate.Month = Date1.Month;
    TempDate.Day = Date1.Day;
    Date1.Year = Date2.Year;
    Date1.Month = Date2.Month;
    Date1.Day = Date2.Day;
    Date2.Year = TempDate.Year;
    Date2.Month = TempDate.Month;
    Date2.Day = TempDate.Day;
}

int GetDifferenceInDays(sDate Date1, sDate Date2, bool IncludeEndDay = false) {
    int Days = 0;
    short SwapFlagValue = 1;
    if (!IsDate1BeforeDate2(Date1, Date2)) {
        SwapDates(Date1, Date2);
        SwapFlagValue = -1;
    }
    while (IsDate1BeforeDate2(Date1, Date2)) {
        Days++;
        Date1 = IncreaseDateByOneDay(Date1);
    }
    return IncludeEndDay ? ++Days * SwapFlagValue : Days * SwapFlagValue;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

int main() {
    sDate Date1 = ReadFullDate();
    cout << "\n\n";
    sDate Date2 = ReadFullDate();
    cout << "\nDifference is: " << GetDifferenceInDays(Date1, Date2) << " Day(s).";
    cout << "\nDifference (Including End Day) is: " << GetDifferenceInDays(Date1, Date2, true) << " Day(s).";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 13
Please enter a Month to check? 12
Please enter a year to check? 1999

Please enter a Day to check? 16
Please enter a Month to check? 8
Please enter a year to check? 2023

Difference is: -8647 Day(s).
Difference (Including End Day) is: -8648 Day(s).
```

---

## المشكلة 20-32: زيادة التاريخ (توابع متعددة)

### وصف المشكلة
مجموعة دوال لزيادة التاريخ بطرق مختلفة (أيام، أسابيع، أشهر، سنوات، عقود، قرون، آلاف السنين).

### الكود
```cpp
#include <iostream>
#include <string>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

bool IsLastDayInMonth(sDate Date) {
    return (Date.Day == NumberOfDaysInAMonth(Date.Month, Date.Year));
}

bool IsLastMonthInYear(short Month) {
    return (Month == 12);
}

sDate IncreaseDateByOneDay(sDate Date) {
    if (IsLastDayInMonth(Date)) {
        if (IsLastMonthInYear(Date.Month)) {
            Date.Month = 1;
            Date.Day = 1;
            Date.Year++;
        }
        else {
            Date.Day = 1;
            Date.Month++;
        }
    }
    else {
        Date.Day++;
    }
    return Date;
}

sDate IncreaseDateByXDays(short Days, sDate Date) {
    for (short i = 1; i <= Days; i++) {
        Date = IncreaseDateByOneDay(Date);
    }
    return Date;
}

sDate IncreaseDateByOneWeek(sDate Date) {
    for (int i = 1; i <= 7; i++) {
        Date = IncreaseDateByOneDay(Date);
    }
    return Date;
}

sDate IncreaseDateByXWeeks(short Weeks, sDate Date) {
    for (short i = 1; i <= Weeks; i++) {
        Date = IncreaseDateByOneWeek(Date);
    }
    return Date;
}

sDate IncreaseDateByOneMonth(sDate Date) {
    if (Date.Month == 12) {
        Date.Month = 1;
        Date.Year++;
    }
    else {
        Date.Month++;
    }
    short NumberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Date.Month, Date.Year);
    if (Date.Day > NumberOfDaysInCurrentMonth) {
        Date.Day = NumberOfDaysInCurrentMonth;
    }
    return Date;
}

sDate IncreaseDateByXMonths(short Months, sDate Date) {
    for (short i = 1; i <= Months; i++) {
        Date = IncreaseDateByOneMonth(Date);
    }
    return Date;
}

sDate IncreaseDateByOneYear(sDate Date) {
    Date.Year++;
    return Date;
}

sDate IncreaseDateByXYears(short Years, sDate Date) {
    for (short i = 1; i <= Years; i++) {
        Date = IncreaseDateByOneYear(Date);
    }
    return Date;
}

sDate IncreaseDateByXYearsFaster(short Years, sDate Date) {
    Date.Year += Years;
    return Date;
}

sDate IncreaseDateByOneDecade(sDate Date) {
    Date.Year += 10;
    return Date;
}

sDate IncreaseDateByXDecades(short Decade, sDate Date) {
    for (short i = 1; i <= Decade * 10; i++) {
        Date = IncreaseDateByOneYear(Date);
    }
    return Date;
}

sDate IncreaseDateByXDecadesFaster(short Decade, sDate Date) {
    Date.Year += Decade * 10;
    return Date;
}

sDate IncreaseDateByOneCentury(sDate Date) {
    Date.Year += 100;
    return Date;
}

sDate IncreaseDateByOneMillennium(sDate Date) {
    Date.Year += 1000;
    return Date;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

int main() {
    sDate Date1 = ReadFullDate();
    cout << "\nDate After: \n";
    Date1 = IncreaseDateByOneDay(Date1);
    cout << "\n01-Adding one day is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByXDays(10, Date1);
    cout << "\n02-Adding 10 days is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByOneWeek(Date1);
    cout << "\n03-Adding one week is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByXWeeks(10, Date1);
    cout << "\n04-Adding 10 weeks is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByOneMonth(Date1);
    cout << "\n05-Adding one month is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByXMonths(5, Date1);
    cout << "\n06-Adding 5 months is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByOneYear(Date1);
    cout << "\n07-Adding one year is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByXYears(10, Date1);
    cout << "\n08-Adding 10 Years is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByXYearsFaster(10, Date1);
    cout << "\n09-Adding 10 Years (faster) is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByOneDecade(Date1);
    cout << "\n10-Adding one Decade is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByXDecades(10, Date1);
    cout << "\n11-Adding 10 Decades is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByXDecadesFaster(10, Date1);
    cout << "\n12-Adding 10 Decade (faster) is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByOneCentury(Date1);
    cout << "\n13-Adding One Century is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    Date1 = IncreaseDateByOneMillennium(Date1);
    cout << "\n14-Adding One Millennium is: " << Date1.Day << "/" << Date1.Month << "/" << Date1.Year;
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 18
Please enter a Month to check? 8
Please enter a year to check? 2023

Date After:
01-Adding one day is: 19/8/2023
02-Adding 10 days is: 29/8/2023
03-Adding one week is: 5/9/2023
04-Adding 10 weeks is: 14/11/2023
05-Adding one month is: 14/12/2023
06-Adding 5 months is: 14/5/2024
07-Adding one year is: 14/5/2025
08-Adding 10 Years is: 14/5/2035
09-Adding 10 Years (faster) is: 14/5/2045
10-Adding one Decade is: 14/5/2055
11-Adding 10 Decades is: 14/5/2155
12-Adding 10 Decade (faster) is: 14/5/2255
13-Adding One Century is: 14/5/2355
14-Adding One Millennium is: 14/5/3355
```

---

## المشكلة 62: التحقق من صحة التاريخ

### وصف المشكلة
برنامج يقوم بالتحقق من صحة التاريخ المدخل.

### الكود
```cpp
#include <iostream>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
    if (Month < 1 || Month > 12)
        return 0;
    int NumberOfDays[12] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : NumberOfDays[Month - 1];
}

bool IsValidDate(sDate Date) {
    if (Date.Day < 1 || Date.Day > 31)
        return false;
    if (Date.Month < 1 || Date.Month > 12)
        return false;
    if (Date.Month == 2) {
        if (IsLeapYear(Date.Year)) {
            if (Date.Day > 29)
                return false;
        }
        else {
            if (Date.Day > 28)
                return false;
        }
    }
    short DaysInMonth = NumberOfDaysInAMonth(Date.Month, Date.Year);
    if (Date.Day > DaysInMonth)
        return false;
    return true;
}

short ReadDay() {
    short Day = 0;
    cout << "\nPlease enter a Day to check? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month = 0;
    cout << "\nPlease enter a Month to check? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year = 0;
    cout << "\nPlease enter a year to check? ";
    cin >> Year;
    return Year;
}

sDate ReadFullDate() {
    sDate Date;
    Date.Day = ReadDay();
    Date.Month = ReadMonth();
    Date.Year = ReadYear();
    return Date;
}

int main() {
    sDate Date1 = ReadFullDate();
    if (IsValidDate(Date1))
        cout << "\nYes, Date is a validate date.\n";
    else
        cout << "\nNo, Date is a NOT validate date\n";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please enter a Day to check? 33
Please enter a Month to check? 15
Please enter a year to check? 2023

No, Date is a NOT validate date
```

---

## المشكلة 63-64: قراءة وطباعة التاريخ كنص

### وصف المشكلة
برنامج يقوم بقراءة تاريخ كسلسلة نصية وتحويله إلى هيكل تاريخ، ثم طباعة مكوناته وطباعته كنص مرة أخرى.

### الكود
```cpp
#include <iostream>
#include <string>
#include <vector>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

vector<string> SplitString(string S1, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S1.find(Delim)) != std::string::npos) {
        sWord = S1.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S1.erase(0, pos + Delim.length());
    }
    if (S1 != "") {
        vString.push_back(S1);
    }
    return vString;
}

string DateToString(sDate Date) {
    return to_string(Date.Day) + "/" + to_string(Date.Month) + "/" + to_string(Date.Year);
}

sDate StringToDate(string DateString) {
    sDate Date;
    vector<string> vDate;
    vDate = SplitString(DateString, "/");
    Date.Day = stoi(vDate[0]);
    Date.Month = stoi(vDate[1]);
    Date.Year = stoi(vDate[2]);
    return Date;
}

string ReadStringDate(string Message) {
    string DateString;
    cout << Message;
    getline(cin >> ws, DateString);
    return DateString;
}

int main() {
    string DateString = ReadStringDate("\nPlease Enter Date dd/mm/yyyy? ");
    sDate Date = StringToDate(DateString);
    cout << "\nDay:" << Date.Day << endl;
    cout << "Month:" << Date.Month << endl;
    cout << "Year:" << Date.Year << endl;
    cout << "\nYou Entered: " << DateToString(Date) << "\n";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please Enter Date dd/mm/yyyy? 24/8/2023
Day:24
Month:8
Year:2023

You Entered: 24/8/2023
```

---

## المشكلة 65: تنسيق التاريخ

### وصف المشكلة
برنامج يقوم بتنسيق التاريخ بعدة صيغ مختلفة.

### الكود
```cpp
#include <iostream>
#include <string>
#include <vector>
using namespace std;

struct sDate {
    short Year;
    short Month;
    short Day;
};

vector<string> SplitString(string S1, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S1.find(Delim)) != std::string::npos) {
        sWord = S1.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S1.erase(0, pos + Delim.length());
    }
    if (S1 != "") {
        vString.push_back(S1);
    }
    return vString;
}

string ReplaceWordInString(string S1, string StringToReplace, string sRepalceTo) {
    short pos = S1.find(StringToReplace);
    while (pos != std::string::npos) {
        S1 = S1.replace(pos, StringToReplace.length(), sRepalceTo);
        pos = S1.find(StringToReplace);
    }
    return S1;
}

string DateToString(sDate Date) {
    return to_string(Date.Day) + "/" + to_string(Date.Month) + "/" + to_string(Date.Year);
}

sDate StringToDate(string DateString) {
    sDate Date;
    vector<string> vDate;
    vDate = SplitString(DateString, "/");
    Date.Day = stoi(vDate[0]);
    Date.Month = stoi(vDate[1]);
    Date.Year = stoi(vDate[2]);
    return Date;
}

string FormateDate(sDate Date, string DateFormat = "dd/mm/yyyy") {
    string FormattedDateString = "";
    FormattedDateString = ReplaceWordInString(DateFormat, "dd", to_string(Date.Day));
    FormattedDateString = ReplaceWordInString(FormattedDateString, "mm", to_string(Date.Month));
    FormattedDateString = ReplaceWordInString(FormattedDateString, "yyyy", to_string(Date.Year));
    return FormattedDateString;
}

string ReadStringDate(string Message) {
    string DateString;
    cout << Message;
    getline(cin >> ws, DateString);
    return DateString;
}

int main() {
    string DateString = ReadStringDate("\nPlease Enter Date dd/mm/yyyy? ");
    sDate Date = StringToDate(DateString);
    cout << "\n" << FormateDate(Date) << "\n";
    cout << "\n" << FormateDate(Date, "yyyy/dd/mm") << "\n";
    cout << "\n" << FormateDate(Date, "mm/dd/yyyy") << "\n";
    cout << "\n" << FormateDate(Date, "mm-dd-yyyy") << "\n";
    cout << "\n" << FormateDate(Date, "dd-mm-yyyy") << "\n";
    cout << "\n" << FormateDate(Date, "Day:dd, Month:mm, Year:yyyy") << "\n";
    system("pause>0");
    return 0;
}
```

### مثال
```
Please Enter Date dd/mm/yyyy? 26/8/2023
26/8/2023
2023/26/8
8/26/2023
8-26-2023
26-8-2023
Day:26, Month:8, Year:2023
```

---

## ملخص دوال التواريخ الأساسية

| الدالة | الوصف |
|--------|-------|
| `IsLeapYear()` | التحقق من السنة الكبيسة |
| `NumberOfDaysInAMonth()` | حساب عدد الأيام في شهر معين |
| `NumberOfDaysInAYear()` | حساب عدد الأيام في سنة معينة |
| `DayOfWeekOrder()` | حساب ترتيب اليوم في الأسبوع |
| `DayShortName()` | إرجاع اسم اليوم المختصر |
| `IncreaseDateByOneDay()` | زيادة التاريخ بيوم واحد |
| `GetDifferenceInDays()` | حساب الفرق بالأيام بين تاريخين |
| `IsValidDate()` | التحقق من صحة التاريخ |
| `DateToString()` | تحويل هيكل التاريخ إلى نص |
| `StringToDate()` | تحويل نص إلى هيكل تاريخ |
| `FormateDate()` | تنسيق التاريخ بصيغ مختلفة |
```