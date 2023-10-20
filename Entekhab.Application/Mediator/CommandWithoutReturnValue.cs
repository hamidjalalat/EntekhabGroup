//namespace Dtx.Mediator
//{
//	public class CommandWithoutReturnValue :
//		object, MediatR.IRequest<FluentResults.Result>
//	{
//		public CommandWithoutReturnValue() : base()
//		{
//		}
//	}
//}

namespace Mediator
{
	public interface ICommandWithoutReturnValue : MediatR.IRequest<FluentResults.Result>
	{
	}
}
