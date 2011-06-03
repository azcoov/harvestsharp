using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace harvestsharp.test
{
    [TestClass]
    public class HarvestTest : BaseTest
    {
        [TestMethod]
        public void test_ProjectsRequestShouldReturnProjectsList()
        {
            var proejcts = harvest.GetProjects();
            Assert.IsNotNull(proejcts);
            Assert.IsInstanceOfType(proejcts, typeof(List<HarvestProject>));
        }

        [TestMethod]
        public void test_NewProjectPostShouldReturnProjectResource()
        {
            project project = new project {
                name = "test", 
                active = true, 
                bill_by = "none",
                client_id = 0, 
                code = "999", 
                notes = "test notes", 
                budget = 100, 
                budget_by = "none"
            };
            
            var result = harvest.CreateNewProject(project);
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        public void test_DeactivatingAProject()
        {
            var project_id = 0;
            harvest.DeactivateProject(project_id);
        }

        [TestMethod]
        public void test_ReactivatingAProject()
        {
            var project_id = 0;
            harvest.ReactivateProject(project_id);
        }
    }
}
