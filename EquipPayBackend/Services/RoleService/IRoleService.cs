using EquipPayBackend.DTOs.RoleDTO;
using EquipPayBackend.Models;

namespace EquipPayBackend.Services.RoleService
{
    public interface IRoleService
    {
        Task<Role> AddRole(AddRoleDTO roleDTO);
        Task<Role> DeleteRole(string roleName);
        Task<List<Role>> GetRoles();
        Task<Role> UpdateRole(UpdateRoleDTO roleDTO);
    }
}