using System;
namespace Lessons
{
	class Program
	{
		public static void Main(string[] args)
		{
			Dispetcher disp=new Dispetcher(1,8," К практическому заданию урока №","Введите номер практического задания или 100 для выхода из программы", "Некорректное значение, повторите ввод");
			disp.TransferControlToLesson();
		}
	}
}// Всего 12 из 15 как тебе такое Илон Маск!))))