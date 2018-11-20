using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using csmvvm.utils;
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
            Ulog.Debug ("Start HttpServer.");

            try {
                HttpListener listener = new HttpListener ();
                listener.Prefixes.Add ("http://localhost:10000/");
                listener.Start ();

                while (true) {
                    HttpListenerContext context = listener.GetContext ();
                    HttpListenerRequest req = context.Request;
                    HttpListenerResponse res = context.Response;
                    routing (req).Request (req, res);
                    Ulog.Debug ("==========================");
                }

            } catch (Exception ex) {
                Ulog.Debug ("Error: " + ex.Message);
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