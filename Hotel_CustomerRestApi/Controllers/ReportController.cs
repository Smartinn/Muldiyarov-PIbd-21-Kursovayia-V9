using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_CustomerRestApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReport _service;

        public ReportController(IReport service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetStorageLoad()
        {
            var list = _service.GetStorageLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetArmors(ReportCoverModel model)
        {
            var list = _service.GetArmors(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void SaveRoomPrice(ReportCoverModel model)
        {
            _service.SaveRoomPrice(model);
        }

        [HttpPost]
        public void SaveStorageLoad(ReportCoverModel model)
        {
            _service.SaveStorageLoad(model);
        }

        [HttpPost]
        public void SaveArmors(ReportCoverModel model)
        {
            _service.SaveArmors(model);
        }
    }
}
