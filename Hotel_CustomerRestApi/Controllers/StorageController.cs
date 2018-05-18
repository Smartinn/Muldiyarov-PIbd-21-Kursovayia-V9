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
    public class StorageController : ApiController
    {
        private readonly IStorage _service;

        public StorageController(IStorage service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(StorageCoverModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(StorageCoverModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(StorageCoverModel model)
        {
            _service.DelElement(model.Id);
        }

        public void PutClearOnStorage(StorageCoverModel model)
        {
            _service.PutClearOnStorage(model.Id);
        }
    }
}
