using FeaturedProjects.Models.Database;
using FeaturedProjects.Models.Github;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FeaturedProjects.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Initial 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Lista minha lista de projetos baseados no parâmetro passado.
        /// </summary>
        /// <param name="lang">Indica qual linguagem de programação deve ser pesquisada sendo: 1 - JavaScript, 2 - C#, 3 - Python, 4 - Java e 5 Kotlin</param>
        /// <returns>Objeto de <see cref="ActionResult"/> contendo os resultados da pesquisa.</returns>
        public async Task<ActionResult> Projects(int lang)
        {
            try
            {
                var language = string.Empty;

                switch (lang)
                {
                    case 1:
                        language = "Javascript";
                        break;
                    case 2:
                        language = "CSharp";
                        break;
                    case 3:
                        language = "Python";
                        break;
                    case 4:
                        language = "Java";
                        break;
                    case 5:
                        language = "Kotlin";
                        break;
                    default:
                        throw new Exception("Opção de linguagem não suportada pela aplicação.");
                }

                using (var service = new ProjectService())
                {
                    var response = service.GetAll().Where(a => a.Language.Equals(language)).ToList();
                    ViewBag.Repositories = response;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, "Internal error " + ex.Message);
            }
        }

        public async Task<JsonResult> Synchronize()
        {
            try
            {
                using (var gitHubservice = new GitHubService())
                {
                    bool x = await gitHubservice.Synchronize();
                    return Json(x, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }   
        }
    }
}