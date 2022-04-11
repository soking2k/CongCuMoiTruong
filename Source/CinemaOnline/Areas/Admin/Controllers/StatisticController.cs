using BELibrary.Core.Entity;
using BELibrary.DbContext;
using BELibrary.Entity;
using BELibrary.Extendsions;
using BELibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaOnline.Areas.Admin.Controllers
{
    public class StatisticController : BaseController
    {
        private readonly string KeyElement = "Thống kê";

        public ActionResult GetRevenuePerYear(int year)
        {
            using (var workScope = new UnitOfWork(new CinemaOnlineDbContext()))
            {
                var orders = workScope.Orders.GetAll();

                var date = new DateTime(year, 1, 1);
                var months = Enumerable.Range(0, 12)
                    .Select(x => new
                    {
                        month = date.AddMonths(x).Month,
                        year = date.AddMonths(x).Year
                    }).ToList();

                var dataPerYearAndMonth =
                    months.GroupJoin(orders,
                        m => new { m.month, m.year },
                        patient => new
                        {
                            month = patient.CreationTime.Month,
                            year = patient.CreationTime.Year
                        },
                        (p, g) => new
                        {
                            month = "Tháng " + p.month,
                            p.year,
                            count = g.Sum(x => x.TotalPrice)
                        });

                return
                    Json(new
                    {
                        status = true,
                        mess = "Thành công ",
                        data = dataPerYearAndMonth.ToList()
                    });
            }
        }

        public ActionResult Index()
        {
            ViewBag.Feature = "Chi tiết";
            ViewBag.Element = KeyElement;
            using (var workScope = new UnitOfWork(new CinemaOnlineDbContext()))
            {
                //var categories = workScope.Categories.GetAll().ToList();
                //ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View();
            }
        }

        [HttpPost]
        public JsonResult GetRegByYear(int year)
        {
            using (var workScope = new UnitOfWork(new CinemaOnlineDbContext()))
            {
                var patients = workScope.Orders.GetAll();

                var date = new DateTime(year, 1, 1);
                var months = Enumerable.Range(0, 12)
                    .Select(x => new
                    {
                        month = date.AddMonths(x).Month,
                        year = date.AddMonths(x).Year
                    }).ToList();

                var dataPerYearAndMonth =
                    months.GroupJoin(patients,
                        m => new { m.month, m.year },
                        patient => new
                        {
                            month = patient.CreationTime.Month,
                            year = patient.CreationTime.Year
                        },
                        (p, g) => new
                        {
                            month = "Tháng " + p.month,
                            p.year,
                            count = g.Count()
                        });

                return
                    Json(new
                    {
                        status = true,
                        mess = "Thành công ",
                        data = dataPerYearAndMonth.ToList()
                    });
            }
        }
    }
}