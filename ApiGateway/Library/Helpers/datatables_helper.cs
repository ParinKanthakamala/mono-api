using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Language;
using static ApiGateway.System.helpers.General;

namespace ApiGateway.Library.Helpers
{
    public static class datatables_helper
    {
        public static void data_tables_init(this IHtmlHelper aColumns, int sIndexColumn, string sTable,
            List<string> join = default(List<string>), List<string> where = default(List<string>),
            List<string> additionalSelect = default(List<string>), string sGroupBy = "",
            List<string> searchAs = default(List<string>))
        {
        }

        public static List<string> get_null_columns_that_should_be_sorted_as_last(this object source)
        {
            var columns = new List<string>()
            {
                "projects.deadline",
                "tasks.duedate",
                "contracts.dateend",
                "subscriptions.date_subscribed"
            };
            hooks().ApplyFilters("null_columns_sort_as_last", columns);
            return columns;
        }


        public static dynamic get_datatables_language_array(this object source)
        {
            var lang = new
            {
                emptyTable =
                    preg_replace("/{(d+)}/", label("dt_entries"), label("dt_empty_table")),
                info = preg_replace("/{(d+)}/", label("dt_entries"), label("dt_info")),
                infoEmpty = preg_replace("/{(d+)}/", label("dt_entries"), label("dt_info_empty")),
                infoFiltered = preg_replace("/{(d+)}/", label("dt_entries"),
                    label("dt_info_filtered")),
                lengthMenu = "_MENU_",
                loadingRecords = label("dt_loading_records"),
                processing = "<div class='dt-loader'></div>",
                search =
                    "<div class='input-group'><span class='input-group-addon'><span class='fa fa-search'></span></span>",
                searchPlaceholder = label("dt_search"),
                zeroRecords = label("dt_zero_records"),
                paginate = new
                {
                    first = label("dt_paginate_first"),
                    last = label("dt_paginate_last"),
                    next = label("dt_paginate_next"),
                    previous = label("dt_paginate_previous")
                },
                aria = new
                {
                    sortAscending = label("dt_sort_ascending"),
                    sortDescending = label("dt_sort_descending"),
                }
            };
            return hooks().ApplyFilters("datatables_language_array", lang);
        }

        public static string prepare_dt_filter(this IHtmlHelper source, params string[] filters)
        {
            var filter = string.Join(" ", filters);
            if (filter.StartsWith("AND"))
            {
                filter = filter.Substring(3);
            }
            else if (filter.StartsWith("OR"))
            {
                filter = filter.Substring(2);
            }

            return filter;
        }

        public static string get_table_last_order(this object source, string tableID)
        {
            var code = source.get_staff_meta(source.get_staff_user_id(), tableID + "-table-last-order");
            return HttpUtility.UrlDecode(code.FirstOrDefault()?.MetaValue);
        }
    }
}