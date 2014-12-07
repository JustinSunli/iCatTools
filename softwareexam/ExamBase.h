class ExamBase{
public:
	int ExamMaxTypeCount;
	//现在定义的为虚函数
	virtual void printMaxCount();
	//如果=0了就是纯虚函数，派生类必须要实现它，
	//不然派生类也会跟着遭殃，把自己变成抽象类。
	//virtual void printMaxCount() = 0;
};