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
    public class RoomController : ApiController
    {
        private readonly IRoom service;

        public RoomController(IRoom service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Data dosn't exists"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var list = service.GetElement(id);
            if (list == null)
            {
                InternalServerError(new Exception("Data dosn't exists"));
            }
            return Ok(list);
        }

        [HttpGet]
        public void AddElement(RoomCoverModel model)
        {
            service.AddElement(model);
        }

        [HttpGet]
        public void UpdElement(RoomCoverModel model)
        {
            service.UpdElement(model);
        }
        [HttpGet]
        public void DelElement(int id)
        {
            service.DelElement(id);
        }
    }
}
