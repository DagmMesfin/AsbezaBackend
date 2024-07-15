using EquipPayBackend.Context;
using LinqToDB;
using EquipPayBackend.Services.Tools;
using AutoMapper;
using EquipPayBackend.Models;
using EquipPayBackend.DTOs.UserDTO;
namespace EquipPayBackend.Services.UserService

{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public UserService(ApplicationDbContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }
        public async Task<UserInfo> AddEmployee(AddUserDTO userDTO)
        {
            //var employee = _mapper.Map<Employee>(employeeDTO);


            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleName == userDTO.RoleName);

            if (role == null)
            {
                // Handle the case where the role does not exist
                throw new ApplicationException($"Role '{employeeDTO.RoleName}' not found.");
            }


            var userAccount = new UserAccount
            {
                UserName = employeeDTO.UserName,
                Role = role
            };
            _toolsService.CreatePasswordHash(employeeDTO.Password, out byte[] PH, out byte[] PS);
            userAccount.PasswordHash = PH;
            userAccount.PasswordSalt = PS;

            var employee = new Employee
            {
                EmployeeName = employeeDTO.EmployeeName,
                Email = employeeDTO.Email,
                Phone = employeeDTO.Phone,
                DateOfBirth = employeeDTO.DateOfBirth,
                EmployeeGender = employeeDTO.EmployeeGender,
                IsCurrentlyActive = employeeDTO.IsCurrentlyActive,
                CreatedAt = employeeDTO.CreatedAt,
            };
            employee.UserAccount = userAccount;
            await _context.Employees.AddAsync(employee);



            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
