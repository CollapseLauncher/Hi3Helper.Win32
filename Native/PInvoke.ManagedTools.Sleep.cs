using Hi3Helper.Win32.Native.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hi3Helper.Win32.Native
{
    public static partial class PInvoke
    {
        public static CancellationTokenSource? _preventSleepToken;
        private static bool _preventSleepRunning;

        public static async void RestoreSleep()
        {
            // Return early if token is disposed/already cancelled
            if (_preventSleepToken == null || _preventSleepToken.IsCancellationRequested)
                return;
            await (_preventSleepToken?.CancelAsync() ?? Task.CompletedTask);
        }

        public static async void PreventSleep(ILogger? logger = null)
        {
            // Only run this loop once
            if (_preventSleepRunning) return;

            // Initialize instance if it's still null
            _preventSleepToken ??= new CancellationTokenSource();

            // If the instance cancellation has been requested, return
            if (_preventSleepToken.IsCancellationRequested) return;

            // Set flag
            _preventSleepRunning = true;

            try
            {
                logger?.LogWarning("[InvokeProp::PreventSleep()] Starting to prevent sleep!");
                while (!_preventSleepToken.IsCancellationRequested)
                {
                    // Set ES to SystemRequired every 60s
                    SetThreadExecutionState(ExecutionState.EsContinuous | ExecutionState.EsSystemRequired);
                    await Task.Delay(60000, _preventSleepToken.Token);
                }
            }
            catch (TaskCanceledException)
            {
                //do nothing, its cancelled :)
            }
            catch (Exception ex)
            {
                logger?.LogError($"[InvokeProp::PreventSleep()] Errors while preventing sleep!\r\n{ex}");
            }
            finally
            {
                // Reset flag and ES 
                _preventSleepRunning = false;
                SetThreadExecutionState(ExecutionState.EsContinuous);
                logger?.LogWarning("[InvokeProp::PreventSleep()] Stopped preventing sleep!");

                // Null the token for the next time method is called
                _preventSleepToken = null;
            }
        }
    }
}
