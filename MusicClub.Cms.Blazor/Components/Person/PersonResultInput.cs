using Microsoft.AspNetCore.Components;
using MusicClub.Cms.Blazor.Components.Shared;
using MusicClub.Dto.Abstractions;

namespace MusicClub.Cms.Blazor.Components.Person
{
    public partial class PersonResultInput : DataResultInput<IPersonService, PersonRequest, PersonResult, PersonFilterRequest, PersonFilterResult> 
    {
        [Inject]
        public override required IPersonService ApiService { get;  set; }

        protected override string Model => "Person";
    }

}
