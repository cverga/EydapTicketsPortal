using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EydapTickets.Models
{
    public class MigrationSearchQueryResults
    {
        IEnumerable<MigrationResultsModel> _results;

        [Display(Name = "Κριτήρια")]
        public MigrationSearchCriteria Criteria { get; }

        [Display(Name = "Aποτελέσματα")]
        public IEnumerable<MigrationResultsModel> Results
        {
            get { return _results ?? ( _results = new List<MigrationResultsModel>() ); }
            set { _results = value; }
        }

        public MigrationSearchQueryResults(MigrationSearchCriteria criteria)
        {
            Criteria = criteria;
        }
    }
}
