using Microsoft.AspNetCore.Components;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Components.Shared
{
    public abstract partial class DataResultInput<TApiService, TDataRequest, TDataResult, TFilterRequest, TFilterResult> where TApiService : IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult> where TDataResult : class where TFilterRequest : new() 
    {
        [Inject]
        public required abstract TApiService ApiService { get; set; }

        [Parameter, EditorRequired]
        public required TDataResult? DataResult { get; set; }

        [Parameter, EditorRequired]
        public required RenderFragment<TDataResult> Info { get; set; }

        [Parameter, EditorRequired]
        public required EventCallback OnDataRequest { get; set; }

        protected abstract string Model { get; }

        [Parameter]
        public int? Id { get; set; }

        [Parameter]
        public EventCallback<int?> IdChanged { get; set; }

        private int? CurrentId
        {
            get => Id;
            set
            {
                if (Id != value)
                {
                    Id = value;
                    IdChanged.InvokeAsync(value); // Notify parent of change
                }
            }
        }

        private async Task FetchAll(PaginationRequest paginationRequest, TFilterRequest filterRequest)
        {
            await ApiService.GetAll(paginationRequest, filterRequest);
        }
    }
}
