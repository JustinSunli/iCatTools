#include "Exam.h"
#include <iostream>
using namespace std;

Exam::Exam()
{
	this->no = 0;
	this->personCount = 20;
}
Exam::Exam(int no)
{
	
	this->no = no;
}

void Exam::setNo(int newNo)
{
	this->personCount = newNo;
}
void Exam::TestDirectObject()
{
	Exam exam;
	//Exam exam(20);
	cout<<exam.no<<endl;
	exam.setNo(30);
	cout<<exam.personCount<<endl;
}
void Exam::TestPointer()
{
	//同c#不同的表示对象方式，实际原理相同。
	Exam* exam = new Exam(200);
	int newno;

	cout<<exam->no<<endl;

	cin>>newno;
	exam->setNo(newno);
	cout<<exam->personCount<<endl;
	delete exam;
}
