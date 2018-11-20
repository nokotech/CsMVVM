using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using csmvvm.presenter;
using csmvvm.utils;
using csmvvm.viewmodel;
using UniRx;

namespace csmvvm.view {

    interface ISampleView : IBaseView { }

    class SampleView : BaseView, ISampleView {

        private ISamplePresenter presenter = new SamplePresenter ();
        private IDisposable disposable;

        public override void Request (HttpListenerRequest req, HttpListenerResponse res) {
            disposable = presenter.SampleViewResponseObserver ().Subscribe (viewmodel => {
                Ulog.Debug (viewmodel.ToString ());
                disposable.Dispose ();
            });
            presenter.Call ();
            writeResponse (res, new ApiResponse { Json = new SampleViewResponse { Id = 0, Name = "name" }, StatusCode = 200 });
        }
    }
}