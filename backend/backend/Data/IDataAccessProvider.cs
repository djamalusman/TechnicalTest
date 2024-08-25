using backend.Models;

namespace backend.Data
{
    public interface IDataAccessProvider
    {
        GeneralOutputModel loginUser(LoginModel pr);

        GeneralOutputModel GetdataBpkb();
        GeneralOutputModel GetdatabyIdBpkb(byId pr);
        GeneralOutputModel Getdatalocations();
        Task<GeneralOutputModel> InsertDataAsync(Bpkbstore data);
        Task<GeneralOutputModel> UpdateDataAsync(Bpkbstore data);
    }
}
