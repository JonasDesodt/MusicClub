namespace MusicClub.Dto.Abstractions
{
    public interface IConvertToFormModel<TFormModel>
    {
        TFormModel ToFormModel();
    }
}
