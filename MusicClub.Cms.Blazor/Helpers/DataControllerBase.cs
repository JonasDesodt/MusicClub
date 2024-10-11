using Microsoft.AspNetCore.Components;
using MusicClub.Cms.Blazor.Services;
using MusicClub.Dto.Abstractions;
using MusicClub.Dto.Transfer;

namespace MusicClub.Cms.Blazor.Helpers
{
    public abstract class DataControllerBase(NavigationManager navigationManager, MemoryService memoryService)
    {
        public object? Data { get; set; } //todo: make private & add method that gets and deletes the data

        public event EventHandler<bool>? OnFetchStateChanged;

        private CancellationTokenSource? _cancellationSource;

        public async Task<bool> HandleLocationChanged(string targetLocation)
        {
            Uri uri;

            var domain = new Uri(navigationManager.Uri).GetLeftPart(UriPartial.Authority);

            if (!targetLocation.StartsWith(domain))
            {
                uri = new Uri(domain + targetLocation);
            }
            else
            {
                uri = new Uri(targetLocation);
            }

            var route = uri.GetLeftPart(UriPartial.Path).Replace(domain, string.Empty);

            return await HandleRoute(route);
        }


        public async Task<TResult> Fetch<TResult>(Func<Task<TResult>> function)
        {
            Data = null;
            _cancellationSource = new CancellationTokenSource();

            OnFetchStateChanged?.Invoke(this, true);

            var task = function();

            var result = await task.WaitAsync(_cancellationSource.Token);

            OnFetchStateChanged?.Invoke(this, false);

            return result;
        }

        public async Task CancelCurrentFetch()
        {
            if (_cancellationSource is not null)
            {
                await _cancellationSource.CancelAsync();
                //_cancellationSource.Dispose();

                OnFetchStateChanged?.Invoke(this, false);
                Data = null;
            }
        }

        public void InvokeOnFetchStateChanged()
        {
            OnFetchStateChanged?.Invoke(this, true);
        }

        protected async Task<bool> HandleIndexRouteMatchFound<TDataRequest, TDataResult, TFilterRequest, TFilterResult>(IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult> apiService) where TFilterResult : class?, IConvertToRequest<TFilterRequest> where TFilterRequest : new()
        {
            var paginationRequest = new PaginationRequest
            {
                Page = memoryService.Get<PaginationResult>()?.Page ?? MemoryService.DefaultPage,
                PageSize = memoryService.Get<PaginationResult>()?.PageSize ?? MemoryService.DefaultPageSize
            };

            var filterResult = memoryService.Get<TFilterResult>();
            TFilterRequest? filterRequest;
            if (filterResult is not null)
            {
                filterRequest = filterResult.ToRequest();
            }
            else
            {
                filterRequest = new TFilterRequest();
            }

            Data = await Fetch<PagedServiceResult<IList<TDataResult>, TFilterResult>>(async () => await apiService.GetAll(paginationRequest, filterRequest));

            if (Data is PagedServiceResult<IList<TDataResult>, TFilterResult> pagedServiceResult)
            {
                memoryService.Set(pagedServiceResult.Filter);
                memoryService.Set(pagedServiceResult.Pagination);

                return pagedServiceResult.Messages?.HasMessage is not true;
            }

            return false;
        }

        protected async Task<bool> HandleEditRouteMatchFound<TDataRequest, TDataResult, TFilterRequest, TFilterResult>(IService<TDataRequest, TDataResult, TFilterRequest, TFilterResult> apiService, string route) where TFilterResult : class?, IConvertToRequest<TFilterRequest> where TFilterRequest : new()
        {
            Data = await Fetch<ServiceResult<TDataResult>>(async () => await apiService.Get(int.Parse(route.Split('/').Last())));

            if (Data is ServiceResult<TDataResult> serviceResult)
            {
                return serviceResult.Messages?.HasMessage is not true;
            }

            return false;
        }

        protected abstract Task<bool> HandleRoute(string route);

        protected virtual Task<bool> HandleCustomRoute(string route) 
        {
            return Task.FromResult(true);
        }
    } 
}
