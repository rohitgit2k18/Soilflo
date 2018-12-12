
using MobileFlo.Services.Models.RequestModels;
using MobileFlo.Services.Models.ResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Notifit.Services.Models;
using Notifit.Services.Models.RequestModels;
using Notifit.Services.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileFlo.Services.ApiHandler
{
    public class RestApi
    {
        public WebRequest webRequest = null;
        private HttpClient client;      
        private string _col = ":";       

        public RestApi()

        {
            client = new HttpClient();
        }
        //*****************Get Generic Api's**************************
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="Tobject"></param>
        /// <returns></returns>
        public async Task<T> GetAsyncData_GetApi<T>(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, T Tobject) where T : new()
        {
            // var _storedToken=Settings;
            try
            {
              //  client.MaxResponseContentBufferSize = 256000;
                if (IsHeaderRequired)
                {

                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));
                    //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    //client.DefaultRequestHeaders.Add("Authorization", "application/json");
                    //client.DefaultRequestHeaders.Add("Content-Length", "84");
                    //client.DefaultRequestHeaders.Add("User-Agent", "Fiddler");
                    //client.DefaultRequestHeaders.Add("Host", "localhost:49165");
                    // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                // var request = new HttpRequestMessage(HttpMethod.Get, uri);

                // request.Content = new FormUrlEncodedContent(keyValues);

                //  HttpResponseMessage response = await client.SendAsync(request);

                HttpResponseMessage response = await client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
                {

                    var responseContent = response.Content;
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    //  SucessResponse = SucessResponse.Insert(1, "\"Status\"" + _col + "\"Success\",");
                    Tobject = JsonConvert.DeserializeObject<T>(SucessResponse);
                    return Tobject;

                }
                else
                {

                    //long ResonseStatus = Convert.ToInt64(response.StatusCode);
                    //switch (ResonseStatus)
                    //{
                    //    case 302:
                    //        _response = "{\"Status\"" + _col + "\"Invalid User Name and password..\"}";
                    //        break;
                    //    case 400:
                    //        _response = "{\"Status\"" + _col + "\"Bad Request\"}";
                    //        break;
                    //    case 401:
                    //        _response = "{\"Status\"" + _col + "\"Invalid User Name and password..\"}";
                    //        break;
                    //    case 404:
                    //        _response = "{\"Status\"" + _col + "\"Not Found\"}";
                    //        break;

                    //    default:
                    //        _response = "{\"Status\"" + _col + "\"Internal Server errror\"}";
                    //        break;

                    var responseContent = response.Content;
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    ErrorResponse = ErrorResponse.Insert(1, "\"Status\"" + _col + "\"fail\",");
                    Tobject = JsonConvert.DeserializeObject<T>(ErrorResponse);
                    return Tobject;

                    // }
                }

                //Tobject = JsonConvert.DeserializeObject<T>(_response);
                //return Tobject;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
               
               
            }
        }       
      /// <summary>
      /// 
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="uri"></param>
      /// <param name="IsHeaderRequired"></param>
      /// <param name="objHeaderModel"></param>
      /// <param name="Tobject"></param>
      /// <returns></returns>
       public async Task<ObservableCollection<T>> GetAsyncData_GetApiList<T>(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, ObservableCollection<T> Tobject) where T : new()
        {
            // var _storedToken=Settings;
            try
            {
                HttpResponseMessage response = null;
                //  client.MaxResponseContentBufferSize = 256000;
                if (IsHeaderRequired)
                {

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);

                }


                response = await client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
                {

                    var responseContent = response.Content;
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    //  SucessResponse = SucessResponse.Insert(1, "\"Status\"" + _col + "\"Success\",");
                    Tobject = JsonConvert.DeserializeObject<ObservableCollection<T>>(SucessResponse);
                    return Tobject;

                }
                else
                {





                    var responseContent = response.Content;
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    //  ErrorResponse = ErrorResponse.Insert(1, "\"Status\"" + _col + "\"fail\",");
                    Tobject = JsonConvert.DeserializeObject<ObservableCollection<T>>(ErrorResponse);
                    return Tobject;


                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }
        public async Task<ObservableCollection<T>> GetAsyncData_GetCountryApiList<T>(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, ObservableCollection<T> Tobject) where T : new()
        {
            
            // var _storedToken=Settings;
            try
            {
               // HttpResponseMessage response = null;
                //  client.MaxResponseContentBufferSize = 256000;
                if (IsHeaderRequired)
                {

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);

                }

                using (var w = new WebClient())
                {
                    var json_data = string.Empty;
                    // attempt to download JSON data as a string
                    try
                    {
                        //json_data =  w.DownloadString(uri);
                        json_data= await w.DownloadStringTaskAsync(uri);
                    }
                    catch (Exception)
                    {

                    }
                    // if string with JSON data is not empty, deserialize it to class and return its instance 
                    //if (!string.IsNullOrEmpty(json_data))
                    //{
                    //    return JsonConvert.DeserializeObject<ObservableCollection<T>>(json_data);
                    //}
                    //else
                    //{
                    //    return null;
                    //}
                    //  return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<ObservableCollection<T>>(json_data) : new T();
              
                //  response = await client.GetAsync(uri);


                if (!string.IsNullOrEmpty(json_data))
                {

                   // var responseContent = response.Content;
                   // var SucessResponse = await response.Content.ReadAsStringAsync();
                    //  SucessResponse = SucessResponse.Insert(1, "\"Status\"" + _col + "\"Success\",");
                    var res =  JsonConvert.DeserializeObject<ObservableCollection<T>>(json_data);
                    return   res;

                }
                else
                {





                   // var responseContent = response.Content;
                   // var ErrorResponse = await response.Content.ReadAsStringAsync();
                    //  ErrorResponse = ErrorResponse.Insert(1, "\"Status\"" + _col + "\"fail\",");
                   // Tobject = JsonConvert.DeserializeObject<ObservableCollection<T>>(json_data);
                    return null;


                }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }

            //*********************************POST APIS**************************

        /// <summary>
        /// Register Driver Mobile Api
        /// </summary>
        public async Task<RegisterMobileResponseModel> MobileNumberAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel,RegisterMobileRequestModel _objRegisterMobileRequestModel)
        {

            RegisterMobileResponseModel objRegisterMobileResponseModel;
            string s = JsonConvert.SerializeObject(_objRegisterMobileRequestModel);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {
                IsHeaderRequired = true;
                if (IsHeaderRequired)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", objHeaderModel.TokenCode);
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                }
                response = await client.PostAsync(uri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objRegisterMobileResponseModel = JsonConvert.DeserializeObject<RegisterMobileResponseModel>(SucessResponse);
                    return objRegisterMobileResponseModel;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objRegisterMobileResponseModel = JsonConvert.DeserializeObject<RegisterMobileResponseModel>(ErrorResponse);
                    return objRegisterMobileResponseModel;
                }
            }
        }
        /// <summary>
        /// Start Hauling Mobile Api
        /// </summary>
        public async Task<StarHaulingResponseModel> getProjectAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, StartHaulingRequestModel _objStartHaulingRequestModel)
        {

            StarHaulingResponseModel objRegisterMobileResponseModel;
            string s = JsonConvert.SerializeObject(_objStartHaulingRequestModel);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {
                IsHeaderRequired = true;
                if (IsHeaderRequired)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                }
                response = await client.PutAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objRegisterMobileResponseModel = JsonConvert.DeserializeObject<StarHaulingResponseModel>(SucessResponse);
                    return objRegisterMobileResponseModel;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objRegisterMobileResponseModel = JsonConvert.DeserializeObject<StarHaulingResponseModel>(ErrorResponse);
                    return objRegisterMobileResponseModel;
                }
            }
        }
        /// <summary>
        /// Validate Code Api
        /// </summary>

        public async Task<CodeVerificationResponseModel> ValidateCodeAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, CodeVerificationRequestModel _objCodeVerificationRequestModel)
        {

            CodeVerificationResponseModel objCodeVerificationResponseModel;
            string s = JsonConvert.SerializeObject(_objCodeVerificationRequestModel);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {
                IsHeaderRequired = true;
                if (IsHeaderRequired)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                }
                response = await client.PutAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objCodeVerificationResponseModel = JsonConvert.DeserializeObject<CodeVerificationResponseModel>(SucessResponse);
                    return objCodeVerificationResponseModel;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objCodeVerificationResponseModel = JsonConvert.DeserializeObject<CodeVerificationResponseModel>(ErrorResponse);
                    return objCodeVerificationResponseModel;
                }
            }
        }

        public async Task<SetStatusResponse> SetStatusAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, SetStatusRequest _objSetStatusRequest)
        {

            SetStatusResponse objSetStatusResponse;
            string s = JsonConvert.SerializeObject(_objSetStatusRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {
                IsHeaderRequired = true;
                if (IsHeaderRequired)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                }
                response = await client.PutAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objSetStatusResponse = JsonConvert.DeserializeObject<SetStatusResponse>(SucessResponse);
                    return objSetStatusResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objSetStatusResponse = JsonConvert.DeserializeObject<SetStatusResponse>(ErrorResponse);
                    return objSetStatusResponse;
                }
            }
        }


        /// <summary>
        /// Resend Code Api
        /// </summary>
        public async Task<CodeVerificationResponseModel> ResendCodeAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, CodeVerificationRequestModel _objCodeVerificationRequestModel)
        {

            CodeVerificationResponseModel objCodeVerificationResponseModel;
            string s = JsonConvert.SerializeObject(_objCodeVerificationRequestModel);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {
                IsHeaderRequired = true;
                if (IsHeaderRequired)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                }
                response = await client.PutAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objCodeVerificationResponseModel = JsonConvert.DeserializeObject<CodeVerificationResponseModel>(SucessResponse);
                    return objCodeVerificationResponseModel;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objCodeVerificationResponseModel = JsonConvert.DeserializeObject<CodeVerificationResponseModel>(ErrorResponse);
                    return objCodeVerificationResponseModel;
                }
            }
        }

        /// <summary>
        /// Create Driver Name Api
        /// </summary>
        public async Task<CreateDriverNameResponse> CreateDriverNameAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, CreateDriverNameRequest _objCreateDriverNameRequest)
        {

            CreateDriverNameResponse objCreateDriverNameResponse;
            string s = JsonConvert.SerializeObject(_objCreateDriverNameRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {
                IsHeaderRequired = true;
                if (IsHeaderRequired)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                }
                response = await client.PutAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objCreateDriverNameResponse = JsonConvert.DeserializeObject<CreateDriverNameResponse>(SucessResponse);
                    return objCreateDriverNameResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objCreateDriverNameResponse = JsonConvert.DeserializeObject<CreateDriverNameResponse>(ErrorResponse);
                    return objCreateDriverNameResponse;
                }
            }
        }

        /// <summary>
        /// Create Driver Email Api
        /// </summary>
        public async Task<CreateDriverEmailResponse>CreateDriverEmailAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, CreateDriverEmailRequest _objCreateDriverEmailRequest)
        {

            CreateDriverEmailResponse objCreateDriverEmailResponse;
            string s = JsonConvert.SerializeObject(_objCreateDriverEmailRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {
                IsHeaderRequired = true;
                if (IsHeaderRequired)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                }
                response = await client.PutAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objCreateDriverEmailResponse = JsonConvert.DeserializeObject<CreateDriverEmailResponse>(SucessResponse);
                    return objCreateDriverEmailResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objCreateDriverEmailResponse = JsonConvert.DeserializeObject<CreateDriverEmailResponse>(ErrorResponse);
                    return objCreateDriverEmailResponse;
                }
            }
        }

        public async Task<SetPositionResponseModel> SetPositionAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, SetPositionRequestModel _objSetPositionRequestModel)
        {

            SetPositionResponseModel objSetPositionResponseModel;
            string s = JsonConvert.SerializeObject(_objSetPositionRequestModel);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {
                IsHeaderRequired = true;
                if (IsHeaderRequired)
                {
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                    client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                                                  "Basic",
                                                  Convert.ToBase64String(
                                                  System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                  string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objSetPositionResponseModel = JsonConvert.DeserializeObject<SetPositionResponseModel>(SucessResponse);
                    return objSetPositionResponseModel;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objSetPositionResponseModel = JsonConvert.DeserializeObject<SetPositionResponseModel>(ErrorResponse);
                    return objSetPositionResponseModel;
                }
            }

        }

        //public async Task<GetStatusResponseModel> GetStatusAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel)
        //{

        //    SetPositionResponseModel objSetPositionResponseModel;
        //    string s = JsonConvert.SerializeObject(_objSetPositionRequestModel);
        //    HttpResponseMessage response = null;
        //    using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
        //    {
        //        IsHeaderRequired = true;
        //        if (IsHeaderRequired)
        //        {
        //            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
        //            client.DefaultRequestHeaders.Authorization =
        //            new AuthenticationHeaderValue(
        //                                          "Basic",
        //                                          Convert.ToBase64String(
        //                                          System.Text.ASCIIEncoding.ASCII.GetBytes(
        //                                          string.Format("{0}:{1}", "jigadmin", "Gr8ApI#"))));

        //        }
        //        response = await client.PostAsync(uri, stringContent);


        //        if (response.IsSuccessStatusCode)
        //        {
        //            var SucessResponse = await response.Content.ReadAsStringAsync();
        //            objSetPositionResponseModel = JsonConvert.DeserializeObject<SetPositionResponseModel>(SucessResponse);
        //            return objSetPositionResponseModel;
        //        }
        //        else
        //        {
        //            var ErrorResponse = await response.Content.ReadAsStringAsync();
        //            objSetPositionResponseModel = JsonConvert.DeserializeObject<SetPositionResponseModel>(ErrorResponse);
        //            return objSetPositionResponseModel;
        //        }
        //    }

        //}


        //******************Generics**************************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> PostAsyncData(string uri)
        {
            try
            {

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                return await response.Content.ReadAsStringAsync(); ;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public void FetchData(string url)
        {

            // Create an HTTP web request using the URL:
            webRequest = WebRequest.Create(new Uri(url));
            webRequest.ContentType = "application/json";
            webRequest.Method = "GET";
            webRequest.BeginGetRequestStream(new AsyncCallback(RequestStreamCallback), webRequest);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asynchronousResult"></param>
        private void RequestStreamCallback(IAsyncResult asynchronousResult)
        {
            webRequest = (HttpWebRequest)asynchronousResult.AsyncState;

            using (var postStream = webRequest.EndGetRequestStream(asynchronousResult))
            {
                //send yoour data here
            }
            webRequest.BeginGetResponse(new AsyncCallback(ResponseCallback), webRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asynchronousResult"></param>
        void ResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest myrequest = (HttpWebRequest)asynchronousResult.AsyncState;
            using (HttpWebResponse response = (HttpWebResponse)myrequest.EndGetResponse(asynchronousResult))
            {
                using (System.IO.Stream responseStream = response.GetResponseStream())
                {
                    using (var reader = new System.IO.StreamReader(responseStream))
                    {
                        var data = reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
