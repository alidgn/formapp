using FormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormApp.ViewModels
{
    public class FormModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public virtual FieldsModel Fields { get; set; }
        public virtual UsersModel Users { get; set; }
    }
}