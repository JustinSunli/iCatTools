#include "ExamBase.h"
class Exam: public ExamBase{
public:
	//��Ա����
	int no;
	int personCount;
	//���캯��
	Exam();
	Exam(int no);
	//��Ա������������Ϊ
	void setNo(int newNo);
	//��̬��Ա����
	static void TestDirectObject();
	static void TestPointer();
	//void printMaxCount();

};
//�������ֺźܱ�Ҫ�����c#���ǲ�һ���ġ�