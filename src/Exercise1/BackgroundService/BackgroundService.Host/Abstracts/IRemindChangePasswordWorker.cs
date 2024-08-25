namespace BackgroundService.Host.Abstracts;

interface IRemindChangePasswordWorker
{
    Task DoWorkAsync();
}
