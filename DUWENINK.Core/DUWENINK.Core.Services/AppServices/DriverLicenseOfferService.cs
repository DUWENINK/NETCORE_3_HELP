using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DUWENINK.Core.Data;
using DUWENINK.Core.Data.Entity;
using DUWENINK.Core.Infrastructure;
using DUWENINK.Core.Infrastructure.Extentions;
using DUWENINK.Core.Interfaces;
using DUWENINK.Core.Models.Business;
using DUWENINK.Core.Models.Enum;
using DUWENINK.Core.Models.Filters;
using Microsoft.EntityFrameworkCore;
using DUWENINK.Core.Weixin.SDK;
using DUWENINK.Core.Weixin.SDK.Helpers;

namespace DUWENINK.Core.Services.AppServices
{
    public class DriverLicenseOfferService: IDriverLicenseOfferService
   {
       private readonly DUWENINKContext _context;
       private readonly IAreaService _areaService;
       private readonly IMapper _mapper;
      

       /// <summary>
       /// ctor
       /// </summary>
       /// <param name="context"></param>
       /// <param name="areaService"></param>
       /// <param name="mapper"></param>
       public DriverLicenseOfferService(DUWENINKContext context, IAreaService areaService, IMapper mapper)
       {
           _context = context;
           _areaService = areaService;
           _mapper = mapper;
       }

        public async Task<string> Add(DriverLicenseOfferDto dto)
        {
            var entity = _mapper.Map<DriverLicenseOfferDto, DriverLicenseOfferEntity>(dto);
            entity.Init();
            _context.DriverLicenseOffers.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

       /// <inheritdoc />
       /// <summary>
       /// 获取相关信息
       /// </summary>
       /// <param name="dto"></param>
       /// <returns></returns>
        public async Task<Ranking> GetRanking(DriverLicenseOfferDto dto)
        {
            //你的分数为xx分,在驾照取得地,可值xx元,超越了xx%本地用户,超越xx全国用户,在居住地,可值xx元,超越了xx%本地用户,超越xx全国用户
            var result = new Ranking();
            if (dto == null)
            {
                return result;
            }
            if (!string.IsNullOrEmpty(dto.SourceAreaId))//
            {
                //取得报价
                result.SourceTotalPrice = await _areaService.GetOfferByAreaId(dto.SourceAreaId, dto.DriverLicenseType) * dto.ScoreLeft;
                var totalSource = await GetSourceCount(dto.SourceAreaId, 0);
                if (totalSource == 0)
                {
                    totalSource = 1;
                }
                result.SourceBeyond = (float)await GetSourceCountSub(dto.SourceAreaId, result.SourceTotalPrice) / totalSource;
                var totalAllSource = await GetTotalSourceCount(0);
                if (totalAllSource == 0)
                {
                    totalAllSource = 1;
                }
                result.SourceBeyondAll = (float)await GetTotalSourceCountSub(result.SourceTotalPrice) / totalAllSource;
            }

            if (string.IsNullOrEmpty(dto.GoalAreaId)) return result;
            //取得报价
            //居住地
            result.GoalTotalPrice = await _areaService.GetOfferByAreaId(dto.GoalAreaId, dto.DriverLicenseType)* dto.ScoreLeft;
            var totalGoal = await GetGoalCount(dto.GoalAreaId, 0);
            if (totalGoal == 0)
            {
                totalGoal = 1;
            }
            result.GoalBeyond = (float)await GetGoalCountSub(dto.GoalAreaId, result.GoalTotalPrice) / totalGoal;
            var totalAllGoal = await GetTotalGoalCount(0);
            if (totalAllGoal == 0)
            {
                totalAllGoal = 1;
            }
            result.GoalBeyondAll = (float)await GetTotalGoalCountSub(result.GoalTotalPrice) / totalAllGoal;
            result.DriverLicenseOfferId = await Add(dto);
            return result;
        }

       public async Task<bool> Update(DriverLicenseOfferDto dto)
       {
           var entity = await _context.DriverLicenseOffers.FindAsync(dto.Id);
           if (entity == null) return false;
           entity.SourceTotalPrice = dto.SourceTotalPrice;
           //entity.DriverLicenseType = dto.DriverLicenseType;
           entity.GoalAddress = dto.GoalAddress;
           entity.GoalTotalPrice = dto.GoalTotalPrice;
           //entity.ScoreLeft = dto.ScoreLeft;
           entity.Sex = (byte) dto.Sex;
           entity.AcquisitionTime = dto.AcquisitionTime;
           //entity.GoalAreaId = dto.GoalAreaId;
           entity.PhoneNumber = dto.PhoneNumber;
           entity.WeiXinId = dto.WeiXinId;
           //entity.SourceAreaId = dto.SourceAreaId;
           return await _context.SaveChangesAsync()==1;
           
        }

       public async Task<PagedResult<DriverLicenseOfferDto>> SearchAsync(DriverLicenseOfferFilters filters)
       {
           if (filters == null)
               return new PagedResult<DriverLicenseOfferDto>();

           var query = _context.DriverLicenseOffers.AsQueryable();

            //if (filters.keywords.IsNotBlank())
            //    query = query.Where(x => x..Contains(filters.keywords));
           if (filters.MinLeftScore != 0)
           {
               query = query.Where(x => x.ScoreLeft >= filters.MinLeftScore);
           }
           if (filters.MaxLeftScore != 0)
           {
               query = query.Where(x => x.ScoreLeft <= filters.MaxLeftScore);
           }
      
           var areas =await _areaService.FindAllByParentId(string.Empty);
           return await query.OrderByDescending(item => item.CreateDateTime)
               .Select(item => new DriverLicenseOfferDto
               {
                   Id = item.Id,
                   ScoreLeft = item.ScoreLeft,
                   DriverLicenseType = item.DriverLicenseType,
                   SourceAreaId = areas == null ? string.Empty : (areas.FirstOrDefault(c => c.id == item.SourceAreaId) == null ? string.Empty : areas.FirstOrDefault(c => c.id == item.SourceAreaId).name),
                   SourceTotalPrice = item.SourceTotalPrice,
                   //-------------------------------------------
                   GoalAreaId = areas == null ? string.Empty : (areas.FirstOrDefault(c => c.id == item.GoalAreaId) == null ? string.Empty : areas.FirstOrDefault(c => c.id == item.GoalAreaId).name),
                   GoalAddress = item.GoalAddress,
                   GoalTotalPrice = item.GoalTotalPrice,
                   Sex = (SexType)item.Sex,
                   PhoneNumber= item.PhoneNumber,
                   AcquisitionTime= item.AcquisitionTime,
                   WeiXinId = item.WeiXinId
               }).PagingAsync(filters.page, filters.rows);
        }

       public async Task<NormalResult<WeChatUserInfoDto>> GetUserInfo(WeChatCodeDto dto)
       {
          var t= new GetRequestResult<WeChatCodeDto>
           {
               Url =$"https://api.weixin.qq.com/sns/oauth2/access_token?appid=wxa3b1569e3268c7dc&secret=7e5ff36c54980ecff9c919969f7fcdf3&code={dto.Code}&grant_type=authorization_code"
               
           };
          var result =await RequestHelper.GetResponseAsync<WeChatUserInfoDto, GetRequestResult<WeChatCodeDto>> (t);
           if (result == null||string.IsNullOrEmpty(result.openid))
           {
               return new NormalResult<WeChatUserInfoDto> {Successful = false, Message = "内部错误"};
           }
           return new NormalResult<WeChatUserInfoDto>{Successful  =true,Data = result};
       }
        /// <summary>
        /// 获取微信签名
        /// </summary>
        /// <returns></returns>
       public async Task<string> GetWeChatTicketAsync()
       {
           var t = new GetRequestResult<WeChatCodeDto>
           {
               Url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx5f156604fbf98302&secret=633a432213d81c25819643186b7313fe"
               

           };
           var result = await RequestHelper.GetResponseAsync<AccessToken, GetRequestResult<WeChatCodeDto>>(t);
           var t1 = new GetRequestResult
           {
               Url = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={result.access_token}&type=jsapi"
           };
           var aa=  await RequestHelper.GetResponseAsync<Ticket, GetRequestResult>(t1);
           return aa.ticket;
       }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public NormalResult<WeiChatSigntureDto> GetWeiChatSignture(string weChatTickets)
        {
            return new NormalResult<WeiChatSigntureDto>
            {
                Data = new WeiChatSigntureDto
                {
                    NonceStr = Util.CreateNonce_str(),
                    Signature = Util.Sha1(weChatTickets),
                    Timestamp = Util.CreateTimestamp()
                }
            };
        }
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public NormalResult<WeiChatSigntureDto> GetWeiChatSignture1(string weChatTickets)
       {
           return new NormalResult<WeiChatSigntureDto>
           {
               Data = new WeiChatSigntureDto
               {
                   NonceStr = Util.CreateNonce_str(),
                   Signature = Util.Sha1(weChatTickets),
                   Timestamp = Util.CreateTimestamp()
               }
           };
       }

        private async Task<int> GetSourceCount(string areaId, decimal offerWorth)
       {
           return await _context.DriverLicenseOffers.CountAsync(c =>
               c.SourceAreaId == areaId && c.SourceTotalPrice >= offerWorth);
       }
       private async Task<int> GetSourceCountSub(string areaId, decimal offerWorth)
       {
           return await _context.DriverLicenseOffers.CountAsync(c =>
               c.SourceAreaId == areaId && c.SourceTotalPrice <= offerWorth);
       }
        private async Task<int> GetGoalCount(string areaId, decimal offerWorth)
       {
           return await _context.DriverLicenseOffers.CountAsync(c =>
               c.GoalAreaId == areaId && c.GoalTotalPrice >= offerWorth);
       }
       private async Task<int> GetGoalCountSub(string areaId, decimal offerWorth)
       {
           return await _context.DriverLicenseOffers.CountAsync(c =>
               c.GoalAreaId == areaId && c.GoalTotalPrice <= offerWorth);
       }
        private async Task<int> GetTotalSourceCount(decimal offerWorth)
       {
           return await _context.DriverLicenseOffers.CountAsync(c=>c.SourceTotalPrice>= offerWorth);
       }
       private async Task<int> GetTotalSourceCountSub(decimal offerWorth)//1200
       {
           return await _context.DriverLicenseOffers.CountAsync(c => c.SourceTotalPrice <= offerWorth);
       }
        private async Task<int> GetTotalGoalCount(decimal offerWorth)
       {
           return await _context.DriverLicenseOffers.CountAsync(c => c.GoalTotalPrice >= offerWorth);
       }
       private async Task<int> GetTotalGoalCountSub(decimal offerWorth)
       {
           return await _context.DriverLicenseOffers.CountAsync(c => c.GoalTotalPrice <= offerWorth);
       }
    }
}
