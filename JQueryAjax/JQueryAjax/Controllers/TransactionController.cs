using JQueryAjax.Helper;
using JQueryAjax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JQueryAjax.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionDbContext _context;

        public TransactionController(TransactionDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TransactionModels.ToListAsync());
        }

        //// GET: Transaction/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transactionModel = await _context.TransactionModels
        //        .FirstOrDefaultAsync(m => m.TransactionId == id);
        //    if (transactionModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transactionModel);
        //}

        //// GET: Transaction/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // GET: Transaction/AddOrEdit(Insert)
        // GET: Transaction/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new TransactionModel());
            else
            {
                // return View(_context.TransactionModels.FindAsync(id));
                var transactionModel = await _context.TransactionModels.FindAsync(id);
                if (transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }



        //// GET: Employee/Create
        //public IActionResult AddOrEdit(int id = 0)
        //{
        //    if (id == 0)
        //        return View(new TransactionModel());
        //    else
        //        return View(_context.TransactionModels.Find(id));
        //}

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount")] TransactionModel transactionModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(transactionModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(transactionModel);
        //}

        //// GET: Transaction/Edit/5
        //public async Task<IActionResult> AddOrEdit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transactionModel = await _context.TransactionModels.FindAsync(id);
        //    if (transactionModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(transactionModel);
        //}

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")] 
        TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    transactionModel.Date = DateTime.Now;
                    _context.Add(transactionModel);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(transactionModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(transactionModel.TransactionId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.Helper.RenderRazorViewToString(this, "_ViewAll", _context.TransactionModels.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.Helper.RenderRazorViewToString(this, "AddOrEdit", transactionModel) });
        }


        //// GET: Transaction/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transactionModel = await _context.TransactionModels
        //        .FirstOrDefaultAsync(m => m.TransactionId == id);
        //    if (transactionModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transactionModel);
        //}

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.TransactionModels.FindAsync(id);
            _context.TransactionModels.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.Helper.RenderRazorViewToString(this, "_ViewAll", _context.TransactionModels.ToList()) });
            //  return RedirectToAction(nameof(Index));
        }

        private bool TransactionModelExists(int id)
        {
            return _context.TransactionModels.Any(e => e.TransactionId == id);
        }
    }
}