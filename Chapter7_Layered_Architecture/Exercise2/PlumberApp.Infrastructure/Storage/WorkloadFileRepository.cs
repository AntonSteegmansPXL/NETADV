using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PlumberApp.AppLogic;
using PlumberApp.Domain;

namespace PlumberApp.Infrastructure.Storage
{
    public class WorkloadFileRepository : IWorkloadRepository
    {
        private readonly string _workloadFileDirectory;
        public WorkloadFileRepository(string workloadFileDirectory)
        {
            String folderName = workloadFileDirectory;
            String pathString = "C:/Users/Anton/Source/Repos/NETADV/Chapter7_Layered_Architecture/Exercise2/PlumberApp.Tests/bin/Debug/net472/testworkloads";
            System.IO.Directory.CreateDirectory(pathString.Trim());
        }

        public void Add(IWorkload workload)
        {
            SaveWorkload(workload);
        }

        public IReadOnlyList<IWorkload> GetAll()
        {
            //TODO: read all workload files in the directory, convert them to IWorkload objects and return them
            //Tip: use helper methods that are given (ReadWorkloadFromFile)
            return null;
        }

        public void SaveChanges(IWorkload workload)
        {
            SaveWorkload(workload);
        }

        private IWorkload ReadWorkloadFromFile(string workLoadFilePath)
        {
            string text = File.ReadAllText(workLoadFilePath);

            IWorkload iWorkLoad = ConvertJsonToWorkload(text);
            //TODO: read the json in a workload file and deserialize the json into an IWorkload object
            //Tip: use helper methods that are given (ConvertJsonToWorkload)
        }

        private void SaveWorkload(IWorkload workload)
        {
            File.WriteAllText(GetWorkloadFilePath(workload.Id), ConvertWorkloadToJson(workload));
            //TODO: save the workload in a json format in a file
            //Tip: use helper methods that are given (GetWorkloadFilePath, ConvertWorkloadToJson)
        }

        private string ConvertWorkloadToJson(IWorkload workload)
        {
            string json = JsonConvert.SerializeObject(workload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            return json;
        }

        private IWorkload ConvertJsonToWorkload(string json)
        {
            Workload workload =  JsonConvert.DeserializeObject<Workload>(json, new JsonSerializerSettings
            {
                ContractResolver = new JsonAllowPrivateSetterContractResolver(),
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                TypeNameHandling = TypeNameHandling.Auto
            });
            return workload as IWorkload;
        }

        private string GetWorkloadFilePath(Guid workLoadId)
        {
            string fileName = $"Workload_{workLoadId}.json";
            return Path.Combine(_workloadFileDirectory, fileName);
        }
    }
}
