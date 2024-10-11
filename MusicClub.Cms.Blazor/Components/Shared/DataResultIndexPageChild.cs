using MusicClub.Cms.Blazor.Controllers;
using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Components.Shared
{
    public class DataResultIndexPageChild<TDataRequest, TDataResult, TFilterRequest, TFilterResult, TApiService, TFilterFormModel> : DataResultIndex<TDataRequest, TDataResult, TFilterRequest, TFilterResult, TApiService, TFilterFormModel>, IDisposable
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

        public void Dispose() => DataController.Data = null;
    }
}
