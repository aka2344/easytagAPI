using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RoomApi.Models;
using RoomApi.Repository;

namespace RoomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly RoomRepository roomRepository;
        private readonly EquipmentRepository equipmentRepository;
        private readonly BuildingRepository buildingRepository;
        private readonly AccountRepository accountRepository;
        private readonly ComplaintRepository complaintRepository;
        private readonly DepartmentRepository departmentRepository;
        private readonly MaintenanceRepository maintenanceRepository;
        private readonly SurveyRepository surveyRepository;
        private readonly HistoryRepository historyRepository;

        public RoomController(IConfiguration configuration)
        {
            roomRepository = new RoomRepository(configuration);
            equipmentRepository = new EquipmentRepository(configuration);
            buildingRepository = new BuildingRepository(configuration);
            accountRepository = new AccountRepository(configuration);
            complaintRepository = new ComplaintRepository(configuration);
            departmentRepository = new DepartmentRepository(configuration);
            maintenanceRepository = new MaintenanceRepository(configuration);
            surveyRepository = new SurveyRepository(configuration);
            historyRepository = new HistoryRepository(configuration);
        }

        [HttpGet("room")]
        public IActionResult GetAllRoom()
        {
            return new OkObjectResult(roomRepository.FindAll());
        }

        [HttpGet("room/{id}")]
        public IActionResult GetOneEquipment(int id)
        {
            return new OkObjectResult(equipmentRepository.FindByID(id));
        }

        [HttpPost("room_delete")]
        public void DeleteRoom(Room item)
        {
            roomRepository.Remove(item);
        }

        [HttpPost("room_add")]
        public void AddRoom(Room item)
        {
            roomRepository.Add(item);
        }

        [HttpPost("room_update")]
        public void UpdateRoom(Condtion condt)
        {
            roomRepository.Update(condt);
        }

        [HttpPost("room_condt")]
        public IActionResult GetRoomByCondt(Condtion condt)
        {
            return new OkObjectResult(roomRepository.FindByCond(condt));
        }

        [HttpGet("equipment")]
        public IActionResult GetAllEquipment()
        {
            return new OkObjectResult(equipmentRepository.FindAll());
        }

        [HttpGet("equipment/{id}")]
        public IActionResult GetOneEquipment(double id)
        {
            return new OkObjectResult(equipmentRepository.FindByID(id));
        }

        [HttpPost("equipment_add")]
        public void AddEquipment(Equipment item)
        {
            equipmentRepository.Add(item);
        }

        [HttpPost("equipment_delete")]
        public void ReomveEquipment(Equipment item)
        {
            equipmentRepository.Remove(item);
        }

        [HttpPost("equipment_update")]
        public void UpdateEquipment(Condtion condt)
        {
            equipmentRepository.Update(condt);
        }

        [HttpPost("equipment_condt")]
        public IActionResult GetEquipByCondt(Condtion condt)
        {
            return new OkObjectResult(equipmentRepository.FindByCond(condt));
        }

        [HttpGet("building")]
        public IActionResult GetAllBuilding()
        {
            return new OkObjectResult(buildingRepository.FindAll());
        }

        [HttpGet("building/{id}")]
        public IActionResult GetOneBuilding(int id)
        {
            return new OkObjectResult(buildingRepository.FindByID(id));
        }

        [HttpPost("building_add")]
        public void AddBuilding(Building item)
        {
            buildingRepository.Add(item);
        }

        [HttpPost("building_delete")]
        public void RemoveBuilding(Building item)
        {
            buildingRepository.Remove(item);
        }

        [HttpPost("building_update")]
        public void UpdateBuilding(Condtion condt)
        {
            buildingRepository.Update(condt);
        }

        [HttpPost("building_condt")]
        public IActionResult GetBuildingByCondt(Condtion condt)
        {
            return new OkObjectResult(buildingRepository.FindByCond(condt));
        }

        [HttpGet("account")]
        public IActionResult GetAllAccount()
        {
            return new OkObjectResult(accountRepository.FindAll());
        }

        [HttpGet("account/{id}")]
        public IActionResult GetOneAccount(string id)
        {
            return new OkObjectResult(accountRepository.FindByID(id));
        }

        [HttpPost("account_add")]
        public void AddAccount(Account item)
        {
            accountRepository.Add(item);
        }

        [HttpPost("account_delete")]
        public void DeleteAccount(Account item)
        {
            accountRepository.Remove(item);
        }

        [HttpPost("account_update")]
        public void UpdateAccount(Condtion condt)
        {
            accountRepository.Update(condt);
        }

        [HttpPost("account_condt")]
        public IActionResult GetAccountByCondt(Condtion condt)
        {
            return new OkObjectResult(accountRepository.FindByCond(condt));
        }

        [HttpGet("complaint")]
        public IActionResult GetAllComplaint()
        {
            return new OkObjectResult(complaintRepository.FindAll());
        }

        [HttpGet("complaint/{id}")]
        public IActionResult GetOneComplaint(int id)
        {
            return new OkObjectResult(complaintRepository.FindByID(id));
        }

        [HttpPost("complaint_add")]
        public void AddComplaint(Complaint item)
        {
            complaintRepository.Add(item);
        }

        [HttpPost("complaint_delete")]
        public void DeleteComplaint(Complaint item)
        {
            complaintRepository.Remove(item);
        }

        [HttpPost("complaint_update")]
        public void UpdateComplaint(Condtion condt)
        {
            complaintRepository.Update(condt);
        }

        [HttpPost("complaint_condt")]
        public IActionResult GetComplaintByCondt(Condtion condt)
        {
            return new OkObjectResult(complaintRepository.FindByCond(condt));
        }

        [HttpGet("department")]
        public IActionResult GetAllDepartment()
        {
            return new OkObjectResult(departmentRepository.FindAll());
        }

        [HttpGet("department/{id}")]
        public IActionResult GetOneDepartment(int id)
        {
            return new OkObjectResult(departmentRepository.FindByID(id));
        }

        [HttpPost("department_add")]
        public void AddDepartment(Department item)
        {
            departmentRepository.Add(item);
        }

        [HttpPost("department_delete")]
        public void DeleteDepartment(Department item)
        {
            departmentRepository.Remove(item);
        }

        [HttpPost("department_update")]
        public void UpdateDepartment(Condtion condt)
        {
            departmentRepository.Update(condt);
        }

        [HttpPost("department_condt")]
        public IActionResult GetDepartmentByCondt(Condtion condt)
        {
            return new OkObjectResult(departmentRepository.FindByCond(condt));
        }

        [HttpGet("maintenance")]
        public IActionResult GetAllMaintence()
        {
            return new OkObjectResult(maintenanceRepository.FindAll());
        }

        [HttpGet("maintenance/{id}")]
        public IActionResult GetOneMaintenance(int id)
        {
            return new OkObjectResult(maintenanceRepository.FindByID(id));
        }

        [HttpPost("maintenance_add")]
        public void AddMaintenance(Maintenance item)
        {
            maintenanceRepository.Add(item);
        }

        [HttpPost("maintenance_delete")]
        public void DeleteMaintenance(Maintenance item)
        {
            maintenanceRepository.Remove(item);
        }

        [HttpPost("maintenance_update")]
        public void UpdateMaintenance(Condtion condt)
        {
            maintenanceRepository.Update(condt);
        }

        [HttpPost("maintenance_condt")]
        public IActionResult GetMaintenanceByCondt(Condtion condt)
        {
            return new OkObjectResult(maintenanceRepository.FindByCond(condt));
        }

        [HttpGet("survey")]
        public IActionResult GetAllSurvey()
        {
            return new OkObjectResult(surveyRepository.FindAll());
        }

        [HttpGet("survey/{id}")]
        public IActionResult GetOneSurvey(int id)
        {
            return new OkObjectResult(surveyRepository.FindByID(id));
        }

        [HttpPost("survey_add")]
        public void AddSurvey(Survey item)
        {
            surveyRepository.Add(item);
        }

        [HttpPost("survey_delete")]
        public void DeleteSurvey(Survey item)
        {
            surveyRepository.Remove(item);
        }

        [HttpPost("survey_update")]
        public void UpdateSurvey(Condtion condt)
        {
            surveyRepository.Update(condt);
        }

        [HttpPost("survey_condt")]
        public IActionResult GetSurveyByCondt(Condtion condt)
        {
            return new OkObjectResult(surveyRepository.FindByCond(condt));
        }

        [HttpGet("history")]
        public IActionResult GetAllHistory()
        {
            return new OkObjectResult(historyRepository.FindAll());
        }

        [HttpPost("history_condt")]
        public IActionResult GetHistoryByCondt(Condtion condt)
        {
            return new OkObjectResult(historyRepository.FindByCond(condt));
        }

    }
}
