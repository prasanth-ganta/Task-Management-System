using Models;
using System.Text.Json;
using TaskManagement.DataBase.IDataBaseOperations;
namespace TaskManagement.DataBase.DataBaseOperations;
public class DataBaseOperation : IDatabaseOptions
{
    public void SaveToFile(List<RegisterModel> registerList)
    {
        string json = JsonSerializer.Serialize(registerList);
        File.WriteAllText("C://Dotnet_Prac//Assignment26//Database//UserData.json", json);
    }

    public List<RegisterModel> LoadFromFile()
    {
        string json = File.ReadAllText("C://Dotnet_Prac//TaskManagementSystem//TaskManagement.Database//UserData.json");
        List<RegisterModel> registerList = JsonSerializer.Deserialize<List<RegisterModel>>(json);
        return registerList;
    }

    public bool SaveAllTasks(String userName, List<TaskDetails> listOfTasks)
    {
        if (!UserExists(userName))
        {
            return false;
        }
        if (dataBase.ContainsKey(userName))
        {
            dataBase[userName] = listOfTasks;
        }
        else
        {
            dataBase.Add(userName, listOfTasks);
        }

        string json = JsonSerializer.Serialize(dataBase);
        File.WriteAllText("C://Dotnet_Prac//TaskManagementSystem//TaskManagement.Database//UserTasks.json", json);
        return true;
    }

    public bool LoadAllTasks(Dictionary<String, List<TaskDetails>> dataBase)
    {
        string json = File.ReadAllText("C://Dotnet_Prac//TaskManagementSystem//TaskManagement.Database//UserTasks.json");
        dataBase = JsonSerializer.Deserialize<Dictionary<String, List<TaskDetails>>>(json);
        return true;
    }

    private bool UserExists(String userName)
    {
        List<RegisterModel> registerList = LoadFromFile();
        foreach (RegisterModel user in registerList)
        {
            if (user.Username.Equals(userName)) return true;
        }
        return false;
    }

    private Dictionary<String, List<TaskDetails>> dataBase = new Dictionary<string, List<TaskDetails>>();
}