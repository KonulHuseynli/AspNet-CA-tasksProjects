using front_to_back.Models;

namespace front_to_back.ViewModels.Contact
{
    public class ContactIndexViewModel
    {
        public ContactComponent ContactComponent { get; set; }
        public ContactMainComponent ContactMainComponent { get; set; }
        public List<ContactCommunucationComponent> ContactCommunucationComponent { get; set; }
    }
}
