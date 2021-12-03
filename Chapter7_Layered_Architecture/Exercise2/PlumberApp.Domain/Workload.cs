using System;
using System.Collections.Generic;

namespace PlumberApp.Domain
{
    public class Workload : IWorkload
    {
        Workload() {
            this.Jobs = new List<Job>();
            this.Capacity = 10;
            this.Name = "aub";
            this.Id = new Guid();
        }

        public Workload(String name, int capacity)
        {
            if (capacity <= 0 || name == "" || name == null)
            {
                throw new ArgumentException();
            } else
            {
                this.Capacity = capacity;
                this.Name = name;
                this.Id = new Guid();
            }

        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Capacity { get; private set; }


        public IReadOnlyCollection<IJob> Jobs { get; set; }

        public void AddJob(string description)
        {
            Job newJob = new Job(description, Id);
            //Jobs.Add(newJob);

            throw new InvalidOperationException(); 
        }

        public override string ToString()
        {
            return this.Name + " " + this.Capacity;
        }
    }
}