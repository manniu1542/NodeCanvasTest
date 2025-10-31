using ZHFSM;
using UnityEngine;
public partial class PlayerMovementController : StateMachineScriptController
{
//Don't delete or modify the #region & #endregion
#region Method
	[State("roll")]
	private void on_roll_execute(State state, StateExecuteType type)
	{
		if (type == StateExecuteType.OnEnter)
		{
			animPlayer.RequestTransition("Roll");
			PauseService("ProcessInput");
		}
		else if (type == StateExecuteType.OnExit)
		{
			ContinueService("ProcessInput");
		}
	}
	[CanExit("roll","褰揜oll鐨勫姩鐢绘挱鏀惧畬鎴愭椂鑷鍔ㄥ洖鍒癐dle鐘舵")]
	private bool can_roll_exit(State state)
	{
		return animPlayer.CurrentFinishPlaying;
	}

#endregion Method
}
