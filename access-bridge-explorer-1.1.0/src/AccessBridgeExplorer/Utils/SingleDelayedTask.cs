// Copyright 2016 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Timers;

namespace AccessBridgeExplorer.Utils {
  /// <summary>
  /// Execution of callbacks driven by a queue with a single element. Each new
  /// posted callback overrides the previously enqueued callback. The callback
  /// executes on a thread of the default <see
  /// cref="System.Threading.ThreadPool"/>.
  /// </summary>
  public class SingleDelayedTask {
    private readonly Timer _timer = new Timer();
    private ElapsedEventHandler _currentHandler;

    public SingleDelayedTask() {
      _timer.AutoReset = false;
    }

    /// <summary>
    /// Enqeue <paramref name="callback"/> to be executed after the specified
    /// <paramref name="delay"/>. The currently enqueued callback is removed
    /// from the queue and won't be executed.
    /// </summary>
    public void Post(TimeSpan delay, Action callback) {
      Cancel();

      _currentHandler = (obj, args) => {
        callback();
      };
      _timer.Elapsed += _currentHandler;
      _timer.Interval = delay.TotalMilliseconds;
      _timer.Start();
    }

    /// <summary>
    /// Cancels the currently enqueued delayed task if there is one.
    /// </summary>
    public void Cancel() {
      _timer.Stop();
      if (_currentHandler != null) {
        _timer.Elapsed -= _currentHandler;
        _currentHandler = null;
      }
    }
  }
}