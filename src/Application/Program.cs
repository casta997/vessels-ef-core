using VesselManagementData;

using (VesselManagemetContext vmc = new VesselManagemetContext())
{
    vmc.Database.EnsureCreated();
}

VesselManagementLogic.Services.MenuService vesselMS = new VesselManagementLogic.Services.MenuService();

vesselMS.SelectAction();


