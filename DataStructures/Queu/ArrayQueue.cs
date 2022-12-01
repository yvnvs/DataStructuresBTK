namespace DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly List<T> list = new List<T>();
        public int Count {get; private set;}

        public T DeQueu()
        {
            if (Count == 0)
            {
                throw new Exception("Empty queue!");
            }
            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public void EnQueue(T value)
        {
            if (value==null)
            {
                throw new ArgumentNullException("value");
            }
            list.Add(value);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new Exception("Empty queue!");
            }
            return list[0];
        }
    }
}

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var found = new HashSet<int>();

        foreach (var n in nums)
        {
            if (found.Contains(n))
            {
                return true;
            }
            found.Add(n);
        }

        return false;
    }
}
