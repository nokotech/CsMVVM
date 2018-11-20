using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csmvvm.utils;
using UnityEngine;

namespace csmvvm.repository {

    public interface IBaseRepository<T> where T : class { }

    /// <summary>
    /// 【シングルトン】リポジトリの抽象クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> where T : class, IBaseRepository<T> {
        protected static T instance;
        protected BaseRepository () { }
    }
}