using InvoiceApp.Commons.Models;

namespace InvoiceApp.Server.Interfaces;

public interface IPersonDataRepository
{
    Task<IList<PersonData>> GetPersonDatasAsync();
    Task<PersonData> GetPersonDataByIdAsync(int personDataId);
    Task<PersonData> CreatePersonData(PersonData personData);
    Task<bool> UpdatePersonData(PersonData personData);
    Task<bool> DeletePersonData(int personDataId);
}
