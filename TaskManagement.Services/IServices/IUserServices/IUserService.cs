using Models;
namespace TaskManagement.Services.IServices;

public interface IUserService
{
    
    bool CreateUser(RegisterModel userDetails);
    bool LoginUser(LoginModel loginDetails);
    bool SaveAllTasks(String userName,List<TaskDetails>listOfTasks);
    bool LoadAllTasks(Dictionary<String,List<TaskDetails>>dataBase);
    bool UserExists(String userName);
    
}