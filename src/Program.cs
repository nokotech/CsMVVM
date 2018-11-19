using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using csmvvm.view;
using Newtonsoft.Json;
using UniRx;

namespace csmvvm {

    class Program {

        Program () { }

        /// <summary>
        /// サーバー起動
        /// </summary>
        /// <param name="args"></param>
        static void Main (string[] args) {
            Console.WriteLine ("Start HttpServer.");

            try {
                HttpListener listener = new HttpListener ();
                listener.Prefixes.Add ("http://localhost:10000/");
                listener.Start ();

                while (true) {
                    HttpListenerContext context = listener.GetContext ();
                    HttpListenerRequest req = context.Request;
                    HttpListenerResponse res = context.Response;
                    routing (req).Request (req, res);
                }

            } catch (Exception ex) {
                Console.WriteLine ("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// ルーティング
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private static IBaseView routing (HttpListenerRequest req) {
            switch (req.RawUrl) {
                case "/":
                    return new SampleView ();
                default:
                    return new SampleView ();
            }
        }
    }
}