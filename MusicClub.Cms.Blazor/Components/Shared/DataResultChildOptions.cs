using MusicClub.Cms.Blazor.Services;
using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Components.Shared
{
    public class DataResultChildOptions<TDataRequest, TDataResult, TFilterRequest, TFilterResult, TApiService, TFilterFormModel>
        : DataResultIndex<TDataRequest, TDataResult, TFilterRequest, TFilterResult, TApiService, TFilterFormModel>
        where TDataResult : class
        where TFilterRequest : class, new()
        where TFilterResult : class, IConvertToRequest<TFilterRequest>
        where TApiService : IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult>
        where TFilterFormModel : class, new()
    {
        protected override async Task OnInitializedAsync()
        {
            var paginationRequest = MemoryService.GetDefaultPaginationRequest();

            var filterRequest = new TFilterRequest();

            PagedServiceResult = await DataController.Fetch<PagedServiceResult<IList<TDataResult>, TFilterResult>>(async () => await ApiService.GetAll(paginationRequest, filterRequest));
            if (PagedServiceResult is not null)
            {
                FilterEditContext = new(FilterResultHelper.ToFormModel(PagedServiceResult.Filter));
            }

            await base.OnInitializedAsync();
        }
    }
}
