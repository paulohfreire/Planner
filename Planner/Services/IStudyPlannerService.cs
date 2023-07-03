using Planner.Model;

namespace Planner.Services
{
    public interface IStudyPlannerService
    {
        Task AddSubject(Subject subject);
        Task<Dictionary<string, int>> GetStudyPlan();
    }
}
