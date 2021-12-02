using System;

namespace PlumberApp.Domain
{
    public class Job : IJob
    {
        Job() { }
        public Job(String description, Guid workloadId)
        {
            this.Description = description;
        }

        public Guid Id { get; private set; }

        public string Description { get; private set; }

        public Guid WorkloadId { get; private set; }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
