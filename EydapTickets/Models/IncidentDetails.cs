using System;
using System.ComponentModel.DataAnnotations;

namespace EydapTickets.Models
{
    public class IncidentDetails
    {
        public IncidentDetails(
            Guid id,
            string ticketTraceId,
            string customerServiceId,
            DateTime? announcementDate,
            DateTime? announcementTime,
            string callerFullName,
            string callerPhone,
            string problemType,
            string am,
            string counterNumber,
            string billingNumber,
            string cause,
            string comments,
            string correlatedIncident,
            int status)
        {
            Id = id;
            TicketTraceId = ticketTraceId;
            CustomerServiceId = customerServiceId;
            AnnouncementDate = announcementDate;
            AnnouncementTime = announcementTime;
            CallerFullName = callerFullName;
            CallerPhone = callerPhone;
            ProblemType = problemType;
            AM = am;
            CounterNumber = counterNumber;
            BillNumber = billingNumber;
            Cause = cause;
            Comments = comments;
            CorrelatedIncident = correlatedIncident;
            Status = status;
        }

        [Display(Name = "Κλειδί")]
        public Guid Id { get; set; }

        [Display(Name = "Ticket Trace Id")]
        public string TicketTraceId { get; set; }

        [Display(Name = "Κωδικός 1022")]
        public string CustomerServiceId { get; set; }

        [Display(Name = "Ημερομηνία Αναφοράς")]
        public DateTime? AnnouncementDate { get; set; }

        [Display(Name = "Ώρα Αναφοράς")]
        public DateTime? AnnouncementTime { get; set; }

        [Display(Name = "Όνοματεπώνυμο Καλούντος")]
        public string CallerFullName { get; set; }

        [Display(Name = "Τηλέφωνο Επικοινωνίας")]
        public string CallerPhone { get; set; }

        [Display(Name = "Αριθμός Μητρώου")]
        public string AM { get; set; }

        [Display(Name = "Αριθμός Μετρητή")]
        public string CounterNumber { get; set; }

        [Display(Name = "Αριθμός Λογαριασμού")]
        public string BillNumber { get; set; }

        [Display(Name = "Πρόβλημα")]
        public string Cause { get; set; }

        [Display(Name = "Είδος Προβλήματος")]
        public string ProblemType { get; set; }

        [Display(Name = "Σχόλια")]
        public string Comments { get; set; }

        [Display(Name = "Κωδικός Σχετιζόμενου")]
        public string CorrelatedIncident { get; set; }

        [Display(Name = "Κατάσταση")]
        public int Status { get; set; }
    }
}