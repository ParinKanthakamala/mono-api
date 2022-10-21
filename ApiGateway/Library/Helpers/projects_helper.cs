using System.Linq;
using ApiGateway.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiGateway.Library.Helpers
{
    public static class projects_helper
    {
        public static int get_client_id_by_project_id(this object source, int id)
        {
            using (var db = new DBContext())
            {
                var project = db.Projects.FirstOrDefault(table => table.ProjectId == id);

                if (project != null)
                {
                    return project.ClientId;
                }
            }

            return 0;
        }

        public static string get_project_name_by_id(this IHtmlHelper source, int id)
        {
            // var project = (Projects) app_object_cache().get("project-name-data-" + id);
            //
            // if (project == null)
            // {
            //     using (var db = new DBContext())
            //     {
            //         project = db.Projects.FirstOrDefault(table => table.ProjectId == id);
            //         if (project != null)
            //         {
            //             app_object_cache().Add("project-name-data-" + id, project);
            //             return project.Name;
            //         }
            //     }
            // }

            return string.Empty;
        }
    }
}