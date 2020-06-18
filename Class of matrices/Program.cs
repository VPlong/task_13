//HMTбд-01-18 Черкасова Валерия 
//Задача 13. "Описать класс матриц, в котором реализованы основные операторы: сложения, вычитания, умножения, транспонирования."
//17.06.2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program 
{
    class Matrix
    {
        // Скрытые поля
        private int n;
        private int m;
        private int[,] mass;

        // Создаем конструкторы матрицы
        public Matrix() { }
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }

        public int M
        {
            get { return m; }
            set { if (value > 0) m = value; }
        }

        // Задаем аксессоры для работы с полями вне класса Matrix
        public Matrix(int n, int m) 
        {
            this.n = n;
            this.m = m;
            mass = new int[this.n, this.m];
        }
        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }

        // Рандомное заполение матрицы
        public void RandomWriteMat()
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    mass[i, j] = rnd.Next(1, 100); 
                }
            }
        }

        // Ввод матрицы с клавиатуры
        public void WriteMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введите элемент {0}{1}", i + 1, j + 1);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        // Вывод матрицы на консоль
        public void ReadMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Транспонирование матрицы
        public static Matrix Tr(Matrix a) 
        {
            Matrix trMat = new Matrix(a.M, a.N);
            for (int i = 0; i < a.M; i++)
                 for (int j = 0; j < a.N; j++)
                     trMat[i, j] = a[j, i]; 
                   
            return trMat; 
            
        }
        
        // Умножение матрицы А на матрицу В
        public static Matrix Mult(Matrix a, Matrix b)
        {
            
                Matrix resMat = new Matrix(a.N, b.M);
                for (int i = 0; i < a.N; i++)
                    for (int j = 0; j < b.M; j++)
                        for (int k = 0; k < b.N; k++)
                            resMat[i, j] += a[i, k] * b[k, j];

                return resMat;
            
            
        }

        // перегрузка оператора умножения
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.Mult(a, b); 
        }

        // Метод вычитания матрицы Б из матрицы А
        public static Matrix Substr(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N, a.M);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка оператора вычитания
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.Substr(a, b);
        }

        // Метод сложения матрицы А с матрицой В
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N, a.M); 
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка сложения
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }

        // Деструктор Matrix
        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }

    }
    class MainProgram
    {

        static void Main(string[] args)
        {
            //Создаём массив под матрицу А
            Console.WriteLine("Введите количество строк матрицы A:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            while (n1 <= 0)
            {
                Console.WriteLine("Ошибка. Количество строк введено неккоректно.");
                Console.WriteLine("Введите количество строк матрицы A:");
                n1 = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите количество столбцов матрицы А: ");
            int m1 = Convert.ToInt32(Console.ReadLine());
            while (m1 <= 0)
            {
                Console.WriteLine("Ошибка. Количество столбцов введено неккоректно.");
                Console.WriteLine("Введите количество столбцов матрицы A:");
                m1 = Convert.ToInt32(Console.ReadLine());
            }
            Matrix mass1 = new Matrix(n1, m1);

            //Создаём массив под матрицу В
            Console.WriteLine("Введите количество строк матрицы В: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            while (n2 <= 0)
            {
                Console.WriteLine("Ошибка. Количество строк введено неккоректно.");
                Console.WriteLine("Введите количество строк матрицы B:");
                n2 = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите количество столбцов матрицы B:"); 
            int m2 = Convert.ToInt32(Console.ReadLine());
            while (m2 <= 0)
            {
                Console.WriteLine("Ошибка. Количество столбцов введено неккоректно.");
                Console.WriteLine("Введите количество столбцов матрицы В:");
                m2 = Convert.ToInt32(Console.ReadLine());
            }
            Matrix mass2 = new Matrix(n2, m2);

            Console.WriteLine("Если хотите задать матрицу А с клавиатуры напишите 1, если хотите заполнить матрицу А случайными числами, напишите 2");
            int v = Convert.ToInt32(Console.ReadLine());
            while (v != 1 && v != 2)
            {
                Console.WriteLine("Вы выбрали не существующий вариант");
                Console.WriteLine("Если хотите задать матрицу А с клавиатуры напишите 1, если хотите заполнить матрицу А случайными числами, напишите 2");
                v = Convert.ToInt32(Console.ReadLine());
            }

            if (v == 1)
            {
                Console.WriteLine("Ввод элементов матрицы А:");
                mass1.WriteMat();
            } 
            else if (v == 2)
            {
                Console.WriteLine("Рандомное заполнение матрицы А:");
                mass1.RandomWriteMat();
            }

            Console.WriteLine();
            Console.WriteLine("Матрица А: ");
            Console.WriteLine();
            mass1.ReadMat();
            Console.WriteLine();

            Console.WriteLine("Если хотите задать матрицу В с клавиатуры напишите 1, если хотите заполнить матрицу А случайными числами, напишите 2");
            v = Convert.ToInt32(Console.ReadLine());
            while (v != 1 && v != 2)
            {
                Console.WriteLine("Вы выбрали не существующий вариант");
                Console.WriteLine("Если хотите задать матрицу B с клавиатуры напишите 1, если хотите заполнить матрицу B случайными числами, напишите 2");
                v = Convert.ToInt32(Console.ReadLine());
            }

            if (v == 1)
            {
                Console.WriteLine("Ввод элементов матрицы B:");
                mass2.WriteMat();
            }
            else if (v == 2)
            {
                Console.WriteLine("Рандомное запонение матрицы B:");
                mass2.RandomWriteMat();
            }

            Console.WriteLine("Матрица В: ");
            Console.WriteLine();
            mass2.ReadMat();
            Console.WriteLine();         

            Console.WriteLine("Сумма матриц А и Б: ");
            if (n1 != n2 || m1 != m2)
            {
                Console.WriteLine();
                Console.WriteLine("Не корректные размеры матриц для операции сложения");
                Console.WriteLine();
            }
            else
            {
                Matrix mass3 = (mass1 + mass2);
                Console.WriteLine();
                mass3.ReadMat();
                Console.WriteLine();
            }

            Console.WriteLine("Разность матриц А и В: ");
            if (n1 != n2 || m1 != m2)
            {
                Console.WriteLine();
                Console.WriteLine("Не корректные размеры матриц для операции вычитания");
                Console.WriteLine();
            }
            else
            {
                Matrix mass4 = new Matrix(n1, m1);
                mass4 = (mass1 - mass2);
                Console.WriteLine();
                mass4.ReadMat();
                Console.WriteLine();
            }

            Console.WriteLine("Произведение матриц А и В: ");
            if (m1 != n2)
            {
                Console.WriteLine();
                Console.WriteLine("Не корректные размеры матриц для операции умножения");
                Console.WriteLine();
            }
            else
            { 
                Matrix mass5 = (mass1 * mass2);
                Console.WriteLine();
                mass5.ReadMat();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Транспонированная матрица к A:");
            Console.WriteLine();
            Matrix mass6 = Matrix.Tr(mass1);
            mass6.ReadMat();

            Console.WriteLine();
            Console.WriteLine("Транспонированная матрица к B:");
            Console.WriteLine();
            Matrix mass7 = Matrix.Tr(mass2);
            mass7.ReadMat();

            Console.ReadKey();
        }
    }
}
