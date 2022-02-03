using System;
using System.Collections.Generic;
using Web.Client.Areas.Admin.Core;

namespace Web.Client.Areas.Admin.Components.Utilities
{
    public class BulkPdfExporterRazor : AdminComponentBase
    {
        public List<dynamic> credit_notes_statuses = new();
        public List<dynamic> estimate_statuses = new();
        public List<dynamic> invoice_statuses = new();
        public List<int> proposal_statuses = new();

        public override void OnUpdate()
        {

        }

        protected override void OnInitialized()
        {

        }
    }
}