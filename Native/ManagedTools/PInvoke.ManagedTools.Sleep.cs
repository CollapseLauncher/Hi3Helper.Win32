using Hi3Helper.Win32.Native.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hi3Helper.Win32.Native
{
    public static partial class PInvoke
    {
        public static  CancellationTokenSource? _preventSleepToken;
        private static bool                     _preventSleepRunning;
        private static ILogger?                 _logger;

        public static async void RestoreSleep()
        {
            // Return early if token is disposed/already cancelled
            if (_preventSleepToken == null || _preventSleepToken.IsCancellationRequested)
                return;
            _logger?.LogInformation($"[InvokeProp::RestoreSleep()] Called by{new System.Diagnostics.StackTrace()}");
            await _preventSleepToken.CancelAsync();
        }

        public static async void PreventSleep(ILogger? logger = null)
        {
            // Only run this loop once
            if (_preventSleepRunning) return;
            _logger = logger;

            // Initialize instance if it's still null
            _preventSleepToken ??= new CancellationTokenSource();

            // If the instance cancellation has been requested, return
            if (_preventSleepToken.IsCancellationRequested) return;

            // Set flag
            _preventSleepRunning = true;

            try
            {
                _logger?.LogWarning("[InvokeProp::PreventSleep()] Starting to prevent sleep!");
                _logger?.LogInformation($"[InvokeProp::PreventSleep()] Called by{new System.Diagnostics.StackTrace()}");
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
                _logger            = null;
            }
        }
    }
}
