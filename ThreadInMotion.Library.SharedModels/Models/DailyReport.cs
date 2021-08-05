using System;

namespace ThreadInMotion.Library.SharedModels.Models
{
    public class DailyReport
    {
        public string BookName { get; set; }
        public string MemberName { get; set; }
        public DateTime ExitDate { get; set; }
        public int TimeSpent { get; set; }
        public int PenaltyGoal { get; set; }
    }
}
