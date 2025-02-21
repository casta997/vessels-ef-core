//using var db = new ManageVesselContext();
//db.Database.MigrateAsync().Wait();

using Application.ManageProgram;

var manageProgram = new OperationsCentralBase();

//manageProgram.AddVessel();
//manageProgram.ShowVessels();
//manageProgram.UpdateVessel();
//manageProgram.DeleteVessel();


manageProgram.AddOwner();
//manageProgram.ShowOwners();
//manageProgram.UpdateOwner();
//manageProgram.DeleteOwner();

//manageProgram.AssignVesselToOwner();