using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using csmvvm.viewmodel;
using UniRx;

namespace csmvvm.network {

    public interface IBaseNetwork<T> where T : class { }

    /// <summary>
    /// 【シングルトン】ネットワークの抽象クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseNetwork<T> where T : class, IBaseNetwork<T> {
        protected static T instance;
        protected BaseNetwork () { }
    }
}