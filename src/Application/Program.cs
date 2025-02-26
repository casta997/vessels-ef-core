using Microsoft.EntityFrameworkCore;
using VesselManagementData;

using (VesselManagemetContext vmc = new VesselManagemetContext())
{
    vmc.Database.Migrate();
}

VesselManagementLogic.Services.MenuService vesselMS = new VesselManagementLogic.Services.MenuService();

vesselMS.SelectAction();


