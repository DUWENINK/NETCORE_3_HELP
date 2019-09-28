using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Models;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Enum;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DUWENINK.Core.Services
{
    /// <summary>
    /// CQP消息机器人发送逻辑
    /// </summary>
  public  class CQPHelper
    {
        private string _baseUrl;

        public CQPHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
            if (string.IsNullOrEmpty(_baseUrl)||!_baseUrl.StartsWith("http://")||!_baseUrl.EndsWith("Cqp/"))
            {
                //http://www.duwenink.cn:36524/api/v1/Cqp/CQ_sendPrivateMsg
                throw new ArgumentOutOfRangeException("BaseUrl必须存在并且以http://开始和Cqp/结束!");
            }
        }
        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task SendPrivateMessage(PrivateMsgDto dto)
        {
            var request = new GetRequestResult<PrivateMsgDto>
            {
                Url = $"{_baseUrl}{CQPProcessType.CQ_sendPrivateMsg.ToString()}",
                Data = dto
            };
            await RequestHelper.GetTResponseAsync<EmptyDto, PrivateMsgDto, GetRequestResult<PrivateMsgDto>>(request, Method.POST);
        }




    }
}
