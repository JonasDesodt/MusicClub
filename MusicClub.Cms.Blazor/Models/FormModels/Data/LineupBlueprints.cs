using MusicClub.Cms.Blazor.Attributes;

namespace MusicClub.Cms.Blazor.Models.FormModels.Data
{
    [GenerateDataFormModel("Lineup")]
    public abstract class LineupDataFormModelBlueprint : LineupRequest, IImageSelect
    {
        public ImageResult? ImageResult { get; set; }
    }
    public partial class LineupFormModel { }

    [GenerateDataFormModelExtensions("Lineup")]
    public abstract class LineupDataFormModelExtensionsBlueprint : LineupRequest { }

    [GenerateDataResultExtensions("Lineup")]
    public abstract class LineupDataResultBlueprint : LineupResult { }
}
