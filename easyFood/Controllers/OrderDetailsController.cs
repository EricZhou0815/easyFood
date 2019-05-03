using System.Collections.Generic;
using easyFood.Models;
using easyFood.Services;
using Microsoft.AspNetCore.Mvc;

namespace easyFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailService _orderDetailService;

        public OrderDetailsController(OrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        // GET api/orderDetails
        [HttpGet]
        public ActionResult<List<OrderDetail>> Get()
        {
            return _orderDetailService.Get();
        }

        // GET api/orderDetails/5
        [HttpGet("{id:length(24)}", Name = "GetOrderDetail")]
        public ActionResult<OrderDetail> Get(string id)
        {
            var orderDetail = _orderDetailService.Get(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        // POST api/orderDetails
        [HttpPost]
        public ActionResult<OrderDetail> Create(OrderDetail orderDetail)
        {
            _orderDetailService.Create(orderDetail);

            return CreatedAtRoute("GetOrderDetail", new { id = orderDetail.Id.ToString() }, orderDetail);
        }

        // PUT api/orderDetails/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, OrderDetail orderDetailIn)
        {
            var orderDetail = _orderDetailService.Get(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            _orderDetailService.Update(id, orderDetailIn);

            return NoContent();
        }

        // DELETE api/orderDetails/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var orderDetail = _orderDetailService.Get(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            _orderDetailService.Remove(orderDetail.Id);

            return NoContent();
        }
    }
}