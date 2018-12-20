using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        readonly int _l;
        int lenght;
        Node<TKey, TValue>[] arr;
        public int count { get; private set; }

        public MyDictionary()
        {
            lenght = 100;
            _l = lenght;
            arr = new Node<TKey, TValue>[lenght];
        }
        public MyDictionary(uint l)
        {
            lenght = (int)l;
            _l = lenght;
            arr = new Node<TKey, TValue>[lenght];
        }

        public void Add(TKey key, TValue value)
        {
            var index = GetHash(key);
            if(arr[index] == null)
            {
                arr[index] = new Node<TKey, TValue>() {Key = (key), Value = value };
            }
            else
            {
                Node<TKey,TValue> temp = arr[index];
                while (temp.NextNode != null)
                {
                    temp = temp.NextNode;
                }
                temp.NextNode = new Node<TKey, TValue>() { Key = key, Value = value };
            }
            count++;
        }

        public void Clear()
        {
            Node<TKey, TValue>[] temp = new Node<TKey, TValue>[_l];
            arr = temp;
            count = 0;
        }

        public TValue ContainsKey(TKey key)
        {
            var pos = GetHash(key);
            if(count != 0)
            {
                Node<TKey, TValue> temp;
                if (arr[pos] != null)
                {
                    temp = arr[pos];
                    while (temp.NextNode != null)
                    {
                        if (temp.Key.Equals(key))
                        {
                            Console.Write("Key - {0} exists.Value - {1} ", key, temp.Value);
                            return temp.Value;
                        }
                        temp = temp.NextNode;
                    }
                }
                Console.Write("Key - {0} not exists. ", key);
                return default(TValue);
            }
            else
            {
                Console.WriteLine("Dictionary empty");
                return default(TValue);
            }
        }

        public TValue ContainsValue(TValue value)
        {
            if(count != 0)
            {
                Node<TKey, TValue> temp;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != null)
                    {
                        temp = arr[i];
                        while (temp.NextNode != null)
                        {
                            if (temp.Value.Equals(value))
                            {
                                Console.Write("Value - {0} exists. ", value);
                                return value;
                            }
                            temp = temp.NextNode;
                        }
                    }
                }
                Console.Write("Value - {0} not exists. ", value);
                return default(TValue);
            }
            else
            {
                Console.WriteLine("Dictionary empty");
                return default(TValue);
            }
        }

        public void Remove(TKey key)
        {
            var pos = GetHash(key);
            if (count != 0)
            {
                Node<TKey, TValue> temp;
                Node<TKey, TValue> Oldtemp = new Node<TKey, TValue>();
                int posCount = 0;
                if(arr[pos] != null)
                {
                    if(arr[pos].NextNode == null && arr[pos].Key.Equals(key))
                    {
                        arr[pos] = null;
                        count--;
                    }
                    temp = arr[pos];
                    while (temp != null)
                    {
                        if (temp.Key.Equals(key))
                        {
                            if( posCount == 0)
                            {
                                arr[pos] = arr[pos].NextNode;
                                count--;
                                break;
                            }
                            Oldtemp.NextNode = temp.NextNode;
                            temp = Oldtemp;
                            count--;
                            break;
                        }
                        posCount++;
                        Oldtemp = temp;
                        temp = temp.NextNode;
                    }
                }
            }
            else
            {
                Console.WriteLine("Dictionary empty");
            }
        }

        public int GetHash(TKey key)
        {
            return Math.Abs(key.GetHashCode() % arr.Length);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> Enumerator()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != null)
                {
                    if(arr[i].NextNode == null)
                    {
                        yield return new KeyValuePair<TKey, TValue>(arr[i].Key, arr[i].Value);
                    }
                    else
                    {
                        Node<TKey, TValue> temp = arr[i];
                        while(temp != null)
                        {
                            yield return new KeyValuePair<TKey, TValue>(temp.Key, temp.Value);
                            temp = temp.NextNode;
                        }
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Enumerator();
        }

        public void DictionaryInfo()
        {
            Node<TKey, TValue> temp;
            if(count != 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("Index {0}:", i);
                    if(arr[i] != null)
                    {
                        temp = arr[i];
                        Console.Write(" Key: {0} - Value: {1} ", temp.Key, temp.Value);
                        while (temp.NextNode != null)
                        {
                            temp = temp.NextNode;
                            Console.Write(" Key: {0} - Value: {1} ", temp.Key, temp.Value);
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Dictionary empty");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enumerator();
        }
    }
}
