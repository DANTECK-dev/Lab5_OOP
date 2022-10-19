namespace MyList
{
    interface IListQueue
    {
        public void Add(Person person);
        public Person? Remove();
        public void GetMassive();
    }
    public class Person
    {
        private string? Name { get; }
        private string? Surname { get; }
        private string? Patronymic { get; }

        public Person(string Name, string Surname, string Patronymic)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
        }
        public override string ToString()
        {
            return Name + " " + Surname + " " + Patronymic;
        }
    }
    public class Node
    {
        public Person? Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }
        public override string? ToString()
        {
            return Data?.ToString();
        }
    }
    public class ListQueue : IListQueue
    {
        private Node? head = null;
        private Node? tail = null;
        int count = 0;
        public void Add(Person person)
        {
            Node? node = new()
            {
                Data = person
            };
            if (head == null)
                head = node;
            else if (head.Next == null)
                head.Next = node;

            if (tail != null)
                tail.Next = node;
            tail = node;

            count++;
            Console.WriteLine(person.ToString() + " Added");
        }
        public Person? Remove()
        {
            if (head == null || tail == null)
            {
                Console.WriteLine("ListQueue is empty");
                tail = null;
                return null;
            }
            var person = head.Data;
            if (person == null)
            {
                Console.WriteLine("ListQueue is empty");
                return null;
            }
            head = head.Next;
            Console.WriteLine(person.ToString() + " Removed");
            count--;
            return person;
        }
        public Person? Get(int index)
        {
            if (head == null || tail == null)
            {
                Console.WriteLine("ListQueue is empty");
                return null;
            }
            if (index >= count)
            {
                Console.WriteLine("Out in the range");
                return null;
            }

            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    return cur?.Data;
                }
                cur = cur?.Next;
            }
            return null;
        }
        public void Set(Person? person, int index)
        {
            if (person == null)
            {
                Console.WriteLine("Person is empty");
                return;
            }
            if (head == null || tail == null)
            {
                Console.WriteLine("ListQueue is empty");
                return;
            }
            if (index >= count)
            {
                Console.WriteLine("Out in the range");
                return;
            }

            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    cur.Data = person;
                    return;
                }
                cur = cur?.Next;
            }
            return;
        }
        public void GetMassive()
        {
            Sort();
            Console.WriteLine("");
            Print();
        }
        private void Sort()
        {
            int min = 0;
            int max = count - 1;
            int dir = min;
            do
            {
                for (int i = min; i <= max; i++)
                {
                    if ((i + 1) >= count) continue;
                    //Console.WriteLine((int) Get(i)?.ToString()[0] + " > " + (int) Get(i + 1)?.ToString()[0]);
                    if (Get(i)?.ToString()[0] > Get(i + 1)?.ToString()[0])
                    {
                        Person? temp = Get(i);
                        Set(Get(i + 1), i);
                        Set(temp, i + 1);
                        dir = i + 1;
                    }
                }
                max = dir;
                for (int i = max; min <= i; i--)
                {
                    if ((i - 1) < 0) continue;
                    //Console.WriteLine(Get(i)?.ToString()[0] + " < " + Get(i - 1)?.ToString()[0]);
                    if (Get(i)?.ToString()[0] < Get(i - 1)?.ToString()[0])
                    {
                        Person? temp = Get(i);
                        Set(Get(i - 1), i);
                        Set(temp, i - 1);
                        dir = i - 1;
                    }
                }
                min = dir;
            } while (min != max);
        }
        private void Print()
        {
            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(cur?.Data?.ToString());
                cur = cur?.Next;
            }
        }
    }
}