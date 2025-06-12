using SimpleAdminPanel.Models;

namespace SimpleAdminPanel
{
    public class LSMakerChecker
    {
        public List<LSAnalystAssignPersonList> AssignPersonList()
        {
            List<LSAnalystAssignPersonList> lstAssignPeron = new List<LSAnalystAssignPersonList>();
            lstAssignPeron.Add(new LSAnalystAssignPersonList { Name = "Zwe Wai Yan Htet", Email = "zwewaiyanhtet@yomabank.com" });
            lstAssignPeron.Add(new LSAnalystAssignPersonList { Name = "Rozan Naing", Email = "rozannaing@yomabank.com" });
            lstAssignPeron.Add(new LSAnalystAssignPersonList { Name = "SaBai Aung", Email = "sabai.aung@yomabank.com" });
            lstAssignPeron.Add(new LSAnalystAssignPersonList { Name = "Swe Zin Soe", Email = "swezinsoe@yomabank.com" });
            lstAssignPeron.Add(new LSAnalystAssignPersonList { Name = "Pyae Phyo Swe", Email = "pyaephyoswe@yomabank.com" });
            return lstAssignPeron;
        }

        public string GetEmailByName(string Name)
        {
            return AssignPersonList().Where(x => x.Name == Name).Select(x=>x.Email).FirstOrDefault();
        }
    }
}
