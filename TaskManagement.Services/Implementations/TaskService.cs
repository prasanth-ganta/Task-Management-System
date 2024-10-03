using TaskManagement.Utilities.Models;
using System.Text.Json;
using TaskManagement.Services.Interfaces;
namespace TaskManagement.Services.Implementations;

public class TaskService : ITaskService
{
    List<TaskDetails>listOfTasks=new List<TaskDetails>();
   // Dictionary<String,List<TaskDetails>>dataBase=new Dictionary<string, List<TaskDetails>>();
    public void CreateTask(TaskDetails details)
    {
     listOfTasks.Add(details);
    }
    public List<TaskDetails> ShowAllTasks(){
        
        return listOfTasks;
    }

    public void UpdateTaskStatus(int ID,String status)
    {
      TaskDetails? taskToUpdate = listOfTasks.FirstOrDefault(t => t.ID == ID);
        if (taskToUpdate != null)
        {
            taskToUpdate.Status = status;
        }else{
        
        }
    }
    public void UpdateTaskPriority(int ID ,string priority)
    {
        TaskDetails? taskToUpdate = listOfTasks.FirstOrDefault(t => t.ID == ID);
        if (taskToUpdate != null)
        {
            taskToUpdate.Priority = priority;
        }else{

        }
    }

    public bool DeleteTask(int ID)
    {
        TaskDetails taskToRemove = listOfTasks.FirstOrDefault(t => t.ID == ID);
        if (taskToRemove != null)
        {
            listOfTasks.Remove(taskToRemove);
            return true;
        }
        return false;
    }

    public List<TaskDetails> GetTaskList(){
        return listOfTasks;
    }
    public bool UpdateDate(int ID,DateTime dateTime){

        TaskDetails taskToUpdateDate = listOfTasks.FirstOrDefault(t => t.ID == ID);
        if (taskToUpdateDate != null)
        {
            taskToUpdateDate.DueDate=dateTime;
            return true;
        }
        return false;
    }

  
}