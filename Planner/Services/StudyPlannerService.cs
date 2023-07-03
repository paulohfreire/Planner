using Planner.Model;

namespace Planner.Services
{
    public class StudyPlannerService : IStudyPlannerService
    {
        private List<Subject> subjects = new List<Subject>();

        public Task AddSubject(Subject subject)
        {
            subjects.Add(subject);
            return Task.CompletedTask;
        }

        public Task<Dictionary<string, int>> GetStudyPlan()
        {
            int totalStudyTime = 0;
            foreach (Subject subject in subjects)
            {
                totalStudyTime += subject.StudyTime;
            }

            Dictionary<string, int> studyPlan = new Dictionary<string, int>();

            foreach (Subject subject in subjects)
            {
                int subjectStudyTime = (int)Math.Round((double)subject.StudyTime / totalStudyTime * subject.HoursPerDay);
                studyPlan.Add(subject.Name, subjectStudyTime);
            }

            return Task.FromResult(studyPlan);
        }
    }
}
