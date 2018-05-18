﻿using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_CustomerRestApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomer service;

        public CustomerController(ICustomer service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = service.GetList();
            if(list == null)
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
        public void AddElement(CustomerCoverModel model)
        {
            service.AddElement(model);
        }

        [HttpGet]
        public void UpdElement(CustomerCoverModel model)
        {
            service.UpdElement(model);
        }
        [HttpGet]
        public void DelElement(int id)
        {
            service.DelElement(id);
        }
        [HttpGet]
        public void Enter(CustomerCoverModel model)
        {
            service.Enter(model);
        }

    }
}
