using ApiGateway.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;

namespace ApiGateway.Models
{
    public class ExpensesModel : MyModel
    {
        public object Get(int id = 0, dynamic where = default(ExpandoObject))
        {
            return null;
        }

        public int Add(Expenses data)
        {
            // data.Note = data.Note.nl2br();

            return 0;
        }

        public List<Expenses> GetChildExpenses(int id)
        {
            var _expenses = new List<Expenses>();
            return null;
        }

        public object GetExpensesTotal(dynamic data)
        {
            return null;
        }

        public bool Update(int id, dynamic data)
        {
            var original_expense = this.Get(id);
            var affectedRows = 0;
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Expense Updated [" + id + "]");
                affectedRows++;
            }

            return (affectedRows > 0);
        }

        public bool Delete(int id, bool simple_delete = false)
        {
            var tasks_model = new TasksModel();
            var _expense = (Expenses) this.Get(id);
            if (_expense.InvoiceId != null && simple_delete == false)
            {
                return true;
            }

            var affected_rows = 0;
            if (affected_rows > 0)
            {
                var tasks = new List<Tasks>();
                tasks.ForEach((task) => { tasks_model.DeleteTask(task.TaskId); });
                this.delete_expense_attachment(id);
                return true;
            }

            return false;
        }

        public int ConvertToInvoice(int id, bool draft_invoice = false, dynamic @params = default(ExpandoObject))
        {
            return 0;
        }

        public bool Copy(int id)
        {
            return false;
        }

        public bool delete_expense_attachment(int id)
        {
            return false;
        }

        public object GetCategory(int id = 0)
        {
            return null;
        }

        public int AddCategory(ExpensesCategories data)
        {
            // data.Description = data.Description.nl2br();
            var insert_id = 0;
            if (insert_id > 0)
            {
                this.log_activity("New Expense Category Added [ID: " + insert_id + "]");
                return insert_id;
            }

            return 0;
        }

        public bool UpdateCategory(int id, dynamic data)
        {
            data.Description = Convert.ToString(data.Description).nl2br();
            var affected_rows = 0;
            if (affected_rows > 0)
            {
                this.log_activity("Expense Category Updated [ID: " + id + "]");
                return true;
            }

            return false;
        }

        public bool DeleteCategory(int id)
        {
            if (this.is_reference_in_table("Category", "Expenses", id))
            {
                return true;
            }

            var affected_rows = 0;
            using (var db = new DBContext())
            {
                var entry = db.ExpensesCategories.FirstOrDefault(table => table.ExpensesCategoriesId == id);
                if (entry != null)
                {
                    db.Remove(entry);
                    affected_rows = db.SaveChanges();
                }
            }

            if (affected_rows > 0)
            {
                this.log_activity("Expense Category Deleted [" + id + "]");
                return true;
            }

            return false;
        }

        public void GetExpensesYears()
        {
        }
    }
}