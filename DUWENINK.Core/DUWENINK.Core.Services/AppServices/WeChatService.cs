using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DUWENINK.Core.Interfaces;

namespace DUWENINK.Core.Services.AppServices
{
  public  class WeChatService: IWeChatService
  {
      public readonly IDriverLicenseOfferService _driverLicenseOfferService;
     
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="driverLicenseOfferService"></param>
        public WeChatService(IDriverLicenseOfferService driverLicenseOfferService)
        {
            _driverLicenseOfferService = driverLicenseOfferService;
        }
        public async Task<string> GetLastTicket()
        {
            return await _driverLicenseOfferService.GetWeChatTicketAsync();
        }
    }
}
