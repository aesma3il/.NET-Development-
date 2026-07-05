#include<iostream>

using namespace std;


class Field {
private:
	int colId;
	string FieldName;
	string FieldType;
	string FieldLength;
	bool IsPrimaryKey;
	bool IsUnique;
	bool IsForiegnkey;
	bool IsSortable;
	bool IsVisible;
	bool IsFilterable;
	bool IsSearchable;

};


class Page {
private:
	string title;
	string description;
	string Breadcrumb;
	bool permissions[4];


};

int main() {


	return 0;
}