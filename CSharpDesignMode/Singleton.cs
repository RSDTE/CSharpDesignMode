using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDesignMode
{
    public class Singleton
    {
        private static Singleton uniqueInstance;
        private Singleton() {

        }

        /// <summary>
        /// 原始设计
        /// </summary>
        /// <returns></returns>
        //public static Singleton GetSingleton() {
        //    if (uniqueInstance is null)
        //        uniqueInstance = new Singleton();
        //    return uniqueInstance;
        //}

        private static readonly object locker = new object();

        /// <summary>
        /// 线程安全
        /// </summary>
        /// <returns></returns>
        public static Singleton GetSingleton() {
            lock (locker) {
                if (uniqueInstance is null)
                    uniqueInstance = new Singleton();
            }
            return uniqueInstance;
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance() {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null) {
                lock (locker) {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null) {
                        uniqueInstance = new Singleton();
                    }
                }
            }
            return uniqueInstance;
        }

        #region test property

        public int Age { get; set; } = 12;
        public string Name { get; set; } = "zhang san";

        #endregion

    }
}
