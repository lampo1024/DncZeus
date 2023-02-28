using DncZeus.Api.Utils;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace DncZeus.Api.Extensions
{
    public static class QuartzExtension
    {
        /// <summary>
        /// 每天定期重置示例数据
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRestoreScheduler(this IServiceCollection services)
        {
            if (!ConfigurationManager.AppSettings.IsTrialVersion) return services;
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                var jobKey = new JobKey("ResetDatabase");
                q.AddJob<ResetDatabase>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                        .ForJob(jobKey)
                        .WithIdentity("ResetDatabase-trigger")
                        .WithCronSchedule("0 2 0 ? * *") //0 2 0 ? * *,0 2 * * *,0 * * ? * *
                );
            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            return services;
        }
    }
}
