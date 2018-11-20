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
using csmvvm.translater;
using csmvvm.viewmodel;
using UniRx;

namespace csmvvm.usecase {

    public interface ISampleUsecase : IBaseUsecase<ISampleUsecase> {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Subject<SampleEntity> GetStatus ();
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
        private Subject<SampleEntity> subject = new Subject<SampleEntity> ();
        public Subject<SampleEntity> GetStatus () {
            Task.Run (() => {
                SampleResponse entity = SampleRepositry.GetInstance ().GetStatus ();
                SampleEntity response = SampleTranslater.TranslateSample1 (entity);
                subject.OnNext (response);
            });
            return subject;
        }
    }
}