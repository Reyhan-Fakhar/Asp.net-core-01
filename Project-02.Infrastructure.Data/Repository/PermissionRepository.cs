using Microsoft.EntityFrameworkCore;
using Project_02.Application.Convertor;
using Project_02.Application.Helper;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.Permissions;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;
using Project_02.Infrastructure.Data.Context;

namespace Project_02.Infrastructure.Data.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DataBaseContext _context;

        public PermissionRepository(DataBaseContext context)
        {
            _context = context;
        }

        #region Role
        public async Task<long> AddRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync(); 
            return role.RoleId; 
        }
        public async Task UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
        public async Task<List<RoleResultViewModel>> GetAllRoles()
        {
            return await _context.Roles
                .Select(role => new RoleResultViewModel
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    CreateDate = role.InsertTime.ToShamsi(), 
                })
                .ToListAsync();
        }
        public async Task<Role> GetRoleById(long roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }
        public async Task<DtResult<RoleResultViewModel>> GetData(DtParameters dtParameters)
        {
            try
            {
                var searchBy = dtParameters.Search?.Value;

                var result = _context.Roles
                    .Include(r => r.Permissions)
                    .AsQueryable();

                var column = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                var sort = dtParameters.Order[0].Dir.ConvertDtOrderDirToSort();

                switch (column)
                {
                    case "roleName":
                        result = sort == Sort.OrderBy ? result.OrderBy(r => r.RoleName) : result.OrderByDescending(r => r.RoleName);
                        break;

                    default:
                        result = sort == Sort.OrderBy ? result.OrderBy(r => r.RoleId) : result.OrderByDescending(r => r.RoleId);
                        break;
                }

                if (!string.IsNullOrEmpty(searchBy))
                {
                    result = result.Where(x =>
                        x.RoleName.Contains(searchBy));
                }

                var filteredResultsCount = await result.CountAsync();
                var totalResultsCount = await _context.Roles.CountAsync();

                var finalResult = new DtResult<RoleResultViewModel>
                {
                    Draw = dtParameters.Draw,
                    RecordsTotal = totalResultsCount,
                    RecordsFiltered = filteredResultsCount,
                    Data = await result
                        .Skip(dtParameters.Start)
                        .Take(dtParameters.Length)
                        .Select(x => new RoleResultViewModel()
                        {
                            RoleName = x.RoleName,
                            CreateDate = x.InsertTime.ToShamsi()
                        }).ToListAsync()
                };

                return finalResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public bool IsExistRoleName(string roleName)
        {
            return _context.Roles.Any(r => r.RoleName == roleName);
        }
        #endregion

        #region Permission
        public async Task AddPermissionToRole(long permissionId, long roleId)
        {
            var rolePermission = new RolePermission
            {
                PermissionId = permissionId,
                RoleId = roleId,
            };
            await _context.RolePermission.AddAsync(rolePermission);

            var role = await GetRoleById(roleId);
            role.UpdateTime = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePermissionFromRole(long roleId)
        {
            var rolePermission = await _context.RolePermission.Where(r => r.RoleId == roleId).ToListAsync();
            _context.RolePermission.RemoveRange(rolePermission);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Permission>> GetAllPermission()
        {
            return await _context.Permission.ToListAsync();
        }

        public async Task<List<long>> GetAllRolePermissions(long roleId)
        {
            return await _context.RolePermission
                .Where(r => r.RoleId == roleId)
                .Select(p => p.PermissionId)
                .ToListAsync();
        }
        #endregion

    }
}
