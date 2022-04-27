using System;

namespace EydapTickets.Models
{
    public class Assignment
    {
        public Assignment()
        {
            // NOOP
        }

        public Assignment(
            Guid id,
            DateTime? dateOfAssignment,
            DateTime? dateOfCompletion,
            string status,
            Guid taskId,
            string comments,
            string backEndTabletId)
        {
            AssignmentId = id;
            DateOfAssignment = dateOfAssignment;
            DateOfCompletion = dateOfCompletion;
            Comments = comments;
            Status = status;
            TaskId = taskId;
            BackEndTabletId = backEndTabletId;
        }

        public Guid AssignmentId { get; set; }

        public DateTime? DateOfAssignment { get; set; }

        public DateTime? DateOfCompletion { get; set; }

        public string Comments { get; set; }

        public string Status { get; set; }

        public string BackEndTabletId { get; set; }

        public Guid TaskId { get; set; }
    }
}