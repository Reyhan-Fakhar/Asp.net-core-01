using Microsoft.EntityFrameworkCore;
using Project_02.Application.Convertor;
using Project_02.Application.Helper;
using Project_02.Domain.Interfaces;
using Project_02.Domain.Models.User;
using Project_02.Domain.ViewModels;
using Project_02.Infrastructure.Data.Context;

namespace Project_02.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;
        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        #region User
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<UserResultViewModel>> GetAllUsers()
        {
            return await _context.Users.Select(user => new UserResultViewModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserRole = user.Role.RoleName,
                PhoneNumber = user.PhoneNumber, 
                IsActive = user.IsActive,
                CreateDate = user.InsertTime.ToShamsi(),
            }).ToListAsync();
        }
        public async Task<User> GetUserById(long userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        //public async Task<List< UserResultViewModel>> GetData()
        //{
        //    return await _context.Users.Select(x=> new UserResultViewModel()
        //    {
        //        UserName = x.UserName,
        //        UserRole = x.Role.RoleName,
        //        PhoneNumber = x.PhoneNumber,
        //        CreateDate = x.InsertTime.ToShamsi(),
        //        IsActive = x.IsActive,
        //    }).ToListAsync();


        //    //try
        //    //{
        //    //    var searchBy = dtParameters.Search?.Value;

        //    //    var result = _context.Users
        //    //        .Include(r => r.Role)
        //    //        .AsQueryable();

        //    //    var column = dtParameters.Columns[dtParameters.Order[0].Column].Data;
        //    //    var sort = dtParameters.Order[0].Dir.ConvertDtOrderDirToSort();

        //    //    switch (column)
        //    //    {
        //    //        case "userName":
        //    //            result = sort == Sort.OrderBy ? result.OrderBy(u => u.UserName) : result.OrderByDescending(u => u.UserName);
        //    //            break;

        //    //        case "roleName":
        //    //            result = sort == Sort.OrderBy ? result.OrderBy(u => u.Role.RoleName) : result.OrderByDescending(u => u.Role.RoleName);
        //    //            break;

        //    //        case "phoneNumber":
        //    //            result = sort == Sort.OrderBy ? result.OrderBy(u => u.PhoneNumber) : result.OrderByDescending(u => u.PhoneNumber);
        //    //            break;

        //    //        default:
        //    //            result = sort == Sort.OrderBy ? result.OrderBy(u => u.UserId) : result.OrderByDescending(u => u.UserId);
        //    //            break;
        //    //    }

        //    //    if (!string.IsNullOrEmpty(searchBy))
        //    //    {
        //    //        result = result.Where(x =>
        //    //            x.UserName.Contains(searchBy) ||
        //    //            x.Role.RoleName.Contains(searchBy) ||
        //    //            x.PhoneNumber.Contains(searchBy));
        //    //    }

        //    //    var filteredResultsCount = await result.CountAsync();
        //    //    var totalResultsCount = await _context.Users.CountAsync();

        //    //    var finalResult = new DtResult<UserResultViewModel>
        //    //    {
        //    //        Draw = dtParameters.Draw,
        //    //        RecordsTotal = totalResultsCount,
        //    //        RecordsFiltered = filteredResultsCount,
        //    //        Data = await result
        //    //            .Skip(dtParameters.Start)
        //    //            .Take(dtParameters.Length)
        //    //            .Select(x => new UserResultViewModel()
        //    //            {
        //    //                UserName = x.UserName,
        //    //                UserRole = x.Role.RoleName,
        //    //                PhoneNumber = x.PhoneNumber,
        //    //                CreateDate = x.InsertTime.ToShamsi(),
        //    //                IsActive = x.IsActive,
        //    //            })

        //    //            .ToListAsync()
        //    //    };

        //    //    return finalResult;
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    Console.WriteLine(e.Message);
        //    //    throw;
        //    //}
        //}
        #endregion
    }
}
