using System.Threading.Tasks;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Enum;
using DUWENINK.Core.Services;
using DUWENINK.Core.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DUWENINK.Core.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
   // [Authorize]
    public class MessageCenterController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IVaeService _vaeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="vaeService"></param>
        public MessageCenterController( IConfiguration configuration, IVaeService vaeService)
        {
            _configuration = configuration;
            _vaeService = vaeService;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [IgnoreRightFilter]
        [HttpPost, AllowAnonymous]
        public async Task<NormalResult<Ranking>> SendPrivateMessage([FromBody]PrivateMsgDto dto )
        {
            await new CQPHelper(_configuration.GetSection("CqpApiUrl").Value).SendPrivateMessage(dto);
            return new NormalResult<Ranking> { Data=new Ranking() { GoalBeyond=1 } };
        }

        /// <summary>
        /// 推送许嵩消息,接口随时可能废弃
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [IgnoreRightFilter]
        [HttpPost, AllowAnonymous]
        public async Task<string> PushVaeNews()
        {
          await  _vaeService.PushVaeNews(_configuration.GetSection("CqpApiUrl").Value+ CQPProcessType.CQ_sendPrivateMsg.ToString());//
            return "";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

    }
}