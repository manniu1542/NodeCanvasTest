
namespace ZHFSM
{
	public interface ITimer
	{
		long Elapsed
		{
			get;
		}

		void Reset();
	}
}

