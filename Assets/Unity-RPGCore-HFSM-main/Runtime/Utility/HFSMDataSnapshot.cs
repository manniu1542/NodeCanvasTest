using System;
using System.Collections.Generic;
using System.Linq;

namespace ZHFSM
{
    /// <summary>
    /// 层次状态机的快照数据
    /// </summary>
    [Serializable]
    public class HFSMDataSnapshot
    {
        /// <summary>
        /// 这一帧状态机执行的时间
        /// </summary>
        public long elapsed;

        /// <summary>
        /// 状态机的名称id,从最终执行的状态=>Root  (TODO:可以从配置里面获取到)
        /// </summary>
        public string[] arrStateMachineName;

        /// <summary>
        /// 当前执行的状态名
        /// </summary>
        public string curStateName;

        /// <summary>
        /// 状态机的参数
        /// </summary>
        public float[] arrParameters;
    }

    /// <summary>
    /// 状态机的快照数据辅助类
    /// </summary>
    public static class HFSMDataSnapshotHelper
    {
        public static HFSMDataSnapshot GetSnapshot(StateMachineExecutor executor)
        {
            HFSMDataSnapshot snapshot = new HFSMDataSnapshot();

            State curState = executor.currentExecuteState;

            snapshot.elapsed = curState.timer.Elapsed;
            snapshot.curStateName = curState.id;
            var parameters = executor.scriptController.parameters.ToList();
            snapshot.arrParameters = new float[parameters.Count];
            for (int i = 0; i < parameters.Count; i++)
            {
                snapshot.arrParameters[i] = parameters[i].Value.baseValue;
            }

            //TODO:可以有个配置
            List<string> listStateMachineName = new List<string>();

            StateMachine sm = curState.parentStateMachine;
            while (sm != null && sm.id != "Root")
            {
                listStateMachineName.Add(curState.parentStateMachine.id);
                sm = sm.parentStateMachine;
            }

            snapshot.arrStateMachineName = listStateMachineName.ToArray();


            return snapshot;
        }
        
        public static void SetSnapshot(StateMachineExecutor executor, HFSMDataSnapshot snapshot)
        {
            StateMachine rootState = executor.rootStateMachine;
            StateMachine endState = rootState;
            for (int i = snapshot.arrStateMachineName.Length - 1; i >= 0; i--)
            {
                endState = endState.GetStateByName<StateMachine>(snapshot.arrStateMachineName[i]);
            }

            State state = endState.GetStateByName<State>(snapshot.curStateName);
            
            state.timer.Reset();
            state.timer.startTime += snapshot.elapsed;
            
            
            var parameters = executor.scriptController.parameters.ToList();
            for (int i = 0; i < snapshot.arrParameters.Length; i++)
            {
                parameters[i].Value.baseValue = snapshot.arrParameters[i];
            }
      
            
            executor.FillExecuteStateStack(state);
            
            
        }

        public static T GetStateByName<T>(this StateMachine sm, string name) where T : StateBase
        {
            return sm.states.Find(sm => sm.id.Equals(name)) as T;
        }
    }
}