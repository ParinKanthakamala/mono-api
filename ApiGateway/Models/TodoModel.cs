using ApiGateway.Library.Helpers;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class TodoModel : MyModel
    {
        private int _todo_limit = 0;

        public int todo_limit
        {
            get
            {
                this._todo_limit = 20;
                hooks().ApplyFilters("todos_limit", this._todo_limit);
                return this._todo_limit;
            }
            set => _todo_limit = value;
        }

        public void SetTodosLimit(int limit)
        {
            this.todo_limit = limit;
        }

        public int GetTodosLimit()
        {
            return this.todo_limit;
        }

        public List<Todos> Get(int id = 0)
        {
            return null;
        }

        public List<Todos> GetTodoItems(bool finished, int page = 0)
        {
            var todos = new List<Todos>();
            using (var db = new DBContext())
            {
                todos = db.Todos.Where(
                        table =>
                            table.Finished == finished
                            && table.UserId == this.get_staff_user_id()
                    )
                    .OrderBy(table => table.ItemOrder)
                    .Skip((page > 0) ? (page * this.todo_limit) : 0)
                    .Take(this.todo_limit)
                    .ToList();
            }

            todos.ForEach((todo) => { });
            return todos;
        }

        public int Add(Todos data)
        {
            return 0;
        }

        public bool Update(int id, dynamic data)
        {
            return false;
        }

        public void UpdateTodoItemsOrder(dynamic data)
        {
        }

        public bool DeleteTodoItem(int id)
        {
            return false;
        }

        public dynamic ChangeTodoStatus(int id, int status)
        {
            return false;
        }
    }

    public static class TodoModelExtenasion
    {
        private static TodoModel _instance = null;

        public static TodoModel todo_model(this object source)
        {
            return _instance ??= new TodoModel();
        }
    }
}