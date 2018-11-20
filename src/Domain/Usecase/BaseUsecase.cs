using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using csmvvm.viewmodel;
using UniRx;

namespace csmvvm.usecase {

    public interface IBaseUsecase<T> where T : class { }

    /// <summary>
    /// 【シングルトン】ユースケースの抽象クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseUsecase<T> where T : class, IBaseUsecase<T> {
        protected static T instance;
        protected BaseUsecase () { }
    }
}