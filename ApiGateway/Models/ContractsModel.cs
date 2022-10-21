using ApiGateway.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using ApiGateway.Core;
using ApiGateway.Entities;
using static ApiGateway.Core.MyHooks;

namespace ApiGateway.Models
{
    public class ContractsModel : MyModel
    {
        public List<Contracts> Get(int? id, dynamic where = default(ExpandoObject), bool for_editor = false)
        {
            return null;
        }

        public List<Contracts> GetContractsYears()
        {
            return null;
        }

        public Files GetContractAttachment(int attachment_id = 0, int id = 0)
        {
            return null;
        }

        public List<Files> GetContractAttachments(int attachment_id = 0, int id = 0)
        {
            return null;
        }

        public int Add(Contracts contract)
        {
            contract.DateAdded = DateTime.Now;
            contract.AddedFrom = this.get_staff_user_id();
            return 0;
        }

        public bool Update(Contracts contract)
        {
            var affectedRows = 0;
            if (contract.DateEnd == null)
            {
            }

            return affectedRows > 0;
        }

        public bool ClearSignature(int id)
        {
            return false;
        }

        public bool AddComment(Contracts contract, bool client = false)
        {
            if (this.is_staff_logged_in()) client = false;

            return false;
        }

        public bool EditComment(int id, dynamic data)
        {
            return false;
        }

        public List<Contracts> GetComments(int id)
        {
            return null;
        }

        public ContractComments GetComment(int id)
        {
            return null;
        }

        public bool RemoveComment(int id)
        {
            var comment = this.GetComment(id);

            return false;
        }

        public int Copy(int id)
        {
            return 0;
        }

        public bool Delete(int id)
        {
            hooks().DoAction("before_contract_deleted", id);
            this.ClearSignature(id);
            return false;
        }

        public bool send_contract_to_client(int id, bool attach_pdf = true, string cc = "")
        {
            return false;
        }

        public bool DeleteContractAttachment(int attachment_id)
        {
            var deleted = false;
            return deleted;
        }

        public bool Renew(ContractRenewals data)
        {
            return false;
        }

        public bool DeleteRenewal(int id, int contract_id)
        {
            return false;
        }

        public List<ContractRenewals> GetContractRenewalHistory(int id)
        {
            return null;
        }

        public ContractsTypes GetContractTypes(int id = 0)
        {
            return this.contract_types_model().Get(id);
        }

        public bool DeleteContractType(int id)
        {
            return this.contract_types_model().Delete(id);
        }

        public int AddContractType(ContractsTypes data)
        {
            return this.contract_types_model().Add(data);
        }

        public bool UpdateContractType(int id, ContractsTypes data)
        {
            return this.contract_types_model().Update(id, data);
        }

        public dynamic GetContractsTypesChartData()
        {
            return this.contract_types_model().GetChartData();
        }

        public dynamic get_contracts_types_values_chart_data()
        {
            return this.contract_types_model().GetValuesChartData();
        }
    }

    public static class ContractTypeModelExtension
    {
        private static ContractsModel _instance = null;

        public static ContractsModel contracts_model(this object model)
        {
            return _instance ??= new ContractsModel();
        }
    }
}