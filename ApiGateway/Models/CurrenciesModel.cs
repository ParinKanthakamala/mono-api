using ApiGateway.Library.Helpers;
using System.Collections.Generic;
using System.Linq;
using ApiGateway.Core;
using ApiGateway.Entities;
using static ApiGateway.Core.AppObjectCache;

namespace ApiGateway.Models
{
    public class CurrenciesModel : MyModel
    {
        public List<Currencies> Get(int id = 0)
        {
            if (id > 0)
            {
                using (var db = new DBContext())
                {
                    var currency = db.Currencies.Where(table => table.CurrencyId == id).ToList();
                    app_object_cache().set("currency-" + currency.First().Name, currency);
                    return currency;
                }
            }

            var currencies = app_object_cache().get("currencies-data");
            using (var db = new DBContext())
            {
                if (currencies != null)
                {
                    currencies = db.Currencies.ToList();
                    app_object_cache().add("currencies-data", currencies);
                }
            }

            return (List<Currencies>) currencies;
        }

        public List<Currencies> GetByName(string name)
        {
            var currency = app_object_cache().get("currency-" + name);
            if (currency != null)
            {
                using (var db = new DBContext())
                {
                    var temp = db.Currencies.Where(table => table.Name == name).ToList();
                    app_object_cache().add("currency-" + name, currency);
                    return temp;
                }
            }

            // return new List<object>() {currency};
            return null;
        }

        public bool Add(Currencies data)
        {
            using (var db = new DBContext())
            {
                data.Name = data.Name.ToUpper();
                db.Currencies.Add(data);
                var insert_id = data.CurrencyId;
                if (insert_id > 0)
                {
                    this.log_activity("New Currency Added [ID: " + data.Name + "]");
                    return true;
                }
            }

            return false;
        }

        public bool Edit(Currencies data)
        {
            using (var db = new DBContext())
            {
                data.Name = data.Name.ToUpper();
                db.Currencies.FindAsync(data.CurrencyId);
                db.Currencies.Update(data);
                var affected_rows = db.SaveChanges();

                if (affected_rows > 0)
                {
                    this.log_activity("Currency Updated [" + data.Name + "]");
                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            var currency = this.Get(id).First();
            if (currency.IsDefault)
            {
                return true;
            }

            using (var db = new DBContext())
            {
                db.Currencies.Remove(db.Currencies.Single(table => table.CurrencyId == id));
                var affected_rows = db.SaveChanges();

                db.SaveChanges();
                if (affected_rows > 0)
                {
                    this.log_activity("Currency Deleted [" + id + "]");

                    return true;
                }
            }

            return false;
        }

        public bool MakeBaseCurrency(int id)
        {
            var @base = this.GetBaseCurrency();

            var affected_rows = 0;
            using (var db = new DBContext())
            {
                var currency = db.Currencies.SingleOrDefault(table => table.CurrencyId == id);
                if (currency != null)
                {
                    currency.IsDefault = true;
                    affected_rows = db.SaveChanges();
                }

                if (affected_rows > 0)
                {
                    db.Currencies.Where(table => table.CurrencyId != id).ToList().ForEach((currency) =>
                    {
                        currency.IsDefault = false;
                        db.SaveChanges();
                    });

                    return true;
                }
            }

            return false;
        }

        public Currencies GetBaseCurrency()
        {
            using (var db = new DBContext())
            {
                return db.Currencies.FirstOrDefault(table => table.IsDefault);
            }
        }

        public string GetCurrencySymbol(int id = 0)
        {
            if (id == 0)
            {
                id = this.GetBaseCurrency().CurrencyId;
            }

            var currencies = (List<Currencies>) app_object_cache().get("currencies-data");
            if (currencies != null)
            {
                foreach (var currency in currencies)
                {
                    if (id == currency.CurrencyId)
                    {
                        return currency.Symbol;
                    }
                }
            }

            using (var db = new DBContext())
            {
                var entry = db.Currencies.FirstOrDefault(table => table.CurrencyId == id);
                return (entry != null) ? entry.Symbol : "";
            }
        }
    }

    public static class CurrenciesModelExtension
    {
        private static CurrenciesModel _instance = null;

        public static CurrenciesModel currencies_model(this object source)
        {
            return _instance ??= new CurrenciesModel();
        }
    }
}