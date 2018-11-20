using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using csmvvm.usecase;
using csmvvm.utils;
using csmvvm.viewmodel;
using UniRx;

namespace csmvvm.presenter {

    interface ISamplePresenter {
        void Call ();
        Subject<SampleViewResponse> SampleViewResponseObserver ();
    }

    class SamplePresenter : BasePresenter, ISamplePresenter {

        /// <summary>
        /// 
        /// </summary>
        private Subject<SampleViewResponse> sampleViewResponse = new Subject<SampleViewResponse> ();

        /// <summary>
        /// コール
        /// </summary>
        public void Call () {
            IDisposable disposable = null;
            disposable = SampleUsecase.GetInstance ().GetStatus ().Subscribe (str => {
                Ulog.Debug (str);
                SampleViewResponse json = new SampleViewResponse { Id = 0, Name = str };
                sampleViewResponse.OnNext (json);
                disposable.Dispose ();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Subject<SampleViewResponse> SampleViewResponseObserver () {
            return sampleViewResponse;
        }
    }
}