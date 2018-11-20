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
        Subject<SampleViewModel> SampleViewModelObserver ();
    }

    class SamplePresenter : BasePresenter, ISamplePresenter {

        /// <summary>
        /// 
        /// </summary>
        private Subject<SampleViewModel> sampleViewModel = new Subject<SampleViewModel> ();

        /// <summary>
        /// コール
        /// </summary>
        public void Call () {
            IDisposable disposable = null;
            disposable = SampleUsecase.GetInstance ().GetStatus ().Subscribe (entity => {
                Ulog.Debug ("");
                SampleViewModel json = new SampleViewModel { Id = entity.Id, Name = entity.Name };
                sampleViewModel.OnNext (json);
                disposable.Dispose ();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Subject<SampleViewModel> SampleViewModelObserver () {
            return sampleViewModel;
        }
    }
}