using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WindowsAccessBridgeInterop;
using WindowsAccessBridgeInterop.Win32;

namespace JABConsole
{
    public class JABController
    {
        private readonly HwndCache _windowCache = new HwndCache();
        
        AccessBridge _accessBridge = new AccessBridge();

        public void init()
        {
            InvokeLater(() =>
            {

                _accessBridge.Initialize();

            });
        }


            public void InvokeLater(Action action)
            {
                action.BeginInvoke(null, null);      
            }

            public JABController InicializarDriver()
            {
                _accessBridge = new AccessBridge();
                _accessBridge.Initilized += _bridge_Initilized;

                _accessBridge.Initialize();

            _accessBridge.Initilized += (sender, args) => {
            };

            return this;
        }

        public void CheckJVM()
        {
            NativeMethods.EnumWindows(delegate (IntPtr wnd, IntPtr param)
            {
                var w = wnd;
                var p = param;

                if (w.ToString() == "788752")
                {
                    
                }


                Console.WriteLine(w + " " + w.ToString());

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);


            _accessBridge.Initialize();
            
            var jvms = EnumJvms();


            Console.WriteLine(jvms.Count);
        }

        public List<AccessibleJvm> EnumJvms()
        {
            return _accessBridge.EnumJvms(hwnd => _windowCache.Get(_accessBridge, hwnd));
        }

        private void _bridge_Initilized(object sender, EventArgs e)
        {
            Console.WriteLine("Driver Inicializado !");
        }



        #region Event Handlers

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        private void EventsOnPropertyChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source, string property, string oldValue, string newValue)
        {
            // Note: It seems this event is never fired. Maybe this is from older JDKs?
         
        }

        private void EventsOnPropertyVisibleDataChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source)
        {
         
        }

        private void EventsOnPropertyValueChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source, string oldValue, string newValue)
        {
         
        }

        private void EventsOnPropertyTextChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source)
        {
         
        }

        private void EventsOnPropertyStateChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source, string oldState, string newState)
        {
         
        }

        private void EventsOnPropertySelectionChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source)
        {
            
        }

        private void EventsOnPropertyNameChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source, string oldName, string newName)
        {
            
        }

        private void EventsOnPropertyDescriptionChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source, string oldDescription, string newDescription)
        {
            
        }

        private void EventsOnPropertyCaretChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source, int oldPosition, int newPosition)
        {
            
        }

        private void EventsOnPropertyActiveDescendentChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source, JavaObjectHandle oldActiveDescendent, JavaObjectHandle newActiveDescendent)
        {
            
        }

        private void EventsOnPropertyChildChange(int vmId, JavaObjectHandle evt, JavaObjectHandle source, JavaObjectHandle oldChild, JavaObjectHandle newChild)
        {
        }

        private void EventsOnMouseReleased(int vmId, JavaObjectHandle evt, JavaObjectHandle source)
        {
         
        }

        private void EventsOnMousePressed(int vmId, JavaObjectHandle evt, JavaObjectHandle source)
        {
            
        }

        private void EventsOnMouseExited(int vmId, JavaObjectHandle evt, JavaObjectHandle source)
        {
            
        }


      
      

        
        public void LogErrorMessage(Exception error)
        {
           
        }

      


    }
    // ReSharper restore UnusedParameter.Local
    // ReSharper restore UnusedMember.Local

    #endregion

    public class MessageInfo
    {
        public Action OnDisplay { get; set; }
    }

    public class EventInfo
    {
        public EventInfo()
        {
        }

        public EventInfo(string eventName, AccessibleNode source, string oldValue = "", string newValue = "")
        {
            EventName = eventName;
            Source = source;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string EventName { get; set; }
        public AccessibleNode Source { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Action OnDisplay { get; set; }
    }

    public class HwndCache
    {
        private readonly ConcurrentDictionary<IntPtr, AccessibleWindow> _cache = new ConcurrentDictionary<IntPtr, AccessibleWindow>();

        public AccessibleWindow Get(AccessBridge accessBridge, IntPtr hwnd)
        {
            return _cache.GetOrAdd(hwnd, key => accessBridge.CreateAccessibleWindow(key));
        }

        public void Clear()
        {
            _cache.Clear();
        }

        public IEnumerable<AccessibleWindow> Windows
        {
            get { return _cache.Values.Where(x => x != null); }
        }
    }
}
