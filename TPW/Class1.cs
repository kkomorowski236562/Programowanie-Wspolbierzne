using System;


namespace Hello
{
    public class Hello
    {
        private string hello;
        public void set_hello(string x)
        {
            hello = x;
        }
        public string get_hello()
        {
            return hello;
        }
        public static void Main()
        {
            System.Console.WriteLine("Hello World!");
        }
    }
}
