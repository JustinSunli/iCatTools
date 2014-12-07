#include "ExamBase.h"
class Exam: public ExamBase{
public:
	//成员变量
	int no;
	int personCount;
	//构造函数
	Exam();
	Exam(int no);
	//成员函数，对象行为
	void setNo(int newNo);
	//静态成员方法
	static void TestDirectObject();
	static void TestPointer();
	//void printMaxCount();

};
//最后这个分号很必要，这和c#中是不一样的。