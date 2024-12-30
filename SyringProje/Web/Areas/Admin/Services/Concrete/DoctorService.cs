using Core.Entities;
using Core.Utilities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp.Services.Abstract;
using WebApp.ViewModels.Doctor;
using WebApp.ViewModels.OurVision;

namespace WebApp.Services.Concrete
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorPhotoRepository _doctorPhotoRepository;
        private readonly ModelStateDictionary _modelState;

        public DoctorService(AppDbContext context,
            IWebHostEnvironment webHostEnvironment,
            IFileService fileService,
            IDoctorRepository doctorRepository,
          IDoctorPhotoRepository doctorPhotoRepository,
               IActionContextAccessor actionContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _doctorPhotoRepository = doctorPhotoRepository;
            _doctorRepository = doctorRepository;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async  Task<DoctorIndexVM> GetAllAsync()
        {
            var model = new DoctorIndexVM()
            {
                Doctors = await _doctorRepository.GetAllAsync()
            };
            return model;
        }

        public async Task<bool> CreateAsync(DoctorCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _doctorRepository.AnyAsync(c => c.FullName.Trim().ToLower() == model.FullName.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Name", "This doctor already is exist");
                return false;
            }
            if (!_fileService.IsImage(model.Photo))
            {
                _modelState.AddModelError("MainPhotoName", "File must be img formatt");
                return false;

            }
            if (!_fileService.CheckSize(model.Photo, 500))
            {
                _modelState.AddModelError("MainPhoto", "fILE SIZE IS MOREN THAN REQUESTED");
                return false;

            }

            var doctor = new Doctor
            {
                FullName = model.FullName,
                Description = model.Description,
                Qualification = model.Qualification,
                Photo = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath)

            };

            await _doctorRepository.CreateAsync(doctor);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _doctorRepository.GetAsync(id);
            if (doctor != null)
            {
                foreach (var photo in await _doctorPhotoRepository.GetAllAsync())
                {
                    _fileService.Delete(photo.Name, _webHostEnvironment.WebRootPath);
                }

                await _doctorRepository.DeleteAsync(doctor);
            }
        }

        public async Task<bool> UpdateAsync(DoctorUpdateVM model)
        {
            var isExist = await _doctorRepository.AnyAsync(c => c.FullName.Trim().ToLower() == model.FullName.Trim().ToLower() && c.Id != model.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "This doctor already is exist");
                return false;
            }
            var doctor = await _doctorRepository.GetAsync(model.Id);
            if (doctor == null) return false;

            doctor.FullName = model.FullName;
            doctor.Description = model.Description;
            doctor.Qualification = model.Qualification; 
         
            await _doctorRepository.UpdateAsync(doctor);
            if (model.Photo != null)


                if (!_fileService.IsImage(model.Photo))
                {
                    _modelState.AddModelError("Photo", "Image formatinda secin");
                    return false;
                }
            if (!_fileService.CheckSize(model.Photo, 300))
            {
                _modelState.AddModelError("Photo", "Sekilin olcusu 300 kb dan boyukdur");
                return false;
            }

            _fileService.Delete(doctor.Photo, _webHostEnvironment.WebRootPath);
            doctor.Photo = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath);



            return true;
        }
        public async  Task<DoctorUpdateVM> GetUpdateModelAsync(int id)
        {
            var doctor = await _doctorRepository.GetAsync(id);

            if (doctor != null)
            {


                var model = new DoctorUpdateVM
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    Description = doctor.Description,
                    Qualification= doctor.Qualification
                };
                return model;

            }
            return null;
        }

    }
}
