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
    public class ArmorController : ApiController
    {
        private readonly IArmor service;

        public ArmorController(IArmor service)
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
        public void CreateArmor(ArmorCoverModel model)
        {
            service.CreateArmor(model);
        }

        [HttpGet]
        public void FinishArmor(int id)
        {
            service.FinishArmor(id);
        }

        [HttpGet]
        public void PayArmor(int id)
        {
            service.PayArmor(id);
        }
    }
}
