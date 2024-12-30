using WebApp.ViewModels.OurVision;
using WebApp.ViewModels.WhatWeDoBest;

namespace WebApp.Services.Abstract
{
    public interface IWhatWeDoBestService
    {
        Task<WhatWeDoBestIndexVM> GetAllAsync();
        Task<bool> CreateAsync(WhatWeDoBestCreateVM model);

        Task<WhatWeDoBestUpdateVM> GetUpdateModelAsync(int id);
        Task<bool> UpdateAsync(WhatWeDoBestUpdateVM model);
        Task DeleteAsync(int id);
    }
}
