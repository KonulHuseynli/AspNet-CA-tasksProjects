using Core.Entities;
using Core.Utilities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp.Services.Abstract;
using WebApp.ViewModels.OurVision;
using WebApp.ViewModels.WhatWeDoBest;

namespace WebApp.Services.Concrete
{
    public class WhatWeDoBestService:IWhatWeDoBestService
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly IWhatWeDoBestRepository _whatWeDoRepository;
        private readonly IWhatWeDoBestPhotoRepository _whatWeDoPhotoRepository;
        private readonly ModelStateDictionary _modelState;

        public WhatWeDoBestService(AppDbContext context,
            IWebHostEnvironment webHostEnvironment,
            IFileService fileService,
            IWhatWeDoBestRepository whatWeDoRepository,
          IWhatWeDoBestPhotoRepository whatWeDoPhotoRepository,
               IActionContextAccessor actionContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _whatWeDoRepository = whatWeDoRepository;
            _whatWeDoPhotoRepository = whatWeDoPhotoRepository;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }
        public async Task<WhatWeDoBestIndexVM> GetAllAsync()
        {
            var model = new WhatWeDoBestIndexVM()
            {
                WhatWeDoBests = await _whatWeDoRepository.GetAllAsync()
            };
            return model;
        }

        public async Task<bool> CreateAsync(WhatWeDoBestCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _whatWeDoRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Name", "This WWDB already is exist");
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

            var whatWeDoBest = new WhatWeDoBest
            {
                Title = model.Title,
                Description = model.Description,
                Photo = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath)

            };

            await _whatWeDoRepository.CreateAsync(whatWeDoBest);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var whatWeDoBest = await _whatWeDoRepository.GetAsync(id);
            if (whatWeDoBest != null)
            {
                foreach (var photo in await _whatWeDoPhotoRepository.GetAllAsync())
                {
                    _fileService.Delete(photo.Name, _webHostEnvironment.WebRootPath);
                }

                await _whatWeDoRepository.DeleteAsync(whatWeDoBest);
            }
        }

        public async Task<WhatWeDoBestUpdateVM> GetUpdateModelAsync(int id)
        {
            var whatWeDoBest = await _whatWeDoRepository.GetAsync(id);

            if (whatWeDoBest != null)
            {


                var model = new WhatWeDoBestUpdateVM
                {
                    Id = whatWeDoBest.Id,
                    Title = whatWeDoBest.Title,
                    Description = whatWeDoBest.Description
                };
                return model;

            }
            return null;
        }

        public async Task<bool> UpdateAsync(WhatWeDoBestUpdateVM model)
        {
            var isExist = await _whatWeDoRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "This vision already is exist");
                return false;
            }
            var whatWeDoBest = await _whatWeDoRepository.GetAsync(model.Id);
            if (whatWeDoBest == null) return false;

            whatWeDoBest.Title = model.Title;
            whatWeDoBest.Description = model.Description;
            await _whatWeDoRepository.UpdateAsync(whatWeDoBest);
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

            _fileService.Delete(whatWeDoBest.Photo, _webHostEnvironment.WebRootPath);
            whatWeDoBest.Photo = await _fileService.UploadAsync(model.Photo, _webHostEnvironment.WebRootPath);



            return true;
        }
    }
}
