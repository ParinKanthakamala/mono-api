namespace Gateway.Libraries.RabbitMQ
{
    public class Connection
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; } = 5672;
        public string VHost { get; set; } = "/";
    }

    public class Options
    {
        public bool Durable { get; set; } = true;
        public bool Exclusive { get; set; } = false;
        public bool AutoDelete { get; set; } = true;
        public string Exchange { get; set; } = "";

        public uint PrefetchSize { get; set; } = 0;
        public ushort PrefetchCount { get; set; } = 1;
        public bool Global { get; set; } = false;
    }

    public class RabbitOptions
    {
        public string Name { get; set; }
        public Options Options { get; set; }
        public Connection Connection { get; set; }
    }
}