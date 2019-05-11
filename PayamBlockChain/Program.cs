using System;

namespace PayamBlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class PayamLinkList
    {
        private object Data { get;}
        public PayamLinkList Link;
        
        public PayamLinkList(object data)
        {
            Data = data;
            Link = null;
        }
    }

    public class SingleLinkList
    {
        public PayamLinkList Head { get; set; }
    }


    public class LinkListOps
    {
        public void InsertFront(SingleLinkList singlyLinkList, object data)
        {
            PayamLinkList payamLinkList = new PayamLinkList(data);
            payamLinkList.Link = singlyLinkList.Head;
            singlyLinkList.Head = payamLinkList;
        }
    }
}