using System;
using UnityEngine;

namespace ZHFSM
{
    
    public class Timer : ITimer
    {
        public long startTime;
        /// <summary>
        /// 状态机执行的时间,单位毫秒
        /// </summary>
        public long Elapsed => CurTime - startTime;
        
        /// <summary>
        /// 当前时间,单位毫秒
        /// </summary>
        private long CurTime
        {
            get { return (long)(Time.time * 1000); }
        }

        public Timer()
        {
            startTime = CurTime;
        }

        public void Reset()
        {
            startTime = CurTime;
        }

        public static bool operator >(Timer timer, float duration) => timer.Elapsed > duration;

        public static bool operator <(Timer timer, float duration) => timer.Elapsed < duration;

        public static bool operator >=(Timer timer, float duration) => timer.Elapsed >= duration;

        public static bool operator <=(Timer timer, float duration) => timer.Elapsed <= duration;
    }
}