using Exam1.Handler;
using Exam1.Hubs;
using Exam1.Models.DatabaseContext;
using Exam1.Models.DataModels;
using Exam1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace Exam1.Controllers
{
    public class AdminController : Controller
    {
        private readonly StockDBContext _db;
        private readonly IHubContext<StockHub> _stockHub;
        private readonly IStockHandler _stockHandler;

        public AdminController(StockDBContext db, IStockHandler stockHandler, IHubContext<StockHub> stockHub)
        {
            _db = db;
            _stockHub = stockHub;
            _stockHandler = stockHandler;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStock(string id, Stock stock)
        {
            if(id != stock.Ma)
            {
                return NotFound();
            }
            var stockDb = await _stockHandler.GetByIdAsync(id);
            var stockUpdated = await _stockHandler.UpdateAsync(stock);
            var updateViewModel = new UpdateViewModel
            {
                Ma = id,
                CellsChanged = new List<CellChangedViewModel>()
            };
            var stockType = typeof(Stock);

            foreach (var propInfo in stockType.GetProperties())
            {
                var stockDbPropValue = stockType.GetProperty(propInfo.Name).GetValue(stockDb);
                var stockUpdatedPropValue = stockType.GetProperty(propInfo.Name).GetValue(stockUpdated);
                // nếu stockUpdatedPropValue null k so sánh, chạy luôn hàm if
                // còn nếu k null thì so sánh vs null stockDbPropValue thì trả về false
                if (!stockUpdatedPropValue?.Equals(stockDbPropValue) ?? false) 
                {
                    var cellChanged = new CellChangedViewModel
                    {
                        CellName = propInfo.Name,
                        CellValue = stockUpdatedPropValue
                    };
                    updateViewModel.CellsChanged.Add(cellChanged);
                }
            }
            await _stockHub.Clients.All.SendAsync("updateStock", updateViewModel);
            return RedirectToAction("Admin");
        }


        public String getBrowserInfor()
        {
            var userAgent = HttpContext.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);
            string str = c.UA.Family + " " + c.UA.Major + "." + c.UA.Minor;
            return str;
        }

        public String getIpAddress()
        {
            return HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public IActionResult Admin()
        {
            getBrowserInfor();
            ViewData["IpAddress"] = getIpAddress();
            ViewData["browser"] = getBrowserInfor();
            var stockList = _db.Stocks.ToList();
            return View(stockList);
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var stock = _db.Stocks.Find(id);
            return View(stock);
        }
    }
}
