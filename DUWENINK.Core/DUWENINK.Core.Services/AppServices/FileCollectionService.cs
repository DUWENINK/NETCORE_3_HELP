using AutoMapper;
using DUWENINK.Core.Data;
using DUWENINK.Core.Data.Entity;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Services.AppServices
{
    public class FileCollectionService : IFileCollectionService
    {
        private readonly DUWENINKContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public FileCollectionService(DUWENINKContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="fileCollectionDto"></param>
        /// <returns></returns>
        public async Task<string> AddFileRecord(FileCollectionDto fileCollectionDto)
        {
            var entity = _mapper.Map<FileCollectionDto, FileCollectionEntity>(fileCollectionDto);
            entity.Init();
            entity.CreateUserId = "SYSTEM";
            _context.FileCollections.Add(entity);
           await _context.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// 根据cpuid获取文件列表
        /// </summary>
        /// <param name="cpuId"></param>
        /// <returns></returns>
        public async Task<IList<string>> GetFileNameList(string cpuId)
        {
            var dbSet = _context.FileCollections;
            var query = dbSet.AsQueryable();
                query = query.Where(item => item.CpuId== cpuId);
           return await query.OrderByDescending(x => x.CreateDateTime).Select(c=>c.UserFilePath).ToListAsync();
        }
    }
}
