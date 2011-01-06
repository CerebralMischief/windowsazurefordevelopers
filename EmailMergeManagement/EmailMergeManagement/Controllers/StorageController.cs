using System;
using System.Web.Mvc;
using EmailMergeManagement.Models;

namespace EmailMergeManagement.Controllers
{
    public class StorageController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Windows Azure Table Storage Sample";
            return View();
        }

        public ActionResult List()
        {
            var emailMergeListing = new EmailMergeRepository().Select();
            return View(emailMergeListing);
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(EmailMergeModel emailMergeModel)
        {
            if (!ModelState.IsValid)
                return View();

            emailMergeModel.LastEditStamp = DateTime.Now;
            emailMergeModel.RowKey = Guid.NewGuid().ToString();

            var emailMergeRepository = new EmailMergeRepository();
            emailMergeRepository.Insert(emailMergeModel);

            return RedirectToAction("List");
        }

        public ActionResult Edit(string id)
        {
            var tableStorageDataSource = new EmailMergeRepository();
            var emailMergeModel = tableStorageDataSource.GetEmailMergeModel(id);
            return View(emailMergeModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(EmailMergeModel emailMergeModel)
        {
            var tableStorageDataSource = new EmailMergeRepository();
            tableStorageDataSource.Update(emailMergeModel);
            return RedirectToAction("List");
        }

        public ActionResult Details(string id)
        {
            var tableStorageDataSource = new EmailMergeRepository();
            var emailMergeModel = tableStorageDataSource.GetEmailMergeModel(id);
            return View(emailMergeModel);
        }

        public ActionResult Delete(string id)
        {
            var tableStorageDataSource = new EmailMergeRepository();
            var emailMergeModel = tableStorageDataSource.GetEmailMergeModel(id);
            return View(emailMergeModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(EmailMergeModel emailMergeModel)
        {
            var tableStorageDataSource = new EmailMergeRepository();
            tableStorageDataSource.Delete(emailMergeModel);
            return RedirectToAction("List");
        }

        public ActionResult TableGenerator()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TableGenerator(DataCreationParametersModel dataCreationParametersModel)
        {
            if (!ModelState.IsValid)
                return View();

            if (dataCreationParametersModel.DeleteExistingRows)
            {
                var emailMergeListing = new EmailMergeRepository().Select();
                foreach (var emailMergeModel in emailMergeListing)
                {
                    new EmailMergeRepository().Delete(emailMergeModel);
                }
            }

            var nameFactory = new NameFactory(dataCreationParametersModel.Rows);

            var names = nameFactory.BuildFullNames();

            var emailMergeRepository = new EmailMergeRepository();
            foreach (var name in names)
            {
                emailMergeRepository.Insert(new EmailMergeModel()
                {
                    Email = name.First + "." + name.Last + "@" + "somemaildomain.com",
                    First = name.First,
                    Last = name.Last,
                    LastEditStamp = DateTime.Now,
                    RowKey = Guid.NewGuid().ToString()
                });
            }

            return RedirectToAction("List");
        }
    }
}