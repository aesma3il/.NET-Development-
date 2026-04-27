#include<iostream>
#include<string>
#include<vector>
#include<limits>

using namespace std;


// feat: implement core programming concepts and clean architecture
//
// Variables
// Data Types
// Operators
// Type Casting
// Control Flow
// Conditional Statements (if / else)
// Switch Statement
// Loops (while, do-while)
// Break / Continue
// Functions
// Function Parameters
// Pass by Value
// Pass by Reference
// Return Values
// Structs
// Data Modeling
// Standard Library Containers (std::vector)
// Iteration (range-based loop)
// auto Keyword
// References (&)
// Namespaces
// Separation of Concerns
// Layered Architecture
// Single Responsibility Principle (SRP)
// Input Validation
// Stream Handling (cin state management)
// Error Handling (basic, boolean-based)
// Constants (const)
// Configuration Management
// Type Conversion (std::to_string)
// Standard Library Usage
// Abstraction
// Encapsulation (partial)
// Modularity
// Reusability

struct Number {
	int firstNumber;
	int secondNumber;
	int result;
	char operation;
};

struct MenuItem {
	int key;
	string title;
};

std::vector<MenuItem> menu = {
	{1, "Addition"},
	{2, "Subtraction"},
	{3, "Multiplication"},
	{4, "Division"},
	{0, "Exit"}
};

namespace Messages {
	const std::string ENTER_FIRST = "Enter first number: ";
	const std::string ENTER_SECOND = "Enter second number: ";
	const std::string CHOOSE_OP = "Choose operation (1:+ 2:- 3:* 4:/): ";
	const std::string DIV_ZERO = "Cannot divide by zero.";
	const std::string RESULT = "Result = ";
}

namespace Input {

	double readDouble() {
		double value;
		while (!(std::cin >> value)) {
			std::cin.clear();
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "[!] Invalid number, try again: ";
		}
		return value;
	}

	int readInt() {
		int value;
		while (!(std::cin >> value)) {
			std::cin.clear();
			std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			std::cout << "[!] Invalid input, enter a number: ";
		}
		return value;
	}

}

namespace Output {

	void print(const std::string& message) {
		std::cout << message;
	}

	void println(const std::string& message) {
		std::cout << message << std::endl;
	}

	void error(const std::string& message) {
		std::cout << "[!] " << message << std::endl;
	}

	void prompt(const std::string& message) {
		std::cout << "> " << message;
	}

	void info(const std::string& message) {
		std::cout << "[+] " << message << std::endl;
	}

	void printMenu(const std::vector<MenuItem>& menu) {
		std::cout << "===== Menu =====" << std::endl;

		for (const auto& item : menu) {
			std::cout << item.key << " - " << item.title << std::endl;
		}

		std::cout << "================" << std::endl;
	}

}

namespace Calc {

	double add(double a, double b) {
		return a + b;
	}

	double sub(double a, double b) {
		return a - b;
	}

	double mul(double a, double b) {
		return a * b;
	}

	bool div(double a, double b, double& result) {
		if (b == 0) return false;
		result = a / b;
		return true;
	}

}

namespace Validation {

	bool isValidRange(int value, int min, int max) {
		return value >= min && value <= max;
	}

}

namespace Settings {
	const int MIN_VALUE = -1000;
	const int MAX_VALUE = 1000;
	bool ReadOnlyPostiveNumber = true;
	bool AcceptNegativeNumber = false;
}

int main() {
	int choice;
	Number calc;
	double result;

	do {
		Output::printMenu(menu);
		Output::prompt("Enter your choice: ");
		choice = Input::readInt();

		if (choice == 0) {
			Output::info("Goodbye!");
			break;
		}

		if (!Validation::isValidRange(choice, 1, 4)) {
			Output::error("Invalid choice! Please select 1-4");
			continue;
		}

		// Get numbers
		Output::prompt(Messages::ENTER_FIRST);
		calc.firstNumber = Input::readInt();

		Output::prompt(Messages::ENTER_SECOND);
		calc.secondNumber = Input::readInt();

		// Perform calculation
		bool validOperation = true;
		switch (choice) {
		case 1:
			result = Calc::add(calc.firstNumber, calc.secondNumber);
			calc.operation = '+';
			break;
		case 2:
			result = Calc::sub(calc.firstNumber, calc.secondNumber);
			calc.operation = '-';
			break;
		case 3:
			result = Calc::mul(calc.firstNumber, calc.secondNumber);
			calc.operation = '*';
			break;
		case 4:
			if (!Calc::div(calc.firstNumber, calc.secondNumber, result)) {
				Output::error(Messages::DIV_ZERO);
				validOperation = false;
			}
			else {
				calc.operation = '/';
			}
			break;
		}

		if (validOperation) {
			calc.result = static_cast<int>(result);
			Output::println(Messages::RESULT + std::to_string(result));
			Output::info("Operation completed successfully!");
		}

		std::cout << "\n";

	} while (choice != 0);

	return 0;
}