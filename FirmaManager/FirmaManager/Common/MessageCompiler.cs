using System;

namespace FirmaManager.Common
{
    public static class MessageCompiler
    {
        public static string GetTechnicalMessageFromException(Exception ex)
        {
            return $"Dies ist ein technisches Problem:\n{GetMessage(ex)}\nBitte rufen sie Basil Döring an.";
        }

        private static string GetMessage(Exception ex)
        {
            return ex != null
                ? $"{ex.Message}\n{GetMessage(ex.InnerException)}"
                : string.Empty;
        }
    }
}