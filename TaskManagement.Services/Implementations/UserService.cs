using TaskManagement.Utilities.Models;
using System.Text.Json;
using TaskManagement.DataBase.IDataBaseOperations;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.Services.Implementations;
public class UserService : IUserService
{
    private readonly IDatabaseOptions _dataBaseOperations;

    public UserService(IDatabaseOptions dataBaseOperations)
    {
        _dataBaseOperations = dataBaseOperations;
    }

    public bool CreateUser(RegisterModel userDetails)
    {
        List<RegisterModel> registerList = _dataBaseOperations.LoadFromFile();
        if (registerList.Any(u => u.Username == userDetails.Username || u.Email == userDetails.Email))
        {
            return true;
        }

        registerList.Add(userDetails);
        _dataBaseOperations.SaveToFile(registerList);
        return false;
    }

    public bool LoginUser(LoginModel loginDetails)
    {
        List<RegisterModel> registerList = _dataBaseOperations.LoadFromFile();
        RegisterModel? user = registerList.FirstOrDefault(u => u.Username == loginDetails.Username && u.Password == loginDetails.Password);

        if (user != null)
        {
            return true;
        }
        return false;
    }

    public bool UserExists(String userName)
    {
        List<RegisterModel> registerList = _dataBaseOperations.LoadFromFile();
        foreach (RegisterModel user in registerList)
        {
            if (user.Username.Equals(userName)) return true;
        }
        return false;
    }

    public bool SaveAllTasks(String userName, List<TaskDetails> listOfTasks)
    {
        return _dataBaseOperations.SaveAllTasks(userName, listOfTasks);
    }

    public bool LoadAllTasks(Dictionary<String, List<TaskDetails>> dataBase)
    {
        return _dataBaseOperations.LoadAllTasks(dataBase);
    }
}