using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Modules.FlyingCenterSystem
{
    public class FlyingCenterSystem
    {
       AnonymousUserFacade _anonymousUserFacade = null;
       LoggedInAdministratorFacade _loggedInAdministratorFacade = null;
       LoggedInAirlineFacade _loggedInAirlineFacade = null;
       LoggedInCustomerFacade _loggedInCustomerFacade = null;

        private static readonly FlyingCenterSystem instance = new FlyingCenterSystem();


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static FlyingCenterSystem()
        {
        }

        private FlyingCenterSystem()
        {
        }

        public static FlyingCenterSystem Instance
        {
            get
            {
                return instance;
            }
        }

        public T GetFacade<T>()
        {
            T obj = default(T);
            Type facadeType = typeof(T);
            if (facadeType == typeof(ILoggedInCustomerFacade))
            {
                if (_loggedInCustomerFacade is null)
                {
                    _loggedInCustomerFacade = new LoggedInCustomerFacade();
                }
                obj = (T)(object)_loggedInCustomerFacade;
            }
            else if (facadeType == typeof(ILoggedInAirLineFacade))
            {
                if (_loggedInAirlineFacade is null)
                {
                    _loggedInAirlineFacade = new LoggedInAirlineFacade();
                }
                obj = (T)(object)_loggedInAirlineFacade;
            }
            else if (facadeType == typeof(ILoggedInAdministratorFacade))
            {
                if (_loggedInAdministratorFacade is null)
                {
                    _loggedInAdministratorFacade = new LoggedInAdministratorFacade();
                }
                obj = (T)(object)_loggedInAdministratorFacade;
            }
            else if (facadeType == typeof(IAnonymousUserFacade))
            {
                if (_anonymousUserFacade is null)
                {
                    _anonymousUserFacade = new AnonymousUserFacade();
                }
                obj = (T)(object)_anonymousUserFacade;
            }

            return obj;
        }
    }
}
