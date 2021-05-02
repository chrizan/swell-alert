using Android.Content;
using AndroidX.Work;

namespace SwellAlert.Droid
{
    public class TestWorker : Worker
    {
        private int messageNumber = 0;

        public TestWorker(Context context, WorkerParameters workerParameters) : base(context, workerParameters)
        {
        }

        public override Result DoWork()
        {
            Android.Util.Log.Debug(nameof(TestWorker), $"{nameof(TestWorker)} executed");
            AndroidNotificationManager.Instance.SendNotification(nameof(TestWorker), $"{nameof(TestWorker)} has sent notification #{messageNumber}");
            messageNumber++;
            return Result.InvokeSuccess();
        }
    }
}