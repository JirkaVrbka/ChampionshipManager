using ChampionshipManager.BusinessLayer.Services;

namespace ChampionshipManager.BusinessLayer.Facades
{
    public class OrganizerFacade
    {
        private OrganizerService _organizerService;

        public OrganizerFacade(OrganizerService organizerService)
        {
            _organizerService = organizerService;
        }
    }
}