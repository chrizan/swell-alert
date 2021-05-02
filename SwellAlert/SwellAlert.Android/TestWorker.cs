using Android.Content;
using AndroidX.Core.App;
using AndroidX.Work;

namespace SwellAlert.Droid
{
    public class TestWorker : Worker
    {
        private readonly Context _context;
        public TestWorker(Context context, WorkerParameters workerParameters) : base(context, workerParameters)
        {
            _context = context;
        }

        public override Result DoWork()
        {
            Android.Util.Log.Debug(nameof(TestWorker), $"{nameof(TestWorker)} executed");


            // Build the notification:
            var builder = new NotificationCompat.Builder(_context, "CHANNEL_ID")
                          .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                          .SetContentTitle("Swell Alert triggered") // Set the title
                          .SetSmallIcon(Resource.Drawable.test_icon)
                          .SetContentText("This is the content text for the Swell Alert notification"); // the message to display.

            // Finally, publish the notification:
            var notificationManager = NotificationManagerCompat.From(_context);
            notificationManager.Notify(333, builder.Build());

            return Result.InvokeSuccess();
        }
    }
}