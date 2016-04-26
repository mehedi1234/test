using DailyExpenses.Models;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyExpenses.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Expenses()
        {
            ExpensesEntities obj = new ExpensesEntities();
            var expenses = obj.tblDaiilyExpenses.ToList();
            //if (Session["ExpenseList"] != null)
            //{
            //    expenses = null;// (List<tblDaiilyExpense>)Session["ExpenseList"];
            //}
            //Session["ExpenseList"] = null;
            return View(expenses);
        }
        [HttpPost]
        public ActionResult ExpensesByMonth(int month)
        {


            ExpensesEntities obj = new ExpensesEntities();
            var expenses = obj.tblDaiilyExpenses.Where(i=>i.date.Month==month).ToList();
            //Session["ExpenseList"] = expenses;

            return Json(expenses, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddExpense()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExpense(ExpenseViewModel obj)
        {
            ExpensesEntities DbContext = new ExpensesEntities();
            tblDaiilyExpense objExpense = new tblDaiilyExpense();
            objExpense.amount = obj.Amount;
            objExpense.date = obj.Date;
            objExpense.description = obj.Description;
            objExpense.comments = obj.Comments;

            DbContext.tblDaiilyExpenses.Add(objExpense);
            DbContext.SaveChanges();

            objExpense = null;

            return View();
        }

        [HttpGet]
        public ActionResult EditExpense(int id)
        {
            ExpensesEntities obj = new ExpensesEntities();
            var expenses = obj.tblDaiilyExpenses.ToList();
            var expensebyid = expenses.Where(x => x.id == id).FirstOrDefault();

            ExpenseViewModel objExpenseViewModel = new ExpenseViewModel();
            objExpenseViewModel.Id = expensebyid.id;
            objExpenseViewModel.Description = expensebyid.description;
            objExpenseViewModel.Comments = expensebyid.comments;
            objExpenseViewModel.Date = expensebyid.date;
            objExpenseViewModel.Amount = expensebyid.amount;
            return View(objExpenseViewModel);
        }

        [HttpPost]
        public ActionResult EditExpense(ExpenseViewModel obj)
        {
            ExpensesEntities DbContext = new ExpensesEntities();
            tblDaiilyExpense objExpense = DbContext.tblDaiilyExpenses.Where(a => a.id == obj.Id).FirstOrDefault();

            objExpense.amount = obj.Amount;
            objExpense.date = obj.Date;
            objExpense.description = obj.Description;
            objExpense.comments = obj.Comments;
            objExpense.updated_at = DateTime.Now;
            DbContext.Entry(objExpense).State = EntityState.Modified;
            DbContext.SaveChanges();

            return RedirectToAction("Expenses");
        }

        [HttpGet]
        public ActionResult DeleteExpense(int id)
        {
            return View();
        }


        public ActionResult TestAddForm()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TestAddForm(CustomerViewModel model)
        {

            return View();
        }



    }
}
