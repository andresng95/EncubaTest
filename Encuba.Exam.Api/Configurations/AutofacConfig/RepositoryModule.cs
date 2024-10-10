
using Autofac;
using Encuba.Exam.Domain.Interfaces.Repositories;
using Encuba.Exam.Infrastructure.Cryptography;
using Encuba.Exam.Infrastructure.Repositories;
using Express.Trades.Security.Domain.Interfaces.Cryptography;

namespace   Encuba.Exam.Api.Configurations.AutofacConfig;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserRepository>()
            .As<IUserRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<UserPublicAccessTokenRepository>()
            .As<IUserPublicAccessTokenRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<PublicAccessTokenRepository>()
            .As<IPublicAccessTokenRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<BCryptCryptographyHelper >()
            .As<IBCryptCryptographyHelper >()
            .InstancePerLifetimeScope();
      
    }
}