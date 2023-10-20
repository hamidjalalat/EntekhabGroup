//namespace Dtx.Mediator
//{
//	public class CommandWithReturnValue<TValue> :
//		object, MediatR.IRequest<FluentResults.Result<TValue>>
//	{
//		public CommandWithReturnValue() : base()
//		{
//		}
//	}
//}

namespace Mediator
{
	public interface IRequest :
		MediatR.IRequest<FluentResults.Result>
	{
	}

	public interface IRequest<TReturnValue> :
		MediatR.IRequest<FluentResults.Result<TReturnValue>>
	{
	}
}
