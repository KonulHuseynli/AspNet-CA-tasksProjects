using FlowerProjectP323.Areas.Admin.Helpers;
using FlowerProjectP323.Areas.Admin.ViewModels;
using FlowerProjectP323.Areas.Admin.ViewModels.Product;
using FlowerProjectP323.DAL;
using FlowerProjectP323.Models;
using FlowerProjectP323.ViewModels;
using FlowerProjectP323.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext appDbContext, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ProductIndexViewModel
            {

                Products = await _appDbContext.Products.Include(x => x.Category).ToListAsync()
            };

            return View(model);
        }
        #region create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProductCreateViewModel
            {
                Categories = await _appDbContext.Categories.Select(p => new SelectListItem
                {
                    Text = p.Title,
                    Value = p.Id.ToString()
                })
               .ToListAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            model.Categories = await _appDbContext.Categories.Select(p => new SelectListItem
            {
                Text = p.Title,
                Value = p.Id.ToString()
            })
                .ToListAsync();
            if (!ModelState.IsValid) return View(model);
            var category = await _appDbContext.Categories.FindAsync(model.CategoryId);
            if (category == null)
            {
                ModelState.AddModelError("CategoryId", "This category isnt declared");
                return View(model);
            }
            bool IsExist = await _appDbContext.Products
                .AnyAsync(p => p.Name.ToLower().Trim() == model.Name.ToLower().Trim());
            if (IsExist)
            {
                ModelState.AddModelError("Title", "This category inst declared");
                return View(model);
            }
            if (!_fileService.IsImage(model.MainPhotoName))
            {
                ModelState.AddModelError("MainPhotoName", "File must be img formatt");
                return View(model);

            }
            if (!_fileService.CheckSize(model.MainPhotoName, 500))
            {
                ModelState.AddModelError("MainPhoto", "fILE SIZE IS MOREN THAN REQUESTED");
                return View(model);
            }

            bool hasError = false;
            foreach (var photo in model.ProductPhotos)
            {
                if (!_fileService.IsImage(photo))
                {
                    ModelState.AddModelError("ProductPhotos", $"{photo.FileName} fILE MUST BE IMG FORMAT");
                    hasError = true;

                }
                else if (!_fileService.CheckSize(photo, 300))
                {
                    ModelState.AddModelError("ProductPhotos", $"{photo.FileName}DOWNLOAD fILE SIZE MUST BE LESS THAN 500KB");
                    hasError = true;

                }

            }

            if (hasError) { return View(model); }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Quantity = model.Quantity,
                Weight = model.Weight,
                Dimenesion = model.Dimenesion,
                CategoryId = model.CategoryId,
                Status = model.Status,
                MainPhotoName = await _fileService.UploadAsync(model.MainPhotoName, _webHostEnvironment.WebRootPath)
            };
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");

        }
        #endregion
        #region delete
        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _appDbContext.Products.Include(p => p.ProductPhotos).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            _fileService.Delete(product.MainPhotoName, _webHostEnvironment.WebRootPath);

            foreach (var photo in product.ProductPhotos)
            {
                _fileService.Delete(photo.Name, _webHostEnvironment.WebRootPath);

            }
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion
        #region Details
        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var product = await _appDbContext.Products.Include(p => p.ProductPhotos).FirstOrDefaultAsync(p => p.Id == id);



            if (product == null) return NotFound();

            var model = new ProductDetailsViewModel
            {
                Id = product.Id,
                Title = product.Name,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                Weight = product.Weight,
                Dimenesion = product.Dimenesion,
                CategoryId = product.CategoryId,
                Status = product.Status,
                MainPhoto = product.MainPhotoName,
                Photos = product.ProductPhotos,
                Categories = await _appDbContext.Categories.Select(c => new SelectListItem

                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                }).ToListAsync()

            };

            return View(model);
        }

        #endregion
        #region Update

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var product = await _appDbContext.Products.Include(p => p.ProductPhotos).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            var model = new ProductUpdateViewModel
            {

                Title = product.Name,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                Weight = product.Weight,
                Dimenesion = product.Dimenesion,
                CategoryId = product.CategoryId,
                Status = product.Status,
                MainPhotoName = product.MainPhotoName,
                ProductPhotos = product.ProductPhotos,



                Categories = await _appDbContext.Categories.Select(c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                }).ToListAsync()

            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Update(ProductUpdateViewModel model, int id)
        {
            model.Categories = await _appDbContext.Categories.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToListAsync();

            if (!ModelState.IsValid) return View(model);

            if (id != model.Id) return BadRequest();

            var product = await _appDbContext.Products.Include(p => p.ProductPhotos).FirstOrDefaultAsync(p => p.Id == id);

            model.ProductPhotos = product.ProductPhotos.ToList();



            if (product == null) return NotFound();

            bool isExits = await _appDbContext.Products.AnyAsync(p => p.Name.ToLower().Trim() == model.Title.ToLower().Trim() && p.Id != model.Id);

            if (isExits)
            {
                ModelState.AddModelError("Title", "Bu product movcuddur");
                return View(model);
            }




            if (model.MainPhoto != null)
            {

                if (!_fileService.IsImage(model.MainPhoto))
                {
                    ModelState.AddModelError("Photo", "Image formatinda secin");
                    return View(model);
                }
                if (!_fileService.CheckSize(model.MainPhoto, 300))
                {
                    ModelState.AddModelError("Photo", "Sekilin olcusu 300 kb dan boyukdur");
                    return View(model);
                }

                _fileService.Delete(product.MainPhotoName, _webHostEnvironment.WebRootPath);
                product.MainPhotoName = await _fileService.UploadAsync(model.MainPhoto, _webHostEnvironment.WebRootPath);
            }







            bool hasError = false;

            if (model.Photos != null)
            {
                foreach (var photo in model.Photos)
                {
                    if (!_fileService.IsImage(photo))
                    {
                        ModelState.AddModelError("Photos", $"{photo.FileName} yuklediyiniz file sekil formatinda olmalidir");
                        hasError = true;
                    }
                    else if (!_fileService.CheckSize(photo, 300))
                    {
                        ModelState.AddModelError("Photos", $"{photo.FileName} ci yuklediyiniz sekil 300 kb dan az olmalidir");
                        hasError = true;
                    }
                }

                if (hasError) { return View(model); }

                int order = product.ProductPhotos.OrderByDescending(pp => pp.Order).FirstOrDefault().Order;
                foreach (var photo in model.Photos)
                {
                    var productPhoto = new ProductPhoto
                    {
                        Name = await _fileService.UploadAsync(photo, _webHostEnvironment.WebRootPath),
                        Order = ++order,
                        ProductId = product.Id
                    };
                    await _appDbContext.productPhotos.AddAsync(productPhoto);
                    await _appDbContext.SaveChangesAsync();


                }
            }
            product.Name = model.Title;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Quantity = model.Quantity;
            product.Weight = model.Weight;
            product.Dimenesion = model.Dimenesion;
            product.Status = model.Status;

            model.MainPhotoName = product.MainPhotoName;

            var category = await _appDbContext.Categories.FindAsync(model.CategoryId);
            if (category == null) return NotFound();
            product.CategoryId = category.Id;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

            #endregion
        }
    }
}