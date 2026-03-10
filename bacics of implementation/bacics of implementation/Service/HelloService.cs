namespace bacics_of_implementation.Service
{
    public class HelloService : IHelloService
    {
        public string SayHello(string name)
        {
            return $" Hello {name}, How are You !.";
        }

        public string goodbye()
        {
            return " See you later, goodbye !. ";
        }
    }
}
