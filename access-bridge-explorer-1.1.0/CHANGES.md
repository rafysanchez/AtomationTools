# Access Bridge Explorer Version History


## Version 1.1

* Fix issue where some events are lost
* Show count of active Java Objects in the status bar
* Add a button to manually force a Garbage Collection in the status bar
* Improve support for multi-monitor setups
* Add options (Options | Component Overlay | Hook ...) to enable/disable global
  keyboard hooks (Ctrl+\\ and Ctrl+Shft+\\)
* Improve CodeGen to support XML doc comments in generated code
* Add option (Options | Component Overlay | Synchronize Tree) to synchronize
  the Accessibility Tree when the Component Overlay is updated.


## Version 1.0

* Add options (Options | Component Overlay | Activate on xxx) to offer finer
  grained control on when to update the component overlay window
  * To simulate screen readers, a new options allows activating the component
    overlay when the input focus
  * There is also an option to activate the overlay when the active descendant
    of a container changes (e.g. when the selected item of a list changes)
* Add options (Options | Component Overlay | Show xxx) to allow choosing
  between a tooltip window and/or semi-transparent overlay when displaying
  the component overlay.
* Auto-refresh list of running application bt reguarly polling the list
  of Windows on the system.
* Display the details of errors when double-clicking an error in the
  "Messages" window
* "Component Properties" view is improved for tables. It now contains headers,
  selections, children.
* "Component Properties" view now contains the list of children
* When the row selection in the "Component Properties" view switches to
  a property associated with a screen reactangle, update the component
  overlay location to that of the rectangle.
* A few more properties shown in the "Component Properties" view
* Settings/options are saved in a the 
  "%APPDATA%\Roaming\AccessBridgeExplorer\settings.txt" file
* Fix a bug where the Text of text components contains a "..." suffix,
  incorrectly indicating there was more text.


## Version 0.9.3

* "Component Properties" view
  * Improve performance as sub-properties are evaluated on demand (i.e. when
    node is expanded)
  * For "Text" component, add a node to expose the full text content
  * Add a "Focused element" entry
* Fix bug on Windows 7, where component overlay window would flicker
* CodeGen: Improve generated code for "out" parameters
* CodeGen: Generate less code when wrapper classes are not needed


## Version 0.9.2

* Add support for loading the legacy Windows Access Bridge DLL (version 1.x),
  required to work with older Java Application (e.g. OpenOffice 3.x and
  earlier)
* The Windows Access Bridge P/Invoke wrapper is now automatically generated.
  This was required to make it easier to support the legacy access bridge DLL.


## Version 0.9.1

* Add notification Window when a new version of Access Bridge Explorer is
  available


## Version 0.9.0

* Initial release
