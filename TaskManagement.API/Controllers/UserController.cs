using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Routing;
using Models;
using TaskManagement.Services.IServices;
  
  [ApiController]
  [Route("api/[controller]/[action]")]
  public class UserController:ControllerBase{
    
      private readonly ITaskService _taskService ;
      private readonly IUserService _userService;
      
      public UserController(ITaskService taskService, IUserService userService)
      {
          _taskService = taskService;
          _userService = userService;
      }


       [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel userDetails)
        {
            bool alreadyPresent=_userService.CreateUser(userDetails);
            if(alreadyPresent){
                return BadRequest();
            }
            return Ok("user Added");
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel userDetils)
        {
             bool userPresent=_userService.LoginUser(userDetils);
             if(userPresent){
                 return Ok("Success");
             }
             return BadRequest(new {message="User have to register first"});
          
        }


      [HttpGet]
      public IActionResult SaveAllTasks(String userName){
        List<TaskDetails>listOfTasks=_taskService.GetTaskList();
        bool userPresent=_userService.SaveAllTasks(userName,listOfTasks);
        if(!userPresent){
            return BadRequest(new {message="user not registered could not add tasks"});
        }

        return Ok("All Tasks saved");
      }
     

  }

