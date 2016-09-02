using System;

#if __ANDROID__
namespace Mambo.Android
#else
namespace Mambo.iOS
#endif
{
    public class FFImageCustomLogger : FFImageLoading.Helpers.IMiniLogger
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        public void Error(string errorMessage, Exception ex)
        {
            Error(errorMessage + Environment.NewLine + ex);
        }
    }
}

