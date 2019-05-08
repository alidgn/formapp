using FormApp.Models;
using FormApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormApp.Controllers
{
    public class iController : Controller
    {
        private DataContext db;

        public ActionResult pano()
        {
            if (Session["userId"] != null)
            {
                return View();
            }
            return RedirectToAction("login", "account");
        }

        public JsonResult forms(int? id)
        {
            if (Session["userId"] != null)
            {
                db = new DataContext();

                var userId = Session["userId"];
                if (id != null)
                {
                    var forms = db.Forms.Where(x => x.Id == id && x.CreatedBy == (int)userId).FirstOrDefault();
                    if (forms != null)
                    {
                        var form = new FormModel()
                        {
                            Id = forms.Id,
                            Name = forms.Name,
                            Description = forms.Description,
                            CreatedAt = forms.CreatedAt.ToString("yyyy-MM-dd"),
                            CreatedBy = forms.CreatedBy,
                            Fields = new FieldsModel()
                            {
                                Name = forms.Fields.Name,
                                Surname = forms.Fields.Surname,
                                Age = forms.Fields.Age
                            }
                        };
                        return Json(form, JsonRequestBehavior.AllowGet);
                    }
                    return Json("notfound", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = db.Forms.Where(x => x.CreatedBy == (int)userId).ToList();
                    var forms = new List<object>();
                    foreach (var i in result)
                    {
                        forms.Add(new FormModel()
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Description = i.Description,
                            CreatedAt = i.CreatedAt.ToString("yyyy-MM-dd"),
                            CreatedBy = i.CreatedBy,
                            Fields = new FieldsModel()
                            {
                                Name = i.Fields.Name,
                                Surname = i.Fields.Surname,
                                Age = i.Fields.Age
                            },
                            Users = new UsersModel()
                            {
                                Username = i.Users.Username
                            }
                        });
                    }
                    return Json(forms, JsonRequestBehavior.AllowGet);
                }
            }
            return Json("unauthorized", JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult forms(FormModel formModel)
        {
            if (Session["userId"] != null)
            {
                var userId = (int)Session["userId"];
                if (formModel != null)
                {
                    db = new DataContext();
                    Fields field = new Fields()
                    {
                        Name = formModel.Fields.Name,
                        Surname = formModel.Fields.Surname,
                        Age = formModel.Fields.Age
                    };
                    db.Fields.Add(field);
                    db.SaveChanges();

                    Forms form = new Forms()
                    {
                        Name = formModel.Name,
                        Description = formModel.Description,
                        CreatedAt = DateTime.Now.Date,
                        CreatedBy = userId,
                        FieldId = field.Id,
                    };
                    db.Forms.Add(form);
                    db.SaveChanges();
                    return Json(1);
                }
                return Json(-1);
            }
            return Json(0);
        }
    }
}