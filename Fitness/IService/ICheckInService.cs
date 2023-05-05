using Fitness.Data;

namespace Fitness.IService
{
	public interface ICheckInService
	{
		Task SaveAsync(CheckIns checkIns);
	}
}
