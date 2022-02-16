using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Classes
{
    internal class LoadServiceToClients
    {
        int selectedClient = 0, idService;
        Services service;
        List<Clients> clients = DbConnection.SchoolBase.Clients.ToList();
        List<string> clientsNames = new List<string>();
        DateTime dateTimeBegin = DateTime.Today;
        DateTime timeBegin = new DateTime();
        public string Title => service.serviceName;
        public string Duration => service.duration.ToString() + " мин.";
        public List<string> Clients => clientsNames;
        public int ClientIndex { get => selectedClient; set => selectedClient = value; }
        public DateTime DateBegin { get => dateTimeBegin; set => dateTimeBegin = value; }
        public DateTime TimeBegin { get => timeBegin; set => timeBegin = value; }
        public LoadServiceToClients(int idService)
        {
            this.idService = idService;
            service = DbConnection.SchoolBase.Services.FirstOrDefault(x => x.serviceId == idService);
            foreach (var client in clients)
            {
                clientsNames.Add(client.surename + " " + client.name + " " + client.patronymic);
            }
        }
        public bool SaveData()
        {
            if (selectedClient != -1)
            {
                int lastId = DbConnection.SchoolBase.ClientService.ToList().Last().clientServiceId + 1;
                List<string> namesClient = clientsNames[selectedClient].Split(' ').ToList();
                int idClient = clients.FirstOrDefault(x => x.surename == namesClient[0] && x.name == namesClient[1] && x.patronymic== namesClient[2]).clientId;
                dateTimeBegin.AddHours(timeBegin.Hour);
                dateTimeBegin.AddMinutes(timeBegin.Minute);
                DbConnection.SchoolBase.ClientService.Add(new ClientService()
                {
                    clientServiceId = lastId,
                    clientId = idClient,
                    serviceId = idService,
                    startDate = dateTimeBegin
                });
                DbConnection.SchoolBase.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
