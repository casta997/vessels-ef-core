using VesselManagementData;

using (VesselManagemetContext vmc = new VesselManagemetContext())
{
    vmc.Database.EnsureCreated();
}
