using ConfTool.ClientModules.Conferences.Components;
using ConfTool.ClientModules.Conferences.Services;
using ConfTool.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfTool.ClientModules.Conferences.Pages
{
    public partial class Conference : ComponentBase
    {
        [Parameter]
        public string Mode { get; set; }
        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        private IDialogService _alert { get; set; }
        [Inject]
        private IConferencesServiceClient _conferencesService { get; set; }
        [Inject]
        private CountriesServiceClient _countriesService { get; set; }

        private ConferenceDetails _conferenceDetails;
        private List<string> _countries;
        private bool _isShow;
        
        public Conference()
        {
            _conferenceDetails = new ConferenceDetails
            {
                DateFrom = DateTime.UtcNow,
                DateTo = DateTime.UtcNow
            };

            _countries = new List<string>();
        }

        protected override async Task OnInitializedAsync()
        {
            _isShow = Mode == ConferenceComponentDisplayModes.Show;

            switch (Mode)
            {
                case ConferenceComponentDisplayModes.Show:
                    var conferenceResult = await _conferencesService.GetConferenceDetailsAsync(Id);
                    _conferenceDetails = conferenceResult;
                    break;
                case ConferenceComponentDisplayModes.Edit:
                case ConferenceComponentDisplayModes.New:
                    var countriesResult = await _countriesService.ListCountries();
                    _countries = countriesResult;
                    _conferenceDetails.Country = _countries[0];
                    break;
            }
        }

        private async Task SaveConference(EditContext editContext)
        {
            if (!await _alert.ConfirmAsync("Do you want to save this new entry?"))
            {
                Console.WriteLine("### User declined to save conference!");
                return;
            }

            await _conferencesService.AddConferenceAsync(_conferenceDetails);

            Console.WriteLine("### NEW conference added...");
        }

        private async Task<IEnumerable<string>> FilterCountries(string searchText)
        {
            return await Task.FromResult(_countries.Where(
                c => c.ToLower().Contains(searchText.ToLower())).ToList());
        }
    }
}