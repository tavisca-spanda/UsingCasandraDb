using System;
using Cassandra;

namespace UsingCasandraDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var cluster = Cluster.Builder()
                     .AddContactPoints("localhost")
                 
                     .Build();
            
            var session = cluster.Connect("videodb");

            //var videoStatement = session.Prepare("INSERT INTO videos (videoid, videoname, username) values (?,?,?)");
            //var batch = new BatchStatement()
            //            .Add(videoStatement.Bind(new Guid ("b3a76c6b-7c7f-4af6-964f-803a9283c401"),"xyz","abc"));
            //session.Execute(batch);
            var rs = session.Execute("SELECT * FROM videos");
            foreach (var row in rs)
            {
                Console.WriteLine(row.GetValue<string>(1));
            }
            Console.ReadKey();
        }
    }
}
