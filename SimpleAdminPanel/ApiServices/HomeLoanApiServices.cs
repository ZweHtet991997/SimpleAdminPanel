using RestSharp;
using SimpleAdminPanel.Models;
using System.Text.Json;

namespace SimpleAdminPanel.ApiServices
{
    public class HomeLoanApiServices
    {
        private ApiURLRouter _apiRouter;
        private RestClient _restClient;

        public HomeLoanApiServices(ApiURLRouter apiRouter)
        {
            _apiRouter = apiRouter;
            _restClient = new RestClient();
        }

        public async Task<List<Form1ResponseModel>> GetForm1List()
        {
            try
            {
                Root root = new Root();
                List<Form1ResponseModel> lstForm1 = new List<Form1ResponseModel>();
                var request = new RestRequest(_apiRouter.GetListApiUrl(), Method.Get);
                var response = await _restClient.ExecuteAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    root = JsonSerializer.Deserialize<Root>(response.Content);
                    foreach (var item in root.value)
                    {
                        Form1ResponseModel responseModel = new Form1ResponseModel();
                        responseModel.ID = item.ID;
                        responseModel.CustomerName = item.CustomerName;
                        responseModel.SubmissionDate = item.Form3_Submitted_Date.ToString("mm/dd/yyyy");
                        responseModel.Region = item.RegionCode.Value;
                        responseModel.BranchName = item.BranchName;
                        responseModel.Status = item.LS_Stage;
                        lstForm1.Add(responseModel);
                    }
                }
                return lstForm1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> CreateLS(LSRequestModel model)
        {
            try
            {
                var request = new RestRequest(_apiRouter.CreateApiUrl()).AddJsonBody(model);
                var response = await _restClient.ExecutePostAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
