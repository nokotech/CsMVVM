using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csmvvm.entity;
using csmvvm.network;
using csmvvm.utils;
using csmvvm.viewmodel;
using UniRx;
using UnityEngine;

namespace csmvvm.repository {

    public interface ISampleRepository : IBaseRepository<ISampleRepository> {
        SampleResponse GetStatus ();
    }

    /// <summary>
    /// Singlton: Sampleのユースケース
    /// </summary>
    public class SampleRepositry : BaseRepository<ISampleRepository>, ISampleRepository {

        private SampleRepositry () { }

        public static ISampleRepository GetInstance () {
            if (instance == null) {
                instance = new SampleRepositry ();
            }
            return instance;
        }

        public SampleResponse GetStatus () {
            String url = "http://localhost:3000/ping";
            SampleResponse response = Http.GetInstance ().CallApp<SampleResponse> (url);
            Ulog.Debug (response.ToString ());
            return response;
        }
    }
}