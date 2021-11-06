using Microsoft.AspNetCore.Mvc;
using SafeboardKernel.ScanFacade;
using SafeboardWebApi.Services.Scanner;
using SafeboardWebApi.Services.TasksRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeboardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanController : ControllerBase
    {
        private readonly IScanner _scanner;
        private readonly ITaskRepository _taskRepository;

        public ScanController(IScanner scanner, ITaskRepository taskRepository)
        {
            _scanner = scanner;
            _taskRepository = taskRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            bool isCompleted;
            try
            {
                isCompleted = _taskRepository.IsCompleted(id);
            }
            catch(KeyNotFoundException)
            {
                return BadRequest("Task with this id is not exist");
            }

            if (isCompleted)
                return Ok(_taskRepository.GetResult(id));
            else
                return BadRequest("Scan task in progress, please wait");

        }

        [HttpPost]
        public IActionResult Post(string directoryPath)
        {
            Task<string[]> scanTask = new Task<string[]>(() => _scanner.Scan(directoryPath));

            _taskRepository.Add(scanTask);

            scanTask.Start();

            return Ok($"Scan task was created with ID: {scanTask.Id}");
        }
    }
}
