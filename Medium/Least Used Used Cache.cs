using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class LRUCache
    {

        // key -> Node(key, val)
        private Dictionary<int, Node> map;
        // Node(k1, v1) <-> Node(k2, v2)...
        DoubleList cache;
        // 最大容量
        private int cap;

        public class Node
        {
            //implement double linked Node
            public int key { get; set; }
            public int val { get; set; }
            public Node prev { get; set; }
            public Node next { get; set; }
            //constructor    
            public Node(int key, int val)
            {
                this.key = key;
                this.val = val;
            }

        }

        public class DoubleList
        {

            Node head, tail;

            public DoubleList()
            {
                head = new Node(0, 0);
                tail = new Node(0, 0);
                head.next = tail;
                tail.prev = head;
            }

            // 在链表头部添加节点 x，时间 O(1)
            public void addFirst(Node x)
            {
                //map[x.key] = x.val;
                var temp = head.next;
                head.next = x;
                x.prev = head;
                x.next = temp;
                temp.prev = x;
            }

            // 删除链表中的 x 节点（x 一定存在）
            // 由于是双链表且给的是目标 Node 节点，时间 O(1)
            public void remove(Node x)
            {
                //map.Remove(x.key);
                x.prev.next = x.next;
                x.next.prev = x.prev;
            }

            // 删除链表中最后一个节点，并返回该节点，时间 O(1)
            public Node removeLast()
            {
                var temp = tail.prev;
                remove(tail.prev);
                return temp;
            }
        }





        public LRUCache(int capacity)
        {
            this.cap = capacity;
            map = new Dictionary<int, Node>();
            cache = new DoubleList();
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key))
                return -1;
            int val = map[key].val;
            // 利用 put 方法把该数据提前
            Put(key, val);
            return val;
        }

        public void Put(int key, int val)
        {
            // 先把新节点 x 做出来
            Node x = new Node(key, val);

            if (map.ContainsKey(key))
            {
                // 删除旧的节点，新的插到头部 (更新route)
                cache.remove(map[key]);
                cache.addFirst(x);
                // 更新 map 中对应的数据
                map[key] = x;
            }
            else
            {
                if (cap == map.Count)
                {
                    //(溢出route)
                    // 删除链表最后一个数据
                    Node last = cache.removeLast();
                    // 更新 map 中对应的数据
                    map.Remove(last.key);
                }
                //(添加route)
                // 直接添加到头部
                cache.addFirst(x);
                map[key] = x;
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
