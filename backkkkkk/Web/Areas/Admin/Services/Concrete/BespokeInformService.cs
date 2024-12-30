
using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient.Server;
using System.Collections.Generic;
using Web.Areas.Admin.Services.Abstract;
using Web.Areas.Admin.ViewModels.BespokeInform;

namespace Web.Areas.Admin.Services.Concrete
{
    public class BespokeInformService:IBespokeInformService
    {
        private readonly IBespokeInformRepository _bespokeInformRepository;
        private readonly IFileService _fileService;
        private readonly ModelStateDictionary _modelState;

        public BespokeInformService(IBespokeInformRepository bespokeInformRepository, IActionContextAccessor actionContextAccessor, IFileService fileService)
        {
            _bespokeInformRepository = bespokeInformRepository;

            _fileService = fileService;
            _modelState = actionContextAccessor.ActionContext.ModelState;
        }

        #region BespokeInformCrud
        public async Task<BespokeInformIndexVM> GetAllAsync()
        {
            var model = new BespokeInformIndexVM
            {
                BespokeInforms = await _bespokeInformRepository.GetAllAsync()
            };
            return model;

        }

        public async Task<bool> CreateAsync(BespokeInformCreateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _bespokeInformRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower());
            if (isExist)
            {
                _modelState.AddModelError("Title", "This title already exist");
                return false;
            }

            if (!_fileService.IsImage(model.MainPhoto))
            {
                _modelState.AddModelError("MainPhoto", "file isnt image format");
                return false;
            }
            if (!_fileService.CheckSize(model.MainPhoto, 900))
            {
                _modelState.AddModelError("MainPhoto", "File size more than 900Kb");
                return false;
            }



            var bespokeInform = new BespokeInform
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                CreatedAt = DateTime.Now,

                Photo = await _fileService.UploadAsync(model.MainPhoto),
            };

            await _bespokeInformRepository.CreateAsync(bespokeInform);
            return true;
        }

        public async Task<BespokeInformUpdateVM> GetUpdateModelAsync(int id)
        {


            var bespokeInform = await _bespokeInformRepository.GetAsync(id);

            if (bespokeInform == null) return null;

            var model = new BespokeInformUpdateVM
            {
                Id = bespokeInform.Id,
                Title = bespokeInform.Title,
                Description = bespokeInform.Description,
                MainPhotoName = bespokeInform.Photo,

            };

            return model;

        }


        public async Task<bool> UpdateAsync(BespokeInformUpdateVM model)
        {
            if (!_modelState.IsValid) return false;

            var isExist = await _bespokeInformRepository.AnyAsync(c => c.Title.Trim().ToLower() == model.Title.Trim().ToLower() && c.Id != model.Id);
            if (isExist)
            {
                _modelState.AddModelError("Title", "This title already exist");
                return false;
            }
            if (model.MainPhoto != null)
            {
                if (!_fileService.IsImage(model.MainPhoto))
                {
                    _modelState.AddModelError("MainPhoto", "file isnt image format!");
                    return false;
                }
                if (!_fileService.CheckSize(model.MainPhoto, 900))
                {
                    _modelState.AddModelError("MainPhoto", "File more than 900kb");
                    return false;
                }
            }

            var bespokeInform = await _bespokeInformRepository.GetAsync(model.Id);




            if (bespokeInform != null)
            {
                bespokeInform.Id = model.Id;
                bespokeInform.Title = model.Title;
                bespokeInform.ModifiedAt = DateTime.Now;
                bespokeInform.Description = model.Description;



                if (model.MainPhoto != null)
                {
                    bespokeInform.Photo = await _fileService.UploadAsync(model.MainPhoto);
                }

                await _bespokeInformRepository.UpdateAsync(bespokeInform);

            }
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var bespokeInform = await _bespokeInformRepository.GetAsync(id);
            if (bespokeInform != null)
            {
                _fileService.Delete(bespokeInform.Photo);




                await _bespokeInformRepository.DeleteAsync(bespokeInform);

                return true;

            }

            return false;
        }


        #endregion
    }
}
