namespace Alten.VehicleStatus.Business
{
    public interface IBusinessLogic<T> where T : class
    {
        ResponseObject GetAll(int skip, int take);
        ResponseObject GetById(int id);
        ResponseObject Add(T entity);
        ResponseObject Delete(T entity);
        ResponseObject Update(T entity);
    }
}