using Microsoft.AspNetCore.Components;
using MusicClub.Cms.Blazor.Attributes;

namespace MusicClub.Cms.Blazor.Components.Shared
{
    [GenerateDataResultInputs("Act", "Artist", "Image", "Lineup", "Person")]
    public abstract partial class DataResultInput<TDataResult, TFilterRequest> where TDataResult : class where TFilterRequest : new()

        //public abstract partial class DataResultInput<TApiService, TDataRequest, TDataResult, TFilterRequest, TFilterResult> where TApiService : IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult> where TDataResult : class where TFilterRequest : new() 
    {
        //[Inject]
        //public required abstract TApiService ApiService { get; set; }

        [Parameter, EditorRequired]
        public required TDataResult? DataResult { get; set; }

        [Parameter, EditorRequired]
        public required RenderFragment<TDataResult> Info { get; set; }

        [Parameter, EditorRequired]
        public required EventCallback OnDataRequest { get; set; }

        [Parameter, EditorRequired]
        public required EventCallback OnRemoveRequest { get; set; }

        protected abstract string Model { get; }

        [Parameter]
        public int? Value { get; set; }

        [Parameter]
        public EventCallback<int?> ValueChanged { get; set; }

        private int? CurrentValue
        {
            get => Value;
            set
            {
                if (Value != value)
                {
                    Value = value;
                    ValueChanged.InvokeAsync(value); // Notify parent of change
                }
            }
        }
    }
}
