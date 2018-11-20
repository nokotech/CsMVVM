using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csmvvm.entity;
using csmvvm.repository;
using csmvvm.viewmodel;
using UniRx;

namespace csmvvm.usecase {

    public interface ISampleUsecase : IBaseUsecase<ISampleUsecase> {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Subject<string> GetStatus ();
    }

    /// <summary>
    /// Singlton: Sampleのユースケース
    /// </summary>
    public class SampleUsecase : BaseUsecase<ISampleUsecase>, ISampleUsecase {

        private SampleUsecase () { }

        public static ISampleUsecase GetInstance () {
            if (instance == null) {
                instance = new SampleUsecase ();
            }
            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        private Subject<string> subject = new Subject<string> ();
        public Subject<string> GetStatus () {
            Task.Run (() => {
                SampleEntity entity = SampleRepositry.GetInstance ().GetStatus ();
                subject.OnNext (entity.Result);
            });
            return subject;
        }
    }
}