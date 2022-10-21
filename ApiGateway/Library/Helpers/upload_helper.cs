using System.Collections.Generic;
using System.IO;
using ApiGateway.Core;
using ApiGateway.Entities;

namespace ApiGateway.Library.Helpers
{
    public static class upload_helper
    {
        public static bool _perfex_upload_error(this object source, int error)
        {
            var uploadErrors = new List<string>()
            {
                // label("file_uploaded_success"),
                // label("file_exceeds_max_filesize"),
                // label("file_exceeds_maxfile_size_in_form"),
                // label("file_uploaded_partially"),
                // label("file_not_uploaded"),
                // label("file_missing_temporary_folder"),
                // label("file_failed_to_write_to_disk"),
                // label("file_php_extension_blocked")
            };

            return false;
        }

        public static void handle_newsfeed_post_attachments(this object source, int post_id)
        {
        }

        public static bool handle_project_file_uploads(this object source, int projectId)
        {
            return false;
        }

        public static bool handle_contract_attachment(this object source, int id)
        {
            return false;
        }

        public static bool handle_lead_attachments(this object source, int leadId, string indexName = "file",
            bool formActivity = false)
        {
            return false;
        }

        public static List<Files> handle_task_attachments_array(this object source, int taskid,
            string index_name = "attachments")
        {
            return default(List<Files>);
        }

        public static void handle_sales_attachments(this object source, string rel_id, string rel_type)
        {
        }

        public static void handle_client_attachments_upload(this object source, int id, bool customer_upload = false)
        {
            var path = source.get_upload_path_by_type("customer") + id + "/";
        }

        public static void handle_expense_attachments(this object source, int id)
        {
            var path = source.get_upload_path_by_type("expense") + id + "/";
        }

        public static bool handle_ticket_attachments(this object source, int ticketid,
            string index_name = "attachments")
        {
            return false;
        }

        public static bool handle_company_logo_upload(this object source)
        {
            var logoIndex = new List<string>() {"logo", "logo_dark"};
            var success = false;

            return success;
        }

        public static bool handle_company_signature_upload(this object source)
        {
            return false;
        }

        public static bool handle_favicon_upload(this object source)
        {
            return false;
        }

        public static bool handle_staff_profile_image_upload(this object source, int staff_id = 0)
        {
            return false;
        }

        public static void handle_contact_profile_image_upload(this object source, int ntact_id = 0)
        {
        }

        public static void handle_project_discussion_comment_attachments(this object source, int discussion_id,
            object post_data, object insert_data)
        {
        }

        public static void create_img_thumb(this object source, string path, string filename, int width = 300,
            int height = 300)
        {
        }

        public static bool _upload_extension_allowed(this object source, string filename)
        {
            return true;
        }

        public static void _file_attachments_index_fix(this object source, string index_name)
        {
        }

        public static void _maybe_create_upload_path(this object source, string path)
        {
            if (!File.Exists(path))
            {
            }
        }

        public static string get_upload_path_by_type(this object source, string type)
        {
            var path = "";
            switch (type)
            {
                case "lead":
                    path = Constants.LEAD_ATTACHMENTS_FOLDER;

                    break;
                case "expense":
                    path = Constants.EXPENSE_ATTACHMENTS_FOLDER;

                    break;
                case "project":
                    path = Constants.PROJECT_ATTACHMENTS_FOLDER;

                    break;
                case "proposal":
                    path = Constants.PROPOSAL_ATTACHMENTS_FOLDER;

                    break;
                case "estimate":
                    path = Constants.ESTIMATE_ATTACHMENTS_FOLDER;

                    break;
                case "invoice":
                    path = Constants.INVOICE_ATTACHMENTS_FOLDER;

                    break;
                case "credit_note":
                    path = Constants.CREDIT_NOTES_ATTACHMENTS_FOLDER;

                    break;
                case "task":
                    path = Constants.TASKS_ATTACHMENTS_FOLDER;

                    break;
                case "contract":
                    path = Constants.CONTRACTS_UPLOADS_FOLDER;

                    break;
                case "customer":
                    path = Constants.CLIENT_ATTACHMENTS_FOLDER;

                    break;
                case "staff":
                    path = Constants.STAFF_PROFILE_IMAGES_FOLDER;

                    break;
                case "company":
                    path = Constants.COMPANY_FILES_FOLDER;

                    break;
                case "ticket":
                    path = Constants.TICKET_ATTACHMENTS_FOLDER;

                    break;
                case "contact_profile_images":
                    path = Constants.CONTACT_PROFILE_IMAGES_FOLDER;

                    break;
                case "newsfeed":
                    path = Constants.NEWSFEED_FOLDER;

                    break;
            }

            // hooks().ApplyFilters("get_upload_path_by_type", new {path = path, type = type});
            return path;
        }
    }
}