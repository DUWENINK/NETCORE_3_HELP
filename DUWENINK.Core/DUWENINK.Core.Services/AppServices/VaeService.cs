using AutoMapper;
using DUWENINK.Core.Data;
using DUWENINK.Core.Data.Entity;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Services.AppServices
{
    public class VaeService : IVaeService
    {

        private readonly IMemoryCache _memoryCache;
        private readonly DUWENINKContext _context;
        private readonly IMapper _mapper;


        public VaeService(IMemoryCache memoryCache, DUWENINKContext context, IMapper mapper)
        {
            _memoryCache = memoryCache;
            _context = context;
            _mapper = mapper;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContentId"></param>
        /// <returns></returns>
        public bool CheckExists(string ContentId)
        {
          return   _context.Vaes.FirstOrDefault(c => c.ContentId == ContentId) != null;
        }

        public string InsertVaeNews(VaeNewsDto dto)
        {
           var entity= _mapper.Map<VaeNewsDto, VaeEntity>(dto);
            entity.Init();
            entity.CreateUserId = "SYSTEM";
             _context.Vaes.Add(entity);
             _context.SaveChangesAsync();
            return entity.Id;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> PushVaeNews(string cqpApiUrl)
        {
            //获取最新的消息id
            DateTime dt1 = new DateTime(1997, 08, 29);
            
            var t = new GetRequestResult
            {
                Url = $"http://www.xusong.com/api/NEWS/getCalendarList.json?page=1&pageSize=10",
            };
            var result = await RequestHelper.GetResponseAsync<VaeDto, GetRequestResult>(t);
            if (result.state&& result.result.activityInfo.Any())//有消息返回
            {

                result.result.activityInfo.ForEach( x =>
                {
                    if (! CheckExists(x.id))
                    {
                        var tt = new GetRequestResult<PrivateMessageDto>
                        {
                            Url = $"{cqpApiUrl}/api/v1/Cqp/CQ_sendPrivateMsg",
                            Data = new PrivateMessageDto { qqid = "1160780733", msg = "信息推送：" + Environment.NewLine + "新活动：" + x.title + Environment.NewLine + "内容：" + x.content + Environment.NewLine + "时间：" + x.startTime + "--" + x.endTime + Environment.NewLine + "不要错过哦！~~" }

                        };

                        var result1 = RequestHelper.GetTResponseAsync<VaeDto, PrivateMessageDto, GetRequestResult<PrivateMessageDto>>(tt, Method.POST);
                        var tt2 = new GetRequestResult<PrivateMessageDto>
                        {
                            Url = $"{cqpApiUrl}/api/v1/Cqp/CQ_sendPrivateMsg",
                            Data = new PrivateMessageDto { qqid ="1292670374", msg =  "信息推送：" + Environment.NewLine + "新活动：" + x.title + Environment.NewLine + "内容：" + x.content + Environment.NewLine + "时间：" + x.startTime + "--" + x.endTime + Environment.NewLine + $"今天是小霞同学出生的第{(DateTime.Now- dt1).Days}天" }

                        };


                        #region xzm
                        var xzm = new GetRequestResult<PrivateMessageDto>
                        {
                            Url = $"{cqpApiUrl}/api/v1/Cqp/CQ_sendPrivateMsg",
                            Data = new PrivateMessageDto { qqid = "923314333", msg = "信息推送：" + Environment.NewLine + "新活动：" + x.title + Environment.NewLine + "内容：" + x.content + Environment.NewLine + "时间：" + x.startTime + "--" + x.endTime + Environment.NewLine + "不要错过哦！~~" }

                        };
                        var resultxzm= RequestHelper.GetTResponseAsync<VaeDto, PrivateMessageDto, GetRequestResult<PrivateMessageDto>>(xzm, Method.POST);
                        #endregion
                        var result2 = RequestHelper.GetTResponseAsync<VaeDto, PrivateMessageDto, GetRequestResult<PrivateMessageDto>>(tt2, Method.POST);
                        VaeNewsDto dto = new VaeNewsDto
                        {
                            Content = x.content,
                            ContentId = x.id,
                            Title = x.title
                        };
                        DateTime dt = DateTime.Now;
                        DateTime.TryParse(x.startTime, out dt);
                        dto.StartTime = dt;
                        DateTime.TryParse(x.endTime, out dt);
                        dto.EndTime = dt;
                        InsertVaeNews(dto);
                    }
                   
                });



              //var ss =result.result.activityInfo.FindAll(c => Convert.ToInt32(c.id) > vaeXingChengMaxId).OrderByDescending(c => Convert.ToInt32(c.id)).LastOrDefault();
              //  if (ss != null) {
              //      var tt = new GetRequestResult<PrivateMessageDto>
              //      {
              //          Url = $"{cqpApiUrl}/api/v1/Cqp/CQ_sendPrivateMsg",
              //          Data = new PrivateMessageDto { qqid = "1160780733", msg = "信息推送："+Environment.NewLine+"新活动："+ ss.title + Environment.NewLine +"内容："+ss.content + Environment.NewLine +"时间："+ss.startTime+"--"+ ss.endTime+ Environment.NewLine +"不要错过哦！~~"}

                //      };
                //      var result1 = RequestHelper.GetTResponseAsync<VaeDto, PrivateMessageDto, GetRequestResult<PrivateMessageDto>>(tt, Method.POST);
                //      var tt2 = new GetRequestResult<PrivateMessageDto>
                //      {
                //          Url = $"{cqpApiUrl}/api/v1/Cqp/CQ_sendPrivateMsg",
                //          Data = new PrivateMessageDto { qqid = "1292670374", msg = "信息推送：" + Environment.NewLine + "新活动：" + ss.title + Environment.NewLine + "内容：" + ss.content + Environment.NewLine + "时间：" + ss.startTime + "--" + ss.endTime + Environment.NewLine + "不要错过哦！~~" }

                //      };
                //      var result2 = RequestHelper.GetTResponseAsync<VaeDto, PrivateMessageDto, GetRequestResult<PrivateMessageDto>>(tt2, Method.POST);
                //      _memoryCache.Set(cacheKey, Convert.ToInt32(ss.id), new MemoryCacheEntryOptions()
                //          .SetSlidingExpiration(TimeSpan.FromMinutes(60)));//设置缓存一个小时一次(滑动)

                //  }


            }



            //return _driverLicenseOfferService.GetWeiChatSignture(result);

            return true;
        }



    }
}
