using System;
using UnityEngine;

namespace RPGCore.AI.HFSM
{
    /// <summary>
    /// 状态机Controller配置数据
    /// </summary>
    [System.Serializable]
	public class StateMachineControllerConfig
    {
        public bool CustomFilePath;
        public string FilePath;
        public bool UseNamespace;
        public string Namespace;
        public bool DisperseGenerate;
        public bool DisperseAll;
    }
}