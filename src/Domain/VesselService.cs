using Data.Repositories;
using System.Text.Json;

namespace Domain;

public class VesselService(IVesselRepository vesselRepository) : IVesselService
{
    public async Task ShowAsync(Action<string> outputProvider)
    {
        var vessels = await vesselRepository.GetAllAsync();
        vessels.ForEach(vessel =>
        {
            outputProvider.Invoke(JsonSerializer.Serialize(vessel));
        });
    }
}
