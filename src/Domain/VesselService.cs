using Common;
using Data.Entities;
using Data.Repositories;
using System.Text.Json;

namespace Domain;

public class VesselService(IVesselRepository vesselRepository, IHumanMachineInterface humanMachineInterface) : IVesselService
{
    public async Task ShowAllAsync()
    {
        var vessels = await vesselRepository.GetAllAsync();
        vessels.ForEach(vessel =>
        {
            humanMachineInterface.Write(JsonSerializer.Serialize(vessel));
        });
    }

    public async Task RegisterOnlyOne(Func<string> inputProvider, Action<string> outputProvider)
    {
        outputProvider.Invoke("Add IMO Number:");
        var imoNumber = inputProvider.Invoke();
        var vessel = new Vessel { ImoNumber = imoNumber };
        var vesselRecorded = await vesselRepository.AddSingleRecordAsync(vessel);

        outputProvider.Invoke(JsonSerializer.Serialize(vesselRecorded.Entity));
    }
}
