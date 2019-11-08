using Alten.VehicleStatus.Data.Models;
using Alten.VehicleStatus.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alten.VehicleStatus.Business
{
    public class VehicleBLL : IBusinessLogic<Vehicle>
    {
        private IEnumerable<Vehicle> vehicles { set; get; }
        public ResponseObject Add(Vehicle entity)
        {

            try
            {
                IRepository<Vehicle> vehicleRepository = new Repository<Vehicle>();
                return Helper.FillResponse(vehicleRepository.Add(entity), true, "Item Added Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }


        }

        public ResponseObject Delete(Vehicle entity)
        {
            try
            {
                IRepository<Vehicle> vehicleRepository = new Repository<Vehicle>();
                vehicleRepository.Delete(entity);
                return Helper.FillResponse(null, true, "Item Deleted Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }


        }

        public ResponseObject GetAll()
        {
            try
            {
                IRepository<Vehicle> vehicleRepository = new Repository<Vehicle>();
                Customer customer= new Customer() { id = 1, name = "Kalles Grustransporter AB", address = "Cementvägen 8, 111 11 Södertälje" };
                Customer customer2 = new Customer() { id = 2, name = "Johans Bulk AB", address = "Balkvägen 12, 222 22 Stockholm" };
                Customer customer3= new Customer() { id = 3, name = "Haralds Värdetransporter AB", address = "Budgetvägen 1, 333 33 Uppsala" };
                vehicles = new List<Vehicle>() {
                    new Vehicle() {
                        id = 1,
                        identifire = "YS2R4X20005399401",
                        owner = customer,
                        regNr = "ABC123",status="Connected"
                    },
                    new Vehicle() {
                        id = 2,
                        identifire = "VLUR4X20009093588",
                        owner = customer,
                        regNr = "DEF456",status="Disconnected"
                    },
                    new Vehicle() {
                        id = 3,
                        identifire = "VLUR4X20009048066",
                        owner =customer,
                        regNr = "GHI789",status="Connected"
                    },
                      new Vehicle() {
                        id = 1,
                        identifire = "YS2R4X20005388011",
                        owner = customer2,
                        regNr = "JKL012",status="Connected"
                    },
                    new Vehicle() {
                        id = 2,
                        identifire = "YS2R4X20005387949",
                        owner = customer2,
                        regNr = "MNO345",status="Disconnected"
                    },
                    new Vehicle() {
                        id = 3,
                        identifire = "VLUR4X20009048066",
                        owner =customer3,
                        regNr = "PQR678",status="Connected"
                    },
                     new Vehicle() {
                        id = 3,
                        identifire = "YS2R4X20005387055",
                        owner =customer3,
                        regNr = "STU901",status="Connected"
                    }
                };
                return Helper.FillResponse(vehicles, true, "Items Retreived Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }

        }

        public ResponseObject GetAll(int skip, int take)
        {
            try
            {
                IRepository<Vehicle> vehicleRepository = new Repository<Vehicle>();
                vehicles = new List<Vehicle>() { new Vehicle() { id = 1, identifire = "YS2R4X20005399401", owner = new Customer() { id = 1, name = "Kalles Grustransporter AB", address = "Cementvägen 8, 111 11 Södertälje" }, regNr = "ABC123", status = "Active" } };
                return Helper.FillResponse(vehicles, true, "Items Retreived Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }
        }

        public ResponseObject GetById(int id)
        {
            try
            {
                IRepository<Vehicle> vehicleRepository = new Repository<Vehicle>();
                return Helper.FillResponse(vehicleRepository.GetById(id), true, "Item Retreived Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }


        }

        public ResponseObject Update(Vehicle entity)
        {
            try
            {
                IRepository<Vehicle> vehicleRepository = new Repository<Vehicle>();
                return Helper.FillResponse(vehicleRepository.Update(entity, entity.id), true, "Item Updated Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }


        }
    }
}
