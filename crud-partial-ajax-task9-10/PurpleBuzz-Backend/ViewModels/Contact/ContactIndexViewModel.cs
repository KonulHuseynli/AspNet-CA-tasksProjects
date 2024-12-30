using PurpleBuzz_Backend.Models;

namespace PurpleBuzz_Backend.ViewModels.Contact
{
    public class ContactIndexViewModel
    {
        public ContactIntroComponent ContactIntroComponent { get; set; }
        public ContactContextComponent ContactContextComponent { get; set; }
        public List<ContactCommunicationComponent> ContactCommunicationComponent { get; set; }
    }
}
