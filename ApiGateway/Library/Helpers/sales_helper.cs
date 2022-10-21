using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ApiGateway.Entities;
using ApiGateway.Models;
using Microsoft.AspNetCore.Http;
using static ApiGateway.Core.MyHooks;
using static ApiGateway.System.Language;

namespace ApiGateway.Library.Helpers
{
    public static class sales_helper
    {
        public static bool is_using_multiple_currencies(this object source, string table = null)
        {
            var currencies_model = new CurrenciesModel();
            var currencies = currencies_model.Get();


            var total_currencies_used = 0;
            var other_then_base = false;
            var base_found = false;
            foreach (var currency in currencies)
            {
                var total = 0;
                using (var db = new DBContext())
                {
                    total = db
                        .Currencies
                        .Where(table => table.CurrencyId == currency.CurrencyId)
                        .ToList()
                        .Count;
                }


                if (total > 0)
                {
                    total_currencies_used++;
                    other_then_base = (currency.IsDefault == false) ? true : false;
                }
            }

            if (total_currencies_used > 1 && base_found && other_then_base)
            {
                return true;
            }
            else if (total_currencies_used == 1 && base_found == false && other_then_base)
            {
                return true;
            }
            else if (total_currencies_used == 0 || total_currencies_used == 1)
            {
                return false;
            }

            return true;
        }

        public static object app_format_number(this object source, object total, bool foce_check_zero_decimals = false)
        {
            if (!(total.GetType() == typeof(int)))
            {
                return total;
            }

            var decimal_separator = source.get_option<string>("decimal_separator");
            var thousand_separator = source.get_option<string>("thousand_separator");

            var d = source.get_decimal_places();
            if (source.get_option<bool>("remove_decimals_on_zero") || foce_check_zero_decimals)
            {
            }

            var formatted = string.Format(total + "", d, decimal_separator, thousand_separator);

            return hooks().ApplyFilters("number_after_format", new
            {
                formatted = formatted,
                total = total,
                decimal_separator = decimal_separator,
                thousand_separator = thousand_separator,
                decimal_places = d,
            });
        }

        public static string app_format_money(this object source, decimal? amount, string currency_symbol,
            bool excludeSymbol = false)
        {
            if (amount > 0)
            {
                return amount + "";
            }

            var currency = new Currencies()
            {
                Symbol = currency_symbol,
                Name = currency_symbol,
                Placement = "before",
                DecimalSeparator = source.get_option<string>("decimal_separator"),
                ThousandSeparator = source.get_option<string>("thousand_separator")
            };


            var Symbol = !excludeSymbol ? currency.Symbol : "";

            var d = source.get_option<bool>("remove_decimals_on_zero") && amount > 0 ? 0 : source.get_decimal_places();

            var amountFormatted = string.Format(amount + "", d, currency.DecimalSeparator, currency.ThousandSeparator);

            var formattedWithCurrency = currency.Placement == "after"
                ? amountFormatted + "" + Symbol
                : Symbol + "" + amountFormatted;

            hooks().ApplyFilters("app_format_money", new
            {
                formattedWithCurrency = formattedWithCurrency,
                amount = amount,
                currency = currency,
                exclude_Symbol = excludeSymbol,
                decimal_places = d
            });
            return formattedWithCurrency;
        }

        public static bool is_decimal(this object source, int val)
        {
            return false;
        }

        public static bool multiple_taxes_found_for_item(this object source, List<Taxes> taxes)
        {
            var names = new List<string>();
            foreach (var t in taxes)
            {
                names.Add(t.Name);
            }

            return !(names.Count == 1);
        }

        public static int ajax_on_total_items(this object source)
        {
            return Convert.ToInt32(hooks().ApplyFilters("ajax_on_total_items", 200));
        }

        public static Taxes get_tax_by_id(this object source, int id)
        {
            var output = new Taxes();

            using (var db = new DBContext())
            {
                output = db.Taxes.FirstOrDefault(table => table.Id == id);
            }

            return output;
        }

        public static Taxes get_tax_by_name(this object source, string name)
        {
            var output = new Taxes();

            using (var db = new DBContext())
            {
                output = db.Taxes.FirstOrDefault(table => table.Name == name);
            }

            return output;
        }

        public static string _maybe_remove_first_and_last_br_tag(this object source, string text)
        {
            var pattern = "/^<br ?/?>/is";

            var regex = new Regex(pattern);
            text = regex.Replace(text, "");

            return text;
        }

        public static string _info_format_replace(this object source, string mergeCode, string val, string txt)
        {
            // Regex regHtml = new System.Text.RegularExpressions.Regex("<[^>]*>");
            // var tmpVal = regHtml.Replace(val, "");
            var result = "";
            // if (tmpVal != "")
            // {
            //     var pattern = "/({" + mergeCode + "})/i";
            //     var regex = new Regex(pattern);
            //     result = regex.Replace(val, txt);
            // }
            // else
            // {
            //     var pattern = "/s{0,}{" + mergeCode + "}(<br ?/?>(\n))?/i";
            //     var regex = new Regex(pattern);
            //     result = regex.Replace("", txt);
            // }

            return result;
        }

        public static string _info_format_custom_field(this object source, int id, string label, object value,
            string txt)
        {
            var result = "";

            hooks().ApplyFilters("info_format_custom_field", new
            {
                id = id,
                result = result,
                label = label,
                txt = txt,
            });
            return result;
        }

        public static string _info_format_custom_fields_check(this object source, int custom_fields, string txt)
        {
            return txt;
        }


        public static string format_customer_info(this object source, CustomersGroups data, string @for, string type,
            bool companyLink = false)
        {
            var format = source.get_option<string>("customer_info_format");
            var clientId = 0;


            if (@for == "statement")
            {
            }
            else if (type == "billing")
            {
            }

            var companyName = "";
            if (@for == "statement")
            {
                companyName = source.get_company_name(clientId);
            }
            else if (type == "billing")
            {
            }

            if (@for == "invoice" ||
                @for == "estimate" ||
                @for == "payment" ||
                @for == "credit_note")
            {
            }

            var street = "";
            if (type == "billing")
            {
            }

            else if (type == "shipping")
            {
            }

            var city = "";
            if (type == "billing")
            {
            }

            else if (type == "shipping")
            {
            }

            var state = "";
            if (type == "billing")
            {
            }

            else if (type == "shipping")
            {
            }

            var zipCode = "";
            if (type == "billing")
            {
            }

            else if (type == "shipping")
            {
            }

            var countryCode = "";
            var countryName = "";
            var country = new Countries();
            if (type == "billing")
            {
            }
            else if (type == "shipping")
            {
            }

            if (country != null)
            {
                countryCode = country.Iso2;
                countryName = country.ShortName;
            }

            var phone = "";
            var vat = "";
            format += source._info_format_replace("company_name", companyName, format);
            format += source._info_format_replace("customer_id", clientId + "", format);
            format += source._info_format_replace("street", street, format);
            format += source._info_format_replace("city", city, format);
            format += source._info_format_replace("state", state, format);
            format += source._info_format_replace("zip_code", zipCode, format);
            format += source._info_format_replace("country_code", countryCode, format);
            format += source._info_format_replace("country_name", countryName, format);
            format += source._info_format_replace("phone", phone, format);
            format += source._info_format_replace("vat_number", vat, format);
            format += source._info_format_replace("vat_number_with_label",
                string.IsNullOrEmpty(vat) ? "" : label("client_vat_number") + ": " + vat, format);

            format = source._maybe_remove_first_and_last_br_tag(format);

            hooks().ApplyFilters("customer_info_text", new
            {
                format = format,
                data = data,
                @for = @for,
                type = type,
                company_link = companyLink,
            });
            return format;
        }


        public static dynamic format_proposal_info(this object source, Proposals proposal, string @for = "")
        {
            var format = source.get_option<string>("proposal_info_format");

            var countryCode = "";
            var countryName = "";
            var country = source.get_country(proposal.Country);

            if (country != null)
            {
                countryCode = country.Iso2;
                countryName = country.ShortName;
            }

            var proposalTo = "<b>" + proposal.ProposalTo + "</b>";
            var phone = proposal.Phone;
            var email = proposal.Email;

            if (@for == "admin")
            {
                var hrefAttrs = "";
                if (proposal.RelType == "lead")
                {
                    hrefAttrs = " href='#' onclick='init_lead(" + proposal.RelId +
                                "); return false; data-toggle='tooltip' data-title='" + label("lead") + "'";
                }
                else
                {
                    hrefAttrs = " href='" + source.admin_url("clients/client/" + proposal.RelId) +
                                "' data-toggle='tooltip' data-title='" + label("client") + "'";
                }

                proposalTo = "<a" + hrefAttrs + ">" + proposalTo + "</a>";
            }

            if (@for == "html" || @for == "admin")
            {
                phone = "<a href='tel:" + proposal.Phone + "'>" + proposal.Phone + "</a>";
                email = "<a href='mailto:" + proposal.Email + "'>" + proposal.Email + "</a>";
            }

            format = source._info_format_replace("proposal_to", proposalTo, format);
            format = source._info_format_replace("address", proposal.Address, format);
            format = source._info_format_replace("city", proposal.City, format);
            format = source._info_format_replace("state", proposal.State, format);

            format = source._info_format_replace("country_code", countryCode, format);
            format = source._info_format_replace("country_name", countryName, format);

            format = source._info_format_replace("zip_code", proposal.Zip, format);
            format = source._info_format_replace("phone", phone, format);
            format = source._info_format_replace("email", email, format);

            return hooks().ApplyFilters("proposal_info_text", new {format = format, proposal = proposal, @for = @for});
        }


        public static string format_organization_info(this object source)
        {
            var format = source.get_option<string>("company_info_format");
            var vat = source.get_option<string>("company_vat");

            format = source._info_format_replace("company_name",
                "<b style='color:black' class='company-name-formatted'>" +
                source.get_option<string>("invoice_company_name") + "</b>", format);
            format = source._info_format_replace("address", source.get_option<string>("invoice_company_address"),
                format);
            format = source._info_format_replace("city", source.get_option<string>("invoice_company_city"), format);
            format = source._info_format_replace("state", source.get_option<string>("company_state"), format);

            format = source._info_format_replace("zip_code", source.get_option<string>("invoice_company_postal_code"),
                format);
            format = source._info_format_replace("country_code",
                source.get_option<string>("invoice_company_country_code"), format);
            format = source._info_format_replace("phone", source.get_option<string>("invoice_company_phonenumber"),
                format);
            format = source._info_format_replace("vat_number", vat, format);
            format = source._info_format_replace("vat_number_with_label",
                string.IsNullOrEmpty(vat) ? "" : label("company_vat_number") + ": " + vat, format);

            hooks().ApplyFilters("organization_info_text", format);
            return format;
        }

        public static decimal get_decimal_places(this object source)
        {
            decimal output = 2;
            hooks().ApplyFilters("app_decimal_places", new {value = output});
            return output;
        }

        public static List<Itemable> get_items_by_type(this object source, string type, int id)
        {
            var output = new List<Itemable>();

            using (var db = new DBContext())
            {
                output = db.Itemable.Where(
                        table => table.RelId == id && table.RelType == type)
                    .OrderBy(table => new {table.ItemOrder})
                    .ToList();
            }

            return output;
        }

        public static void update_sales_total_tax_column(this object source, int id, string type, string table)
        {
        }

        public static bool _maybe_insert_post_item_tax(this object source, int item_id, string post_item, int rel_id,
            string rel_type)
        {
            var affectedRows = 0;
            return affectedRows > 0 ? true : false;
        }

        public static int add_new_sales_item_post(this object source, IFormCollection item, int rel_id, string rel_type)
        {
            var custom_fields = false;

            if (item.ContainsKey("custom_fields"))
            {
                custom_fields = Convert.ToBoolean(item["custom_fields"]);
            }

            var itemable = new Itemable()
            {
                Description = item["description"],
                // LongDescription = Convert.ToString(item["long_description"]).nl2br(),
                Qty = Convert.ToDecimal(item["qty"]),
                Rate = Convert.ToDecimal(item["rate"]),
                RelId = rel_id,
                RelType = rel_type,
                ItemOrder = Convert.ToInt32(item["order"]),
                Unit = item["unit"]
            };

            using (var db = new DBContext())
            {
                db.Add(itemable);
                db.SaveChanges();
            }


            var id = itemable.ItemableId;

            if (custom_fields)
            {
            }

            return id;
        }

        public static bool update_sales_item_post(this object source, int item_id, dynamic data, string field = "")
        {
            Itemable update = null;
            if (!string.IsNullOrEmpty(field))
            {
            }
            else
            {
                update = new Itemable()
                {
                    ItemOrder = data.order,
                    Description = data.description,
                    LongDescription = Convert.ToString(data.long_description).nl2br(),
                    Rate = string.Format(data.rate, source.get_decimal_places(), ",", ""),
                    Qty = data.qty,
                    Unit = data.unit
                };
            }

            using (var db = new DBContext())
            {
                if (update != null)
                {
                    var entry = db.Itemable.Where(table => table.ItemableId == item_id).ToList();
                    if (entry != null)
                    {
                        db.Entry(entry).CurrentValues.SetValues(update);
                        var affected_rows = db.SaveChanges();
                        return (affected_rows > 0);
                    }
                }
            }


            return false;
        }

        public static bool handle_removed_sales_item_post(this object source, int id, string rel_type)
        {
            using (var db = new DBContext())
            {
                var entry = db.Itemable.FirstOrDefault(table => table.ItemableId == id);
                db.Remove(entry);
                var affected_rows = db.SaveChanges();

                if (affected_rows > 0)
                {
                    source.delete_taxes_from_item(id, rel_type);

                    var entry2 =
                        db.CustomFieldsValues.FirstOrDefault(table => table.RelId == id && table.FieldTo == "items");
                    db.Remove(entry2);
                    db.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public static bool delete_taxes_from_item(this object source, int item_id, string rel_type)
        {
            var affected_rows = 0;
            using (var db = new DBContext())
            {
                var entry = db.ItemTax.FirstOrDefault(table => table.Itemid == item_id && table.RelType == rel_type);
                db.Remove(entry);
                affected_rows = db.SaveChanges();
            }


            return affected_rows > 0;
        }

        public static bool is_sale_discount_applied(this object source, dynamic data)
        {
            return data.discount_total > 0;
        }

        public static bool is_sale_discount(this object source, dynamic data, string @is)
        {
            if (data.discount_percent == 0 && data.discount_total == 0)
            {
                return false;
            }

            var discount_type = "fixed";
            if (data.discount_percent != 0)
            {
                discount_type = "percent";
            }

            return discount_type == @is;
        }

        public static bool get_items_table_data(this object source, string transaction, string type,
            string @for = "html", bool admin_preview = false)
        {
            return false;
        }


        public static string sales_number_format(this object source, int number, int format, string applied_prefix,
            DateTime? date)
        {
            var originalNumber = number;
            var prefixPadding = source.get_option<decimal>("number_padding_prefixes");

            if (format == 1)
            {
            }

            else if (format == 2)
            {
            }
            else if (format == 3)
            {
            }
            else if (format == 4)
            {
            }

            hooks().ApplyFilters("sales_number_format", new
            {
                format = format,
                date = date,
                number = originalNumber,
                prefix_padding = prefixPadding,
            });
            return "";
        }


        public static Currencies get_currency(this object source, string name)
        {
            var currencies_model = new CurrenciesModel();
            return currencies_model.GetByName(name).FirstOrDefault();
        }

        public static Currencies get_currency(this object source, int id)
        {
            var currencies_model = new CurrenciesModel();
            return currencies_model.Get(Convert.ToInt32(id)).FirstOrDefault();
        }

        public static string get_base_currency(this object source)
        {
            var currencies_model = new CurrenciesModel();
            return "";
        }
    }
}