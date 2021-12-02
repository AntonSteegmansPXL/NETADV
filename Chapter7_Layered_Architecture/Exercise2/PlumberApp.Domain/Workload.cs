using System;
using System.Collections.Generic;

namespace PlumberApp.Domain
{
    public class Workload : IWorkload
    {
        public Guid Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public IReadOnlyCollection<IJob> Jobs => throw new NotImplementedException();

        public void AddJob(string description)
        {
            throw new NotImplementedException();
        }
    }
}