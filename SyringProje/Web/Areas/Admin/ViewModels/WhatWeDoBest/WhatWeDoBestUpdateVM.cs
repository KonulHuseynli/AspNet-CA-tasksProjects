namespace WebApp.ViewModels.WhatWeDoBest
{
    public class WhatWeDoBestUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Photo { get; set; }
        public string? PhotoName { get; set; }
    }
}
