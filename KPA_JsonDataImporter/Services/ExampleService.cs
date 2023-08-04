using KPA_JsonDataImporter.Database;
using KPA_JsonDataImporter.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KPA_JsonDataImporter.Services
{
    public class ExampleService
    {
        private readonly DatabaseContext _databaseContext;

        public ExampleService()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task ImportJsonData(IFormFile file)
        {
            string fileString = (new StreamReader(file.OpenReadStream())).ReadToEnd();

            // Parse file containing json to an Array of Example Models
            IEnumerable<ExampleModel>? intakeDataList = JsonSerializer.Deserialize<IEnumerable<ExampleModel>>(fileString);

            if (intakeDataList != null && intakeDataList.Any())
            {
                await SaveExamples(intakeDataList);
                return;
            }

            // If not an Array, Parse to a single Example Model
            ExampleModel? intakeData = JsonSerializer.Deserialize<ExampleModel>(fileString);

            if (intakeData != null)
            {
                await SaveExample(intakeData);
            }
            else
            {
                throw new Exception("Invalid json format");
            }
        }

        public async Task<IList<ExampleModel>> GetExampleList()
        {
            return await _databaseContext.ExampleModels.ToListAsync();
        }

        public async Task<ExampleModel> GetExamplel(int id)
        {
            ExampleModel? exampleModel = await _databaseContext.ExampleModels.FirstOrDefaultAsync(j => j.Id == id);
            if (exampleModel == null)
            {
                throw new Exception("Could not find the Example in database");
            }
            return exampleModel;
        }

        public async Task SaveExample(ExampleModel exampleModel)
        {
            _databaseContext.ExampleModels.Add(exampleModel);
            await _databaseContext.SaveChangesAsync();
        }


        public async Task SaveExamples(IEnumerable<ExampleModel> exampleModels)
        {
            await _databaseContext.ExampleModels.AddRangeAsync(exampleModels);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
