namespace Alten.VehicleStatus.Business
{
    public class Helper
    {
        public static ResponseObject FillResponse(object data, bool isSuccessded, string message)
        {

            ResponseObject response = new ResponseObject();
            response.Data = data;
            response.IsSuccessded = isSuccessded;
            response.Message = message;
            return response;
        }
    }
}