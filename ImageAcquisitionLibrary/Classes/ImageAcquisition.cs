using ImageAcquisitionLibrary.Interfaces;
using ContractLibrary.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;



namespace ImageAcquisitionLibrary.Classes
{
    public class ImageAcquisition : IImageAcquisition
    {
        public async Task<CameraImageResponse> GetPreviewImage()
        {
            int machineID = RTGMachinesList.chosenMachineID;
            HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync("http://"+ RTGMachinesList.RTGMachineAddress[machineID] + "/api/camera");            
            HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/camera");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CameraImageResponse>(responseBody);
        }

        public void CreateCaptureLogForImage(string image)
        {
            
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory+"log.txt", true))
            {
                file.WriteLine(image);
            }

        }


        public void SaveImage(CameraImageCaptureRequest cameraImageCaptureRequest,string base64StringImage)
        {
            var pathToStorageDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "storage";
            int fileInStorageDirectoryCounter = Directory.GetFiles(pathToStorageDirectory, "*", SearchOption.TopDirectoryOnly).Length;
            var pathToCurrentlyTakenImage = System.AppDomain.CurrentDomain.BaseDirectory + "storage/"+ fileInStorageDirectoryCounter + "_rtgimage_"+cameraImageCaptureRequest.imageDate+"_" +  cameraImageCaptureRequest.imageTime.Replace(":","_")+".jpg";

            var currentlyTakenImagesInBytes = Convert.FromBase64String(base64StringImage);
            using (var currentImageFile = new FileStream(pathToCurrentlyTakenImage, FileMode.Create))
            {
                currentImageFile.Write(currentlyTakenImagesInBytes, 0, currentlyTakenImagesInBytes.Length);
                currentImageFile.Flush();
            }

            
            FileStream currentImageFileStream = new FileStream(pathToCurrentlyTakenImage, FileMode.Open,FileAccess.Read,FileShare.Read);

            BitmapMetadata myBitmapMetadata = new BitmapMetadata("jpg");
            JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
            myBitmapMetadata.DateTaken = cameraImageCaptureRequest.imageDate+" "+cameraImageCaptureRequest.imageTime;
            myBitmapMetadata.Comment = "Brightness:"+cameraImageCaptureRequest.light+";Contrast:" + cameraImageCaptureRequest.contrast+";Image negative:"+cameraImageCaptureRequest.negative+";";
            var authorList = new List<string>();
            authorList.Add(cameraImageCaptureRequest.userName);
            ReadOnlyCollection<string> read = new ReadOnlyCollection<string>(authorList);
            myBitmapMetadata.Author = read;

            JpegBitmapDecoder jpegBitmapDecoder = new JpegBitmapDecoder(currentImageFileStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            currentImageFileStream.Close();

            jpegBitmapEncoder.Frames.Add(
             BitmapFrame.Create(
                jpegBitmapDecoder.Frames[0],
                jpegBitmapDecoder.Frames[0].Thumbnail,
                myBitmapMetadata,
                jpegBitmapDecoder.ColorContexts)
              );

            FileStream CurrentImageFileStreamCopy = new FileStream(pathToCurrentlyTakenImage, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            jpegBitmapEncoder.Save(CurrentImageFileStreamCopy);
            CurrentImageFileStreamCopy.Close();
            CurrentImageFileStreamCopy.Dispose();
        }

         public async Task<CameraImageResponse> GetXRAYImage(CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            //int machineID = cameraImageCaptureRequest.machineID;
            int machineID = RTGMachinesList.chosenMachineID;
            HttpClient client = new HttpClient();
            StringContent rtgParametersStringContent = new StringContent(JsonConvert.SerializeObject(cameraImageCaptureRequest), Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("http://"+RTGMachinesList.RTGMachineAddress[machineID]+"/api/camera/capture", rtgParametersStringContent);
            HttpResponseMessage response = await client.PostAsync("http://localhost:63766/api/camera/capture", rtgParametersStringContent);
            response.EnsureSuccessStatusCode();
            CreateCaptureLogForImage(JsonConvert.SerializeObject(cameraImageCaptureRequest));
            string responseBody = await response.Content.ReadAsStringAsync();
            var convertedResponseBody = JsonConvert.DeserializeObject<CameraImageResponse>(responseBody);
            if(convertedResponseBody.errorMessage == null)
                SaveImage(cameraImageCaptureRequest, convertedResponseBody.Base64);
            return convertedResponseBody;
        }
    }
}
