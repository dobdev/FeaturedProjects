using FeaturedProjects.Models.Database;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FeaturedProjects.Models.Github
{
    public class GitHubService : IDisposable
    {
        private GitHubClient _client;

        private List<Project> _projects;

        private string[] _languages = { "Javascript", "CSharp", "Python", "Java", "Kotlin" };

        public GitHubService()
        {
            Initialize();
        }

        public async Task<bool> Synchronize()
        {
            Language[] languages = { Language.JavaScript, Language.CSharp, Language.Python, Language.Java, Language.Kotlin };
            
            for (var cont = 0; cont < languages.Count(); cont++)
            {
                var request = new SearchRepositoriesRequest()
                {
                    // Habilitei a busca para pegar apenas projetos com mais de 1000 estrelas
                    Stars = Range.GreaterThan(1000),

                    // Defini qual a linguagem de programação a ser pesquisada
                    Language = languages[cont],

                    // Defini a ordenação dos resultados pela quantidade de estrelas
                    SortField = RepoSearchSort.Stars
                };
                var response = await _client.Search.SearchRepo(request);

                var result = response.Items.Take(25);

                _projects.AddRange(result.Select(a => new Project
                {
                    ProductOwner = a.Owner.Login,
                    ProjectName = a.Name,
                    ProjectLink = a.HtmlUrl,
                    Language = _languages[cont]
                }).ToList());
            }

            AddOnDatabase();

            return true;
        }

        public void Initialize()
        {
            var basicAuth = new Credentials("dobdev", "elephant5p");
            _client = new GitHubClient(new ProductHeaderValue("FeaturedProjects"));
            _client.Credentials = basicAuth;

            _projects = new List<Project>();
        }

        public void Dispose()
        {
            _client = null;
            _projects = null;
        }

        private void AddOnDatabase()
        {
            foreach (var item in _projects)
            {
                using(var projService = new ProjectService()) {
                    projService.Add(item);
                }
            }
        }

    }
}