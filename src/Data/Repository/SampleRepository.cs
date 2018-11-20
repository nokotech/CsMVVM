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
        SampleEntity GetStatus ();
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

        public SampleEntity GetStatus () {
            String url = "https://raw.githubusercontent.com/nokotech/iOSMVVM/master/MockData/sample.json";
            SampleEntity response = Http.GetInstance ().CallApp<SampleEntity> (url);
            Ulog.Debug (response.ToString ());
            return response;
        }
    }
}