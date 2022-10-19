using System;
using System.Windows;
using MyList;

namespace Lab5_OOP
{
    class Program
    {
        public static void Main(string[] _)
        {
            Task1();
            Task2();
        }
        private static void Task1()
        {
            /*Создайте класс, описывающий данные по варианту. 
             * Доступ ко всем полям организуйте через свойства, 
             * учитывающие ограничения на возможные значения поля. 
             * Всем полям также определите значения по умолчанию и несколько вариантов конструктора. 
             * В классе должно быть статическое поле и соответствующее ему свойство. 
             * Помимо этого должен быть статический метод, 
             * который производит вычисления на основе этого свойства. 
             * Продемонстрируйте работу с этим классом. */

            ///////////// 8 ВАРИАНТ ///////////////

            /* Класс: Сотрудник – поля и свойства: ФИО (не может быть пустой строкой),
             * должность (только определенный набор значений), отдел (только определенный набор значений), 
             * возраст (от 18). Статическое поле: пенсионный возраст (больше 30). 
             * Статический метод: вычисляет, может ли сотрудник выйти на пенсию.*/

            new Employee("Ivan", "Ivanov", "Ivanovich", "A-Block", 32, 20);
            new Employee("Ivan", "Ivanov", "Ivanovich", "A-Block", 12);
            new Employee("Ivan", "Ivanov", "Ivanovich", "", 20);
            new Employee("Ivan", "Ivanov", "     ", "A-Block", 20);
            new Employee("Ivan", " ", "Ivanovich", "A-Block", 20);
            new Employee(string.Empty, "Ivanov", "Ivanovich", "A-Block", 20);


            Console.WriteLine(new Employee("Ivan", "Ivanov", "Ivanovich", "A-Block", 23).ToString());
            Employee.EmployeeCanRetire(new Employee("Ivan", "Ivanov", "Ivanovich", "A-Block", 23));
            Employee.EmployeeCanRetire(new Employee("Ivan", "Ivanov", "Ivanovich", "A-Block", 23, 32));
            Employee.EmployeeCanRetire(new Employee("Ivan", "Ivanov", "Ivanovich", "A-Block", 80));
            Console.ReadKey();
            Console.Clear();

        }
        private static void Task2()
        {
            /*Создайте класс, описывающий данные по варианту. 
             * Доступ ко всем полям организуйте через свойства, 
             * учитывающие ограничения на возможные значения поля. 
             * Всем полям также определите значения по умолчанию и несколько вариантов конструктора. 
             * В классе должно быть статическое поле и соответствующее ему свойство. 
             * Помимо этого должен быть статический метод, 
             * который производит вычисления на основе этого свойства. 
             * Продемонстрируйте работу с этим классом. */
            ListQueue listQueue = new ListQueue();





            Console.ReadKey();
            Console.Clear();
        }
    }
    class Employee
    {
        private string _name;
        private string _surname;
        private string _patronomic;
        private string _department;
        private int _age;
        private static int _retirementAge;

        public string Name
        {
            get { return _name; }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("_name", "Name is Empty");
                if(value.Any(x => char.IsDigit(x))) throw new Exception("Имя недолжно содержать цифр");

                _name = value;
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("_surname", "Surname is Empty");
                if (value.Any(x => char.IsDigit(x))) throw new Exception("Фамилия недолжно содержать цифр");

                _surname = value;
            }
        }
        public string Patronomic
        {
            get { return _patronomic; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("_patronomic", "Patronomic is Empty");
                if (value.Any(x => char.IsDigit(x))) throw new Exception("Отчество недолжно содержать цифр");

                _patronomic = value;
            }
        }
        public string Department
        {
            get { return _department; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("_department");

                _department = value;
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 18) throw new Exception("Возвраст работника не может быть меньше 18");

                _age = value;
            }
        }
        public int RetirementAge
        {
            get { return _retirementAge; }
            set
            {
                if (value < 30) throw new Exception("Пенсионный возвраст работника не может быть меньше 30");

                _retirementAge = value;
            }
        }

        public Employee(string name, string surname, string patronomic, string department, int age)
        {
            try
            {
                Name = name;
                Surname = surname;
                Patronomic = patronomic;
                Department = department;
                Age = age;
                RetirementAge = 65;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        public Employee(string name, string surname, string patronomic, string department, int age, int retirementAge)
        {
            try
            {
                Name = name;
                Surname = surname;
                Patronomic = patronomic;
                Department = department;
                Age = age;
                RetirementAge = retirementAge;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        public static void EmployeeCanRetire(Employee employee)
        {
            if(employee._age >= _retirementAge)
            {
                Console.WriteLine("Сотрудник может выйти на пенсию");
            }
            else
            {
                Console.WriteLine("Сотрудник сможет выйти на пенсию, через " + (_retirementAge - employee._age) + "  лет");
            }
        }
        public override string ToString()
        {
            return "Full name " + _name + " " + _surname + " " + _patronomic + ". Department " + _department + ". Age " + _age;
        }
    }

}