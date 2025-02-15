using DevSpot.Constants;
using DevSpot.Models;
using DevSpot.Repositories;
using DevSpot.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DevSpot.Controllers
{
    [Authorize]
    public class JobPostingsController : Controller
    {
        private readonly IRepository<JobPosting> _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public JobPostingsController(
            IRepository<JobPosting> repository,
            UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var jobPostings = await _repository.GetAllAsync();

            if (User.IsInRole(Roles.Employer))
            {
                var allJobPosting = await _repository.GetAllAsync();
                var userid = _userManager.GetUserId(User);
                var filteredJobPosting = allJobPosting.Where(jp => jp.UserId == userid);
                return View(filteredJobPosting);
            }
            var jobPosting = await _repository.GetAllAsync();

            return View(jobPosting);
        }

        [Authorize(Roles = "Admin, Employer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobPostingViewModel jobPostingVm)
        {
            var jobPosting = new JobPosting
            {
                Title = jobPostingVm.Title,
                Description = jobPostingVm.Description,
                Company = jobPostingVm.Company,
                Location = jobPostingVm.Location,
                UserId = _userManager.GetUserId(User),
            };
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(jobPosting);
                return RedirectToAction(nameof(Index));
            }

            return View(jobPostingVm);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin, Employer")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobPosting = await _repository.GetById(id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            if (User.IsInRole(Roles.Admin) == false && jobPosting.UserId != userId)
            {
                return Forbid();
            }

            await _repository.DeleteAsync(id);
            return Ok();
        }
    }

}
