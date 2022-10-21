using ApiGateway.Library.Helpers;
using ApiGateway.Library.Services.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using ApiGateway.Library;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class ClientsModel : MyModel
    {
        private List<string> contact_columns = new List<string>();

        public List<Clients> Get(int id = 0, dynamic where = default(ExpandoObject))
        {
            if (id > 0)
            {
            }

            return null;
        }

        public List<Contacts> GetContacts(int customer_id = 0, dynamic where = default(ExpandoObject))
        {
            if (where == default(ExpandoObject))
            {
                where.active = 1;
            }

            return null;
        }

        public Contacts GetContact(int? id)
        {
            using (var db = new DBContext())
            {
                return db.Contacts.SingleOrDefault(table => table.UserId == id);
            }
        }

        public int Add(dynamic data, bool client_or_lead_convert_request = false)
        {
            var contact_data = new Dictionary<string, object>();
            var client = new Clients();
            this.contact_columns.ForEach((field) =>
            {
                if (data.ContainsKey(field))
                {
                    contact_data[field] = data[field];
                    if (field != "phonenumber")
                    {
                    }
                }
            });
            if (data.ContainsKey("contact_phonenumber"))
            {
                contact_data["phonenumber"] = data["contact_phonenumber"];
            }

            data = this.CheckZeroColumns(data);
            client.DateCreated = DateTime.Now;
            if (this.is_staff_logged_in())
            {
                client.AddedFrom = this.get_staff_user_id();
            }

            hooks().ApplyFilters("before_client_added", data);
            return 0;
        }

        public bool Update(int id, dynamic data, bool client_request = false)
        {
            using (var db = new DBContext())
            {
            }

            return false;
        }

        public object UpdateContact(Contacts data, bool client_request = false, bool send_set_password_email = false)
        {
            var affectedRows = 0;
            using (var db = new DBContext())
            {
                var clients = this.GetContact(data.ContactId);
                if (string.IsNullOrEmpty(data.Password))
                {
                    data.Password = "";
                }
                else
                {
                    data.Password = PasswordHandler.CreatePasswordHash(data.Password);
                    data.LastPasswordChange = DateTime.Now;
                }

                var set_password_email_sent = false;
                var permissions =
                    new List<Permission>();
                if (client_request)
                {
                    data.IsPrimary = 0;
                }

                if (client_request == false)
                {
                }

                hooks().ApplyFilters("before_update_contact", data);

                var contact = db.Contacts.Find(data.ContactId);
                db.Entry(contact).CurrentValues.SetValues(data);
                var affected_rows = db.SaveChanges();

                if (affected_rows > 0)
                {
                    affectedRows++;
                    if (data.IsPrimary == 1)
                    {
                        var entry =
                            db.Contacts.SingleOrDefault(table => table.ContactId != data.ContactId
                                                                 && table.UserId == contact.UserId);
                        if (entry != null)
                        {
                            db
                                .Entry(entry).CurrentValues
                                .SetValues(new Contacts()
                                {
                                    IsPrimary = 0
                                });
                        }
                    }
                }

                if (client_request == false)
                {
                    var roles_model = new RolesModel();
                    var customer_permissions = roles_model.GetContactPermissions(data.UserId);

                    if (customer_permissions.Count > 0)
                    {
                        foreach (var customer_permission in customer_permissions)
                        {
                            var entry = db.ContactPermissions.SingleOrDefault(
                                table =>
                                    table.UserId == data.UserId
                                    && table.PermissionId == customer_permission.PermissionId);

                            if (entry != null)
                            {
                                db.ContactPermissions.Remove(entry);
                                affected_rows = db.SaveChanges();
                            }

                            if (affected_rows > 0)
                            {
                                affectedRows++;
                            }
                        }

                        foreach (var permission in permissions)
                        {
                            var _exists = db.ContactPermissions.SingleOrDefault(
                                table =>
                                    table.UserId == data.UserId
                                    && table.PermissionId == 0
                            );

                            if (_exists == null)
                            {
                                db.ContactPermissions.Add(new ContactPermissions()
                                {
                                    UserId = data.UserId,
                                    PermissionId = 0
                                });
                                affected_rows = db.SaveChanges();
                                if (affected_rows > 0)
                                {
                                    affectedRows++;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var permission in permissions)
                        {
                            db.ContactPermissions.Add(new ContactPermissions()
                            {
                                UserId = data.UserId,
                                PermissionId = 0
                            });

                            if (affected_rows > 0)
                            {
                                affectedRows++;
                            }
                        }
                    }

                    if (send_set_password_email)
                    {
                        set_password_email_sent = this.authentication_model().SetPasswordEmail(data.Email);
                    }
                }

                if (affectedRows > 0 && !set_password_email_sent)
                {
                    this.log_activity("Contact Updated [ID: " + data.UserId + "]");

                    return true;
                }
                else if (affectedRows > 0 && set_password_email_sent)
                {
                    return true;
                }
                else if (affectedRows == 0 && set_password_email_sent)
                {
                    return true;
                }
            }

            return null;
        }

        public bool AddContact(int customer_id, dynamic data, bool not_manual_request = false)
        {
            return false;
        }

        public bool UpdateCompanyDetails(int id, Clients data)
        {
            return false;
        }

        public List<CustomerAdmins> GetAdmins(int id)
        {
            return null;
        }

        public List<CustomerAdmins> GetCustomersAdminUniqueIds()
        {
            return null;
        }

        public bool AssignAdmins(dynamic data)
        {
            var affectedRows = 0;
            return (affectedRows > 0);
        }

        public bool Delete(int? id)
        {
            return false;
        }

        public bool DeleteContact(int? id)
        {
            hooks().DoAction("before_delete_contact", id);
            return false;
        }

        public int GetCustomerDefaultCurrency(int id)
        {
            return 0;
        }

        public List<Clients> GetCustomerBillingAndShippingDetails(int id)
        {
            return null;
        }

        public List<Files> GetCustomerFiles(int id, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public bool DeleteAttachment(int id)
        {
            var deleted = false;
            return deleted;
        }

        public bool ChangeContactStatus(int id, bool status)
        {
            hooks().ApplyFilters("change_contact_status");
            using (var db = new DBContext())
            {
                var entry = db.Contacts.FirstOrDefault(table => table.ContactId == id);
                db.Entry(entry).CurrentValues.SetValues(new Contacts()
                {
                    Active = status
                });
                var affected_rows = db.SaveChanges();
                this.log_activity("Contact Status Changed [ContactID: " + id + " Status(Active/Inactive): " + status +
                                  "]");
                return (affected_rows > 0);
            }
        }

        public bool ChangeClientStatus(int id, int status)
        {
            return false;
        }

        public bool ChangeContactPassword(int id, string oldPassword, string newPassword)
        {
            return false;
        }

        public CustomerGroups GetCustomerGroups(int id)
        {
            var client_groups_model = new ClientGroupsModel();
            return client_groups_model.GetCustomerGroups(id);
        }

        public List<CustomersGroups> GetGroups(int id = 0)
        {
            return this.client_groups_model().GetGroups(id);
        }

        public bool DeleteGroup(int? id)
        {
            var client_groups_model = new ClientGroupsModel();
            return client_groups_model.Delete(id);
        }

        public int AddGroup(CustomersGroups data)
        {
            using (var db = new DBContext())
            {
                db.Add(data);
                db.SaveChanges();
            }

            var client_groups_model = new ClientGroupsModel();
            return client_groups_model.Add(data);
        }

        public bool EditGroup(CustomersGroups data)
        {
            var client_groups_model = new ClientGroupsModel();
            return client_groups_model.Edit(data);
        }

        public bool VaultEntryCreate(int customer_id, Vault data)
        {
            var client_vault_entries_model = new ClientVaultEntriesModel();
            return (client_vault_entries_model.Create(customer_id, data) > 0);
        }

        public bool VaultEntryUpdate(int id, Vault data)
        {
            var client_vault_entries_model = new ClientVaultEntriesModel();
            return client_vault_entries_model.Update(id, data);
        }

        public bool VaultEntryDelete(int id)
        {
            var client_vault_entries_model = new ClientVaultEntriesModel();
            return client_vault_entries_model.Delete(id);
        }

        public Vault GetVaultEntries(int customer_id,
            dynamic where = default(ExpandoObject))
        {
            var client_vault_entries_model = new ClientVaultEntriesModel();
            return client_vault_entries_model.GetByCustomerId(customer_id, where);
        }

        public Vault GetVaultEntry(int id)
        {
            var client_vault_entries_model = new ClientVaultEntriesModel();
            return client_vault_entries_model.Get(id);
        }

        public List<object> GetStatement(int customer_id, DateTime from, DateTime to)
        {
            var statement_model = new StatementModel();
            return statement_model.GetStatement(customer_id, from, to);
        }

        public bool SendStatementToEmail(int customer_id, string send_to, string from, string to, string cc = "")
        {
            var statement_model = new StatementModel();
            return statement_model.SendStatementToEmail(customer_id, send_to, from, to, cc);
        }

        public bool require_confirmation(int client_id)
        {
            var ContactId = this.get_primary_contact_user_id(client_id);
            return true;
        }

        public bool ConfirmRegistration(int client_id)
        {
            var ContactId = this.get_primary_contact_user_id(client_id);
            var contact = this.GetContact(ContactId);
            if (contact != null)
            {
                return true;
            }

            return false;
        }

        public bool SendVerificationEmail(int id)
        {
            return false;
        }

        public bool MarkEmailAsVerified(int id)
        {
            return false;
        }

        public IList GetClientsDistinctCountries()
        {
            using (var db = new DBContext())
            {
                return db.Clients.Join(
                        db.Countries,
                        clients => clients.Country,
                        countries => countries.CountryId,
                        (clients, countries) => new {clients, countries})
                    .ToList();
            }
        }

        public void SendNotificationCustomerProfileFileUploadedToResponsibleStaff(int ContactId, int customer_id)
        {
        }

        public List<Users> GetStaffMembersThatCanAccessCustomer(int id)
        {
            return null;
        }

        private Clients CheckZeroColumns(Clients data)
        {
            return data;
        }
    }

    public static class ClientModelExtension
    {
        private static ClientsModel _instance = null;

        public static ClientsModel clients_model(this object model)
        {
            return _instance ??= new ClientsModel();
        }
    }
}