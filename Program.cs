using System;
using System.Collections.Generic;

namespace Lab_OOP_3
{
    public class Worker
    {
        //Функция, проверяющая состоит ли строка только из букв
        protected static bool IsLettersOnly(string str)
        {
            foreach (char s in str)
            {
                if (s >= '0' && s <= '9')
                    return false;
            }
            return true;
        }
        //Функция, изменяющая строку таким образом, что первая буква становится заглавной, а остальные строчными
        protected static string FirstLetterToUpper(string str)
        {
            str = str.ToLower();
            string FirstUpperStr = str.Substring(0,1).ToUpper() + str[1..];
            return FirstUpperStr;
        }

        private string surname;
        private string initials;
        private string post;
        private int yearOfApply;
        private int salary;

        public string Surname
        {
            get 
            {
                return surname;
            }
            set
            {
                if (IsLettersOnly(value))
                {
                    surname = FirstLetterToUpper(value);
                }
                else 
                {
                    Console.WriteLine("Некорректный ввод. В фамилии присутствует число, попробуйте ещё раз.");
                }
            }
        }
        public string Initials
        {
            get
            {
                return initials;
            }
            set
            {
                if (IsLettersOnly(value))
                {
                    initials = value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. В инициалах присутствует число, попробуйте ещё раз.");
                }
            }
        }
        public string Post
        {
            get
            {
                return post;
            }
            set
            {
                if (int.TryParse(value, out _))
                {
                    Console.WriteLine("Некорректный ввод. Вместо должности было введено число.");
                }
                else
                {
                    post = FirstLetterToUpper(value);
                }
            }
        }
        public int YearOfApply
        {
            get
            {
                return yearOfApply;
            }
            set
            {
                if (value >= 2000 && value <= DateTime.Now.Year)
                {
                    yearOfApply = value;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введенная дата не соответствует указанному промежутку. Попробуйте ещё раз.");
                }
            }
        }
        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value > 0)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введена некорректная зарплата. Попробуйте ещё раз.");
                }
            }
        }
        public Worker()
        { 
        
        }
        public Worker(string surname, string initials, string post, int yearOfApply, int salary)
        {
            Surname = surname;
            Initials = initials;
            Post = post;
            YearOfApply = yearOfApply;
            Salary = salary;
        }
    }

    class Program : Worker
    {
        //Функция, выводящая интерфейс
        protected static void PrintInterface(bool ListIsNotEmpty)
        {
            Console.Write("\r\nВыберите действие:\r\n1.Создать работника");
            if (ListIsNotEmpty)
            {
                Console.Write("\r\n2.Вывести список работников, стаж которых привышает заданное число лет\r\n3.Вывести список работников, зарплата которых больше заданной\r\n4.Вывести список работников, занимающих заданную должность\r\n5.Удалить работника");
            }
            Console.Write("\r\n6.Выход\r\nВвод: ");
        }
        //Функция, проверяющая ввод на число
        protected static int GetNumber(string input)
        {
            if (int.TryParse(input, out int num))
            {
                return num;
            }
            else
            {
                Console.WriteLine("Ошибка! Вы ввели строку вместо числа. Попробуйте ещё раз.");
                Console.Write("Ввод: ");
                return GetNumber(Console.ReadLine());
            }
        }
        //Функция, печатающая верхнюю строку таблицы с информацией
        protected static void PrintTableInfo()
        {
            Console.WriteLine("Список работников:\r\n{0,4}\t|{1,20}\t|{2,20}\t|{3,20}\t|{4,15}", "№", "Фамилия и инициалы", "Должность", "Год поступления", "Зарплата");
        }
        //Функция, печатающая информацию о сотруднике
        protected static void PrintWorkerInfo(int num, string surname, string initials, string post, int yearOfApply, int salary)
        {
            Console.WriteLine("{0,4}\t|{1,20}\t|{2,20}\t|{3,20}\t|{4,15}", num, surname + " " +initials, post, yearOfApply, salary);
        }
        //Функция, преобразующая имя и отчество в инициалы
        protected static string MakeInitials(string name, string patronymic)
        {
            string initials = (name.Substring(0, 1) + "." + patronymic.Substring(0, 1)).ToUpper() + ".";
            return initials;
        }
        //Функция, возвращающая значение для осуществления возврата к меню после выбора команды
        protected static string CheckBack()
        {
            Console.Write(" или введите команду \"Назад\": ");
            string back = Console.ReadLine();
            return back;
        }

        static void Main()
        {
            // TODO: Переписать главное разветление, образованное переменной WorkersAreNotEmpty
            List<Worker> workers = new List<Worker>();
            bool flag = true, workersAreNotEmpty;
            int action, num, index;
            string post, name, patronymic, ansAutoData, back;
            
            do
            {
                Console.WriteLine("Желаете заполнить массив данными по умолчанию?(Да/Нет)");
                Console.Write("Ввод: ");
                ansAutoData = Console.ReadLine();
                if (ansAutoData.ToUpper() == "ДА")
                {
                    Worker worker1 = new Worker("Гугучкин", "А.А.", "Джун", 2020, 25000);
                    workers.Add(worker1);
                    Worker worker2 = new Worker("Хауди", "Х.О.", "Мидл", 2015, 45000);
                    workers.Add(worker2);
                    Worker worker3 = new Worker("Дрянин", "М.Е.", "Сеньор", 2012, 70000);
                    workers.Add(worker3);
                }
                else if (ansAutoData.ToUpper() != "НЕТ")
                {
                    Console.WriteLine("Ошибка! Вы ввели другой ответ, попробуйте ещё раз.");
                    ansAutoData = null;
                }
            } while (ansAutoData == null);
            
            while (flag)
            {
                index = 1;
                if (workers.Count == 0)
                {
                    workersAreNotEmpty = false;
                }
                else
                {
                    workersAreNotEmpty = true;
                }
                PrintInterface(workersAreNotEmpty);
                action = GetNumber(Console.ReadLine());
                if (action == 1)
                {
                    Console.Write("Для начала ввода данных работника нажмите Enter");
                    back = CheckBack();
                    if (back.ToUpper() != "НАЗАД")
                    {
                        Worker worker = new Worker();
                        while (worker.Surname == null)
                        {
                            Console.Write("Введите фамилию: ");
                            worker.Surname = Console.ReadLine();
                        }
                        name = null;
                        while (name == null)
                        {
                            Console.Write("Введите имя: ");
                            name = Console.ReadLine();
                            if (!IsLettersOnly(name))
                            {
                                Console.WriteLine("Ошибка! Вы ввели строку, содержащую число. Попробуйте ещё раз.");
                                name = null;
                            }
                        }
                        patronymic = null;
                        while (patronymic == null)
                        {
                            Console.Write("Введите отчество: ");
                            patronymic = Console.ReadLine();
                            if (!IsLettersOnly(patronymic))
                            {
                                Console.WriteLine("Ошибка! Вы ввели строку, содержащую число. Попробуйте ещё раз.");
                                patronymic = null;
                            }
                        }
                        worker.Initials = MakeInitials(name, patronymic);
                        while (worker.Post == null)
                        {
                            Console.Write("Введите должность: ");
                            worker.Post = Console.ReadLine();
                        }
                        while (worker.YearOfApply == 0)
                        {
                            Console.Write("Введите год поступления на работу(в 21 веке и не позже действительного года): ");
                            if (int.TryParse(Console.ReadLine(), out num))
                            {
                                worker.YearOfApply = num;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Вы ввели строку вместо числа. Попробуйте ещё раз.");
                            }
                        }
                        while (worker.Salary == 0)
                        {
                            Console.Write("Введите зарплату(в рублях): ");
                            if (int.TryParse(Console.ReadLine(), out num))
                            {
                                worker.Salary = num;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Вы ввели строку вместо числа. Попробуйте ещё раз.");
                            }
                        }
                        workers.Add(worker);
                    }
                }
                else if (action == 2 && workersAreNotEmpty)
                {
                    Console.Write("Введите стаж работы: ");
                    num = GetNumber(Console.ReadLine());
                    PrintTableInfo();
                    foreach (Worker w in workers)
                    {
                        if (DateTime.Now.Year - w.YearOfApply > num)
                        {
                            PrintWorkerInfo(index, w.Surname, w.Initials, w.Post, w.YearOfApply, w.Salary);
                            index++;
                        }
                    }
                }
                else if (action == 3 && workersAreNotEmpty)
                {
                    Console.Write("Введите зарплату: ");
                    num = GetNumber(Console.ReadLine());
                    PrintTableInfo();
                    foreach (Worker w in workers)
                    {
                        if (w.Salary > num)
                        {
                            PrintWorkerInfo(index, w.Surname, w.Initials, w.Post, w.YearOfApply, w.Salary);
                            index++;
                        }
                    }
                }
                else if (action == 4 && workersAreNotEmpty)
                {
                    Console.Write("Введите должность: ");
                    post = Console.ReadLine();
                    while (post == null)
                    {
                        if (int.TryParse(post, out _))
                        {
                            Console.WriteLine("Некорректный ввод. Вместо должности было введено число.");
                            post = null;
                        }
                        else
                        {
                            post = FirstLetterToUpper(post);
                        }
                    }
                    PrintTableInfo();
                    foreach (Worker w in workers)
                    {
                        if (w.Post.ToUpper() == post.ToUpper())
                        {
                            PrintWorkerInfo(index, w.Surname, w.Initials, w.Post, w.YearOfApply, w.Salary);
                            index++;
                        }
                    }
                }
                else if (action == 5 && workersAreNotEmpty)
                {
                    num = 1;
                    PrintTableInfo();
                    foreach (Worker w in workers)
                    {
                        PrintWorkerInfo(num, w.Surname, w.Initials, w.Post, w.YearOfApply, w.Salary);
                        num++;
                    }
                    Console.Write("\r\nВведите номер работника, которого хотите удалить");
                    back = CheckBack();
                    if (back.ToUpper() != "НАЗАД")
                    {
                        num = GetNumber(back);
                        if (num <= workers.Count)
                        {
                            workers.RemoveAt(num - 1);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод. Не существует работника под введенным номером.");
                        }
                    }
                }
                else if (action == 6)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Ошибка! В меню отсутствует пункт под введенный номер. Попробуйте ещё раз.");
                }                   
            }
        }
    }
}
