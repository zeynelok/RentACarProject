using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
            var sourcePath = Path.GetTempFileName();
            if (formFile.Length>0)
            {
                using (var uploading=new FileStream(sourcePath, FileMode.Create))
                {
                    formFile.CopyTo(uploading);
                }
            }
            var result = newPath(formFile);
            File.Move(sourcePath, result);
            return result;
        }

        public static string Update(string path,IFormFile formFile)
        {
            var result = newPath(formFile);
            if (path.Length>0)
            {
                using (var stream=new FileStream(result,FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(path);
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
                return new SuccessResult();
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
        }

        private static string newPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            var fileExtention = fileInfo.Extension;
            var path = Environment.CurrentDirectory + @"\wwwroot\uploads";
            var newPath = Guid.NewGuid().ToString() + fileExtention;
            var fullPath = $@"{path}\{newPath}";
            return fullPath;
        }
    }
}
