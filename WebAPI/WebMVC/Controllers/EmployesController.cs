using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class EmployesController : Controller
    {
        HttpClient client;
        string url = "http://localhost:49352/api/Employees";
        public EmployesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
            MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Employes
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employees = JsonConvert.DeserializeObject<List<Employee>>(responseData);
                return View(Employees);
            }
            return View("Error");
        }


        public ActionResult Create()
        {
            return View(new Employee());
        }


        [HttpPost]
        public async Task<ActionResult> Create(Employee Employee)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url,Employee);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        public async Task<ActionResult> Edit(string id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employees = JsonConvert.DeserializeObject<Employee>(responseData);
                return View(Employees);
            }
            return View("Error");
        }


        [HttpPost]
        public async Task<ActionResult> Edit(string id, Employee Employee)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, Employee);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        public async Task<ActionResult> Delete(string id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employees = JsonConvert.DeserializeObject<Employee>(responseData);
                return View(Employees);
            }
            return View("Error");
        }


        [HttpPost]
        public async Task<ActionResult> Delete(string id, Employee Employee)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}