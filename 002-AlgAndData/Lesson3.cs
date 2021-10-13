using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;



namespace Lessons
{
    public class Lesson3
    {
        public static void LessonMenu()
        {
            bool onemoretime = true;
            while (onemoretime)
            {
                Console.WriteLine("Урок 3. Класс, структура и дистанция");
                Console.WriteLine();
                Menu Lesson3Menu = new Menu(1, 1, "протестировать методы расчета дистанции", "Для просмотра введите номер задания или введите 100 для возврата в главное меню.", "Некорректное значение. Повторите ввод");
                Lesson3Menu.PrintMenu();
                ValidChoice VC = new ValidChoice();

                switch (VC.FromMenu(Lesson3Menu))
                {
                    case 1:
                        Console.Clear();
                        TestBench();
                        onemoretime = true;
                        break;
                    case 100:
                        onemoretime = false;
                        break;
                    default:
                        onemoretime = true;
                        break;
                }

            }
        }
        public static void TestBench()
        {
            BenchmarkSwitcher.FromAssembly(typeof(Lesson3).Assembly).Run();
        }
    }
    public class PointClass<T>
    {
        public T X;
        public T Y;
    }
    public struct PointStruct<T>
    {
        public T X;
        public T Y;
    }

    public class BechmarkClass
    {
        [Benchmark]
        public float Distance_Ref_float()//Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
        {
            PointClass<float> pointOne1 = new PointClass<float> { X = 123.456f, Y = 7859.256f };
            PointClass<float> pointTwo2 = new PointClass<float> { X = 454.456f, Y = 4178.256f };

            float x = pointOne1.X - pointTwo2.X;
            float y = pointOne1.Y - pointTwo2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public float Distance_Val_float()//Обычный метод расчёта дистанции со значимым типом(PointStruct — координаты типа float).

        {
            PointStruct<float> pointOne = new PointStruct<float> { X = 123.456f, Y = 7859.256f };
            PointStruct<float> pointTwo = new PointStruct<float> { X = 454.456f, Y = 4178.256f };

            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public double Distance_Val_double()//Обычный метод расчёта дистанции со значимым типом(PointStruct — координаты типа double).

        {
            PointStruct<double> pointOne = new PointStruct<double> { X = 123.456, Y = 7859.256 };
            PointStruct<double> pointTwo = new PointStruct<double> { X = 454.456, Y = 4178.256 };

            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public float Distance_Val_float_NO_sqrt()//Обычный метод расчёта дистанции со значимым типом без вычисления корня(PointStruct — координаты типа float).

        {
            PointStruct<float> pointOne = new PointStruct<float> { X = 123.456f, Y = 7859.256f };
            PointStruct<float> pointTwo = new PointStruct<float> { X = 454.456f, Y = 4178.256f };

            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
    }
}
