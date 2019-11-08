using Alten.VehicleStatus.Data.Models;
using Alten.VehicleStatus.Data.Repository;
using System;

namespace Alten.VehicleStatus.Business
{

    public class CustomerBLL : IBusinessLogic<Customer>
    {
        public ResponseObject Add(Customer entity)
        {

            try
            {
                IRepository<Customer> customerRepository = new Repository<Customer>();
                return Helper.FillResponse(customerRepository.Add(entity), true, "Item Added Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }


        }

        public ResponseObject Delete(Customer entity)
        {
            try
            {
                IRepository<Customer> customerRepository = new Repository<Customer>();
                customerRepository.Delete(entity);
                return Helper.FillResponse(null, true, "Item Deleted Succssfully");
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
                IRepository<Customer> customerRepository = new Repository<Customer>();
                return Helper.FillResponse(customerRepository.GetAll(), true, "Items Retreived Succssfully");
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
                IRepository<Customer> customerRepository = new Repository<Customer>();
                return Helper.FillResponse(customerRepository.GetById(id), true, "Item Retreived Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }


        }

        public ResponseObject Update(Customer entity)
        {
            try
            {
                IRepository<Customer> customerRepository = new Repository<Customer>();
                return Helper.FillResponse(customerRepository.Update(entity, entity.id), true, "Item Updated Succssfully");
            }
            catch (Exception ex)
            {
                return Helper.FillResponse(null, false, ex.Message);
            }


        }
    }

}
