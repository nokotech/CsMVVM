using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using csmvvm.utils;

namespace csmvvm.network {

    public interface IHttp : IBaseNetwork<IHttp> {
        T CallApp<T> (String url);
    }

    /// <summary>
    /// 【シングルトン】リポジトリの抽象クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Http : BaseNetwork<IHttp>, IHttp {

        private Http () { }

        public static IHttp GetInstance () {
            if (instance == null) {
                instance = new Http ();
            }
            return instance;
        }

        /// <summary>
        /// API共通処理
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public T CallApp<T> (String url) {
            Ulog.Debug (url);
            WebRequest request = WebRequest.Create (url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse ();
            StreamReader reader = new StreamReader (response.GetResponseStream ());
            string responseFromServer = reader.ReadToEnd ();
            Ulog.Debug (((HttpWebResponse) response).StatusDescription);
            reader.Close ();
            response.Close ();
            Ulog.Debug (responseFromServer);
            return Json<T> (responseFromServer);
        }

        /// <summary>
        /// JSONパース
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T Json<T> (String json) {
            try {
                using (var stream = new MemoryStream (Encoding.UTF8.GetBytes (json))) {
                    var serializer = new DataContractJsonSerializer (typeof (T));
                    var deserialized = (T) serializer.ReadObject (stream);
                    Ulog.Debug (deserialized.ToString ());
                    return deserialized;
                }
            } catch (Exception e) {
                Ulog.Debug (e.Message);
                throw new Exception ();
            }
        }
    }
}