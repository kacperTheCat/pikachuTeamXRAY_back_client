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

        public AuditLogImageResponse GetImageByName(string imageName)
        {
            var auditLogImageResponse = new AuditLogImageResponse()
            {
                xRayImageName = imageName
            };
            auditLogImageResponse.base64 = GetRequestedImageBase64(imageName);
            return auditLogImageResponse;
        }

        public string GetRequestedImageBase64(string imageName)
        {
            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "storage/" + imageName + ".jpg") == true)
            {
                Byte[] requestedImageBytes = File.ReadAllBytes(System.AppDomain.CurrentDomain.BaseDirectory + "storage/" + imageName + ".jpg");
                String requestedImageBase64 = Convert.ToBase64String(requestedImageBytes);
                return requestedImageBase64;
            }
            else
            {
                throw new FileNotFoundException("File do not exists");
            }
        }
    }
}
