using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.System;
using DUWENINK.Core.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class FileCollectionController : Controller
    {
        private readonly IFileCollectionService _fileCollectionService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCollectionService"></param>
        public FileCollectionController(IFileCollectionService fileCollectionService)
        {
            _fileCollectionService = fileCollectionService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         public ActionResult Index()
         {
            return View();
         }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpuId"></param>
        /// <returns></returns>
        [HttpGet]
        [IgnoreRightFilter]
        [AllowAnonymous]
        public async Task<NormalResult<IList<string>>> GetFileList(string cpuId)
        {
            var result = new NormalResult<IList<string>>();
            var data=await _fileCollectionService.GetFileNameList(cpuId);
            result.Data = data;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="upfiles"></param>
        /// <returns></returns>
        [IgnoreRightFilter]
        [AllowAnonymous]
        [HttpPost]
        public async Task<NormalResult<IList<string>>> UpLoadFile([FromForm] IFormCollection  upfiles )
        {
            var getFiles = upfiles;
            var cpuId = Request.Form["CpuId"].ToString() ?? string.Empty;
            var userFilePath = Request.Form["UserFilePath"].ToString() ?? string.Empty;
            var files = Request.Form.Files.ToList();
            long size = files.Sum(f => f.Length);
            // full path to file in temp location
            //var filePath = Path.GetTempFileName();
            //var filePath = @"D:\UploadingFiles\" + formFile.FileName;
            var list = new List<string>();
            list.AddRange(files.FindAll(c => c.Length > 0).ConvertAll(c => c.FileName));
            #region 文件流
            //foreach (var formFile in files)
            //{
            //    if (formFile.Length <= 0) continue;

            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //            await formFile.CopyToAsync(stream);

            //        BinaryReader br = new BinaryReader(stream);
            //        var byData = br.ReadBytes((int)stream.Length);

            //    }
            //} 
            #endregion
            #region 内存流

            //foreach (var formFile in files)
            //{
            //    if (formFile.Length <= 0) continue;

            //    //using (var stream = new MemoryStream())
            //    //{
            //    //    await formFile.CopyToAsync(stream);

            //    //    BinaryReader br = new BinaryReader(stream);
            //    //    var byData = br.ReadBytes((int)stream.Length);

            //    //}

            //    using var stream = formFile.OpenReadStream();
            //    BinaryReader br = new BinaryReader(stream);
            //    var byData = br.ReadBytes((int)stream.Length);


            //} 
            #endregion
            #region 流
            try
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length <= 0) continue;
                    using var stream = formFile.OpenReadStream();
                    var savePath = Path.Combine("FileUpLoads", cpuId);
                    if (!Directory.Exists(savePath))
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    string saveFile = Guid.NewGuid().ToString("N");
                    BinaryReader br = new BinaryReader(stream);
                    var byData = br.ReadBytes((int)stream.Length);
                    //将下载下来的文件放在当前目录下，保存为e.wav；当然如果是图片，可以保存为a.jpg
                    using FileStream fs = new FileStream(Path.Combine(savePath, saveFile+".png"), FileMode.OpenOrCreate);
                    MemoryStream m = new MemoryStream(byData);
                    m.WriteTo(fs);
                    var dto = new FileCollectionDto { CpuId = cpuId, FileName = formFile.FileName, FilePath = Path.Combine(savePath, saveFile + ".png"), UserFilePath = userFilePath,ImageFileStream= null };
                    await _fileCollectionService.AddFileRecord(dto);
                }
            }
            catch(Exception ex )
            {
                //吃掉
            }
            #endregion
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return new NormalResult<IList<string>> { Data = list };
        }




    }
}