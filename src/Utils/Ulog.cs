using System;
using System.Diagnostics;
using UnityEngine;

namespace csmvvm.utils {
    /// <summary>
    /// ログ
    /// </summary>
    public class Ulog {

        /// <summary>
        /// DEBUGログ
        /// </summary>
        /// <param name="str"></param>
        public static void Debug (string str) {
            StackFrame callerFrame = new StackFrame (1);
            string className = callerFrame.GetMethod ().ReflectedType.Name;
            string methodName = callerFrame.GetMethod ().Name;
            string log = String.Format ("[{0}: {1}] {2}", className, methodName, str);
            Console.WriteLine (log);
        }
    }
}