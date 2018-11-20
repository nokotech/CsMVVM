using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using csmvvm.utils;
using Newtonsoft.Json;
using UniRx;

namespace csmvvm.view {

    interface IBaseView {
        void Request (HttpListenerRequest req, HttpListenerResponse res);
    }

    class ApiResponse {
        public int StatusCode;
        public object Json;
    }

    abstract class BaseView : IBaseView {

        public abstract void Request (HttpListenerRequest req, HttpListenerResponse res);

        protected void writeResponse (HttpListenerResponse res, ApiResponse response) {
            string jsonString = JsonConvert.SerializeObject (response.Json);
            Ulog.Debug (jsonString);

            byte[] content = Encoding.UTF8.GetBytes (jsonString);
            res.OutputStream.Write (content, 0, content.Length);
            res.StatusCode = response.StatusCode;
            res.Close ();
        }
    }
}