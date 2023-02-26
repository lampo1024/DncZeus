using DncZeus.Api.Entities;
using DncZeus.Api.Entities.Enums;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DncZeus.Api.Utils
{
    public class ResetDatabase : IJob
    {
        private DncZeusDbContext _dbContext;

        public ResetDatabase(DncZeusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("开始重置数据...");
            await using (_dbContext)
            {
                _dbContext.DncRolePermissionMapping.RemoveRange(_dbContext.DncRolePermissionMapping.Where(x => x.IsSeed == CommonEnum.YesOrNo.No));
                _dbContext.DncUserRoleMapping.RemoveRange(_dbContext.DncUserRoleMapping.Where(x => x.IsSeed == CommonEnum.YesOrNo.No));
                _dbContext.DncIcon.RemoveRange(_dbContext.DncIcon.Where(x => x.IsSeed == CommonEnum.YesOrNo.No));
                _dbContext.DncMenu.RemoveRange(_dbContext.DncMenu.Where(x => x.IsSeed == CommonEnum.YesOrNo.No));
                _dbContext.DncPermission.RemoveRange(_dbContext.DncPermission.Where(x => x.IsSeed == CommonEnum.YesOrNo.No));
                _dbContext.DncRole.RemoveRange(_dbContext.DncRole.Where(x => x.IsSeed == CommonEnum.YesOrNo.No));
                _dbContext.DncUser.RemoveRange(_dbContext.DncUser.Where(x => x.IsSeed == CommonEnum.YesOrNo.No));
                await _dbContext.SaveChangesAsync();
                Console.WriteLine("数据重置完成...");
            }
        }
    }
}
