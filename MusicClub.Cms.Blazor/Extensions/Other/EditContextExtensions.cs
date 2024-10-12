using Microsoft.AspNetCore.Components.Forms;

namespace MusicClub.Cms.Blazor.Extensions.Other
{
    internal static class EditContextExtensions
    {
        public static void SelectDataResult<TDataResult>(this EditContext? editContext, TDataResult dataResult, Func<int> getId, Action<int> setId, Action<TDataResult> setDataResult) where TDataResult : class
        {
            if (editContext is null) return;

            setId(getId());
            setDataResult(dataResult);

            editContext.NotifyFieldChanged(FieldIdentifier.Create(() => getId));
        }
    }
}
