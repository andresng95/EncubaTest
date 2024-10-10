using MediatR;
using System.Reflection;
using Autofac;
using Encuba.Exam.Application.Commands.UserCommands;
using Module = Autofac.Module;
namespace  Encuba.Exam.Api.Configurations.AutofacConfig;

public class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(typeof(CreateUserCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
    }
}