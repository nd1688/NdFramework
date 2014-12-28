
namespace Nd.Framework.Commands
{
    /// <summary>
    /// 表示该接口实现类为命令处理程序
    /// </summary>
    /// <typeparam name="TCommand">命令</typeparam>
    public interface ICommandHandler<TCommand> : IHandler<TCommand>
        where TCommand : class,ICommand
    {
    }
}