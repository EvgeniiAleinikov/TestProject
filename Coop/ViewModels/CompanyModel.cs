using Coop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coop.ViewModels
{
    public class CompanyModel
    {
        [Required]
        public string Name{ get; set; }
        public string Date{ get; set; }
        public int Id { get; set; }
        public ICollection<HouseModel> Houses { get; set; }
        public Manager Manager;

        public CompanyModel(Company company)
        {
            Id = company.Id;
            Name = company.Name;
            Date = company.Date.ToString();
            Houses = new List<HouseModel>();
            foreach (var item in company.Houses)
            {
                Houses.Add(new HouseModel(item));
            }
        }

        public static List<CompanyModel> GetCompanyModelList(Manager manager)
        {
            List<CompanyModel> list = new List<CompanyModel>();
            foreach (var item in manager.Companys)
            {
                list.Add(new CompanyModel(item));
            }
            return list;
        }

        public static List<CompanyModel> GetCompanyModelList(List<Company> companys)
        {
            List<CompanyModel> list = new List<CompanyModel>();
            foreach (var item in companys)
            {
                list.Add(new CompanyModel(item));
            }
            return list;
        }
    }
}