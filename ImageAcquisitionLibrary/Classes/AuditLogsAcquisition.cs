using ContractLibrary.Models;
using ImageAcquisitionLibrary.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAcquisitionLibrary.Classes
{
    public class AuditLogsAcquisition : IAuditLogsAcquisition
    {
        public List<AuditLogResponse> GetAuditLogs()
        {
            string logLine;
            var auditLog = new AuditLogResponse();
            var auditLogList = new List<AuditLogResponse>();
            // Read the file and display it line by line.  
            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "log.txt")){
                System.IO.StreamReader file =
                    new System.IO.StreamReader(System.AppDomain.CurrentDomain.BaseDirectory+"log.txt");
                while ((logLine = file.ReadLine()) != null)
                {
                    auditLog = JsonConvert.DeserializeObject<AuditLogResponse>(logLine);
                    auditLogList.Add(auditLog);
                }
                file.Close();
            }
            else
            {
                return auditLogList;
            }
            return auditLogList;
        }
    }
}
