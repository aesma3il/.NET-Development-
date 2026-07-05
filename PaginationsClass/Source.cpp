#include<iostream>

using namespace std;

class Pagination {
private:
	int _totalItems;
	int _pageSize;
	int _totalPages;
	int _currentPage = 1;


public:

	Pagination(int totalRecords, int pageSize = 10) {
		
		this->_totalItems = totalRecords;
		this->_pageSize = pageSize;
		this->_totalPages = (this->_totalItems + this->_pageSize -1) / this->_pageSize;
	}

	void First() {
		_currentPage = 1;
	}

	void Last() {
		_currentPage = _totalPages;
	}

	void Previous() {

		if (_currentPage > 1) {
			_currentPage--;
		}
	}

	void Next() {
		if (_currentPage < _totalPages) {
			_currentPage++;
		}
	}

	bool IsFirstDisabled() {
		return _currentPage == 1;
	}

	bool IsLastDisabled() {
		return _currentPage == _totalPages;
	}




};


int main() {



	return 0;

}