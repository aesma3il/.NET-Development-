
```markdown
# سلسلة حلول البرامج الأساسية - المستوى الأول

## منهجية الحل

### أفضل طريقة لحل أي برنامج
- التفكير في جزء واحد فقط من المشكلة في كل مرة
- كلما زاد عدد Functions and Procedures، كان التحكم في البرنامج أسهل وأسرع
- أفضل كود هو الأقل نسبة خطأ
- تجربة كل الاحتمالات (الصحيحة والخاطئة) عند عمل برنامج أو كود

---

## حل المشكلة 1
### برنامج يطبع اسمك على الشاشة

```cpp
// Write a program to print your name on screen
#include <iostream>
#include <string>
using namespace std;

void PrintName(string Name) {
    cout << "\n Your Name is : " << Name << endl;
}

int main() {
    PrintName("Saeed");
}
```

---

## حل المشكلة 2
### برنامج يطلب من المستخدم إدخال اسمه ويتم طباعته على الشاشة

```cpp
// Type a program that asks the user to enter his name and prints it on the screen
#include <iostream>
#include <string>
using namespace std;

string ReadName() {
    string Name;
    cout << "Pleas enter your name ? " << endl;
    getline(cin, Name);
    return Name;
}

void PrintName(string Name) {
    cout << "\n Your Name is : " << Name << endl;
}

int main() {
    PrintName(ReadName());
}
```

---

## حل المشكلة 3
### برنامج يطلب من المستخدم إدخال رقم إذا كان فردي يطبع 'ODD' وإذا كان زوجي يطبع 'Even'

```cpp
// Write a program that asks the user to enter a number if it is odd or an even number if it is even
#include <iostream>
using namespace std;

enum enNumberType { Odd = 1, Even = 2 };

int ReadNumber() {
    int Num;
    cout << "Pleas enter a number? " << endl;
    cin >> Num;
    return Num;
}

enNumberType CheckNumberType(int Num) {
    int Result = Num % 2;
    if (Result == 0)
        return enNumberType::Even;
    else
        return enNumberType::Odd;
}

void PrintNumberType(enNumberType NumberType) {
    if (NumberType == enNumberType::Even)
        cout << "\n Number is Even \n";
    else
        cout << "\n Number is Odd \n";
}

int main() {
    PrintNumberType(CheckNumberType(ReadNumber()));
}
```

---

## حل المشكلة 4
### برنامج يطلب من المستخدم إدخال بياناته (العمرو رخصة القيادة) فإذا كان عمره أكبر من 21 ويوجد لديه رخصة قيادة يطبع "Hired" وإلا يطبع "Rejected"

```cpp
// Write a program that asks the user to enter their details: age and driver's license, then 'rented' if they are over 21 years old and have a driver's license, otherwise print 'disapproved'
#include <iostream>
using namespace std;

struct stInfo {
    short Age;
    bool HasDrivingLicense;
};

stInfo ReadInfo() {
    stInfo Info;
    cout << "Pleas enter Your Age ?" << endl;
    cin >> Info.Age;
    cout << "Do you has driver License?" << endl;
    cin >> Info.HasDrivingLicense;
    return Info;
}

bool IsAccepted(stInfo Info) {
    return (Info.Age > 21 && Info.HasDrivingLicense);
}

void PrintResult(stInfo Info) {
    if (IsAccepted(Info))
        cout << "\n Hired \n";
    else
        cout << "\n Rejected \n";
}

int main() {
    PrintResult(ReadInfo());
}
```

---

## حل المشكلة 5
### برنامج يطلب من المستخدم إدخال بياناته (العمر ورخصة القيادة أو واسطة) فإذا كان عمره أكبر من 21 ولديه رخصة قيادة أو لديه واسطة يطبع "Hired" وإلا يطبع "Rejected"

```cpp
// Write a program that asks the user to enter their details: age and driver's license or Has Recommendation, then 'rented' if they are over 21 years old and have a driver's license, otherwise print 'disapproved'
#include <iostream>
using namespace std;

struct stInfo {
    short Age;
    bool HasDrivingLicense;
    bool HasRecommendation;
};

stInfo ReadInfo() {
    stInfo Info;
    cout << "Pleas enter Your Age ?" << endl;
    cin >> Info.Age;
    cout << "Do you have driver License?" << endl;
    cin >> Info.HasDrivingLicense;
    cout << "Do you have Recommendation? " << endl;
    cin >> Info.HasRecommendation;
    return Info;
}

bool IsAccepted(stInfo Info) {
    if (Info.HasRecommendation)
        return true;
    else
        return (Info.Age > 21 && Info.HasDrivingLicense);
}

void PrintResult(stInfo Info) {
    if (IsAccepted(Info))
        cout << "\n Hired \n";
    else
        cout << "\n Rejected \n";
}

int main() {
    PrintResult(ReadInfo());
}
```

---

## حل المشكلة 6
### برنامج يطلب من المستخدم إدخال البيانات (الاسم والكنية) ثم يطبع الاسم مع الكنية

```cpp
#include <iostream>
using namespace std;

struct stInfo {
    string FirstName;
    string LastName;
};

stInfo ReadInfo() {
    stInfo Info;
    cout << "Pleas enter Your First Name ?" << endl;
    cin >> Info.FirstName;
    cout << "Pleas enter Your Last Name ?" << endl;
    cin >> Info.LastName;
    return Info;
}

// تعديل لعكس الاسم والكنية، يكون في سطر واحد فقط
string GetFullName(stInfo Info, bool Reversed) {
    string FullName = "";
    if (Reversed)
        FullName = Info.LastName + " " + Info.FirstName;
    else
        FullName = Info.FirstName + " " + Info.LastName;
    return FullName;
}

// تستطيع إعطاء أمر للطباعة مثل ولا للشاشة
void PrintFullName(string FullName) {
    cout << "\n Your full name is : " << FullName << endl;
}

int main() {
    PrintFullName(GetFullName(ReadInfo(), false));
}
```

---

## حل المشكلة 7
### برنامج يطلب من المستخدم إدخال رقم ثم يطبع "Half of the (Number) is (???)"

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadNamber() {
    int Num;
    cout << "Pleas enter your Number ? \n";
    cin >> Num;
    return Num;
}

float CalculateHalfNumber(int Num) {
    return (float)Num / 2;
}

void PrintResults(int Num) {
    string Result = "Half of " + to_string(Num) + " is " + to_string(CalculateHalfNumber(Num));
    cout << Result << endl; // النتيجة تكون 5.5000000
}

int main() {
    PrintResults(ReadNamber());
}
```

---

## حل المشكلة 8
### برنامج يطلب من المستخدم إدخال درجة الاختبار فإذا كانت الدرجة => 50 يطبع "P" وإلا يطبع "Fail"

```cpp
#include <iostream>
#include <string>
using namespace std;

enum enPassFail { PASS = 1, FAIL = 2 };

int ReadMark() {
    int Mark;
    cout << "Pleas enter your Mark ? \n";
    cin >> Mark;
    return Mark;
}

enPassFail CheckMark(int Mark) {
    if (Mark >= 50)
        return enPassFail::PASS;
    else
        return enPassFail::FAIL;
}

void PrintResults(int Mark) {
    if (CheckMark(Mark) == enPassFail::PASS)
        cout << "\n You Passed \n";
    else
        cout << "\n You Faild \n";
}

int main() {
    PrintResults(ReadMark());
}
```

---

## حل المشكلة 9
### برنامج يطلب من المستخدم إدخال ثلاثة أرقام ثم يطبع مجموع تلك الأرقام

```cpp
#include <iostream>
#include <string>
using namespace std;

void ReadNumbers(int& Num1, int& Num2, int& Num3) {
    cout << "Pleas enter your Number 1 ? \n";
    cin >> Num1;
    cout << "Pleas enter your Number 2 ? \n";
    cin >> Num2;
    cout << "Pleas enter your Number 3 ? \n";
    cin >> Num3;
}

int SumOf3Numbers(int Num1, int Num2, int Num3) {
    return Num1 + Num2 + Num3;
}

void PrintResults(int Total) {
    cout << "\n The total sum of numbers is : " << Total << endl;
}

int main() {
    int Num1, Num2, Num3;
    ReadNumbers(Num1, Num2, Num3);
    PrintResults(SumOf3Numbers(Num1, Num2, Num3));
}
```

---

## حل المشكلة 10
### برنامج يطلب من المستخدم إدخال ثلاثة اخترات درجات ثم يطبع متوسط الدرجات

```cpp
#include <iostream>
#include <string>
using namespace std;

void ReadNumbers(int& Mark1, int& Mark2, int& Mark3) {
    cout << "Pleas enter your Mark 1 ? \n";
    cin >> Mark1;
    cout << "Pleas enter your Mark 2 ? \n";
    cin >> Mark2;
    cout << "Pleas enter your Mark 3 ? \n";
    cin >> Mark3;
}

int SumOf3Marks(int Mark1, int Mark2, int Mark3) {
    return Mark1 + Mark2 + Mark3;
}

float CalculateAverage(int Mark1, int Mark2, int Mark3) {
    return (float)SumOf3Marks(Mark1, Mark2, Mark3) / 3;
}

void PrintResults(float Average) {
    cout << "\n The total sum of numbers is : " << Average << endl;
}

int main() {
    int Mark1, Mark2, Mark3;
    ReadNumbers(Mark1, Mark2, Mark3);
    PrintResults(CalculateAverage(Mark1, Mark2, Mark3));
}
```

---

## حل المشكلة 11
### برنامج يطلب من المستخدم إدخال ثلاثة اختبارات علامات ثم يطبع متوسط العلامات، وإذا كان المتوسط => 50 يطبع "P" وإلا يطبع "F"

```cpp
#include <iostream>
#include <string>
using namespace std;

enum enPassFail { Pass = 1, Fail = 2 };

void ReadNumbers(int& Mark1, int& Mark2, int& Mark3) {
    cout << "Pleas enter your Mark 1 ? \n";
    cin >> Mark1;
    cout << "Pleas enter your Mark 2 ? \n";
    cin >> Mark2;
    cout << "Pleas enter your Mark 3 ? \n";
    cin >> Mark3;
}

int SumOf3Marks(int Mark1, int Mark2, int Mark3) {
    return Mark1 + Mark2 + Mark3;
}

float CalculateAverage(int Mark1, int Mark2, int Mark3) {
    return (float)SumOf3Marks(Mark1, Mark2, Mark3) / 3;
}

enPassFail CheckAverage(float Average) {
    if (Average >= 50)
        return enPassFail::Pass;
    else
        return enPassFail::Fail;
}

void PrintResults(float Average) {
    cout << "\n The total sum of numbers is : " << Average << endl;
    if (CheckAverage(Average) == enPassFail::Pass)
        cout << "\n You Passed \n";
    else
        cout << "\n You Faild \n";
}

int main() {
    int Mark1, Mark2, Mark3;
    ReadNumbers(Mark1, Mark2, Mark3);
    PrintResults(CalculateAverage(Mark1, Mark2, Mark3));
}
```

---

## حل المشكلة 12
### برنامج يطلب من المستخدم إدخال رقمين ثم يطبع أكبر رقم

```cpp
#include <iostream>
#include <string>
using namespace std;

void ReadNumbers(int& Num1, int& Num2) {
    cout << "Pleas enter Number 1 ? \n";
    cin >> Num1;
    cout << "Pleas enter Number 2 ? \n";
    cin >> Num2;
}

int MaxOf2Numbers(int Num1, int Num2) {
    if (Num1 > Num2)
        return Num1;
    else
        return Num2;
}

void PrintResults(int Max) {
    cout << "\n The Maximun Number is : " << Max << endl;
}

int main() {
    int Num1, Num2;
    ReadNumbers(Num1, Num2);
    PrintResults(MaxOf2Numbers(Num1, Num2));
}
```

---

## حل المشكلة 13
### برنامج يطلب من المستخدم إدخال ثلاثة أرقام ثم يطبع أكبر رقم

```cpp
#include <iostream>
#include <string>
using namespace std;

void ReadNumbers(int& Num1, int& Num2, int& Num3) {
    cout << "Pleas enter Number 1 ? \n";
    cin >> Num1;
    cout << "Pleas enter Number 2 ? \n";
    cin >> Num2;
    cout << "Pleas enter Number 3 ? \n";
    cin >> Num3;
}

int MaxOf3Numbers(int Num1, int Num2, int Num3) {
    if (Num1 > Num2)
        if (Num1 > Num3)
            return Num1;
        else
            return Num3;
    else if (Num2 > Num3)
        return Num2;
    else
        return Num3;
}

void PrintResults(int Max) {
    cout << "\n The Maximun Number is : " << Max << endl;
}

int main() {
    int Num1, Num2, Num3;
    ReadNumbers(Num1, Num2, Num3);
    PrintResults(MaxOf3Numbers(Num1, Num2, Num3));
}
```

---

## حل المشكلة 14
### برنامج يطلب من المستخدم إدخال رقمين ثم يطبع الرقمين ثم يبدل مكان الأول بالثاني ثم يطبعهما

```cpp
#include <iostream>
#include <string>
using namespace std;

void ReadNumbers(int& Num1, int& Num2) {
    cout << "Pleas enter Number 1 ? \n";
    cin >> Num1;
    cout << "Pleas enter Number 2 ? \n";
    cin >> Num2;
}

void Swap(int& A, int& B) {
    int Temp;
    Temp = A;
    A = B;
    B = Temp;
}

void PrintResults(int Num1, int Num2) {
    cout << "\n Number 1 : " << Num1 << endl;
    cout << " Number 2 : " << Num2 << endl;
}

int main() {
    int Num1, Num2;
    ReadNumbers(Num1, Num2);
    PrintResults(Num1, Num2);
    Swap(Num1, Num2);
    PrintResults(Num1, Num2);
}
```

---

## حل المشكلة 15
### برنامج لحساب مساحة المستطيل وطباعتها على الشاشة

```cpp
#include <iostream>
#include <string>
using namespace std;

void ReadNumbers(float& Num1, float& Num2) {
    cout << "Pleas enter rectangle Width ? \n";
    cin >> Num1;
    cout << "Pleas enter rectangle Length ? \n";
    cin >> Num2;
}

float CalculateRectangleArea(float Num1, float Num2) {
    return Num1 * Num2;
}

void PrintResults(float Area) {
    cout << "\n Rectangle Area = " << Area << endl;
}

int main() {
    float Num1, Num2;
    ReadNumbers(Num1, Num2);
    PrintResults(CalculateRectangleArea(Num1, Num2));
}
```

---

## حل المشكلة 16
### برنامج لحساب مساحة المستطيل من خلال المنطقة القائمة للمستطيل

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

void ReadNumbers(float& A, float& D) {
    cout << "Pleas enter rectangle Side A ? \n";
    cin >> A;
    cout << "Pleas enter rectangle Diagonal D ? \n";
    cin >> D;
}

float RectangleAreaBySideAndDiagonal(float A, float D) {
    float Area = A * sqrt(pow(D, 2) - pow(A, 2));
    return Area;
}

void PrintResults(float Area) {
    cout << "\n Rectangle Area = " << Area << endl;
}

int main() {
    float Num1, Num2;
    ReadNumbers(Num1, Num2);
    PrintResults(RectangleAreaBySideAndDiagonal(Num1, Num2));
}
```

---

## حل المشكلة 17
### برنامج لحساب مساحة المثلث

```cpp
#include <iostream>
#include <string>
using namespace std;

void ReadNumbers(float& A, float& H) {
    cout << "Pleas enter triangle base A ? \n";
    cin >> A;
    cout << "Pleas enter triangle height H ? \n";
    cin >> H;
}

float TriangleArea(float A, float H) {
    float Area = (A / 2) * H;
    return Area;
}

void PrintResults(float Area) {
    cout << "\n Triangle Area = " << Area << endl;
}

int main() {
    float Num1, Num2;
    ReadNumbers(Num1, Num2);
    PrintResults(TriangleArea(Num1, Num2));
}
```

---

## حل المشكلة 18
### برنامج لحساب مساحة نصف قطر الدائرة

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

float ReadRadious() {
    float R;
    cout << "Pleas enter Radious R ? \n";
    cin >> R;
    return R;
}

float CircleArea(float R) {
    const float PI = 3.141592653589793238;
    float Area = PI * pow(R, 2);
    return Area;
}

void PrintResults(float Area) {
    cout << "\n Circle Area = " << Area << endl;
}

int main() {
    PrintResults(CircleArea(ReadRadious()));
}
```

---

## حل المشكلة 19
### برنامج لحساب مساحة قطر الدائرة

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

float ReadDiameter() {
    float D;
    cout << "Pleas enter Diameter R ? \n";
    cin >> D;
    return D;
}

float CircleAreaByDiameter(float D) {
    const float PI = 3.141592653589793238;
    float Area = (PI * pow(D, 2)) / 4;
    return Area;
}

void PrintResults(float Area) {
    cout << "\n Circle Area = " << Area << endl;
}

int main() {
    PrintResults(CircleAreaByDiameter(ReadDiameter()));
}
```

---

## حل المشكلة 20
### برنامج لحساب مساحة دائرة داخل مربع

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

float ReadSquareSide() {
    float A;
    cout << "Pleas enter Square Side A ? \n";
    cin >> A;
    return A;
}

float CircleAreaInscribedInSquare(float A) {
    const float PI = 3.141592653589793238;
    float Area = (PI * pow(A, 2)) / 4;
    return Area;
}

void PrintResults(float Area) {
    cout << "\n Circle Area = " << Area << endl;
}

int main() {
    PrintResults(CircleAreaInscribedInSquare(ReadSquareSide()));
}
```

---

## حل المشكلة 21
### برنامج لحساب مساحة محيط الدائرة

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

float ReadCircumference() {
    float L;
    cout << "Pleas enter Circumference L ? \n";
    cin >> L;
    return L;
}

float CircleAreaByCircumference(float L) {
    const float PI = 3.141592653589793238;
    float Area = pow(L, 2) / (PI * 4);
    return Area;
}

void PrintResults(float Area) {
    cout << "\n Circle Area = " << Area << endl;
}

int main() {
    PrintResults(CircleAreaByCircumference(ReadCircumference()));
}
```

---

## حل المشكلة 22
### برنامج لحساب مساحة دائرة داخل مثلث

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

void ReadTriangleData(float& A, float& B) {
    cout << "Pleas enter Triangle Side A ? \n";
    cin >> A;
    cout << "Pleas enter Triangle base B ? \n";
    cin >> B;
}

float CircleAreaByTriangle(float A, float B) {
    const float PI = 3.141592653589793238;
    float Area = PI * (pow(B, 2) / 4) * ((2 * A - B) / (2 * A + B));
    return Area;
}

void PrintResults(float Area) {
    cout << "\n Circle Area = " << Area << endl;
}

int main() {
    float A, B;
    ReadTriangleData(A, B);
    PrintResults(CircleAreaByTriangle(A, B));
}
```

---

## حل المشكلة 23
### برنامج لحساب مساحة دائرة باستخدام معلومات المثلث

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

void ReadTriangleData(float& A, float& B, float& C) {
    cout << "Pleas enter Triangle Side A ? \n";
    cin >> A;
    cout << "Pleas enter Triangle base B ? \n";
    cin >> B;
    cout << "Pleas enter Triangle Side C ? \n";
    cin >> C;
}

float CircleAreaByTriangle(float A, float B, float C) {
    const float PI = 3.141592653589793238;
    float P = (A + B + C) / 2;
    float T = (A * B * C) / (4 * sqrt(P * (P - A) * (P - B) * (P - C)));
    float Area = PI * pow(T, 2);
    return Area;
}

void PrintResults(float Area) {
    cout << "\n Circle Area = " << Area << endl;
}

int main() {
    float A, B, C;
    ReadTriangleData(A, B, C);
    PrintResults(CircleAreaByTriangle(A, B, C));
}
```

---

## حل المشكلة 24
### برنامج يطلب من المستخدم إدخال "العمر" إذا كان العمر بين 18 و 45 يطبع "Valid Age" وإلا يطبع "Invalid Age"

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadAge() {
    int Age;
    cout << "Pleas enter your Age between 18 and 45 ? \n";
    cin >> Age;
    return Age;
}

bool ValidateNumberInRange(int Number, int From, int To) {
    return Number >= From && Number <= To;
}

void PrintResult(int Age) {
    if (ValidateNumberInRange(Age, 18, 45))
        cout << Age << " is a valid age \n";
    else
        cout << Age << " is invalid age \n";
}

int main() {
    PrintResult(ReadAge());
}
```

---

## حل المشكلة 25
### برنامج يطلب من المستخدم إدخال "العمر" إذا كان العمر بين 18 و 45 يطبع "Valid Age" وإلا يطبع "Invalid Age" وأعد مطالبة المستخدم بإدخال عمر صالح

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadAge() {
    int Age;
    cout << "Pleas enter your Age between 18 and 45 ? \n";
    cin >> Age;
    return Age;
}

bool ValidateNumberInRange(int Number, int From, int To) {
    return Number >= From && Number <= To;
}

int ReadUntilAgeBetween(int From, int To) {
    int Age = 0;
    do {
        Age = ReadAge();
    } while (!ValidateNumberInRange(Age, From, To));
    return Age;
}

void PrintResult(int Age) {
    if (ValidateNumberInRange(Age, 18, 45))
        cout << Age << " is a valid age \n";
    else
        cout << Age << " is invalid age \n";
}

int main() {
    PrintResult(ReadUntilAgeBetween(18, 45));
}
```

---

## حل المشكلة 26
### برنامج يطلب من المستخدم إدخال رقم ثم يطبع من 1 إلى الرقم

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadNumber() {
    int Num;
    cout << "Pleas enter your Number ? \n";
    cin >> Num;
    return Num;
}

void PrintRangeFrom1toNum_UsingFor(int Num) {
    // هذا هو أفضل حل لأنه نعرف نطاق الف
    cout << "Range printed using For Statement: \n";
    for (int Counter = 1; Counter <= Num; Counter++) {
        cout << Counter << endl;
    }
}

void PrintRangeFrom1toNum_UsingWhile(int Num) {
    int Counter = 0;
    cout << "Range printed using While Statement: \n";
    while (Counter < Num) {
        Counter++;
        cout << Counter << endl;
    }
}

void PrintRangeFrom1toNum_UsingDoWhile(int Num) {
    int Counter = 0;
    cout << "Range printed using Do While Statement: \n";
    do {
        Counter++;
        cout << Counter << endl;
    } while (Counter < Num);
}

int main() {
    int Num = ReadNumber();
    PrintRangeFrom1toNum_UsingFor(Num);
    PrintRangeFrom1toNum_UsingWhile(Num);
    PrintRangeFrom1toNum_UsingDoWhile(Num);
}
```

---

## حل المشكلة 27
### برنامج يطلب من المستخدم إدخال رقم ثم يطبع من الرقم إلى 1

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadNumber() {
    int Num;
    cout << "Pleas enter your Number ? \n";
    cin >> Num;
    return Num;
}

void PrintRangeFrom1toNum_UsingFor(int Num) {
    cout << "Range printed using For Statement: \n";
    for (int Counter = Num; Counter > 1; Counter--) {
        cout << Counter << endl;
    }
}

void PrintRangeFrom1toNum_UsingWhile(int Num) {
    int Counter = Num + 1;
    cout << "Range printed using While Statement: \n";
    while (Counter > 1) {
        Counter--;
        cout << Counter << endl;
    }
}

void PrintRangeFrom1toNum_UsingDoWhile(int Num) {
    int Counter = Num + 1;
    cout << "Range printed using Do While Statement: \n";
    do {
        Counter--;
        cout << Counter << endl;
    } while (Counter > 1);
}

int main() {
    int Num = ReadNumber();
    PrintRangeFrom1toNum_UsingFor(Num);
    PrintRangeFrom1toNum_UsingWhile(Num);
    PrintRangeFrom1toNum_UsingDoWhile(Num);
}
```

---

## حل المشكلة 28
### برنامج يطلب من المستخدم إدخال رقم ثم يجمع الأعداد الفردية

```cpp
#include <iostream>
#include <string>
using namespace std;

enum enOddOrEven { Odd = 1, Even = 2 };

int ReadNumber() {
    int Num;
    cout << "Pleas enter a Number ? \n";
    cin >> Num;
    return Num;
}

enOddOrEven CheckOddEven(int Number) {
    if (Number % 2 != 0)
        return enOddOrEven::Odd;
    else
        return enOddOrEven::Even;
}

int SumOddFrom1toNum_UsingFor(int Num) {
    cout << "Sum Odd Numbers using For Statement: \n";
    int Sum = 0;
    for (int Counter = 1; Counter <= Num; Counter++) {
        if (CheckOddEven(Counter) == enOddOrEven::Odd) {
            Sum += Counter;
        }
    }
    return Sum;
}

int SumOddFrom1toNum_UsingWhile(int Num) {
    int Counter = 0;
    int Sum = 0;
    cout << "Sum Odd Numbers using While Statement: \n";
    while (Counter < Num) {
        Counter++;
        if (CheckOddEven(Counter) == enOddOrEven::Odd) {
            Sum += Counter;
        }
    }
    return Sum;
}

int SumOddFrom1toNum_UsingDoWhile(int Num) {
    int Counter = 0;
    int Sum = 0;
    cout << "Sum Odd Numbers using Do While Statement: \n";
    do {
        if (CheckOddEven(Counter) == enOddOrEven::Odd) {
            Sum += Counter;
        }
        Counter++;
    } while (Counter <= Num);
    return Sum;
}

int main() {
    int Num = ReadNumber();
    cout << SumOddFrom1toNum_UsingFor(Num) << endl;
    cout << SumOddFrom1toNum_UsingWhile(Num) << endl;
    cout << SumOddFrom1toNum_UsingDoWhile(Num) << endl;
}
```

---

## حل المشكلة 29
### برنامج يطلب من المستخدم إدخال رقم ثم يجمع الأعداد الزوجية

```cpp
#include <iostream>
#include <string>
using namespace std;

enum enOddOrEvenOrAll { Odd = 1, Even = 2, All = 3 };

int ReadNumber() {
    int Num;
    cout << "Pleas enter a Number ? \n";
    cin >> Num;
    return Num;
}

enOddOrEvenOrAll CheckOddOrEvenOrALl(int Number) {
    if (Number % 2 != 0)
        return enOddOrEvenOrAll::Odd;
    else
        return enOddOrEvenOrAll::Even;
}

int SumEvenFrom1toNum_UsingFor(int Num) {
    cout << "Sum Even Numbers using For Statement: \n";
    int Sum = 0;
    for (int Counter = 1; Counter <= Num; Counter++) {
        if (CheckOddOrEvenOrALl(Counter) == enOddOrEvenOrAll::Even) {
            Sum += Counter;
        }
    }
    return Sum;
}

int SumEvenFrom1toNum_UsingWhile(int Num) {
    int Counter = 0;
    int Sum = 0;
    cout << "Sum Even Numbers using While Statement: \n";
    while (Counter <= Num) {
        if (CheckOddOrEvenOrALl(Counter) == enOddOrEvenOrAll::Even) {
            Sum += Counter;
        }
        Counter++;
    }
    return Sum;
}

int SumEvenFrom1toNum_UsingDoWhile(int Num) {
    int Counter = 0;
    int Sum = 0;
    cout << "Sum Even Numbers using Do While Statement: \n";
    do {
        if (CheckOddOrEvenOrALl(Counter) == enOddOrEvenOrAll::Even) {
            Sum += Counter;
        }
        Counter++;
    } while (Counter <= Num);
    return Sum;
}

int main() {
    int Num = ReadNumber();
    cout << SumEvenFrom1toNum_UsingFor(Num) << endl;
    cout << SumEvenFrom1toNum_UsingWhile(Num) << endl;
    cout << SumEvenFrom1toNum_UsingDoWhile(Num) << endl;
}
```

---

## حل المشكلة 30
### برنامج يطلب من المستخدم إدخال رقم موجب فقط ثم يضرب الأعداد الأقل منه

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadPOsitiveNumber(string Message) {
    int Number;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

int Factorial(int Num) {
    int Factorial = 1;
    for (int Counter = Num; Counter >= 1; Counter--) {
        Factorial *= Counter;
    }
    return Factorial;
}

int main() {
    cout << Factorial(ReadPOsitiveNumber("Pleas enter a Positive Number ?")) << endl;
}
```

---

## حل المشكلة 31
### برنامج يطلب من المستخدم إدخال رقم ثم يضربه في القوة 2 و 3 و 4

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadNumber() {
    int Number;
    cout << "Pleas enter a Number?" << endl;
    cin >> Number;
    return Number;
}

void PowerOf2_3_4(int Number) {
    int a, b, c;
    a = Number * Number;
    b = Number * Number * Number;
    c = Number * Number * Number * Number;
    cout << a << " " << b << " " << c << endl;
}

int main() {
    PowerOf2_3_4(ReadNumber());
}
```

---

## حل المشكلة 32
### برنامج يطلب من المستخدم إدخال رقمين، الأساس هو الرقم الأول والثاني هو الأس

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadNumber() {
    int Number;
    cout << "Pleas enter a Number?" << endl;
    cin >> Number;
    return Number;
}

int ReadPower() {
    int Power;
    cout << "Pleas enter the Power?" << endl;
    cin >> Power;
    return Power;
}

int PowerOfM(int Number, int M) {
    if (M == 0)
        return 1;
    int P = 1;
    for (int i = 1; i <= M; i++) {
        P *= Number;
    }
    return P;
}

int main() {
    cout << "Result = " << PowerOfM(ReadNumber(), ReadPower());
}
```

---

## حل المشكلة 33
### برنامج يطلب من المستخدم إدخال درجة الاختبار ثم يطبع الدرجة كالتالي: 90-100 = A، 80-89 = B، 70-79 = C، 60-69 = D، 50-59 = E، أقل من 50 = F

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadNumberInRange(int Form, int To) {
    int Grade;
    do {
        cout << "Pleas enter a Grade between 0 and 100 ? \n";
        cin >> Grade;
    } while (Grade < Form || Grade > To);
    return Grade;
}

char GetGradeLetter(int Grade) {
    if (Grade >= 90)
        return 'A';
    else if (Grade >= 80)
        return 'B';
    else if (Grade >= 70)
        return 'C';
    else if (Grade >= 60)
        return 'D';
    else if (Grade >= 50)
        return 'E';
    else
        return 'F';
}

int main() {
    cout << "Result = " << GetGradeLetter(ReadNumberInRange(0, 100)) << endl;
}
```

---

## حل المشكلة 34
### برنامج يطلب من المستخدم إدخال إجمالي المبيعات فإذا باع أكثر من مليون يعطى نسبة 1%، أكثر من 500 ألف 2%، أكثر من 100 ألف 3%، أكثر من 50 ألف 5%، أقل من 50 ألف 0%

```cpp
#include <iostream>
#include <string>
using namespace std;

int ReadTotalSales() {
    int TotalSales;
    cout << "Pleas enter a Total Sales ? \n";
    cin >> TotalSales;
    return TotalSales;
}

float GetComissionPercentage(float TotalSales) {
    if (TotalSales >= 1000000)
        return 0.01;
    else if (TotalSales >= 500000)
        return 0.02;
    else if (TotalSales >= 100000)
        return 0.03;
    else if (TotalSales >= 50000)
        return 0.05;
    else
        return 0.00;
}

float CalculateTotalComission(float TotalSales) {
    return GetComissionPercentage(TotalSales) * TotalSales;
}

int main() {
    float TotalSales = ReadTotalSales();
    cout << endl << "Comission Percentage = " << GetComissionPercentage(TotalSales) << endl;
    cout << endl << "Total Comission = " << CalculateTotalComission(TotalSales) << endl;
}
```

---

## حل المشكلة 35
### برنامج يطلب من المستخدم إدخال البنس، النيكل، الدايم، الربع دولار، الدولار ثم يحسب إجمالي البنسات وإجمالي الدولارات

```cpp
#include <iostream>
#include <string>
using namespace std;

struct stPiggyBankContenet {
    int Pennies, Nickels, Dimes, Quarters, Dollars;
};

stPiggyBankContenet ReadPiggyBankContenet() {
    stPiggyBankContenet PiggyBankContenet;
    cout << "Pleas enter a Total Pennies ? \n";
    cin >> PiggyBankContenet.Pennies;
    cout << "Pleas enter a Total Nickels ? \n";
    cin >> PiggyBankContenet.Nickels;
    cout << "Pleas enter a Total Dimes ? \n";
    cin >> PiggyBankContenet.Dimes;
    cout << "Pleas enter a Total Quarters ? \n";
    cin >> PiggyBankContenet.Quarters;
    cout << "Pleas enter a Total Dollars ? \n";
    cin >> PiggyBankContenet.Dollars;
    return PiggyBankContenet;
}

int CalculateTotalPennies(stPiggyBankContenet PiggyBankContenet) {
    int TotalPennies = 0;
    TotalPennies = PiggyBankContenet.Pennies * 1 +
                   PiggyBankContenet.Nickels * 5 +
                   PiggyBankContenet.Dimes * 10 +
                   PiggyBankContenet.Quarters * 25 +
                   PiggyBankContenet.Dollars * 100;
    return TotalPennies;
}

int main() {
    int TotalPennies = CalculateTotalPennies(ReadPiggyBankContenet());
    cout << endl << "Total Pennies = " << TotalPennies << endl;
    cout << endl << "Total Dollars = " << (float)TotalPennies / 100 << endl;
}
```

---

## حل المشكلة 36
### برنامج يطلب من المستخدم إدخال رقمين ونوع العملية (+ - * /)

```cpp
#include <iostream>
#include <string>
using namespace std;

enum enOperationType { Add = '+', Subtract = '-', Multiply = '*', Divide = '/' };

float ReadNumber(string Message) {
    float Number = 0;
    cout << Message << endl;
    cin >> Number;
    return Number;
}

enOperationType ReadType() {
    char OT = '+';
    cout << "Pleas enter Operation Type ( + , - , * , / )? \n";
    cin >> OT;
    return (enOperationType)OT;
}

float Calculate(float Number1, float Number2, enOperationType OpType) {
    switch (OpType) {
        case enOperationType::Add:
            return Number1 + Number2;
        case enOperationType::Subtract:
            return Number1 - Number2;
        case enOperationType::Multiply:
            return Number1 * Number2;
        case enOperationType::Divide:
            return Number1 / Number2;
        default:
            return Number1 + Number2;
    }
}

int main() {
    float Number1 = ReadNumber("Pleas enter the first Number ?");
    float Number2 = ReadNumber("Pleas enter the second Number ?");
    enOperationType OpType = ReadType();
    cout << endl << " Result = " << Calculate(Number1, Number2, OpType) << endl;
}
```

---

## حل المشكلة 37
### برنامج لقراءة الأرقام من المستخدم ويستمر في القراءة حتى يدخل -99 ثم يطبع المجموع على الشاشة

```cpp
#include <iostream>
#include <string>
using namespace std;

float ReadNumber(string Message) {
    float Number = 0;
    cout << Message << endl;
    cin >> Number;
    return Number;
}

float SumNumbers() {
    int Sum = 0, Number = 0, Counter = 1;
    do {
        Number = ReadNumber("Pleas enter a Number " + to_string(Counter));
        if (Number == -99)
            break;
        Sum += Number;
        Counter++;
    } while (Number != -99);
    return Sum;
}

int main() {
    cout << endl << " Result = " << SumNumbers() << endl;
}
```

---

## حل المشكلة 38
### برنامج لقراءة رقم والتحقق مما إذا كان أولي أم لا

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

enum enPrimNotPrime { Prime = 1, NotPrime = 2 };

float ReadPositiveNumber(string Message) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

enPrimNotPrime CheckPrime(int Number) {
    int M = round(Number / 2);
    for (int Counter = 2; Counter <= M; Counter++) {
        if (Number % Counter == 0)
            return enPrimNotPrime::NotPrime;
    }
    return enPrimNotPrime::Prime;
}

void PrintNumberType(int Number) {
    switch (CheckPrime(Number)) {
        case enPrimNotPrime::Prime:
            cout << "The number is Prime \n";
            break;
        case enPrimNotPrime::NotPrime:
            cout << "The number is Not Prime \n";
            break;
    }
}

int main() {
    PrintNumberType(ReadPositiveNumber("Pleas enter a positive number "));
}
```

---

## حل المشكلة 39
### برنامج لقراءة الفاتورة والمبلغ المدفوع ثم يحسب الباقي

```cpp
#include <iostream>
#include <string>
using namespace std;

float ReadPositiveNumber(string Message) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

float CalculatRemainder(float TotalBill, float TotalCashPaid) {
    return TotalCashPaid - TotalBill;
}

void PrintRemainder() {
    float TotalBill = ReadPositiveNumber("Pleas Enter Total Bill?");
    float TotalCashPaid = ReadPositiveNumber("Pleas Enter Total Cash Paid ?");
    cout << endl;
    cout << "Total Bill = " << TotalBill << endl;
    cout << "Total Cash Paid = " << TotalCashPaid << endl;
    cout << "************************\n";
    cout << "Remainder = " << CalculatRemainder(TotalBill, TotalCashPaid) << endl;
}

int main() {
    PrintRemainder();
}
```

---

## حل المشكلة 40
### برنامج لقراءة قيمة الفاتورة وإضافة رسوم خدمة 10% وضريبة مبيعات 16% ثم يطبع إجمالي الفاتورة

```cpp
#include <iostream>
#include <string>
using namespace std;

float ReadPositiveNumber(string Message) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

float TotalBillAfterServiceAndTax(float TotalBill) {
    TotalBill *= 1.1;
    TotalBill *= 1.16;
    return TotalBill;
}

void PrintTotalBillAfterServiceAndTax() {
    float TotalBill = ReadPositiveNumber("Pleas Enter Total Bill?");
    cout << endl;
    cout << "Total Bill = " << TotalBill << endl;
    cout << "Total Bill After service Fee and Sales Tax = " << TotalBillAfterServiceAndTax(TotalBill) << endl;
}

int main() {
    PrintTotalBillAfterServiceAndTax();
}
```

---

## حل المشكلة 41
### برنامج لقراءة عدد الساعات وحساب عدد الأيام والأسابيع الموجودة في هذا العدد

```cpp
#include <iostream>
#include <string>
using namespace std;

float ReadPositiveNumber(string Message) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

float HoursToDays(float NumberOfHours) {
    return (float)NumberOfHours / 24;
}

float HoursToWeeks(float NumberOfHours) {
    return (float)NumberOfHours / 24 / 7;
}

float DaysToWeeks(float NumberOfDays) {
    return (float)NumberOfDays / 7;
}

void PrintConvertHoursIntoDaysAndWeeks() {
    float NumberOfHours = ReadPositiveNumber("Pleas Enter Number of Hours? ");
    float HoursOfDays = HoursToDays(NumberOfHours);
    cout << endl;
    cout << "Total Hours = " << NumberOfHours << endl;
    cout << "Total Days = " << HoursOfDays << endl;
    cout << "Total Weeks = " << HoursToWeeks(NumberOfHours) << endl;
}

int main() {
    PrintConvertHoursIntoDaysAndWeeks();
}
```

---

## حل المشكلة 42
### برنامج يدخل الأيام والساعات والدقائق والثواني ويحولها إلى ثواني

```cpp
#include <iostream>
#include <string>
using namespace std;

struct strTaskDuration {
    int NumberOfDays, NumberOfHours, NumberOfMinutes, NumberOfSeconds;
};

int ReadPositiveNumber(string Message) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

strTaskDuration ReadTaskDuration() {
    strTaskDuration TaskDuration;
    TaskDuration.NumberOfDays = ReadPositiveNumber("Pleas Enter Number Of Days ? ");
    TaskDuration.NumberOfHours = ReadPositiveNumber("Pleas Enter Number Of Hours ? ");
    TaskDuration.NumberOfMinutes = ReadPositiveNumber("Pleas Enter Number Of Minutes ? ");
    TaskDuration.NumberOfSeconds = ReadPositiveNumber("Pleas Enter Number Of Seconds ? ");
    return TaskDuration;
}

int TaskDurationInSeconds(strTaskDuration TaskDuration) {
    int DurationInSeconds = 0;
    DurationInSeconds = TaskDuration.NumberOfDays * 24 * 60 * 60;
    DurationInSeconds += TaskDuration.NumberOfHours * 60 * 60;
    DurationInSeconds += TaskDuration.NumberOfMinutes * 60;
    DurationInSeconds += TaskDuration.NumberOfSeconds;
    return DurationInSeconds;
}

int main() {
    cout << endl << "Task Duration In Seconds : " << TaskDurationInSeconds(ReadTaskDuration()) << endl;
}
```

---

## حل المشكلة 43
### برنامج يدخل عدد الثواني ويحولها إلى أيام وساعات ودقائق وثواني

```cpp
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

struct strTaskDuration {
    int NumberOfDays, NumberOfHours, NumberOfMinutes, NumberOfSeconds;
};

int ReadPositiveNumber(string Message) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

strTaskDuration SecondsToTaskDuration(int TotalSeconds) {
    strTaskDuration TaskDuration;
    const int SecondsPerDay = 24 * 60 * 60;
    const int SecondsPerHours = 60 * 60;
    const int SecondsPerMinute = 60;
    int Remainder = 0;

    TaskDuration.NumberOfDays = floor(TotalSeconds / SecondsPerDay);
    Remainder = TotalSeconds % SecondsPerDay;
    TaskDuration.NumberOfHours = floor(Remainder / SecondsPerHours);
    Remainder = Remainder % SecondsPerHours;
    TaskDuration.NumberOfMinutes = floor(Remainder / SecondsPerMinute);
    Remainder = Remainder % SecondsPerMinute;
    TaskDuration.NumberOfSeconds = Remainder;

    return TaskDuration;
}

void PrintTaskDurationDetils(strTaskDuration TaskDuration) {
    cout << endl;
    cout << TaskDuration.NumberOfDays << ":"
         << TaskDuration.NumberOfHours << ":"
         << TaskDuration.NumberOfMinutes << ":"
         << TaskDuration.NumberOfSeconds << "\n";
}

int main() {
    int TotalSeconds = ReadPositiveNumber("Pleas Enter Total Seconds ?");
    PrintTaskDurationDetils(SecondsToTaskDuration(TotalSeconds));
}
```

---

## حل المشكلة 44
### برنامج يطلب من المستخدم إدخال اليوم (الاحد = 1، الاثنين = 2، الثلاثاء = 3، الاربعاء = 4، الخميس = 5، الجمعة = 6، السبت = 7)

```cpp
#include <iostream>
#include <string>
using namespace std;

enum enDayOfWeek { Sat = 1, Sun = 2, Mon = 3, Tue = 4, Wed = 5, Thu = 6, Fri = 7 };

int ReadNumberInRange(string Message, int From, int To) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number < From || Number > To);
    return Number;
}

enDayOfWeek ReadDayOfWeek() {
    return (enDayOfWeek)ReadNumberInRange("Pleas enter day number [Sat = 1 , Sun = 2 , Mon =3 , Tue =4 , Wed =5 , Thu = 6 , Fri = 7]?", 1, 7);
}

string GetDayOfWeek(enDayOfWeek Day) {
    switch (Day) {
        case enDayOfWeek::Sat: return "Saturday";
        case enDayOfWeek::Sun: return "Sunday";
        case enDayOfWeek::Mon: return "Monday";
        case enDayOfWeek::Tue: return "Tuesday";
        case enDayOfWeek::Wed: return "Wednesday";
        case enDayOfWeek::Thu: return "Thursday";
        case enDayOfWeek::Fri: return "Friday";
        default: return "Not a valid Day";
    }
}

int main() {
    cout << GetDayOfWeek(ReadDayOfWeek()) << endl;
}
```

---

## حل المشكلة 45
### برنامج يطلب من المستخدم إدخال الشهر (1 = يناير، 2 = فبراير، 3 = مارس، 4 = أبريل، 5 = مايو، 6 = يونيو، 7 = يوليو، 8 = أغسطس، 9 = سبتمبر، 10 = أكتوبر، 11 = نوفمبر، 12 = ديسمبر)

```cpp
#include <iostream>
#include <string>
using namespace std;

enum enMonthOfYears { Jan = 1, Feb = 2, Mar = 3, Apr = 4, May = 5, Jun = 6, Jul = 7, Aug = 8, Sep = 9, Oct = 10, Nov = 11, Dec = 12 };

int ReadNumberInRange(string Message, int From, int To) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number < From || Number > To);
    return Number;
}

enMonthOfYears ReadMonthOfYears() {
    return (enMonthOfYears)ReadNumberInRange("Pleas enter Month number [ 1 to 12 ]?", 1, 12);
}

string GetMonthOfYears(enMonthOfYears Month) {
    switch (Month) {
        case enMonthOfYears::Jan: return "January";
        case enMonthOfYears::Feb: return "February";
        case enMonthOfYears::Mar: return "March";
        case enMonthOfYears::Apr: return "April";
        case enMonthOfYears::May: return "May";
        case enMonthOfYears::Jun: return "June";
        case enMonthOfYears::Jul: return "July";
        case enMonthOfYears::Aug: return "August";
        case enMonthOfYears::Sep: return "September";
        case enMonthOfYears::Oct: return "October";
        case enMonthOfYears::Nov: return "November";
        case enMonthOfYears::Dec: return "December";
        default: return "Not a valid Month";
    }
}

int main() {
    cout << GetMonthOfYears(ReadMonthOfYears()) << endl;
}
```

---

## حل المشكلة 46
### برنامج لطباعة جميع الحروف من A إلى Z

```cpp
#include <iostream>
using namespace std;

void PrintLettersAtoZ() {
    for (int i = 65; i <= 90; i++) {
        cout << char(i) << endl;
    }
}

int main() {
    PrintLettersAtoZ();
}
```

---

## حل المشكلة 47
### برنامج لقراءة القرض والقسط الشهري وحساب عدد الأشهر التي تحتاجها لتسوية القرض

```cpp
#include <iostream>
#include <string>
using namespace std;

float ReadPositiveNumber(string Message) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

float TotalMonths(float LoanAmiount, float MonthlyInstallment) {
    return (float)LoanAmiount / MonthlyInstallment;
}

int main() {
    float LoanAmiount = ReadPositiveNumber("Pleas Enter Loan Amiount ?");
    float MonthlyInstallment = ReadPositiveNumber("Pleas Enter Monthly Installmentt ?");
    cout << "\n Total Months to pay = " << TotalMonths(LoanAmiount, MonthlyInstallment) << endl;
}
```

---

## حل المشكلة 48
### برنامج لقراءة القرض وعدد الأشهر وحساب القسط الشهري

```cpp
#include <iostream>
#include <string>
using namespace std;

float ReadPositiveNumber(string Message) {
    float Number = 0;
    do {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

float MonthlyInstallment(float LoanAmiount, float HowManMonths) {
    return (float)LoanAmiount / HowManMonths;
}

int main() {
    float LoanAmiount = ReadPositiveNumber("Pleas Enter Loan Amiount ?");
    float HowManMonths = ReadPositiveNumber("How Man Months ?");
    cout << "\n Monthly Installment = " << MonthlyInstallment(LoanAmiount, HowManMonths) << endl;
}
```

---

## حل المشكلة 49
### برنامج لقراءة الرقم السري للصراف الآلي من المستخدم والتحقق من صحته (الرقم السري = 1234)

```cpp
#include <iostream>
#include <string>
using namespace std;

string ReadPinCode() {
    string Pincode;
    cout << "Pleas Enter PIN Code \n";
    cin >> Pincode;
    return Pincode;
}

bool Login() {
    string PinCode;
    do {
        PinCode = ReadPinCode();
        if (PinCode == "1234") {
            return true;
        } else {
            cout << "\nWrong PIN \n";
            system("color 4F");
        }
    } while (PinCode != "1234");
}

int main() {
    if (Login()) {
        system("color 2F");
        cout << "\n Your account balance is " << 7500 << '\n';
    }
}
```

---

## حل المشكلة 50
### برنامج لقراءة الرقم السري للصراف الآلي من المستخدم والتحقق من صحته (الرقم السري = 1234) مع إعطاء 3 محاولات فقط

```cpp
#include <iostream>
#include <string>
using namespace std;

string ReadPinCode() {
    string Pincode;
    cout << "Pleas Enter PIN Code \n";
    cin >> Pincode;
    return Pincode;
}

bool Login() {
    string PinCode;
    int Counter = 3;
    do {
        Counter--;
        PinCode = ReadPinCode();
        if (PinCode == "1234") {
            return true;
        } else {
            cout << "\nWrong PIN , you have " << Counter << " more tries \n";
            system("color 4F");
        }
    } while (PinCode != "1234" && Counter >= 1);
    return false;
}

int main() {
    if (Login()) {
        system("color 2F");
        cout << "\n Your account balance is " << 7500 << '\n';
    } else {
        cout << "\n Your card blocked call the bank for help. \n";
    }
}
```


# Problems Title and Code

## Problem 1
Print Multiplication Table from 1 to 10

```cpp
#include<iostream>
using namespace std;

void PrintTableHeader()
{
    cout << "\n\n\t\t\t Multipliaction Table From 1 to 10\n\n";
    cout << "\t";
    for (int i = 1; i <= 10; i++)
    {
        cout << i << "\t";
    }
    cout << "\n___________________________________________________________________________________\n";
}

string ColumnSperator(int i)
{
    if (i < 10)
        return"   |";
    else
        return"  |";
}

void PrintMultiplicationTable()
{
    PrintTableHeader();
    for (int i = 1; i <= 10; i++)
    {
        cout << " " << i << ColumnSperator(i) << "\t";
        for (int j = 1; j <= 10; j++)
        {
            cout << j * i << "\t";
        }
        cout << endl;
    }
}

int main()
{
    PrintMultiplicationTable();
}
```

---

## Problem 2
Print Prime Numbers from 1 to N

```cpp
#include <iostream>
using namespace std;

enum enPrimNotPrime { Prime = 1, NotPrime = 2 };

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

enPrimNotPrime CheckPrime(int Number)
{
    int M = round(Number / 2);
    for (int Counter = 2; Counter <= M; Counter++)
    {
        if (Number % Counter == 0)
            return enPrimNotPrime::NotPrime;
    }
    return enPrimNotPrime::Prime;
}

void PrintPrimeNumbersFrom1ToNumber(int Number)
{
    cout << "\n Prime Numbers from " << 1 << " To " << Number << " are : \n";
    for (int i = 1; i <= Number; i++)
    {
        if (CheckPrime(i) == enPrimNotPrime::Prime)
        {
            cout << i << endl;
        }
    }
}

int main()
{
    PrintPrimeNumbersFrom1ToNumber(ReadPositiveNumber("Pleas enter a positive number "));
}
```

---

## Problem 3
Check if Number is Perfect

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

bool IsPerfectNumber(int Number)
{
    int Sum = 0;
    for (int i = 1; i < Number; i++)
    {
        if (Number % i == 0)
            Sum += i;
    }
    return Number == Sum;
}

void PrintResult(int Number)
{
    if (IsPerfectNumber(Number))
        cout << "\n " << Number << " Is Perfect Number \n";
    else
        cout << "\n " << Number << " Is Not Perfect Number \n";
}

int main()
{
    PrintResult(ReadPositiveNumber("Pleas enter a positive number "));
}
```

---

## Problem 4
Print All Perfect Numbers from 1 to N

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

bool IsPerfectNumber(int Number)
{
    int Sum = 0;
    for (int i = 1; i < Number; i++)
    {
        if (Number % i == 0)
            Sum += i;
    }
    return Number == Sum;
}

void PrintPerfectNumberFrom1ToNum(int Number)
{
    cout << "\n";
    for (int i = 1; i < Number; i++)
    {
        if (IsPerfectNumber(i))
            cout << i << endl;
    }
}

int main()
{
    PrintPerfectNumberFrom1ToNum(ReadPositiveNumber("Pleas enter a positive number ? "));
}
```

---

## Problem 5
Print Digits in Reverse Order

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

void PrintDigits(int Number)
{
    int Remainder = 0;
    while (Number > 0)
    {
        Remainder = Number % 10;
        Number = Number / 10;
        cout << Remainder << endl;
    }
}

int main()
{
    PrintDigits(ReadPositiveNumber("Pleas enter a positie Number ?"));
}
```

---

## Problem 6
Sum of Digits

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

int PrintSumOfDigits(int Number)
{
    int Sum = 0, Remainder = 0;
    while (Number > 0)
    {
        Remainder = Number % 10;
        Number = Number / 10;
        Sum = Sum + Remainder;
    }
    return Sum;
}

int main()
{
    cout << "\n Sum Of Digits = " << PrintSumOfDigits(ReadPositiveNumber("Pleas enter a positie Number ?")) << endl;
}
```

---

## Problem 7
Reverse Number

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

int ReverseNumbers(int Number)
{
    int Remainder = 0, Number2 = 0;
    while (Number > 0)
    {
        Remainder = Number % 10;
        Number = Number / 10;
        Number2 = Number2 * 10 + Remainder;
    }
    return Number2;
}

int main()
{
    cout << "\n Reverse is : \n " << ReverseNumbers(ReadPositiveNumber("Pleas enter a positie Number ?"));
}
```

---

## Problem 8
Count Digit Frequency

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

int CountDigitFrequency(int Number, short DigitToCheck)
{
    int Remainder = 0;
    short FreqCount = 0;
    while (Number > 0)
    {
        Remainder = Number % 10;
        Number = Number / 10;
        if (DigitToCheck == Remainder)
        {
            FreqCount++;
        }
    }
    return FreqCount;
}

int main()
{
    int Number = ReadPositiveNumber("Pleas enter the main Number ?");
    short DigitToCheck = ReadPositiveNumber("Pleas enter one digit to check ?");
    cout << "\n Digit " << DigitToCheck << " Frequency is " << CountDigitFrequency(Number, DigitToCheck) << " Time(s). \n";
    return 0;
}
```

---

## Problem 9
Print All Digits Frequency

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

int CountDigitFrequency(int Number, short DigitToCheck)
{
    int Remainder = 0;
    short FreqCount = 0;
    while (Number > 0)
    {
        Remainder = Number % 10;
        Number = Number / 10;
        if (DigitToCheck == Remainder)
        {
            FreqCount++;
        }
    }
    return FreqCount;
}

void PrintAllDigitsFrequency(int Number)
{
    for (int i = 0; i < 10; i++)
    {
        short DigitFrequency = 0;
        DigitFrequency = CountDigitFrequency(Number, i);
        if (DigitFrequency > 0)
        {
            cout << "\n Digit " << i << " Frequency is " << DigitFrequency << " Time(s). \n";
        }
    }
}

int main()
{
    int Number = ReadPositiveNumber("Pleas enter the main Number ?");
    PrintAllDigitsFrequency(Number);
    return 0;
}
```

---

## Problem 10
Reverse and Print Digits

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

int ReverseNumbers(int Number)
{
    int Remainder = 0;
    int Number2 = 0;
    while (Number > 0)
    {
        Remainder = Number % 10;
        Number /= 10;
        Number2 = Number2 * 10 + Remainder;
    }
    return Number2;
}

void PrintDigits(int Number)
{
    int Remainder = 0;
    while (Number > 0)
    {
        Remainder = Number % 10;
        Number /= 10;
        cout << Remainder << endl;
    }
}

int main()
{
    PrintDigits(ReverseNumbers(ReadPositiveNumber("Pleas enter a positie Number ?")));
}
```

---

## Problem 11
Check if Number is Palindrome

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

int ReverseNumbers(int Number)
{
    int Remainder = 0;
    int Number2 = 0;
    while (Number > 0)
    {
        Remainder = Number % 10;
        Number /= 10;
        Number2 = Number2 * 10 + Remainder;
    }
    return Number2;
}

bool IsPalindrome(int Number)
{
    return Number == ReverseNumbers(Number);
}

int main()
{
    if (IsPalindrome(ReverseNumbers(ReadPositiveNumber("Pleas enter a positie Number ?"))))
        cout << "\n Yes , it is a Palindrome number \n";
    else
        cout << "\n No , it is NOT a Palindrome number \n";
}
```

---

## Problem 12
Print Inverted Number Pattern

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

void PrintInvertedNumberPattern(int Number)
{
    cout << "\n";
    for (int i = Number; i >= 1; i--)
    {
        for (int j = 1; j <= i; j++)
        {
            cout << i;
        }
        cout << endl;
    }
}

int main()
{
    PrintInvertedNumberPattern(ReadPositiveNumber("Pleas enter a positie Number ?"));
}
```

---

## Problem 13
Print Number Pattern

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

void PrintNumberPattern(int Number)
{
    cout << "\n";
    for (int i = 1; i <= Number; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            cout << i;
        }
        cout << endl;
    }
}

int main()
{
    PrintNumberPattern(ReadPositiveNumber("Pleas enter a positie Number ?"));
}
```

---

## Problem 14
Print Inverted Letter Pattern

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);
    return Number;
}

void PrintInvertedLetterPattern(int Number)
{
    cout << "\n";
    for (int i = 65 + Number - 1; i >= 65; i--)
    {
        for (int j = 1; j <= Number - (65 + Number - 1 - i); j++)
        {
            cout << char(i);
        }
        cout << endl;
    }
}

int main()
{
    PrintInvertedLetterPattern(ReadPositiveNumber("Pleas enter a Positive Number ?"));
}
```

---

## Problem 15
Print Letter Pattern

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);
    return Number;
}

void PrintLetterPattern(int Number)
{
    cout << "\n";
    for (int i = 65; i <= 65 + Number - 1; i++)
    {
        for (int j = 1; j <= i - 65 + 1; j++)
        {
            cout << char(i);
        }
        cout << endl;
    }
}

int main()
{
    PrintLetterPattern(ReadPositiveNumber("Pleas enter a Positive Number ?"));
}
```

---

## Problem 16
Print Words from AAA to ZZZ

```cpp
#include <iostream>
using namespace std;

void PrintWordsFromAAAtoZZZ()
{
    cout << "\n";
    string Word = "";
    for (int i = 65; i <= 90; i++)
    {
        for (int j = 65; j <= 90; j++)
        {
            for (int k = 65; k <= 90; k++)
            {
                Word = Word + char(i);
                Word = Word + char(j);
                Word = Word + char(k);
                cout << Word << endl;
                Word = "";
            }
        }
        cout << "\n______________________________\n";
    }
}

int main()
{
    PrintWordsFromAAAtoZZZ();
}
```

---

## Problem 17
Guess Password

```cpp
#include <iostream>
using namespace std;

string ReadPassword()
{
    string Password;
    cout << "Pleas enter a 3-Letter Password (all capital) ? \n";
    cin >> Password;
    return Password;
}

bool GuessPassword(string OriginalPassword)
{
    cout << "\n";
    string Word = "";
    int Counter = 0;
    for (int i = 65; i <= 90; i++)
    {
        for (int j = 65; j <= 90; j++)
        {
            for (int k = 65; k <= 90; k++)
            {
                Counter++;
                Word = Word + char(i);
                Word = Word + char(j);
                Word = Word + char(k);
                cout << "Trial [" << Counter << "] : " << Word << endl;
                if (Word == OriginalPassword)
                {
                    cout << "\nPassword is : " << OriginalPassword << endl;
                    cout << "Found after " << Counter << " Trial(s)\n";
                    return true;
                }
                Word = "";
            }
        }
    }
    return false;
}

int main()
{
    GuessPassword(ReadPassword());
}
```

---

## Problem 18
Encrypt and Decrypt Text

```cpp
#include <iostream>
#include <string>
using namespace std;

string ReadText()
{
    string Text;
    cout << "Pleas enter Text ? \n";
    getline(cin, Text);
    return Text;
}

string EncryptText(string Text, short EncryptionKey)
{
    for (int i = 0; i <= Text.length(); i++)
    {
        Text[i] = char((int)Text[i] + EncryptionKey);
    }
    return Text;
}

string DecryptionText(string Text, short EncryptionKey)
{
    for (int i = 0; i <= Text.length(); i++)
    {
        Text[i] = char((int)Text[i] - EncryptionKey);
    }
    return Text;
}

int main()
{
    const short EncryptionKey = 2;
    string Text = ReadText();
    string TextAfterEncryption = EncryptText(Text, EncryptionKey);
    string TextAfterDecryption = DecryptionText(TextAfterEncryption, EncryptionKey);
    cout << endl << "Text Before Encryption : " << Text << endl;
    cout << "Text After Encryption : " << TextAfterEncryption << endl;
    cout << "Text After Decryption : " << TextAfterDecryption << endl;
}
```

---

## Problem 19
Generate Random Number

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

int main()
{
    srand((unsigned)time(NULL));
    cout << RandomNumber(1, 10) << endl;
    cout << RandomNumber(1, 10) << endl;
    cout << RandomNumber(1, 10) << endl;
}
```

---

## Problem 20
Generate Random Character

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

enum enCharTayp {SmallLetter = 1, CapitalLetter = 2 , SpecialCharacter = 3, Digit = 4};

char GetRandomCharacter(enCharTayp CharType)
{
    switch (CharType)
    {
        case enCharTayp::SmallLetter:
        {
            return char(RandomNumber(97, 122));
            break;
        }
        case enCharTayp::CapitalLetter:
        {
            return char(RandomNumber(65, 90));
            break;
        }
        case enCharTayp::SpecialCharacter:
        {
            return char(RandomNumber(33, 47));
            break;
        }
        case enCharTayp::Digit:
        {
            return char(RandomNumber(48, 57));
            break;
        }
    }
}

int main()
{
    srand((unsigned)time(NULL));
    cout << GetRandomCharacter(enCharTayp::SmallLetter) << endl;
    cout << GetRandomCharacter(enCharTayp::CapitalLetter) << endl;
    cout << GetRandomCharacter(enCharTayp::SpecialCharacter) << endl;
    cout << GetRandomCharacter(enCharTayp::Digit) << endl;
}
```

---

## Problem 21
Generate Keys

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

enum enCharTayp { SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4 };

char GetRandomCharacter(enCharTayp CharType)
{
    switch (CharType)
    {
        case enCharTayp::SmallLetter:
        {
            return char(RandomNumber(97, 122));
            break;
        }
        case enCharTayp::CapitalLetter:
        {
            return char(RandomNumber(65, 90));
            break;
        }
        case enCharTayp::SpecialCharacter:
        {
            return char(RandomNumber(33, 47));
            break;
        }
        case enCharTayp::Digit:
        {
            return char(RandomNumber(48, 57));
            break;
        }
    }
}

int ReadPositiveNumber(string Message)
{
    int Number;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);
    return Number;
}

string GenerateWord(enCharTayp CharType, short Length)
{
    string Word;
    for (int i = 1; i <= Length; i++)
    {
        Word += GetRandomCharacter(CharType);
    }
    return Word;
}

string GenerateKey()
{
    string Key = "";
    Key = GenerateWord(enCharTayp::CapitalLetter, 4) + "-";
    Key = Key + GenerateWord(enCharTayp::CapitalLetter, 4) + "-";
    Key = Key + GenerateWord(enCharTayp::CapitalLetter, 4) + "-";
    Key = Key + GenerateWord(enCharTayp::CapitalLetter, 4);
    return Key;
}

void GenerateKeys(short NumberOfKeys)
{
    for (int i = 1; i <= NumberOfKeys; i++)
    {
        cout << "Kay [" << i << "] : " << GenerateKey() << endl;
    }
}

int main()
{
    srand((unsigned)time(NULL));
    GenerateKeys(ReadPositiveNumber("Pleas enter how many keys to generate ?"));
}
```

---

## Problem 22
Count Repeated Number in Array

```cpp
#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);
    return Number;
}

void ReadArray(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    cout << "\n";
    for (int i = 0; i < arrLength; i++)
    {
        cout << "Elements [" << i + 1 << "] : ";
        cin >> arr[i];
    }
    cout << endl;
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int TimeRepeated(int Number, int arr[100], int arrLength)
{
    int Count = 0;
    for (int i = 0; i <= arrLength - 1; i++)
    {
        if (Number == arr[i])
            Count++;
    }
    return Count;
}

int main()
{
    int arr[100], arrLength, NumberToCheck;
    ReadArray(arr, arrLength);
    NumberToCheck = ReadPositiveNumber("Enter the number you want to check : ");
    cout << "\nOriginal array : ";
    PrintArray(arr, arrLength);
    cout << "\nNumber " << NumberToCheck;
    cout << " is repeated ";
    cout << TimeRepeated(NumberToCheck, arr, arrLength) << " time(s).\n";
}
```

---

## Problem 23
Fill Array with Random Numbers

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int main()
{
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : ";
    PrintArray(arr, arrLength);
}
```

---

## Problem 24
Find Max Number in Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int MaxNumberInArray(int arr[100], int arrLength)
{
    int Max = 0;
    for (int i = 0; i < arrLength; i++)
    {
        if (arr[i] > Max)
        {
            Max = arr[i];
        }
    }
    return Max;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : ";
    PrintArray(arr, arrLength);
    cout << "\nMax Number is : " << MaxNumberInArray(arr, arrLength) << endl;
}
```

---

## Problem 25
Find Min Number in Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int MinNumberInArray(int arr[100], int arrLength)
{
    int Min = 0;
    Min = arr[0];
    for (int i = 1; i < arrLength; i++)
    {
        if (arr[i] < Min)
        {
            Min = arr[i];
        }
    }
    return Min;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : ";
    PrintArray(arr, arrLength);
    cout << "\nMin Number is : " << MinNumberInArray(arr, arrLength) << endl;
}
```

---

## Problem 26
Sum of Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int SumArray(int arr[100], int arrLength)
{
    int Sum = 0;
    for (int i = 1; i < arrLength; i++)
    {
        Sum += arr[i];
    }
    return Sum;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : ";
    PrintArray(arr, arrLength);
    cout << "\nSum of all Number is : " << SumArray(arr, arrLength) << endl;
}
```

---

## Problem 27
Average of Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int SumArray(int arr[100], int arrLength)
{
    int Sum = 0;
    for (int i = 1; i < arrLength; i++)
    {
        Sum += arr[i];
    }
    return Sum;
}

float ArrayAverage(int arr[100], int arrLength)
{
    return (float) SumArray(arr, arrLength) / arrLength;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : ";
    PrintArray(arr, arrLength);
    cout << "\nAverage of all Number is : ";
    cout << ArrayAverage(arr, arrLength) << endl;
}
```

---

## Problem 28
Copy Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

void CopyArray(int arrSource[100], int arrDestination[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        arrDestination[i] = arrSource[i];
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    int arr2[100];
    CopyArray(arr, arr2, arrLength);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nArray 2 Elements after copy : \n";
    PrintArray(arr2, arrLength);
}
```

---

## Problem 29
Copy Only Prime Numbers

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

enum enPrimNotPrime { Prime = 1, NotPrime = 2 };

enPrimNotPrime CheckPrime(int Number)
{
    int M = round(Number / 2);
    for (int Counter = 2; Counter <= M; Counter++)
    {
        if (Number % Counter == 0)
            return enPrimNotPrime::NotPrime;
    }
    return enPrimNotPrime::Prime;
}

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

void CopyOnlyPrimeNumbers(int arrSource[100], int arrDestination[100], int arrLength, int& arr2Length)
{
    int Counter = 0;
    for (int i = 0; i < arrLength; i++)
    {
        if (CheckPrime(arrSource[i]) == enPrimNotPrime::Prime)
        {
            arrDestination[Counter] = arrSource[i];
            Counter++;
        }
    }
    arr2Length = --Counter;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    int arr2[100], arr2Length = 0;
    CopyOnlyPrimeNumbers(arr, arr2, arrLength, arr2Length);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nPrime Numbers in Array 2 : \n";
    PrintArray(arr2, arr2Length);
}
```

---

## Problem 30
Sum of Two Arrays

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void SumOf2Arrays(int arr[100], int arr2[100], int arrSum[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        arrSum[i] = arr[i] + arr2[i];
    }
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arr2[100], arrSum[100];
    int arrLength = ReadPositiveNumber("Enter number of elements : ");
    FillArrayWithRandomNumbers(arr, arrLength);
    FillArrayWithRandomNumbers(arr2, arrLength);
    SumOf2Arrays(arr, arr2, arrSum, arrLength);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nArray 2 Elements : \n";
    PrintArray(arr2, arrLength);
    cout << "\nSum of array 1 and array 2 elements : \n";
    PrintArray(arrSum, arrLength);
}
```

---

## Problem 31
Shuffle Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);
    return Number;
}

void Swap(int& A, int& B)
{
    int Temp;
    Temp = A;
    A = B;
    B = Temp;
}

void FillArrayWith1ToNum(int arr[100], int arrLength)
{
    for (int i = 0; i <= arrLength; i++)
    {
        arr[i] = i + 1;
    }
}

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void ShuffleArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        Swap(arr[RandomNumber(1, arrLength) - 1], arr[RandomNumber(1, arrLength) - 1]);
    }
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100];
    int arrLength = ReadPositiveNumber("Enter number of elements : ");
    FillArrayWith1ToNum(arr, arrLength);
    cout << "\nArray elements before shuffle: \n";
    PrintArray(arr, arrLength);
    ShuffleArray(arr, arrLength);
    cout << "\nArray elements after shuffle: \n";
    PrintArray(arr, arrLength);
}
```

---

## Problem 32
Copy Array in Reverse Order

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

void CopyArrayInReverseOrder(int arrSource[100], int arrDestination[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        arrDestination[i] = arrSource[arrLength - 1 - i];
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    int arr2[100];
    CopyArrayInReverseOrder(arr, arr2, arrLength);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nArray 2 Elements after copy : \n";
    PrintArray(arr2, arrLength);
}
```

---

## Problem 33
Fill Array with Keys

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

enum enCharTayp { SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4 };

char GetRandomCharacter(enCharTayp CharType)
{
    switch (CharType)
    {
        case enCharTayp::SmallLetter:
        {
            return char(RandomNumber(97, 122));
            break;
        }
        case enCharTayp::CapitalLetter:
        {
            return char(RandomNumber(65, 90));
            break;
        }
        case enCharTayp::SpecialCharacter:
        {
            return char(RandomNumber(33, 47));
            break;
        }
        case enCharTayp::Digit:
        {
            return char(RandomNumber(48, 57));
            break;
        }
    }
}

void PrintStringArray(string arr[100], int arrLength)
{
    cout << "\nArray elements : \n\n";
    for (int i = 0; i < arrLength; i++)
    {
        cout << "Array [" << i << "] : ";
        cout << arr[i] << "\n";
    }
    cout << endl;
}

int ReadPositiveNumber(string Message)
{
    int Number;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);
    return Number;
}

string GenerateWord(enCharTayp CharType, short Length)
{
    string Word;
    for (int i = 1; i <= Length; i++)
    {
        Word += GetRandomCharacter(CharType);
    }
    return Word;
}

string GenerateKey()
{
    string Key = "";
    Key = GenerateWord(enCharTayp::CapitalLetter, 4) + "-";
    Key = Key + GenerateWord(enCharTayp::CapitalLetter, 4) + "-";
    Key = Key + GenerateWord(enCharTayp::CapitalLetter, 4) + "-";
    Key = Key + GenerateWord(enCharTayp::CapitalLetter, 4);
    return Key;
}

void FillArrayWithKeys(string arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        arr[i] = GenerateKey();
    }
}

int main()
{
    srand((unsigned)time(NULL));
    string arr[100];
    int arrLength = 0;
    arrLength = ReadPositiveNumber("How many keys do you want to generate ?");
    FillArrayWithKeys(arr, arrLength);
    PrintStringArray(arr, arrLength);
}
```

---

## Problem 34
Find Number Position in Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

short FindNumberPositionInArray(int Number, int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        if (arr[i] == Number)
            return i;
    }
    return -1;
}

int ReadNumber()
{
    int Number;
    cout << "\nPlease enter a number to search for?\n";
    cin >> Number;
    return Number;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    int Number = ReadNumber();
    cout << "\nNumber you are looking for is : " << Number << endl;
    short NumberPosition = FindNumberPositionInArray(Number, arr, arrLength);
    if (NumberPosition == -1)
    {
        cout << "\nThe number is not found :-( \n";
    }
    else
    {
        cout << "The number found at position : " << NumberPosition << endl;
        cout << "The number found its order : " << NumberPosition + 1 << endl;
    }
}
```

---

## Problem 35
Check if Number in Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

short FindNumberPositionInArray(int Number, int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        if (arr[i] == Number)
            return i;
    }
    return -1;
}

int ReadNumber()
{
    int Number;
    cout << "\nPlease enter a number to search for?\n";
    cin >> Number;
    return Number;
}

bool IsNumberInArray(int Number, int arr[100], int arrLength)
{
    return FindNumberPositionInArray(Number, arr, arrLength) != -1;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    int Number = ReadNumber();
    cout << "\nNumber you are looking for is : " << Number << endl;
    if (!IsNumberInArray(Number, arr, arrLength))
    {
        cout << "No , The number is not found :-( \n";
    }
    else
    {
        cout << "Yes , it is found :-) " << endl;
    }
}
```

---

## Problem 36
Add Array Element Dynamically

```cpp
#include<iostream>
using namespace std;

int ReadNumber()
{
    int Number;
    cout << "\nPlease enter a number? ";
    cin >> Number;
    return Number;
}

void AddArrayElement(int Number, int arr[100], int& arrLength)
{
    arrLength++;
    arr[arrLength - 1] = Number;
}

void InputUserNumbersInArray(int arr[100], int& arrLength)
{
    bool AddMore = true;
    do
    {
        AddArrayElement(ReadNumber(), arr, arrLength);
        cout << "\nDo you want to add more numbers? [0]:No,[1]:yes? ";
        cin >> AddMore;
    } while (AddMore);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int main()
{
    int arr[100], arrLength = 0;
    InputUserNumbersInArray(arr, arrLength);
    cout << "\nArray Length: " << arrLength << endl;
    cout << "Array elements: ";
    PrintArray(arr, arrLength);
    return 0;
}
```

---

## Problem 37
Copy Array Using AddArrayElement

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

void AddArrayElement(int Number, int arr[100], int& arrLength)
{
    arrLength++;
    arr[arrLength - 1] = Number;
}

void CopyArrayUsingAddArrayElement(int arrSource[100], int arrDestination[100], int arrLength, int& arrDestinationLength)
{
    for (int i = 0; i < arrLength; i++)
        AddArrayElement(arrSource[i], arrDestination, arrDestinationLength);
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength = 0, arr2Length = 0;
    FillArrayWithRandomNumbers(arr, arrLength);
    int arr2[100];
    CopyArrayUsingAddArrayElement(arr, arr2, arrLength, arr2Length);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nArray 2 Elements after copy : \n";
    PrintArray(arr2, arrLength);
}
```

---

## Problem 38
Copy Odd Numbers Only

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

void AddArrayElement(int Number, int arr[100], int& arrLength)
{
    arrLength++;
    arr[arrLength - 1] = Number;
}

void CopyOddNumbers(int arrSource[100], int arrDestination[100], int arrLength, int& arrDestinationLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        if (arrSource[i] % 2 != 0)
        {
            AddArrayElement(arrSource[i], arrDestination, arrDestinationLength);
        }
    }
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength = 0, arr2Length = 0;
    FillArrayWithRandomNumbers(arr, arrLength);
    int arr2[100];
    CopyOddNumbers(arr, arr2, arrLength, arr2Length);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nArray 2 Elements after copy : \n";
    PrintArray(arr2, arr2Length);
}
```

---

## Problem 39
Copy Prime Numbers Only

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

enum enPrimNotPrime { Prime = 1, NotPrime = 2 };

enPrimNotPrime CheckPrime(int Number)
{
    int M = round(Number / 2);
    for (int Counter = 2; Counter <= M; Counter++)
    {
        if (Number % Counter == 0)
            return enPrimNotPrime::NotPrime;
    }
    return enPrimNotPrime::Prime;
}

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

void AddArrayElement(int Number, int arr[100], int& arrLength)
{
    arrLength++;
    arr[arrLength - 1] = Number;
}

void CopyPrimeNumbers(int arrSource[100], int arrDestination[100], int arrLength, int& arrDestinationLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        if (CheckPrime(arrSource[i]) == enPrimNotPrime::Prime)
        {
            AddArrayElement(arrSource[i], arrDestination, arrDestinationLength);
        }
    }
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength = 0, arr2Length = 0;
    int arr2[100];
    FillArrayWithRandomNumbers(arr, arrLength);
    CopyPrimeNumbers(arr, arr2, arrLength, arr2Length);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nArray 2 Prime Number : \n";
    PrintArray(arr2, arr2Length);
}
```

---

## Problem 40
Copy Distinct Numbers

```cpp
#include <iostream>
using namespace std;

void FillArray(int arr[100], int& arrLength)
{
    arrLength = 10;
    arr[0] = 10;
    arr[1] = 10;
    arr[2] = 10;
    arr[3] = 50;
    arr[4] = 50;
    arr[5] = 70;
    arr[6] = 70;
    arr[7] = 70;
    arr[8] = 70;
    arr[9] = 90;
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

short FindNumberPositionInArray(int Number, int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        if (arr[i] == Number)
            return i;
    }
    return -1;
}

bool IsNumberInArray(int Number, int arr[100], int arrLength)
{
    return FindNumberPositionInArray(Number, arr, arrLength) != -1;
}

void AddArrayElement(int Number, int arr[100], int& arrLength)
{
    arrLength++;
    arr[arrLength - 1] = Number;
}

void CopyDistinactNumbersToArray(int arrSource[100], int arrDestination[100], int arrLength, int& arrDestinationLength)
{
    for (int i = 0; i < arrLength; i++)
    {
        if (!IsNumberInArray(arrSource[i], arrDestination, arrLength))
        {
            AddArrayElement(arrSource[i], arrDestination, arrDestinationLength);
        }
    }
}

int main()
{
    int arrSource[100], SourceLength = 0, arrDestination[100], DestinationLength = 0;
    FillArray(arrSource, SourceLength);
    cout << "\nArray 1 Elements : \n";
    PrintArray(arrSource, SourceLength);
    CopyDistinactNumbersToArray(arrSource, arrDestination, SourceLength, DestinationLength);
    cout << "\nArray 1 distinct Elements : \n";
    PrintArray(arrDestination, DestinationLength);
}
```

---

## Problem 41
Check if Array is Palindrome

```cpp
#include <iostream>
using namespace std;

void FillArray(int arr[100], int& arrLength)
{
    arrLength = 6;
    arr[0] = 10;
    arr[1] = 20;
    arr[2] = 30;
    arr[3] = 30;
    arr[4] = 20;
    arr[5] = 10;
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

bool IsPalindromeArray(int arr[100], int Length)
{
    for (int i = 0; i < Length; i++)
    {
        if (arr[i] != arr[Length - i - 1])
        {
            return false;
        }
    }
    return true;
}

int main()
{
    int arr[100], Length = 0;
    FillArray(arr, Length);
    cout << "\nArray Elements : \n";
    PrintArray(arr, Length);
    if (IsPalindromeArray(arr, Length))
    {
        cout << "\nYes array is palindrome \n";
    }
    else
    {
        cout << "\nNo array is not palindrome \n";
    }
}
```

---

## Problem 42
Count Odd Numbers in Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int OddCount(int arr[100], int arrLength)
{
    int counter = 0;
    for (int i = 0; i < arrLength; i++)
    {
        if (arr[i] % 2 != 0)
        {
            counter++;
        }
    }
    return counter;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength = 0;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nOdd numbers count is : \n";
    cout << OddCount(arr, arrLength) << endl;
}
```

---

## Problem 43
Count Even Numbers in Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(1, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int EvenCount(int arr[100], int arrLength)
{
    int counter = 0;
    for (int i = 0; i < arrLength; i++)
    {
        if (arr[i] % 2 == 0)
        {
            counter++;
        }
    }
    return counter;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength = 0;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nEven numbers count is : \n";
    cout << EvenCount(arr, arrLength) << endl;
}
```

---

## Problem 44
Count Positive Numbers in Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(-100, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int PositiveCount(int arr[100], int arrLength)
{
    int counter = 0;
    for (int i = 0; i < arrLength; i++)
    {
        if (arr[i] >= 0)
        {
            counter++;
        }
    }
    return counter;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength = 0;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nPositive numbers count is : \n";
    cout << PositiveCount(arr, arrLength) << endl;
}
```

---

## Problem 45
Count Negative Numbers in Array

```cpp
#include <iostream>
#include <cstdlib>
using namespace std;

int RandomNumber(int From, int To)
{
    int RandNum = rand() % (To - From + 1) + From;
    return RandNum;
}

void FillArrayWithRandomNumbers(int arr[100], int& arrLength)
{
    cout << "Enter number of elements : \n";
    cin >> arrLength;
    for (int i = 0; i < arrLength; i++)
        arr[i] = RandomNumber(-100, 100);
}

void PrintArray(int arr[100], int arrLength)
{
    for (int i = 0; i < arrLength; i++)
        cout << arr[i] << " ";
    cout << "\n";
}

int NegativeCount(int arr[100], int arrLength)
{
    int counter = 0;
    for (int i = 0; i < arrLength; i++)
    {
        if (arr[i] < 0)
        {
            counter++;
        }
    }
    return counter;
}

int main()
{
    srand((unsigned)time(NULL));
    int arr[100], arrLength = 0;
    FillArrayWithRandomNumbers(arr, arrLength);
    cout << "\nArray Elements : \n";
    PrintArray(arr, arrLength);
    cout << "\nNegative numbers count is : \n";
    cout << NegativeCount(arr, arrLength) << endl;
}
```

---

## Problem 46
My Absolute Value

```cpp
#include <iostream>
#include <cmath>
using namespace std;

float MyABS(float Number)
{
    if (Number > 0)
        return Number;
    else
        return Number * -1;
}

float ReadNumber()
{
    float Number;
    cout << "Pleas enter a number ? " << endl;
    cin >> Number;
    return Number;
}

int main()
{
    float Number = ReadNumber();
    cout << "My abs Result : " << MyABS(Number) << endl;
    cout << "C++ abs Result : " << abs(Number) << endl;
}
```

---

## Problem 47
My Round Function

```cpp
#include <iostream>
#include <cmath>
using namespace std;

float GetFractionPart(float Number)
{
    return Number - int(Number);
}

int MyRound(float Number)
{
    int IntPart;
    IntPart = int(Number);
    float FractionPart = GetFractionPart(Number);
    if (abs(FractionPart) >= .5)
    {
        if (Number > 0)
            return ++IntPart;
        else
            return --IntPart;
    }
    else
    {
        return IntPart;
    }
}

float ReadNumber()
{
    float Number;
    cout << "Pleas enter a number ? " << endl;
    cin >> Number;
    return Number;
}

int main()
{
    float Number = ReadNumber();
    cout << "My round Result : " << MyRound(Number) << endl;
    cout << "C++ round Result : " << round(Number) << endl;
}
```

---

## Problem 48
My Floor Function

```cpp
#include <iostream>
#include <cmath>
using namespace std;

int MyFloor(float Number)
{
    if (Number > 0)
        return int(Number);
    else
        return int(Number) - 1;
}

float ReadNumber()
{
    float Number;
    cout << "Pleas enter a number ? " << endl;
    cin >> Number;
    return Number;
}

int main()
{
    float Number = ReadNumber();
    cout << "My floor Result : " << MyFloor(Number) << endl;
    cout << "C++ floor Result : " << floor(Number) << endl;
}
```

---

## Problem 49
My Ceil Function

```cpp
#include <iostream>
#include <cmath>
using namespace std;

float GetFractionPart(float Number)
{
    return Number - int(Number);
}

int MyCeil(float Number)
{
    if (abs(GetFractionPart(Number)) > 0)
    {
        if (Number > 0)
            return int(Number) + 1;
        else
            return int(Number);
    }
    else
    {
        return Number;
    }
}

float ReadNumber()
{
    float Number;
    cout << "Pleas enter a number ? " << endl;
    cin >> Number;
    return Number;
}

int main()
{
    float Number = ReadNumber();
    cout << "My Ceiling Result : " << MyCeil(Number) << endl;
    cout << "C++ Ceiling Result : " << ceil(Number) << endl;
}
```

---

## Problem 50
My Square Root Function

```cpp
#include <iostream>
#include <cmath>
using namespace std;

int MySqrt(float Number)
{
    return pow(Number, 0.5);
}

float ReadNumber()
{
    float Number;
    cout << "Pleas enter a number ? " << endl;
    cin >> Number;
    return Number;
}

int main()
{
    float Number = ReadNumber();
    cout << "My Sqrt Result : " << MySqrt(Number) << endl;
    cout << "C++ Sqrt Result : " << sqrt(Number) << endl;
}
```



```markdown
// Problem 1: Random Matrix 3x3
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 100);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

int main() {
    srand((unsigned)time(NULL));
    int arr[3][3];
    FillMatrixWithRandomNumbers(arr, 3, 3);
    cout << "\n The following is a 3x3 random matrix:\n";
    PrintMatrix(arr, 3, 3);
    system("pause>0");
}

// Problem 2: Sum Each Row in Matrix
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 100);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

int RowSum(int arr[3][3], short RowNumber, short Cols) {
    int Sum = 0;
    for (short j = 0; j <= Cols - 1; j++) {
        Sum += arr[RowNumber][j];
    }
    return Sum;
}

void PrintEachRowSum(int arr[3][3], short Rows, short Cols) {
    cout << "\nThe following are the sum of each row in the matrix : \n";
    for (short i = 0; i < Rows; i++) {
        cout << " Row " << i + 1 << " Sum = " << RowSum(arr, i, Cols) << endl;
    }
}

int main() {
    srand((unsigned)time(NULL));
    int arr[3][3];
    FillMatrixWithRandomNumbers(arr, 3, 3);
    cout << "\n The following is a 3x3 random matrix:\n";
    PrintMatrix(arr, 3, 3);
    PrintEachRowSum(arr, 3, 3);
    system("pause>0");
}

// Problem 3: Sum Each Row in Matrix in Array
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 100);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

int RowSum(int arr[3][3], short RowNumber, short Cols) {
    int Sum = 0;
    for (short j = 0; j <= Cols - 1; j++) {
        Sum += arr[RowNumber][j];
    }
    return Sum;
}

void SumMatrixRowsInArray(int arr[3][3], int arrSum[3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        arrSum[i] = RowSum(arr, i, Cols);
    }
}

void PrintRowsSumArray(int arr[3], short Rows) {
    cout << "\nThe following are the sum of each row in the matrix : \n";
    for (short i = 0; i < Rows; i++) {
        cout << " Row " << i + 1 << " Sum = " << arr[i] << endl;
    }
}

int main() {
    srand((unsigned)time(NULL));
    int arr[3][3];
    int arrSum[3];
    FillMatrixWithRandomNumbers(arr, 3, 3);
    cout << "\n The following is a 3x3 random matrix:\n";
    PrintMatrix(arr, 3, 3);
    SumMatrixRowsInArray(arr, arrSum, 3, 3);
    PrintRowsSumArray(arrSum, 3);
    system("pause>0");
}

// Problem 4: Sum Each Col in Matrix
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 100);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

int ColSum(int arr[3][3], short Rows, short ColNumber) {
    int Sum = 0;
    for (short i = 0; i <= Rows - 1; i++) {
        Sum += arr[i][ColNumber];
    }
    return Sum;
}

void PrintEachColSum(int arr[3][3], short Rows, short Cols) {
    cout << "\nThe following are the sum of each Col in the matrix : \n";
    for (short j = 0; j < Cols; j++) {
        cout << " Col " << j + 1 << " Sum = " << ColSum(arr, Rows, j) << endl;
    }
}

int main() {
    srand((unsigned)time(NULL));
    int arr[3][3];
    FillMatrixWithRandomNumbers(arr, 3, 3);
    cout << "\n The following is a 3x3 random matrix:\n";
    PrintMatrix(arr, 3, 3);
    PrintEachColSum(arr, 3, 3);
    system("pause>0");
}

// Problem 5: Sum Each Col in Matrix in Another Array
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 100);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

int ColSum(int arr[3][3], short Rows, short ColNumber) {
    int Sum = 0;
    for (short i = 0; i <= Rows - 1; i++) {
        Sum += arr[i][ColNumber];
    }
    return Sum;
}

void SumMatrixColsInArray(int arr[3][3], int arrSum[3], short Rows, short Cols) {
    for (short i = 0; i < Cols; i++) {
        arrSum[i] = ColSum(arr, Rows, i);
    }
}

void PrintColsSumArray(int arr[3], short Cols) {
    cout << "\nThe following are the sum of each Col in the matrix : \n";
    for (short j = 0; j < Cols; j++) {
        cout << " Col " << j + 1 << " Sum = " << arr[j] << endl;
    }
}

int main() {
    srand((unsigned)time(NULL));
    int arr[3][3];
    int arrSum[3];
    FillMatrixWithRandomNumbers(arr, 3, 3);
    cout << "\n The following is a 3x3 random matrix:\n";
    PrintMatrix(arr, 3, 3);
    SumMatrixColsInArray(arr, arrSum, 3, 3);
    PrintColsSumArray(arrSum, 3);
    system("pause>0");
}

// Problem 6: 3x3 Ordered Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void FillMatrixWithOrderedNumbers(int arr[3][3], short Rows, short Cols) {
    int Counter = 0;
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            Counter++;
            arr[i][j] = Counter;
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

int main() {
    srand((unsigned)time(NULL));
    int arr[3][3];
    FillMatrixWithOrderedNumbers(arr, 3, 3);
    cout << "\n The following is a 3x3 Ordered matrix:\n";
    PrintMatrix(arr, 3, 3);
    system("pause>0");
}

// Problem 7: Transpose Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void FillMatrixWithOrderedNumbers(int arr[3][3], short Rows, short Cols) {
    int Counter = 0;
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            Counter++;
            arr[i][j] = Counter;
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

void TransposeMatrix(int arr[3][3], int arrTransposed[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arrTransposed[i][j] = arr[j][i];
        }
    }
}

int main() {
    srand((unsigned)time(NULL));
    int arr[3][3];
    int arrTransposed[3][3];
    FillMatrixWithOrderedNumbers(arr, 3, 3);
    cout << "\n The following is a 3x3 Ordered matrix:\n";
    PrintMatrix(arr, 3, 3);
    TransposeMatrix(arr, arrTransposed, 3, 3);
    cout << "\n The following is the Transposed matrix:\n";
    PrintMatrix(arrTransposed, 3, 3);
    system("pause>0");
}

// Problem 8: Multiply Two Matrices
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 10);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            printf(" %0*d", 2, arr[i][j]);
        }
        cout << "\n";
    }
}

void MultiplyMatrix(int Matrix1[3][3], int Matrix2[3][3], int MatrixResults[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            MatrixResults[i][j] = Matrix1[i][j] * Matrix2[i][j];
        }
    }
}

int main() {
    srand((unsigned)time(NULL));
    int Matrix1[3][3], Matrix2[3][3], MatrixResult[3][3];
    FillMatrixWithRandomNumbers(Matrix1, 3, 3);
    cout << "\n Matrix 1 :\n";
    PrintMatrix(Matrix1, 3, 3);
    FillMatrixWithRandomNumbers(Matrix2, 3, 3);
    cout << "\n Matrix 2 \n";
    PrintMatrix(Matrix2, 3, 3);
    MultiplyMatrix(Matrix1, Matrix2, MatrixResult, 3, 3);
    cout << "\n Result : \n";
    PrintMatrix(MatrixResult, 3, 3);
    system("pause>0");
}

// Problem 9: Print Middle Row and Col of Matrix
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 10);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            printf(" %0*d", 2, arr[i][j]);
        }
        cout << "\n";
    }
}

void PrintMiddleRowOfMatrix(int arr[3][3], short Rows, short Cols) {
    short MiddleRow = Rows / 2;
    for (short j = 0; j < Cols; j++) {
        printf(" %0*d", 2, arr[MiddleRow][j]);
    }
    cout << "\n";
}

void PrintMiddleColOfMatrix(int arr[3][3], short Rows, short Cols) {
    short MiddleCol = Cols / 2;
    for (short j = 0; j < Cols; j++) {
        printf(" %0*d", 2, arr[j][MiddleCol]);
    }
    cout << "\n";
}

int main() {
    srand((unsigned)time(NULL));
    int Matrix1[3][3];
    FillMatrixWithRandomNumbers(Matrix1, 3, 3);
    cout << "\n Matrix 1 :\n";
    PrintMatrix(Matrix1, 3, 3);
    cout << "\n Middle Row of Matrix 1 is :\n";
    PrintMiddleRowOfMatrix(Matrix1, 3, 3);
    cout << "\n Middle Col of Matrix 1 is :\n";
    PrintMiddleColOfMatrix(Matrix1, 3, 3);
    system("pause>0");
}

// Problem 10: Sum of Matrix
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 10);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            printf(" %0*d", 2, arr[i][j]);
        }
        cout << "\n";
    }
}

int SumOfMatrix(int Matrix1[3][3], short Rows, short Cols) {
    int Sum = 0;
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            Sum += Matrix1[i][j];
        }
    }
    return Sum;
}

int main() {
    srand((unsigned)time(NULL));
    int Matrix1[3][3];
    FillMatrixWithRandomNumbers(Matrix1, 3, 3);
    cout << "\n Matrix 1 :\n";
    PrintMatrix(Matrix1, 3, 3);
    cout << "\n Sum of matrix 1 is : " << SumOfMatrix(Matrix1, 3, 3) << endl;
    system("pause>0");
}

// Problem 11: Check Matrices Equality
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 10);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            printf(" %0*d", 2, arr[i][j]);
        }
        cout << "\n";
    }
}

int SumOfMatrix(int Matrix1[3][3], short Rows, short Cols) {
    int Sum = 0;
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            Sum += Matrix1[i][j];
        }
    }
    return Sum;
}

bool AreEqualMatrices(int Matrix1[3][3], int Matrix2[3][3], short Rows, short Cols) {
    return (SumOfMatrix(Matrix1, Rows, Cols) == SumOfMatrix(Matrix2, Rows, Cols));
}

int main() {
    srand((unsigned)time(NULL));
    int Matrix1[3][3], Matrix2[3][3];
    FillMatrixWithRandomNumbers(Matrix1, 3, 3);
    cout << "\n Matrix 1 :\n";
    PrintMatrix(Matrix1, 3, 3);
    FillMatrixWithRandomNumbers(Matrix2, 3, 3);
    cout << "\n Matrix 2 :\n";
    PrintMatrix(Matrix2, 3, 3);
    if (AreEqualMatrices(Matrix1, Matrix2, 3, 3))
        cout << "\n YES : both Matrices are equal.";
    else
        cout << "\n No : Matrices are NOT equal";
    system("pause>0");
}

// Problem 12: Check Typical Matrices
#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To) {
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillMatrixWithRandomNumbers(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            arr[i][j] = RandomNumber(1, 10);
        }
    }
}

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            printf(" %0*d", 2, arr[i][j]);
        }
        cout << "\n";
    }
}

bool AreTypicalMatrices(int Matrix1[3][3], int Matrix2[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (Matrix1[i][j] != Matrix2[i][j]) {
                return false;
            }
        }
    }
    return true;
}

int main() {
    srand((unsigned)time(NULL));
    int Matrix1[3][3], Matrix2[3][3];
    FillMatrixWithRandomNumbers(Matrix1, 3, 3);
    cout << "\n Matrix 1 :\n";
    PrintMatrix(Matrix1, 3, 3);
    FillMatrixWithRandomNumbers(Matrix2, 3, 3);
    cout << "\n Matrix 2 :\n";
    PrintMatrix(Matrix2, 3, 3);
    if (AreTypicalMatrices(Matrix1, Matrix2, 3, 3))
        cout << "\n YES : both Matrices are Typical.";
    else
        cout << "\n No : Matrices are NOT Typical";
    system("pause>0");
}

// Problem 13: Check Identity Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

bool IsIdentityMatrix(int Matrix[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (i == j && Matrix[i][j] != 1) {
                return false;
            }
            else if (i != j && Matrix[i][j] != 0) {
                return false;
            }
        }
    }
    return true;
}

int main() {
    int Matrix[3][3] = { {1,0,0},{0,1,0}, {0,0,1} };
    cout << "\n Matrix :\n";
    PrintMatrix(Matrix, 3, 3);
    if (IsIdentityMatrix(Matrix, 3, 3))
        cout << "\n YES : Matrix is Identity.";
    else
        cout << "\n No : Matrix is NOT Identity.";
    system("pause>0");
}

// Problem 14: Check Scalar Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

bool IsScalarMatrix(int Matrix[3][3], short Rows, short Cols) {
    int FirstDiagElement = Matrix[0][0];
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (i == j && Matrix[i][j] != FirstDiagElement) {
                return false;
            }
            else if (i != j && Matrix[i][j] != 0) {
                return false;
            }
        }
    }
    return true;
}

int main() {
    int Matrix[3][3] = { {9,0,0},{0,9,0}, {0,0,9} };
    cout << "\n Matrix :\n";
    PrintMatrix(Matrix, 3, 3);
    if (IsScalarMatrix(Matrix, 3, 3))
        cout << "\n YES : Matrix is Scalar.";
    else
        cout << "\n No : Matrix is NOT Scalar.";
    system("pause>0");
}

// Problem 15: Count Number in Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

short CountNumberInMatrix(int Matrix[3][3], int Number, short Rows, short Cols) {
    short NumberCount = 0;
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (Matrix[i][j] == Number)
                NumberCount++;
        }
    }
    return NumberCount;
}

int main() {
    int Matrix[3][3] = { {9,1,12},{0,9,1}, {0,9,9} };
    cout << "\n Matrix :\n";
    PrintMatrix(Matrix, 3, 3);
    int Number;
    cout << "\n Enter the number to count in matrix ? ";
    cin >> Number;
    cout << "\n Number " << Number << " Count in matrix is " << CountNumberInMatrix(Matrix, Number, 3, 3) << endl;
    system("pause>0");
}

// Problem 16: Check Sparse Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

short CountNumberInMatrix(int Matrix[3][3], int Number, short Rows, short Cols) {
    short NumberCount = 0;
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (Matrix[i][j] == Number)
                NumberCount++;
        }
    }
    return NumberCount;
}

short IsSparseMatrix(int Matrix[3][3], short Rows, short Cols) {
    short MatrixSize = Rows * Cols;
    return (CountNumberInMatrix(Matrix, 0, 3, 3) >= (MatrixSize / 2));
}

int main() {
    int Matrix[3][3] = { {0,0,12},{0,0,1}, {0,0,9} };
    cout << "\n Matrix :\n";
    PrintMatrix(Matrix, 3, 3);
    if (IsSparseMatrix(Matrix, 3, 3))
        cout << "\n YES : it is Sparse.\n";
    else
        cout << "\n No : it's NOT Sparse.\n";
    system("pause>0");
}

// Problem 17: Number Exists In Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

bool IsNumberInMatrix(int Matrix[3][3], int Number, short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (Matrix[i][j] == Number)
                return true;
        }
    }
    return false;
}

int main() {
    int Matrix[3][3] = { {77,5,12},{22,20,1}, {1,0,9} };
    cout << "\n Matrix :\n";
    PrintMatrix(Matrix, 3, 3);
    int Number;
    cout << "\n Enter the number to look for in matrix ? ";
    cin >> Number;
    if (IsNumberInMatrix(Matrix, Number, 3, 3))
        cout << "\n YES : it is there.\n";
    else
        cout << "\n No : it's NOT there.\n";
    system("pause>0");
}

// Problem 18: Intersected Numbers in Matrices
#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

bool IsNumberInMatrix(int Matrix[3][3], int Number, short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (Matrix[i][j] == Number)
                return true;
        }
    }
    return false;
}

void PrintIntersectedNumbers(int Matrix1[3][3], int Matrix2[3][3], short Rows, short Cols) {
    int Number;
    for (short i = 0; i <= Rows - 1; i++) {
        for (short j = 0; j < Cols; j++) {
            Number = Matrix1[i][j];
            if (IsNumberInMatrix(Matrix2, Number, Rows, Cols)) {
                cout << setw(3) << Number << " ";
            }
        }
    }
}

int main() {
    int Matrix[3][3] = { {77,5,12},{22,20,1}, {1,0,9} };
    int Matrix3[3][3] = { {5,80,90},{22,77,1}, {10,8,33} };
    cout << "\n Matrix :\n";
    PrintMatrix(Matrix, 3, 3);
    cout << "\n Matrix 3 :\n";
    PrintMatrix(Matrix3, 3, 3);
    cout << "\n Intersected Numbers are : \n\n";
    PrintIntersectedNumbers(Matrix, Matrix3, 3, 3);
    system("pause>0");
}

// Problem 19: Min / Max Number in Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

int MinNumberInMatrix(int Matrix[3][3], short Rows, short Cols) {
    int Min = Matrix[0][0];
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (Matrix[i][j] < Min)
                Min = Matrix[i][j];
        }
    }
    return Min;
}

int MaxNumberInMatrix(int Matrix[3][3], short Rows, short Cols) {
    int Max = Matrix[0][0];
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            if (Matrix[i][j] > Max)
                Max = Matrix[i][j];
        }
    }
    return Max;
}

int main() {
    int Matrix[3][3] = { {77,5,12},{22,20,6}, {14,3,9} };
    cout << "\n Matrix :\n";
    PrintMatrix(Matrix, 3, 3);
    cout << "\n Minimum Number is : " << MinNumberInMatrix(Matrix, 3, 3) << endl;
    cout << "\n Max Number is : " << MaxNumberInMatrix(Matrix, 3, 3) << endl;
    system("pause>0");
}

// Problem 20: Palindrome Matrix
#include <iostream>
#include <iomanip>
using namespace std;

void PrintMatrix(int arr[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols; j++) {
            cout << setw(3) << arr[i][j] << " ";
        }
        cout << "\n";
    }
}

bool IsPalindromeMatrix(int Matrix[3][3], short Rows, short Cols) {
    for (short i = 0; i < Rows; i++) {
        for (short j = 0; j < Cols / 2; j++) {
            if (Matrix[i][j] != Matrix[i][Cols - 1 - j])
                return false;
        }
    }
    return true;
}

int main() {
    int Matrix[3][3] = { {1,2,1},{5,5,5}, {7,3,7} };
    cout << "\n Matrix :\n";
    PrintMatrix(Matrix, 3, 3);
    if (IsPalindromeMatrix(Matrix, 3, 3))
        cout << "\n YES : Matrix is Palindrome.\n";
    else
        cout << "\n No : Matrix is NOT Palindrome.\n";
    system("pause>0");
}

// Problem 21: Fibonacci Series
#include <iostream>
#include <iomanip>
using namespace std;

void PrintFibonacciUsingLoop(short Number) {
    int FebNumber = 0;
    int Prev2 = 0, Prev1 = 1;
    cout << "1 ";
    for (short i = 2; i <= Number; i++) {
        FebNumber = Prev1 + Prev2;
        cout << FebNumber << " ";
        Prev2 = Prev1;
        Prev1 = FebNumber;
    }
}

int main() {
    PrintFibonacciUsingLoop(10);
    system("pause>0");
}

// Problem 22: Fibonacci Series with Recursion
#include <iostream>
#include <iomanip>
using namespace std;

void PrintFibonacciUsingRecurssion(short Number, int Prev1, int Prev2) {
    int FebNumber = 0;
    if (Number > 0) {
        FebNumber = Prev2 + Prev1;
        Prev2 = Prev1;
        Prev1 = FebNumber;
        cout << FebNumber << " ";
        PrintFibonacciUsingRecurssion(Number - 1, Prev1, Prev2);
    }
}

int main() {
    PrintFibonacciUsingRecurssion(10, 0, 1);
    system("pause>0");
}

// Problem 23: Print First Letter of Each Word
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

void PrintFirstLetterOfEachWord(string S1) {
    bool isFirstLetter = true;
    cout << "\n First letters of this string : \n";
    for (int i = 0; i < S1.length(); i++) {
        if (S1[i] != ' ' && isFirstLetter) {
            cout << S1[i] << endl;
        }
        isFirstLetter = (S1[i] == ' ' ? true : false);
    }
}

int main() {
    PrintFirstLetterOfEachWord(ReadString());
    system("pause>0");
}

// Problem 24: Upper First Letter of Each Word
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

string UpeerFirstLetterOfEachWord(string S1) {
    bool isFirstLetter = true;
    for (int i = 0; i < S1.length(); i++) {
        if (S1[i] != ' ' && isFirstLetter) {
            S1[i] = toupper(S1[i]);
        }
        isFirstLetter = (S1[i] == ' ' ? true : false);
    }
    return S1;
}

int main() {
    string S1 = ReadString();
    cout << "\n String after Conversion : \n";
    S1 = UpeerFirstLetterOfEachWord(S1);
    cout << S1 << endl;
    system("pause>0");
}

// Problem 25: Lower First Letter of Each Word
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

string LowerFirstLetterOfEachWord(string S2) {
    bool isFirstLetter = true;
    for (int i = 0; i < S2.length(); i++) {
        if (S2[i] != ' ' && isFirstLetter) {
            S2[i] = tolower(S2[i]);
        }
        isFirstLetter = (S2[i] == ' ' ? true : false);
    }
    return S2;
}

int main() {
    string S2 = ReadString();
    cout << "\n String after Conversion : \n";
    S2 = LowerFirstLetterOfEachWord(S2);
    cout << S2 << endl;
    system("pause>0");
}

// Problem 26: Upper / Lower All Letters of a String
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

string UpperAllString(string S3) {
    for (int i = 0; i < S3.length(); i++) {
        S3[i] = toupper(S3[i]);
    }
    return S3;
}

string LowerAllString(string S3) {
    for (int i = 0; i < S3.length(); i++) {
        S3[i] = tolower(S3[i]);
    }
    return S3;
}

int main() {
    string S3 = ReadString();
    cout << "\n String after Upper : \n";
    S3 = UpperAllString(S3);
    cout << S3 << endl;
    cout << "\n String after Lower : \n";
    S3 = LowerAllString(S3);
    cout << S3 << endl;
    system("pause>0");
}

// Problem 27: Invert Character Case
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

char ReadChar() {
    char Ch1;
    cout << "Pleas Enter a Character ? \n";
    cin >> Ch1;
    return Ch1;
}

char InvertLetterCase(char Char1) {
    return isupper(Char1) ? tolower(Char1) : toupper(Char1);
}

int main() {
    char Ch1 = ReadChar();
    cout << "\n Char after inverting case : \n";
    Ch1 = InvertLetterCase(Ch1);
    cout << Ch1 << endl;
    system("pause>0");
}

// Problem 28: Invert All Letters Case
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

char InvertLetterCase(char Char1) {
    return isupper(Char1) ? tolower(Char1) : toupper(Char1);
}

string InvertAllStringLetterCase(string S1) {
    for (int i = 0; i < S1.length(); i++) {
        S1[i] = InvertLetterCase(S1[i]);
    }
    return S1;
}

int main() {
    string S4 = ReadString();
    cout << "\n String after Invert All String Letter Case : \n";
    S4 = InvertAllStringLetterCase(S4);
    cout << S4 << endl;
    system("pause>0");
}

// Problem 29: Count Small / Capital Letters
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

short CountCapitalLetters(string S1) {
    short Counter = 0;
    for (int i = 0; i < S1.length(); i++) {
        if (isupper(S1[i]))
            Counter++;
    }
    return Counter;
}

short CountSmallLetters(string S1) {
    short Counter = 0;
    for (int i = 0; i < S1.length(); i++) {
        if (islower(S1[i]))
            Counter++;
    }
    return Counter;
}

enum enWhatToCount { SmallLetters = 0, CapitalLetters = 1, All = 3 };

short CountLetters(string S5, enWhatToCount WhatToCount = enWhatToCount::All) {
    if (WhatToCount == enWhatToCount::All) {
        return S5.length();
    }
    short Counter = 0;
    for (int i = 0; i < S5.length(); i++) {
        if (WhatToCount == enWhatToCount::CapitalLetters && isupper(S5[i]))
            Counter++;
        if (WhatToCount == enWhatToCount::SmallLetters && islower(S5[i]))
            Counter++;
    }
    return Counter;
}

int main() {
    string S5 = ReadString();
    cout << "\nString Length = " << S5.length();
    cout << "\nCapital Letters Count = " << CountCapitalLetters(S5);
    cout << "\nSmall Letters Count = " << CountSmallLetters(S5);
    cout << "\n\nMethod \n";
    cout << "\nString Length = " << CountLetters(S5);
    cout << "\nCapital Letters Count = " << CountLetters(S5, enWhatToCount::CapitalLetters);
    cout << "\nSmall Letters Count = " << CountLetters(S5, enWhatToCount::SmallLetters);
    system("pause>0");
}

// Problem 30: Count Letters
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

char ReadChar() {
    char Ch1;
    cout << "Pleas Enter a Character ? \n";
    cin >> Ch1;
    return Ch1;
}

short CountLetter(string S6, char Letter) {
    short Counter = 0;
    for (short i = 0; i <= S6.length(); i++) {
        if (S6[i] == Letter)
            Counter++;
    }
    return Counter;
}

int main() {
    string S6 = ReadString();
    char Ch2 = ReadChar();
    cout << "\nLetter \'" << Ch2 << "\' count = " << CountLetter(S6, Ch2) << endl;
    system("pause>0");
}

// Problem 31: Count Letters (Match Case)
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

char ReadChar() {
    char Ch1;
    cout << "Pleas Enter a Character ? \n";
    cin >> Ch1;
    return Ch1;
}

char InvertLetterCase(char Char1) {
    return isupper(Char1) ? tolower(Char1) : toupper(Char1);
}

short CountLetter(string S6, char Letter, bool MatchCase = true) {
    short Counter = 0;
    for (short i = 0; i <= S6.length(); i++) {
        if (MatchCase) {
            if (S6[i] == Letter)
                Counter++;
        }
        else {
            if (tolower(S6[i]) == tolower(Letter))
                Counter++;
        }
    }
    return Counter;
}

int main() {
    string S6 = ReadString();
    char Ch3 = ReadChar();
    cout << "\nLetter \'" << Ch3 << "\' count = " << CountLetter(S6, Ch3);
    cout << "\nLetter \'" << Ch3 << "\'";
    cout << "or \'" << InvertLetterCase(Ch3) << "\' ";
    cout << " Count = " << CountLetter(S6, Ch3, false);
    system("pause>0");
}

// Problem 32: Is Vowel?
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

char ReadChar() {
    char Ch1;
    cout << "Pleas Enter a Character ? \n";
    cin >> Ch1;
    return Ch1;
}

bool IsVowel(char Ch4) {
    Ch4 = tolower(Ch4);
    return ((Ch4 == 'a') || (Ch4 == 'e') || (Ch4 == 'i') || (Ch4 == 'o') || (Ch4 == 'u'));
}

int main() {
    char Ch4 = ReadChar();
    if (IsVowel(Ch4))
        cout << "\nYes Letter \'" << Ch4 << "\' is Vowel";
    else
        cout << "\nNo Letter \'" << Ch4 << "\' is NOT Vowel";
    system("pause>0");
}

// Problem 33: Count Vowels
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

bool IsVowel(char Ch4) {
    Ch4 = tolower(Ch4);
    return ((Ch4 == 'a') || (Ch4 == 'e') || (Ch4 == 'i') || (Ch4 == 'o') || (Ch4 == 'u'));
}

short CountVowels(string S7) {
    short Counter = 0;
    for (short i = 0; i < S7.length(); i++) {
        if (IsVowel(S7[i])) {
            Counter++;
        }
    }
    return Counter;
}

int main() {
    string S7 = ReadString();
    cout << "\nNumber of vowels is: " << CountVowels(S7);
    system("pause>0");
}

// Problem 34: Print All Vowels In String
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

bool IsVowel(char Ch4) {
    Ch4 = tolower(Ch4);
    return ((Ch4 == 'a') || (Ch4 == 'e') || (Ch4 == 'i') || (Ch4 == 'o') || (Ch4 == 'u'));
}

void PrintVowels(string S8) {
    cout << "\nVowels in string are : ";
    for (short i = 0; i < S8.length(); i++) {
        if (IsVowel(S8[i])) {
            cout << S8[i] << " ";
        }
    }
}

int main() {
    string S8 = ReadString();
    PrintVowels(S8);
    system("pause>0");
}

// Problem 35: Print Each Word In String
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

void PrintEachWordInString(string S9) {
    string delim = " ";
    cout << "\nYour string words are : \n\n";
    short pos = 0;
    string sWord;
    while ((pos = S9.find(delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            cout << sWord << endl;
        }
        S9.erase(0, pos + delim.length());
    }
    if (S9 != "") {
        cout << S9 << endl;
    }
}

int main() {
    PrintEachWordInString(ReadString());
    system("pause>0");
}

// Problem 36: Count Each Word In String
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

short CountWords(string S9) {
    string delim = " ";
    short Count = 0;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            Count++;
        }
        S9.erase(0, pos + delim.length());
    }
    if (S9 != "") {
        Count++;
    }
    return Count;
}

int main() {
    string S9 = ReadString();
    cout << "\nThe number of words in your string is: ";
    cout << CountWords(S9);
    system("pause>0");
}

// Problem 37: Split String
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

vector<string> SplitString(string S9, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(Delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S9.erase(0, pos + Delim.length());
    }
    if (S9 != "") {
        vString.push_back(S9);
    }
    return vString;
}

int main() {
    vector<string> vString;
    vString = SplitString(ReadString(), " ");
    cout << "Tokens = " << vString.size() << endl;
    for (string& s : vString) {
        cout << s << endl;
    }
    system("pause>0");
}

// Problem 38: TrimLeft, TrimRight, Trim
#include <iostream>
#include <string>
#include <iomanip>
using namespace std;

string TrimLeft(string S10) {
    for (short i = 0; i < S10.length(); i++) {
        if (S10[i] != ' ') {
            return S10.substr(i, S10.length() - i);
        }
    }
    return "";
}

string TrimRight(string S10) {
    for (short i = S10.length() - 1; i >= 0; i--) {
        if (S10[i] != ' ') {
            return S10.substr(0, i + 1);
        }
    }
    return "";
}

string Trim(string S10) {
    return TrimLeft(TrimRight(S10));
}

int main() {
    string S10 = "   Mohammed Abu-Hadhoud   ";
    cout << "\nString = " << S10;
    cout << "\n\nTrim Left = " << TrimLeft(S10);
    cout << "\nTrim Right = " << TrimRight(S10);
    cout << "\nTrim = " << Trim(S10);
    system("pause>0");
}

// Problem 39: Join String (Vector)
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

string JoinString(vector<string> vString, string Delim) {
    string S1 = "";
    for (string& s : vString) {
        S1 = S1 + s + Delim;
    }
    return S1.substr(0, S1.length() - Delim.length());
}

int main() {
    vector<string> vString2 = { "Mohammed","Faid","Ali","Maher" };
    cout << "\nVector after join: \n";
    cout << JoinString(vString2, "###");
    system("pause>0");
}

// Problem 40: Join String (Array Overloading)
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

string JoinString(string arrString[], short Length, string Delim) {
    string S1 = "";
    for (short i = 0; i < Length; i++) {
        S1 = S1 + arrString[i] + Delim;
    }
    return S1.substr(0, S1.length() - Delim.length());
}

int main() {
    string arrString[] = { "Mohammed","Faid","Ali","Maher" };
    cout << "\n\nArray after join: \n";
    cout << JoinString(arrString, 4, "***");
    system("pause>0");
}

// Problem 41: Reverse Words
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

string ReadString() {
    string S1 = " ";
    cout << "Pleas Enter your string ? \n";
    getline(cin, S1);
    return S1;
}

vector<string> SplitString(string S9, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(Delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S9.erase(0, pos + Delim.length());
    }
    if (S9 != "") {
        vString.push_back(S9);
    }
    return vString;
}

string ReverseWordsInString(string S11) {
    vector<string> vString;
    string S2 = "";
    vString = SplitString(S11, " ");
    vector<string>::iterator iter = vString.end();
    while (iter != vString.begin()) {
        --iter;
        S2 += *iter + " ";
    }
    S2 = S2.substr(0, S2.length() - 1);
    return S2;
}

int main() {
    string S11 = ReadString();
    cout << "\n\nString after reversing words:";
    cout << "\n" << ReverseWordsInString(S11);
    system("pause>0");
}

// Problem 42: Replace Words (Built-in Function)
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

string ReplaceWordInStringUsingBuiltInFunction(string S12, string StringToReplace, string sRepalceTo) {
    short pos = S12.find(StringToReplace);
    while (pos != std::string::npos) {
        S12 = S12.replace(pos, StringToReplace.length(), sRepalceTo);
        pos = S12.find(StringToReplace);
    }
    return S12;
}

int main() {
    string S12 = "Welcome to Jordan , Jordan is a nice country";
    string StringToReplace = "Jordan";
    string ReplaceTo = "USA";
    cout << "\nOrigial String\n" << S12;
    cout << "\n\nString After Replace:";
    cout << "\n" << ReplaceWordInStringUsingBuiltInFunction(S12, StringToReplace, ReplaceTo);
    system("pause>0");
}

// Problem 43: Replace Words (Custom)
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

string LowerAllString(string S3) {
    for (int i = 0; i < S3.length(); i++) {
        S3[i] = tolower(S3[i]);
    }
    return S3;
}

vector<string> SplitString(string S9, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(Delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S9.erase(0, pos + Delim.length());
    }
    if (S9 != "") {
        vString.push_back(S9);
    }
    return vString;
}

string JoinString(vector<string> vString, string Delim) {
    string S1 = "";
    for (string& s : vString) {
        S1 = S1 + s + Delim;
    }
    return S1.substr(0, S1.length() - Delim.length());
}

string ReplaceWordInStringUsingSplit(string S13, string StringToReplace, string sRepalceTo, bool MatchCase = true) {
    vector<string> vString = SplitString(S13, " ");
    for (string& s : vString) {
        if (MatchCase) {
            if (s == StringToReplace) {
                s = sRepalceTo;
            }
        }
        else {
            if (LowerAllString(s) == LowerAllString(StringToReplace)) {
                s = sRepalceTo;
            }
        }
    }
    return JoinString(vString, " ");
}

int main() {
    string S13 = "Welcome to Jordan , Jordan is a nice country";
    string StringToReplace = "jordan";
    string ReplaceTo = "USA";
    cout << "\Original String\n" << S13;
    cout << "\n\nReplace with Match Case :";
    cout << "\n" << ReplaceWordInStringUsingSplit(S13, StringToReplace, ReplaceTo);
    cout << "\n\nReplace with don't Match Case :";
    cout << "\n" << ReplaceWordInStringUsingSplit(S13, StringToReplace, ReplaceTo, false);
    system("pause>0");
}

// Problem 44: Remove Punctuations
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

string RemovePunctuationsFromString(string S14) {
    string S2 = "";
    for (short i = 0; i < S14.length(); i++) {
        if (!ispunct(S14[i])) {
            S2 += S14[i];
        }
    }
    return S2;
}

int main() {
    string S14 = "Welcome to Jordan , Jordan is a nice country ; it's amazing";
    cout << "\Original String\n" << S14;
    cout << "\n\nPunctuations Removed : \n" << RemovePunctuationsFromString(S14);
    system("pause>0");
}

// Problem 45: Convert Record to Line
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

struct stClient {
    string AccountNumber = "";
    string PinCode = "";
    string Name = "";
    string Phone = "";
    int AccountBalance = 0;
};

stClient ReadNewClient() {
    stClient Client;
    cout << "Enter Account Number ? ";
    getline(cin >> ws, Client.AccountNumber);
    cout << "Enter PinCode ? ";
    getline(cin, Client.PinCode);
    cout << "Enter Name ? ";
    getline(cin, Client.Name);
    cout << "Enter Phone ? ";
    getline(cin, Client.Phone);
    cout << "Enter Account Balance ? ";
    cin >> Client.AccountBalance;
    return Client;
}

string CounvertRecordToLine(stClient Client, string Separator = "#//#") {
    string stClientRecord = "";
    stClientRecord += Client.AccountNumber + Separator;
    stClientRecord += Client.PinCode + Separator;
    stClientRecord += Client.Name + Separator;
    stClientRecord += Client.Phone + Separator;
    stClientRecord += to_string(Client.AccountBalance);
    return stClientRecord;
}

int main() {
    cout << "\nPlease Enter Client Data : \n\n";
    stClient Client;
    Client = ReadNewClient();
    cout << "\n\nClient Record for Saving is: \n";
    cout << CounvertRecordToLine(Client);
    system("pause>0");
}

// Problem 46: Convert Line Data to Record
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
using namespace std;

struct stClient {
    string AccountNumber = "";
    string PinCode = "";
    string Name = "";
    string Phone = "";
    int AccountBalance = 0;
};

vector<string> SplitString(string S9, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(Delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S9.erase(0, pos + Delim.length());
    }
    if (S9 != "") {
        vString.push_back(S9);
    }
    return vString;
}

stClient CounvertLineToRecord(string Line, string Separator = "#//#") {
    stClient Client;
    vector<string> vClientData;
    vClientData = SplitString(Line, Separator);
    Client.AccountNumber = vClientData[0];
    Client.PinCode = vClientData[1];
    Client.Name = vClientData[2];
    Client.Phone = vClientData[3];
    Client.AccountBalance = stod(vClientData[4]);
    return Client;
}

void PrintClientRecord(stClient Client) {
    cout << "\n\nThe following is the extracted client record : \n\n";
    cout << "Account Number : " << Client.AccountNumber << endl;
    cout << "PinCode : " << Client.PinCode << endl;
    cout << "Name : " << Client.Name << endl;
    cout << "Phone : " << Client.Phone << endl;
    cout << "Account Balance : " << Client.AccountBalance << endl;
}

int main() {
    string stLine = "A150#//#1234#//#Mohammed Abu-Hadhoud#//#079999#//#5270.00000";
    cout << "\nLine Record is : \n";
    cout << stLine << endl;
    stClient Client = CounvertLineToRecord(stLine);
    PrintClientRecord(Client);
    system("pause>0");
}

// Problem 47: Add Clients to File
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
#include <fstream>
using namespace std;

struct stClient {
    string AccountNumber = "";
    string PinCode = "";
    string Name = "";
    string Phone = "";
    int AccountBalance = 0;
};

stClient ReadNewClient() {
    stClient Client;
    cout << "Enter Account Number ? ";
    getline(cin >> ws, Client.AccountNumber);
    cout << "Enter PinCode ? ";
    getline(cin, Client.PinCode);
    cout << "Enter Name ? ";
    getline(cin, Client.Name);
    cout << "Enter Phone ? ";
    getline(cin, Client.Phone);
    cout << "Enter Account Balance ? ";
    cin >> Client.AccountBalance;
    return Client;
}

string CounvertRecordToLine(stClient Client, string Separator = "#//#") {
    string stClientRecord = "";
    stClientRecord += Client.AccountNumber + Separator;
    stClientRecord += Client.PinCode + Separator;
    stClientRecord += Client.Name + Separator;
    stClientRecord += Client.Phone + Separator;
    stClientRecord += to_string(Client.AccountBalance);
    return stClientRecord;
}

const string ClientsFileName = "Clients.txt";

void AddDataLineToFile(string FileName, string strDataLine) {
    fstream MyFile;
    MyFile.open(FileName, ios::out | ios::app);
    if (MyFile.is_open()) {
        MyFile << strDataLine << endl;
        MyFile.close();
    }
}

void AddNewClient() {
    stClient Client;
    Client = ReadNewClient();
    AddDataLineToFile(ClientsFileName, CounvertRecordToLine(Client));
}

void AddClients() {
    char AddMore = 'Y';
    do {
        system("cls");
        cout << "Adding New Client : \n\n";
        AddNewClient();
        cout << "\nClient Added Successfully , do you want to add more clients ? ";
        cin >> AddMore;
    } while (toupper(AddMore) == 'Y');
}

int main() {
    AddClients();
    system("pause>0");
}

// Problem 48: Show All Clients
#include <iostream>
#include <string>
#include <iomanip>
#include <vector>
#include <fstream>
using namespace std;

const string ClientsFileName = "Clients.txt";

struct stClinet {
    string AccountNumber = "";
    string PinCode = "";
    string Name = "";
    string Phone = "";
    int AccountBalance = 0;
};

vector<string> SplitString(string S9, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(Delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S9.erase(0, pos + Delim.length());
    }
    if (S9 != "") {
        vString.push_back(S9);
    }
    return vString;
}

stClinet CounvertLineToRecord(string Line, string Separator = "#//#") {
    stClinet Clinet;
    vector<string> vClinetData;
    vClinetData = SplitString(Line, Separator);
    Clinet.AccountNumber = vClinetData[0];
    Clinet.PinCode = vClinetData[1];
    Clinet.Name = vClinetData[2];
    Clinet.Phone = vClinetData[3];
    Clinet.AccountBalance = stod(vClinetData[4]);
    return Clinet;
}

vector<stClinet> LoadClientsDataFromFile(string FileName) {
    vector<stClinet> vClient;
    fstream MyFile;
    MyFile.open(FileName, ios::in);
    if (MyFile.is_open()) {
        string Line;
        stClinet Clinet;
        while (getline(MyFile, Line)) {
            Clinet = CounvertLineToRecord(Line);
            vClient.push_back(Clinet);
        }
        MyFile.close();
    }
    return vClient;
}

void PrintClientRecord(stClinet Client) {
    cout << "| " << left << setw(15) << Client.AccountNumber;
    cout << "| " << left << setw(10) << Client.PinCode;
    cout << "| " << left << setw(30) << Client.Name;
    cout << "| " << left << setw(12) << Client.Phone;
    cout << "| " << left << setw(12) << Client.AccountBalance;
}

void PrintAllClientsData(vector<stClinet> vClients) {
    cout << "\n\t\t\t\t\t Client List (" << vClients.size() << ") Client(s). ";
    cout << "\n---------------------------------------------------------";
    cout << "-------------------------------------------\n" << endl;
    cout << "| " << left << setw(15) << "Account Number";
    cout << "| " << left << setw(10) << "Pin Code ";
    cout << "| " << left << setw(30) << "Client Name";
    cout << "| " << left << setw(12) << "Phone ";
    cout << "| " << left << setw(12) << "Balance ";
    cout << "\n---------------------------------------------------------";
    cout << "-------------------------------------------\n" << endl;
    for (stClinet Client : vClients) {
        PrintClientRecord(Client);
        cout << endl;
    }
    cout << "\n---------------------------------------------------------";
    cout << "-------------------------------------------\n" << endl;
}

int main() {
    vector<stClinet> vClient = LoadClientsDataFromFile(ClientsFileName);
    PrintAllClientsData(vClient);
    system("pause>0");
}

// Problem 49: Find Client By Account Number
#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <fstream>
using namespace std;

vector<string> SplitString(string S9, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(Delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S9.erase(0, pos + Delim.length());
    }
    if (S9 != "") {
        vString.push_back(S9);
    }
    return vString;
}

struct stClient {
    string AccountNumber = "";
    string PinCode = "";
    string Name = "";
    string Phone = "";
    int AccountBalance = 0;
};

stClient CounvertLineToRecord(string Line, string Separator = "#//#") {
    stClient Client;
    vector<string> vClientData;
    vClientData = SplitString(Line, Separator);
    Client.AccountNumber = vClientData[0];
    Client.PinCode = vClientData[1];
    Client.Name = vClientData[2];
    Client.Phone = vClientData[3];
    Client.AccountBalance = stod(vClientData[4]);
    return Client;
}

void PrintClinetRecord(stClient Clinet) {
    cout << "\n\nThe following is the extracted client record : \n\n";
    cout << "Account Number : " << Clinet.AccountNumber << endl;
    cout << "PinCode : " << Clinet.PinCode << endl;
    cout << "Name : " << Clinet.Name << endl;
    cout << "Phone : " << Clinet.Phone << endl;
    cout << "Account Balance : " << Clinet.AccountBalance << endl;
}

vector<stClient> LoadClientsDataFromFile(string FileName) {
    vector<stClient> vClient;
    fstream MyFile;
    MyFile.open(FileName, ios::in);
    if (MyFile.is_open()) {
        string Line;
        stClient Clinet;
        while (getline(MyFile, Line)) {
            Clinet = CounvertLineToRecord(Line);
            vClient.push_back(Clinet);
        }
        MyFile.close();
    }
    return vClient;
}

const string ClientsFileName = "Clients.txt";

bool FindClientByAccountNumber(string AccountNumber, stClient& Client) {
    vector<stClient> vClients = LoadClientsDataFromFile(ClientsFileName);
    for (stClient C : vClients) {
        if (C.AccountNumber == AccountNumber) {
            Client = C;
            return true;
        }
    }
    return false;
}

string ReadClientAccountNumber() {
    string AccountNumber = "";
    cout << "\nPlease enter AccountNumber ? ";
    cin >> AccountNumber;
    return AccountNumber;
}

int main() {
    stClient Client;
    string AccountNumber = ReadClientAccountNumber();
    if (FindClientByAccountNumber(AccountNumber, Client)) {
        PrintClinetRecord(Client);
    }
    else {
        cout << "\nClient with Account Number (" << AccountNumber << ") is NOT Found! \n";
    }
    system("pause>0");
}

// Problem 50: Delete Client By Account Number
#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <fstream>
using namespace std;

vector<string> SplitString(string S9, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(Delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S9.erase(0, pos + Delim.length());
    }
    if (S9 != "") {
        vString.push_back(S9);
    }
    return vString;
}

struct stClinet {
    string AccountNumber = "";
    string PinCode = "";
    string Name = "";
    string Phone = "";
    double AccountBalance = 0;
    bool MarkForDelete = false;
};

string CounvertRecordToLine(stClinet Clinet, string Separator = "#//#") {
    string stClinetRecord = "";
    stClinetRecord += Clinet.AccountNumber + Separator;
    stClinetRecord += Clinet.PinCode + Separator;
    stClinetRecord += Clinet.Name + Separator;
    stClinetRecord += Clinet.Phone + Separator;
    stClinetRecord += to_string(Clinet.AccountBalance);
    return stClinetRecord;
}

stClinet CounvertLineToRecord(string Line, string Separator = "#//#") {
    stClinet Clinet;
    vector<string> vClinetData;
    vClinetData = SplitString(Line, Separator);
    Clinet.AccountNumber = vClinetData[0];
    Clinet.PinCode = vClinetData[1];
    Clinet.Name = vClinetData[2];
    Clinet.Phone = vClinetData[3];
    Clinet.AccountBalance = stod(vClinetData[4]);
    return Clinet;
}

void PrintClinetRecord(stClinet Clinet) {
    cout << "\n\nThe following are the client Delete : \n\n";
    cout << "Account Number : " << Clinet.AccountNumber << endl;
    cout << "PinCode : " << Clinet.PinCode << endl;
    cout << "Name : " << Clinet.Name << endl;
    cout << "Phone : " << Clinet.Phone << endl;
    cout << "Account Balance : " << Clinet.AccountBalance << endl;
}

const string ClientsFileName = "Clients.txt";

vector<stClinet> LoadClientsDataFromFile(string FileName) {
    vector<stClinet> vClient;
    fstream MyFile;
    MyFile.open(FileName, ios::in);
    if (MyFile.is_open()) {
        string Line;
        stClinet Clinet;
        while (getline(MyFile, Line)) {
            Clinet = CounvertLineToRecord(Line);
            vClient.push_back(Clinet);
        }
        MyFile.close();
    }
    return vClient;
}

bool FindClientByAccountNumber(string AccountNumber, vector<stClinet> vClients, stClinet& Client) {
    for (stClinet C : vClients) {
        if (C.AccountNumber == AccountNumber) {
            Client = C;
            return true;
        }
    }
    return false;
}

string ReadClientAccountNumber() {
    string AccountNumber = "";
    cout << "\nPlease enter AccountNumber ? ";
    cin >> AccountNumber;
    return AccountNumber;
}

bool MarkClientForDeleteByAccountNumber(string AccountNumber, vector<stClinet>& vClients) {
    for (stClinet& C : vClients) {
        if (C.AccountNumber == AccountNumber) {
            C.MarkForDelete = true;
            return true;
        }
    }
    return false;
}

vector<stClinet> SaveClientsDataToFile(string FileName, vector<stClinet> vClients) {
    fstream MyFile;
    MyFile.open(FileName, ios::out);
    string DataLine;
    if (MyFile.is_open()) {
        for (stClinet C : vClients) {
            if (C.MarkForDelete == false) {
                DataLine = CounvertRecordToLine(C);
                MyFile << DataLine << endl;
            }
        }
        MyFile.close();
    }
    return vClients;
}

bool DeleteClientByAccountNumber(string AccountNumber, vector<stClinet>& vClients) {
    stClinet Client;
    char Answer = 'n';
    if (FindClientByAccountNumber(AccountNumber, vClients, Client)) {
        PrintClinetRecord(Client);
        cout << "\n\nAre you sure you want delete client ? n/y ?";
        cin >> Answer;
        if (Answer == 'y' || Answer == 'Y') {
            MarkClientForDeleteByAccountNumber(AccountNumber, vClients);
            SaveClientsDataToFile(ClientsFileName, vClients);
            vClients = LoadClientsDataFromFile(ClientsFileName);
            cout << "\n\n Client Deleted Successfully. \n";
            return true;
        }
    }
    else {
        cout << "\nClient with Account Number (" << AccountNumber << ") is NOT Found! \n";
        return false;
    }
}

int main() {
    vector<stClinet> vClients = LoadClientsDataFromFile(ClientsFileName);
    string AccountNumber = ReadClientAccountNumber();
    DeleteClientByAccountNumber(AccountNumber, vClients);
    system("pause>0");
}

// Problem 51: Update Client By Account Number
#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include <fstream>
using namespace std;

vector<string> SplitString(string S9, string Delim) {
    vector<string> vString;
    short pos = 0;
    string sWord;
    while ((pos = S9.find(Delim)) != std::string::npos) {
        sWord = S9.substr(0, pos);
        if (sWord != "") {
            vString.push_back(sWord);
        }
        S9.erase(0, pos + Delim.length());
    }
    if (S9 != "") {
        vString.push_back(S9);
    }
    return vString;
}

struct stClinet {
    string AccountNumber = "";
    string PinCode = "";
    string Name = "";
    string Phone = "";
    double AccountBalance = 0;
    bool MarkForDelete = false;
};

string CounvertRecordToLine(stClinet Clinet, string Seperator = "#//#") {
    string stClinetRecord = "";
    stClinetRecord += Clinet.AccountNumber + Seperator;
    stClinetRecord += Clinet.PinCode + Seperator;
    stClinetRecord += Clinet.Name + Seperator;
    stClinetRecord += Clinet.Phone + Seperator;
    stClinetRecord += to_string(Clinet.AccountBalance);
    return stClinetRecord;
}

stClinet CounvertLineToRecord(string Line, string Seperator = "#//#") {
    stClinet Clinet;
    vector<string> vClinetData;
    vClinetData = SplitString(Line, Seperator);
    Clinet.AccountNumber = vClinetData[0];
    Clinet.PinCode = vClinetData[1];
    Clinet.Name = vClinetData[2];
    Clinet.Phone = vClinetData[3];
    Clinet.AccountBalance = stod(vClinetData[4]);
    return Clinet;
}

void PrintClinetRecord(stClinet Clinet) {
    cout << "\n\nThe following are the client Delete : \n\n";
    cout << "Account Number : " << Clinet.AccountNumber << endl;
    cout << "PinCode : " << Clinet.PinCode << endl;
    cout << "Name : " << Clinet.Name << endl;
    cout << "Phone : " << Clinet.Phone << endl;
    cout << "Account Balance : " << Clinet.AccountBalance << endl;
}

const string ClientsFileName = "Clients.txt";

vector<stClinet> LoadClientsDataFromFile(string FileName) {
    vector<stClinet> vClient;
    fstream MyFile;
    MyFile.open(FileName, ios::in);
    if (MyFile.is_open()) {
        string Line;
        stClinet Clinet;
        while (getline(MyFile, Line)) {
            Clinet = CounvertLineToRecord(Line);
            vClient.push_back(Clinet);
        }
        MyFile.close();
    }
    return vClient;
}

string ReadClientAccountNumber() {
    string AccountNumber = "";
    cout << "\nPlease enter AccountNumber ? ";
    cin >> AccountNumber;
    return AccountNumber;
}

bool FindClientByAccountNumber(string AccountNumber, vector<stClinet> vClients, stClinet& Client) {
    for (stClinet C : vClients) {
        if (C.AccountNumber == AccountNumber) {
            Client = C;
            return true;
        }
    }
    return false;
}

vector<stClinet> SaveClientsDataToFile(string FileName, vector<stClinet> vClients) {
    fstream MyFile;
    MyFile.open(FileName, ios::out);
    string DataLine;
    if (MyFile.is_open()) {
        for (stClinet C : vClients) {
            if (C.MarkForDelete == false) {
                DataLine = CounvertRecordToLine(C);
                MyFile << DataLine << endl;
            }
        }
        MyFile.close();
    }
    return vClients;
}

stClinet ChangeClientRecord(string AccountNumber) {
    stClinet Client;
    Client.AccountNumber = AccountNumber;
    cout << "Enter PinCode ? ";
    getline(cin >> ws, Client.PinCode);
    cout << "Enter Name ? ";
    getline(cin, Client.Name);
    cout << "Enter Phone ? ";
    getline(cin, Client.Phone);
    cout << "Enter Account Balance ? ";
    cin >> Client.AccountBalance;
    return Client;
}

bool UpdateClientByAccountNumber(string AccountNumber, vector<stClinet>& vClients) {
    stClinet Client;
    char Answer = 'n';
    if (FindClientByAccountNumber(AccountNumber, vClients, Client)) {
        PrintClinetRecord(Client);
        cout << "\n\nAre you sure you want Update client ? n/y ? ";
        cin >> Answer;
        if (Answer == 'y' || Answer == 'Y') {
            for (stClinet& C : vClients) {
                if (C.AccountNumber == AccountNumber) {
                    C = ChangeClientRecord(AccountNumber);
                    break;
                }
            }
            SaveClientsDataToFile(ClientsFileName, vClients);
            vClients = LoadClientsDataFromFile(ClientsFileName);
            cout << "\n\n Client Updated Successfully. \n";
            return true;
        }
    }
    else {
        cout << "\nClient with Account Number (" << AccountNumber << ") is NOT Found! \n";
        return false;
    }
}

int main() {
    vector<stClinet> vClients = LoadClientsDataFromFile(ClientsFileName);
    string AccountNumber = ReadClientAccountNumber();
    UpdateClientByAccountNumber(AccountNumber, vClients);
    system("pause>0");
}
```

```markdown
// Problem 1: Number To Text
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

// Problem 2: Leap Year (Standard)
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

// Problem 3: Leap Year (One Line)
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

// Problem 4: Days, Hours, Minutes, Seconds in a Year
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

// Problem 5: Days, Hours, Minutes, Seconds in a Month
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

// Problem 6: Days in Month (Compact)
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

// Problem 7: Day Name
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

// Problem 8: Month Calendar
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

// Problem 9: Year Calendar
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

// Problem 10: Days from Beginning of Year
#include <iostream>
#include <string>
using namespace std;

bool IsLeapYear(short Year) {
    return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
}

short NumberOfDaysInAMonth(short Month, short Year) {
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

// Problem 11: Date from Day Order
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 12: Add Days to Date
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 13: Check if Date1 is Less Than Date2
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 14: Check if Two Dates are Equal
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 15: Check Last Day and Last Month
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 16: Increase Date by One Day
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 17: Difference in Days Between Two Dates
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 18: Calculate Age in Days
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 19: Difference in Days (Supporting Negative)
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problems 20-32: Date Increase Functions
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problem 62: Validate Date
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
    short Day;
    cout << "\nPlease enter a Day? ";
    cin >> Day;
    return Day;
}

short ReadMonth() {
    short Month;
    cout << "\nPlease enter a Month? ";
    cin >> Month;
    return Month;
}

short ReadYear() {
    short Year;
    cout << "\nPlease enter a Year? ";
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

// Problems 63-64: Read and Print Date as String
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

// Problem 65: Format Date
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



---

---
# course 9
Here are the **concepts** extracted from the provided Arabic text, rewritten as an **English Markdown file**.

---

# Extracted Concepts: Networking & Protocols

## Lesson 1: Basics of Networks
- **Network**: A group of devices connected to share resources and communicate.
- **Purpose of a Network**: Resource sharing, communication (e.g., controlling a TV via phone, sharing files).
- **LAN (Local Area Network)**: Connects close devices (e.g., home, school, hospital). Small or large scale.
- **WAN (Wide Area Network)**: Connects LANs over long distances (e.g., cities, countries). The Internet is the largest WAN.
- **Connection Types**:
    - **Wired**: Uses Ethernet protocol, cables, switches.
    - **Wireless (Wi-Fi)**: Convenient, no cables. Wi-Fi = Wireless Fidelity.
- **Ethernet vs. Wi-Fi**: Ethernet is faster, more stable; Wi-Fi is easier but less stable.

## Lesson 2: MAN (Metropolitan Area Network)
- **MAN**: Larger than LAN, smaller than WAN. Covers a city.
- **Comparison**:
    - **WAN**: Largest, slowest, expensive, more errors.
    - **MAN**: Medium speed/cost/errors.
    - **LAN**: Fastest, cheapest, fewest errors.

## Lesson 3: What is a Server?
- **Server**: A device (computer) that provides services, shares, and processes data for clients.
- **Server vs. PC**:
    - **PC**: Cheaper, less reliable, designed for general use.
    - **Server**: Expensive, highly reliable, 24/7 operation.
- **Types of Servers**: Web, Database, Mail, File, Application, Game/VoIP/Image.
- **Physical Forms**: Tower, Rack, Blade.

## Lesson 4: How Data is Transferred?
- Data is split into small pieces (packets), sent separately, then reassembled.
- A central manager (future lessons) oversees this process.

## Lesson 5: TCP (Transmission Control Protocol)
- **TCP** is responsible for:
    - Sending small packets.
    - Reassembling data correctly.
    - Avoiding congestion/conflicts.
- Works between sender and receiver.

## Lesson 6: IP Protocol Part 1 (IPv4)
- **IP Address**: Unique identifier for a device on a network (like a home address).
- **IPv4**: 4 numbers (0-255), e.g., `192.168.1.1`. Each number is 8 bits. Total ~4 billion addresses.

## Lesson 7: IP Protocol Part 2 (IPv6)
- **IPv6**: Newer standard due to IPv4 exhaustion.
- **Format**: 128 bits, written in hexadecimal (8 groups of 16 bits).
- **Example**: `2001:0db8:0000:0000:ff00:0000:0042:8330`
- Shortened: `2001:bd8:ff00:0:42:8330`
- Capacity: ~3.4×10³⁸ addresses.

## Lesson 8: IP Types
- **Public IP**: Unique worldwide, assigned by ISP.
- **Private IP**: Used inside local networks (e.g., home Wi-Fi), can repeat in different networks.
- **Static IP**: Fixed, used for servers/cameras.
- **Dynamic IP**: Changes automatically via DHCP, common for regular users.

## Lesson 9: Modem, Router, Gateway & Mesh Network
- **Modem**: Converts signal from ISP to computer-understandable data.
- **Router**: Distributes internet to multiple devices (wired/wireless). Works on 2.4 GHz (longer range) or 5 GHz (faster speed).
- **Gateway**: Connects different networks, translates protocols. More powerful than a router.
- **Mesh Network**: Main router + small nodes. Eliminates weak signal zones. Good for large homes.

| Feature | Normal Router | Mesh Network |
|---------|---------------|---------------|
| Coverage | Limited | Full area |
| Signal | Weakens with distance | Strong everywhere |
| Setup | Easy, one device | More nodes |
| Cost | Cheaper | More expensive |

## Lesson 10: DHCP (Dynamic Host Configuration Protocol)
- **DHCP** automatically assigns IPs and network settings.
- **Functions**:
    - Gives each device an IP automatically.
    - Prevents IP conflicts.
    - Provides subnet mask, default gateway, DNS.
- Usually runs on the home router or a dedicated server.

## Lesson 11: NAT & IP Mapping
- **NAT (Network Address Translation)**: Allows multiple private IPs to share one public IP.
- **IP Mapping**: Forwards internet traffic to a specific internal device (port forwarding).
- Used for: Security cameras, game servers, remote desktop, hosting.

| Feature | NAT | IP Mapping |
|---------|-----|-------------|
| Direction | Inside → Outside | Outside → Inside |
| Always active | Yes | Only when needed |
| Purpose | General internet sharing | Hosting services |

## Lesson 12: ISP (Internet Service Provider)
- **ISP**: Company that provides internet access (e.g., Vodafone, WE).
- Provides: Internet connection, Public IP, specific speed.
- Acts as the gateway from your local network to the global internet.

## Lesson 13: Ports & Socket
- **Port**: A number identifying a specific process/service on a device (e.g., Web Server on port 80, Email on port 25).
- **Socket**: IP Address + Port Number. Uniquely identifies a connection.
- Example: `192.168.1.10:80`

## Lesson 14: Subnet Mask & CIDR
- **IP is split into**:
    - Network ID (identifies the network)
    - Host ID (identifies the device inside the network)
- **Subnet Mask**: Determines which part is Network and which is Host.
    - Example: IP `192.168.1.10` + Mask `255.255.255.0` → Network `192.168.1`, Host `10`
- **CIDR (Classless Inter-Domain Routing)** : Short form: `192.168.1.10/24` (24 bits for network).

## Lesson 15: What is MAC Address?
- **MAC Address**: Permanent, unique hardware identifier for any network-capable device.
- **IP vs. MAC**:
    - IP = temporary address (like your current location).
    - MAC = permanent identity (like your national ID).
- Format: Hexadecimal, 6 groups (e.g., `00:1A:2B:3C:4D:5E`).
- Used **only inside the local network** (LAN). For internet access, IP is used.

## Lesson 16: VPN (Virtual Private Network)
- **VPN**: Encrypted tunnel between your device and a VPN server.
- **Without VPN**: ISP and websites see your real IP.
- **With VPN**: Traffic is encrypted, IP is hidden, appears as VPN server's location.
- **Uses**: Privacy, unblocking geo-restricted content, hiding from ISP, safe on public Wi-Fi.

## Lesson 17: Internet vs. WWW
- **Internet**: Global network of networks. Physical infrastructure (cables, routers, data centers).
- **WWW (World Wide Web)** : Collection of linked web pages accessed via a browser. A service *on top* of the Internet.
- **Analogy**: Internet = road network, WWW = destinations (buildings/malls).

| | WWW | Internet |
|--|-----|----------|
| Invented | 1991 | 1960s |
| Needs | Browser, HTTP, URL | Network connection |
| Contains | Websites, pages | Global infrastructure |

## Lesson 18: Browsers
- **Browser**: Software to surf the internet (Chrome, Firefox, Edge, Safari).
- **How it works**: You type a URL → Browser sends HTTP request to server → Server returns HTML file → Browser renders it visually.
- **HTML**: Descriptive language, not a programming language.

## Lesson 19: HTTP & HTTPS Protocols
- **HTTP**: Protocol for transferring web pages (no encryption).
- **HTTPS**: HTTP + Encryption (using SSL/TLS). Secure.
- **Port**: HTTP = 80, HTTPS = 443.
- **Browser alert**: "Not Secure" for HTTP sites.

| Feature | HTTP | HTTPS |
|---------|------|-------|
| Security | No encryption | Encrypted (TLS) |
| Port | 80 | 443 |
| Status | Old standard | Current standard |

## Lesson 20: What is a Domain Name?
- **Domain Name**: Human-readable name mapped to an IP address (e.g., `facebook.com` → `31.13.79.254`).
- **How it works**: You type domain → Browser asks DNS → DNS returns IP → Browser connects.
- **Buying a domain**: Through Domain Registrars. Pay yearly. Example: `mywebsite.com`
    - `mywebsite` = chosen name
    - `com` = Top-Level Domain (TLD)

## Lesson 21: DNS (Domain Name Server)
- **DNS**: Translates domain names to IP addresses (like a phonebook).
- **Why not memorize IPs?** IPs change, servers move, ISPs change.
- **Process**:
    1. Browser asks DNS: "What is `google.com` IP?"
    2. DNS returns IP.
    3. Browser connects.

## Lesson 22: Sub Domain
- **Subdomain**: Extra part added before the main domain to organize content.
- Example: `blog.programmingadvices.com`
    - `blog` = subdomain
    - `programmingadvices` = domain
    - `com` = TLD
- Subdomains are free (no need to buy new domain). Can point to different servers.
- Example: `shop.example.com` (different server) vs `blog.example.com`

## Lesson 23: URL (Uniform Resource Locator)
- **URL**: Complete address to a resource on the internet (webpage, image, file, API).
- Example: `https://www.google.com/index.html`
    - `https://` → Protocol
    - `www.google.com` → Domain Name
    - `/index.html` → Path

## Lesson 24: FTP (File Transfer Protocol)
- **FTP**: Protocol for transferring files between devices.
- **Uses**: Uploading website files, managing shared files, backups.
- **Advantages**:
    - Transfer many files at once.
    - Resume interrupted downloads.
    - Schedule transfers.
    - No file size limit (practically).
- **How**: FTP client (e.g., FileZilla) ↔ FTP server.

## Lesson 25: What is API?
- **API (Application Programming Interface)** : Allows apps to talk to each other (like a waiter).
- Example: Weather app → calls API → API gets data from server → returns to app.
- **Why use API?**
    - Don't rebuild common features (e.g., Google Maps API).
    - Security (app doesn't directly touch your bank).
    - Easier integration across devices.
- Often returns data in JSON format.

## Lesson 26: What is XML?
- **XML (eXtensible Markup Language)** : Language to structure and store data using custom tags.
- **Example**:
    ```xml
    <employee>
        <name>Ahmed Ali</name>
        <age>28</age>
        <job>Developer</job>
    </employee>
    ```
- **Uses**: Data exchange between old systems, config files, Office files (docx, xlsx), SOAP APIs.
- **Cons**: Heavier, slower than JSON.

## Lesson 27: What is JSON?
- **JSON (JavaScript Object Notation)** : Lightweight way to structure data using key:value pairs.
- **Example**:
    ```json
    {
        "name": "Ahmed Ali",
        "age": 28,
        "job": "Developer"
    }
    ```
- **Comparison**:

| Feature | XML | JSON |
|---------|-----|------|
| Format | Tags | Key:Value |
| Size | Heavy | Light |
| Speed | Slower | Faster |
| Human-readable | Yes | Easier |
| Used in | Older systems, SOAP | Modern APIs, mobile/web |

## Lesson 28: What is GUID?
- **GUID (Globally Unique Identifier)** : 128-bit unique ID (e.g., `550e8400-e29b-41d4-a716-446655440000`).
- **Format**: 32 hex digits in 5 groups (8-4-4-4-12).
- **Advantages**:
    - Unique across the whole world.
    - No central coordination needed.
    - Suitable for distributed systems.
- **Use**: Primary keys in databases, API request IDs, distributed systems.

## Lesson 29: 3-Tier Architecture
- **3-Tier Architecture**: Divides application into 3 independent layers.
- **Tiers**:
    1. **Presentation Tier** (UI) – what the user sees (web page, mobile screen).
    2. **Business Logic Tier** – contains rules and calculations (e.g., "is login valid?").
    3. **Data Tier** – database (stores/retrieves data).
- **Benefits**:
    - Separation of concerns.
    - Easy to modify one tier without affecting others.
    - Easier testing and scaling.
- **Analogy**: Restaurant
    - Presentation = you (customer)
    - Business Logic = waiter
    - Data = kitchen/storage