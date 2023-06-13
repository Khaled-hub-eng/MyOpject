using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Dto;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class MyOpjectController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public MyOpjectController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IQueryable<MyOpject> query = _context.MyOpjects.Where(p => p.IsActive).AsQueryable();
            List<MyOpject> myOpjects = query.ToList();
            return View(myOpjects);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateMyOpjectDto model)
        {
            if (model == null | model.Name == null)
            {
                
                return View("OpjectIsNull");
            }

            var myopject = _mapper.Map<MyOpject>(model);
            var isExists = _context.MyOpjects.Any(opj => opj.Name.ToLower() == model.Name.ToLower());
            if (isExists)
            {
                return View("NameIsExist");
            }
             _context.MyOpjects.Add(myopject);
             _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            if (id == null)
            {

                return View("NoId");
            }
            MyOpject myOpject = _context.MyOpjects.Where(p => p.IsActive && p.Id == id).FirstOrDefault();
            
            if (myOpject == null)
            {
                return View("NoId");
            }
            UpdateMyOpjectDto updateMyOpjectDto = _mapper.Map<UpdateMyOpjectDto>(myOpject);
            return View(updateMyOpjectDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateMyOpjectDto updatemyopjectdto)
        {
            if (updatemyopjectdto == null | updatemyopjectdto.Name == null)
            {

                return View("OpjectIsNull");
            }
            MyOpject myOpject = _context.MyOpjects.Where(p => p.IsActive && p.Id == updatemyopjectdto.Id).FirstOrDefault();

            if (myOpject == null)
            {
                return View("NoId");
            }
              
            _mapper.Map(updatemyopjectdto, myOpject);
            myOpject.UpdatedDate = DateTime.Now;
            _context.MyOpjects.Update(myOpject);
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {

                return View("NoId");
            }
            MyOpject myOpject = _context.MyOpjects.Where(p => p.IsActive && p.Id == id).FirstOrDefault();

            if (myOpject == null)
            {
                return View("NoId");
            }

            myOpject.IsActive = false;
            myOpject.DeletedDate = DateTime.Now;
            _context.MyOpjects.Update(myOpject);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
