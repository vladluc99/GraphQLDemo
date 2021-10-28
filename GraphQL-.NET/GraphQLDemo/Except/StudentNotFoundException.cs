using System;

namespace GraphQLDemo.Except
{
    public class StudentNotFoundException : Exception
    {
        public int StudentId { get; internal set; }
    }
}
