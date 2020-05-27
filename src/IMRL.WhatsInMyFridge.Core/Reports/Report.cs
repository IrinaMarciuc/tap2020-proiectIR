using System;
using System.Collections.Generic;
using System.Text;

namespace IMRL.WhatsInMyFridge.Core.Reports
{
    public class Report
    {
        public Guid RecipeId { get; set; }
        public string ReportDescription { get; set; }

        public Report(Guid RecipeId, string ReportDescription)
        {
            this.RecipeId = RecipeId;
            this.ReportDescription = ReportDescription;
        }
    }
}
