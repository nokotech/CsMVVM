using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using csmvvm.viewmodel;
using UniRx;

namespace csmvvm.usecase {

    interface ISampleUsecase {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Subject<string> GetStatus ();
    }

    /// <summary>
    /// Singlton: Sampleのユースケース
    /// </summary>
    class SampleUsecase : BaseUsecase, ISampleUsecase {

        private Subject<string> subject = new Subject<string> ();
        private static ISampleUsecase _singleInstance = new SampleUsecase ();

        private SampleUsecase () { }

        public static ISampleUsecase GetInstance () {
            return _singleInstance;
        }

        public Subject<string> GetStatus () {
            subject.OnNext ("AAAAAAAAAAA");
            return subject;
        }
    }
}