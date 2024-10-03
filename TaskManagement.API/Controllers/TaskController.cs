using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Routing;
using TaskManagement.Services.Interfaces;
using TaskManagement.Utilities.Models;
 
  [ApiController]
  [Route("api/[controller]/[action]")]
  public class TaskController:ControllerBase{
     
      private readonly ITaskService _taskService ;
      private readonly IUserService _userService;
      
      public TaskController(ITaskService taskService, IUserService userService)
      {
          _taskService = taskService;
          _userService = userService;
      }
      

      [HttpPost]
      public IActionResult CreateTask([FromBody]TaskDetails details)
      {
       _taskService.CreateTask(details);
       return Ok();
      }
      

      [HttpPut]
      public IActionResult UpdateTaskStatus([FromQuery]int ID, [FromQuery] String status) {
      _taskService.UpdateTaskStatus(ID,status);
      return Ok();
       
      }
      
      [HttpPut("{id}/{priority}")]
      public IActionResult UpdateTaskPriority(int ID,String priority) {
      _taskService.UpdateTaskPriority(ID,priority);
      return Ok();
      }
      [HttpDelete]
      public IActionResult DeleteTask(int ID) {
      bool taskPresent=_taskService.DeleteTask(ID);
      if(!taskPresent)return BadRequest(new {message=$"task with ID {ID} is not present"});
 
      return Ok("Task deleted");
      
      }
      [HttpPost]
      public IActionResult UpdateDate(int ID,DateTime dateTime){
        bool dateUpdated=_taskService.UpdateDate(ID,dateTime);
        if(!dateUpdated)return BadRequest(new {message=$"task with ID {ID} is not present or Date should be FutureDate"});
        return Ok("Date updated");
      }

      [HttpGet]
      public IActionResult ShowAllTasks(){
        List<TaskDetails> allTasks= _taskService.ShowAllTasks();
        if(allTasks.Count()==0) return BadRequest( new { message="Task list is Empty" });
        return Ok(allTasks);
      }   

  }

