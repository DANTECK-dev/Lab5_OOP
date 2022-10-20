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
        public int Count
        {
            get { return count; }
            private set
            {
                if (count < 0) throw new ArgumentNullException();
                count = value;
            }
        }
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
            node.Prev = tail;
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
            head!.Prev = null;

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
                    cur!.Data = person;
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
            for(int i = 1; i < count; i++)
            {
                Person? cur = Get(i);
                
                for (int j = i; j >= 0; j--)
                {
                    Set(Get(j - 1), j);
                    if (j == 0)
                    {
                        Set(cur, j);
                        break;
                    }
                    if (cur!.ToString()[0] > Get(j - 1)?.ToString()[0] || cur!.ToString()[0] == Get(j - 1)?.ToString()[0])
                    {
                        Set(cur, j);
                        break;
                    }
                }
            }   
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