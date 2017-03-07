using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Engine.Handlers;
using Dealership.Engine.Handlers.Contracts;
using Dealership.Engine.IOProvider;
using Dealership.Models;
using Ninject.Modules;

namespace Dealership
{
    public class DealershipModule : NinjectModule
    {        private const string RegisterHandlerName = "RegisterHandler";
        private const string LoginHandlerName = "LoginHandler";
        private const string LogoutHandlerName = "LogoutHandler";
        private const string AddVehicleHandlerName = "AddVehicleHandler";
        private const string RemoveVehicleHandlerName = "RemoveVehicleHandler";
        private const string AddCommentHandlerName = "AddCommentHandler";
        private const string RemoveCommentHandlerName = "RemoveCommentHandler";
        private const string ShowUsersHandlerName = "ShowUsersHandler";
        private const string ShowVehiclesHandlerName = "ShowVehiclesHandler";
        public override void Load()
        {

            Bind<IIOProvider>().To<IOProvider>();

            Bind<ICommand>().To<Command>();
            Bind<IComment>().To<Comment>();

            this.Bind<IVehicle>().To<Car>();
            this.Bind<IVehicle>().To<Motorcycle>();
            this.Bind<IVehicle>().To<Truck>();
            Bind<IUser>().To<User>();
            Bind<ICar>().To<Car>();
            Bind<ITruck>().To<Truck>();
            Bind<IMotorcycle>().To<Motorcycle>();

            Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
            

            this.Bind<ICommandHandler>().To<RegisterUserHandler>().Named(RegisterHandlerName);
            this.Bind<ICommandHandler>().To<LoginHandler>().Named(LoginHandlerName);
            this.Bind<ICommandHandler>().To<LogoutHandler>().Named(LogoutHandlerName);
            this.Bind<ICommandHandler>().To<AddVehicleHandler>().Named(AddVehicleHandlerName);
            this.Bind<ICommandHandler>().To<RemoveVehicleHandler>().Named(RemoveVehicleHandlerName);
            this.Bind<ICommandHandler>().To<AddComment>().Named(AddCommentHandlerName);
            this.Bind<ICommandHandler>().To<RemoveCommentHandler>().Named(RemoveCommentHandlerName);
            this.Bind<ICommandHandler>().To<ShowAllUsersHandler>().Named(ShowUsersHandlerName);
            this.Bind<ICommandHandler>().To<ShowVehicles>().Named(ShowVehiclesHandlerName);
        }
    }
}
