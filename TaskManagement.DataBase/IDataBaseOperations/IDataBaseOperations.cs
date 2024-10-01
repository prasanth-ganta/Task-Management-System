
using Models;
namespace TaskManagement.DataBase.IDataBaseOperations;
public interface IDatabaseOptions
{
    void SaveToFile(List<RegisterModel> registerList);
    List<RegisterModel> LoadFromFile();
    bool SaveAllTasks(String userName, List<TaskDetails> listOfTasks);
    bool LoadAllTasks(Dictionary<String, List<TaskDetails>> dataBase);
}