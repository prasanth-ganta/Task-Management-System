using TaskManagement.Utilities.Models;
namespace TaskManagement.Services.Interfaces;
public interface ITaskService
{
    List<TaskDetails> GetTaskList();
    void CreateTask(TaskDetails task);
    void UpdateTaskStatus(int ID,String status);
    void UpdateTaskPriority(int ID,String task);
    bool DeleteTask(int id);
    List<TaskDetails> ShowAllTasks();
    bool UpdateDate(int ID,DateTime dateTime);

}




