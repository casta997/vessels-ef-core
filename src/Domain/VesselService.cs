using Data.Entities;
using Data.Repositories;
using System.Text.Json;

namespace Domain;

public class VesselService(IVesselRepository vesselRepository) : IVesselService
{
    public async Task ShowAllAsync(Action<string> outputProvider)
    {
        var vessels = await vesselRepository.GetAllAsync();
        vessels.ForEach(vessel =>
        {
            outputProvider.Invoke(JsonSerializer.Serialize(vessel));
        });
    }

    public async Task RegisterOnlyOne(Action<string> outputProvider)
    {
        var vessel = await vesselRepository.AddSingleRecordAsync();

        outputProvider.Invoke(JsonSerializer.Serialize(vessel.Entity));
    }
}
