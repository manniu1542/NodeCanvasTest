using System;

namespace ZHFSM
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class StateMachineControllerAttribute : Attribute
	{
		public string ControllerName;
	}
}