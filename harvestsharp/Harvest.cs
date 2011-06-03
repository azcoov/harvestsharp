using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Collections;

namespace harvestsharp
{
    public class Harvest
    {
        private IAccount account;
        private Hashtable parameters = new Hashtable();

        public Harvest(string userName, string password, string subDomain)
            : this(new Account(userName, password, subDomain))
        {
        }

        public Harvest(IAccount account)
        {
            this.account = account;
        }

        private static dynamic ParseResponseData(string response)
        {
            var jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });
            dynamic data = jss.Deserialize(response, typeof(object)) as dynamic;
            return data;
        }

        public List<HarvestProject> GetProjects()
        {
            var response = account.request("/projects", "GET");
            dynamic data = ParseResponseData(response);

            List<HarvestProject> projects = new List<HarvestProject>();

            foreach (dynamic item in data) {
                projects.Add(new HarvestProject {
                    id = Convert.ToInt32(item.id),
                    name = item.name,
                    active = Convert.ToBoolean(item.active),
                    billable = Convert.ToBoolean(item.billable),
                    bill_by = item.bill_by,
                    hourly_rate = Convert.ToDecimal(item.hourly_rate),
                    client_id = Convert.ToInt32(item.client_id),
                    code = item.code,
                    notes = item.notes,
                    budget_by = item.budget_by,
                    budget = Convert.ToDecimal(item.budget),
                    hint_latest_record_at = Convert.ToDateTime(item.hint_latest_record_at),
                    hint_earliest_record_at = Convert.ToDateTime(item.hint_earliest_record_at),
                    fees = item.fees,
                    updated_at = Convert.ToDateTime(item.updated_at),
                    created_at = Convert.ToDateTime(item.created_at)
                });
            }
            return projects;
        }

        public Boolean CreateNewProject(project project)
        {
            account.request("/projects", "POST", postData: project.ToXElement().ToString());
            return true;
        }

        public void DeactivateProject(int project_id)
        {
            ToggleActivation(project_id);
        }

        public void ReactivateProject(int project_id)
        {
            ToggleActivation(project_id);
        }

        private void ToggleActivation(int project_id)
        {
            parameters.Clear();
            parameters.Add("project_id", project_id);
            account.request(String.Format("/projects/{0}/toggle", project_id), "PUT");
        }
    }
}
