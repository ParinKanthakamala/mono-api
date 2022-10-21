using Entities.Models;
using JamfahCrm.Controllers.Core;
using JamfahCrm.Library.Apps;
using JamfahCrm.Library.Helpers;
using System.Collections.Generic;
using System.Linq;

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
                    this.app_object_cache().set("currency-" + currency.First().Name, currency);
                    return currency;
                }
            }

            var currencies = this.app_object_cache().get("currencies-data");
            using (var db = new DBContext())
            {
                if (currencies != null)
                {
                    currencies = db.Currencies.ToList();
                    this.app_object_cache().Add("currencies-data", currencies);
                }
            }

            return (List<Currencies>)currencies;
        }

        public List<Currencies> GetByName(string name)
        {
            var currency = (Currencies)this.app_object_cache().get("currency-" + name);
            if (currency != null)
            {
                using (var db = new DBContext())
                {
                    var temp = db.Currencies.Where(table => table.Name == name).ToList();
                    this.app_object_cache().Add("currency-" + name, currency);
                    return temp;
                }
            }

            return new List<Currencies>() { currency };
        }

        public bool Add(Currencies data)
        {
            using (var db = new DBContext())
            {
                data.Name = data.Name.ToUpper();
                db.Currencies.Add(data);
                int insert_id = data.CurrencyId;
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
                int affected_rows = db.SaveChanges();

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
            if (currency.IsDefault == true)
            {
                return true;
            }

            using (var db = new DBContext())
            {
                db.Currencies.Remove(db.Currencies.Single(table => table.CurrencyId == id));
                int affected_rows = db.SaveChanges();

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

            int affected_rows = 0;
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
                return db.Currencies.FirstOrDefault(table => table.IsDefault == true);
            }
        }

        public string GetCurrencySymbol(int id = 0)
        {
            if (id == 0)
            {
                id = this.GetBaseCurrency().CurrencyId;
            }

            var currencies = (List<Currencies>)this.app_object_cache().get("currencies-data");
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