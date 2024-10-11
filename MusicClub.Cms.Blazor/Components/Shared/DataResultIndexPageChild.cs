using MusicClub.Cms.Blazor.Controllers;
using MusicClub.Cms.Blazor.Helpers;
using MusicClub.Cms.Blazor.Services;
using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Components.Shared
{
    public class DataResultIndexPageChild<TDataRequest, TDataResult, TFilterRequest, TFilterResult, TApiService, TFilterFormModel>
        : DataResultIndex<TDataRequest, TDataResult, TFilterRequest, TFilterResult, TApiService, TFilterFormModel>, IDisposable
        where TDataResult : class
        where TFilterRequest : class, new()
        where TFilterResult : class, IConvertToRequest<TFilterRequest>
        where TApiService : IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult>
        where TFilterFormModel : class, new()
    {
        protected override void OnInitialized()
        {
            PagedServiceResult = (PagedServiceResult<IList<TDataResult>, TFilterResult>?)DataController.Data;
            DataController.Data = null;

            if (PagedServiceResult is not null)
            {
                FilterEditContext = new(FilterResultHelper.ToFormModel(PagedServiceResult.Filter));
            }

            base.OnInitialized();
        }

        protected override async Task HandleOnReset()
        {
            await base.HandleOnReset();

            if(PagedServiceResult is not null)
            {
                MemoryService.Set(PagedServiceResult.Filter);
                MemoryService.Set(PagedServiceResult.Pagination);
            }
        }

        protected override async Task HandleOnValidSubmit()
        {
            await base.HandleOnValidSubmit();

            if (PagedServiceResult is not null)
            {
                MemoryService.Set(PagedServiceResult.Filter);
                MemoryService.Set(PagedServiceResult.Pagination);
            }
        }

        protected override async Task HandleOnPageChanged(PaginationRequest paginationRequest)
        {
            await base.HandleOnPageChanged(paginationRequest);

            if (PagedServiceResult is not null)
            {
                MemoryService.Set(PagedServiceResult.Filter);
                MemoryService.Set(PagedServiceResult.Pagination);
            }
        }

        public void Dispose() => DataController.Data = null;
    }
}
