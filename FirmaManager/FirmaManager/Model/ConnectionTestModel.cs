using System;
using System.IO;
using FimaManager.Business;
using FimaManager.Common.Configs;
using FirmaManager.Common;
using Microsoft.Extensions.Configuration;

namespace FirmaManager.Model
{
    public class ConnectionTestModel
    {
        public ConnectionTestModel()
        {
            try
            {
                Configurator.Connectionstring = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile(Constants.CONFIGS_JSON_PATH, false)
                .Build().GetConnectionString(Constants.CONNECTIONSTRING_NAME);

                if(string.IsNullOrEmpty(Configurator.Connectionstring))
                {
                    WasConnectionSuccessful = false;
                    FailureMessage = Constants.CONNECTIONSTRING_EMPTY;
                    return;
                }

                PersonManager.CheckConnection(Configurator.Connectionstring);

                WasConnectionSuccessful = true;
            }
            catch (Exception ex)
            {
                FailureMessage = ex.Message;
                WasConnectionSuccessful = false;
            }
        }

        public string FailureMessage { get; }

        public string ConnectionString { get; }

        public bool WasConnectionSuccessful { get; }
    }
}