using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachLienKetDon
{
    class Node
    {
        private int info;
        private Node next;
        public Node(int x)
        {
            info = x;
            next = null;
        }
        public int Info
        {
            set { this.info = value; }
            get { return info; }
        }
        public Node Next
        {
            set { this.next = value; }
            get { return next; }
        }
    }
    class SingleLinkList
    {
        private Node Head;
        public SingleLinkList()
        { Head = null; }

        public void AddHead(int x)
        {
            Node p = new Node(x);
            p.Next = Head;
            Head = p;
        }
        public void DeleteHead()
        {
            if (Head != null)
            {
                Node p = Head;
                Head = Head.Next;
                p.Next = null;
            }
        }
        public void DeleteLast()
        {
            if (Head != null)
            {
                Node p = Head;
                Node q = null;
                while (p.Next != null)
                {
                    q = p;
                    p = p.Next;
                }
                q.Next = null;
            }
        }

        public void AddLast(int x)
        {
            Node p = new Node(x);
            if (Head == null)
            {
                Head = p;
            }
            else
            {
                Node q = Head;
                while (q.Next != null) { q = q.Next; }
                q.Next = p;
            }
        }
        public void DeleteNode(int x)
        {
            if (Head != null)
            {
                Node p = Head;
                Node q = null;
                while (p != null && p.Info != x)
                {
                    q = p;
                    p = p.Next;
                }
                if (p != null)
                {
                    if (p == null)
                        DeleteHead();
                    else
                    {
                        q.Next = p.Next;
                        p.Next = null;
                    }
                }
            }
        }
        public float Avg()
        {
            float sum = 0;
            int count = 0;
            Node p = Head;
            while (p != null)
            {
                sum += p.Info;
                count++;

                p = p.Next;
            }
            return sum / count;
        }
        public Node findMax()
        {
            Node max = Head;
            Node p = Head.Next;
            while (p != null)
            {
                if (p.Info > max.Info)
                {
                    max = p;
                }
                p = p.Next;
            }
            return max;
        }
        public void ProcessList()
        {
            Node p = Head;
            while (p != null)
            {
                Console.Write($"{p.Info}  ");
                p = p.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SingleLinkList l = new SingleLinkList();
            //l.AddHead(9);
            //l.AddHead(7);
            //l.AddHead(5);
            //l.AddLast(3);
            NhapDanhSach(l);

            Console.WriteLine("Danh sách liên kết: ");
            l.ProcessList();

            l.DeleteHead();
            Console.WriteLine("\n Danh sách liên kết sau khi bị xoá nút đầu:");
            l.ProcessList();

            l.DeleteLast();
            Console.WriteLine("\n Danh sách liên kết sau khi bị xoá nút cuối:");
            l.ProcessList();

            Console.Write("Nhập giá x cần xoá: ");
            int x = int.Parse(Console.ReadLine());
            l.DeleteNode(x);
            Console.Write("\n Danh sách liên kết sau khi xoá nút có giá trị x: ");
            l.ProcessList();


            Node max = l.findMax();
            Console.WriteLine($"\n Nút có giá trị lớn nhất: { max.Info}");
            float tbc = l.Avg();
            Console.WriteLine($"\n Giá trị trung bình các nút: {tbc}");
            Console.ReadLine();
        }
        static void NhapDanhSach(SingleLinkList l)
        {
            string chon = "y";
            int x;
            while (chon != "n")
            {
                Console.WriteLine("Nhập giá trị nút: ");
                x = int.Parse(Console.ReadLine());
                l.AddLast(x);
                Console.Write("Tiếp tục (y/n)?");
                chon = Console.ReadLine();
            }
        }
    }
}

