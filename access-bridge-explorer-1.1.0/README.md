# Access Bridge Explorer

[Access Bridge Explorer](https://github.com/google/access-bridge-explorer) is
a Windows application that allows exploring, as well as interacting with, the
Accessibility tree of any Java applications that uses the
[Java Access Bridge](https://www.google.com/?gws_rd=ssl#q=java+access+bridge)
to expose their accessibility features, for example
[Android Studio](http://developer.android.com/sdk/index.html) and
[IntelliJ](https://www.jetbrains.com/idea/).

[Access Bridge Explorer](https://github.com/google/access-bridge-explorer)
provides features similar to the [Java Ferret](http://docs.oracle.com/javase/accessbridge/2.0.2/javaferret.htm)
and [Java Monkey](http://docs.oracle.com/javase/accessbridge/2.0.2/javamonkey.htm)
sample applications that were distributed as part of the
[Java Access Bridge](http://docs.oracle.com/javase/accessbridge/2.0.2/introduction.htm)
SDK when it was still distributed as a stand alone download.
[Access Bridge Explorer](https://github.com/google/access-bridge-explorer) integrates
both set of features in a single application, is more stable and has been tested
on recent versions of Windows (7, 8, 8.1 and 10) and offers a more modern and
advanced user interface.

[Access Bridge Explorer](https://github.com/google/access-bridge-explorer)
consumes the same API that Windows screen readers supporting the
[Java Access Bridge](https://www.google.com/?gws_rd=ssl#q=java+access+bridge)
(e.g. [nvda](http://www.nvaccess.org/),
[Jaws](http://www.freedomscientific.com/Products/Blindness/JAWS)) consume.
As such, [Access Bridge Explorer](https://github.com/google/access-bridge-explorer)
can be useful for validating accessibility support or identifying accessibility
issues of such Java applications without having to rely on a screen reader.

**Note**: [Access Bridge Explorer](https://github.com/google/access-bridge-explorer)
should not considered a screen reader, as it is merely a debugging tools
useful for developers of Java applications who want to validated/ensure
holistic support for screen readers in their application.

## Screenshot

![Access Bridge Explorer](/screenshots/AccessBridgeExplorer.png?raw=true "Access Bridge Explorer")

## Requirements

The [Access Bridge Explorer](https://github.com/google/access-bridge-explorer)
application requires 

* Windows 7 or later
* .NET 4.0 or later
* A version of the Java JRE/JDK that contains the Java Access Bridge, e.g. 
  Java SE Runtime Environment (JRE) Release 7 Update 6 (7u6) and later. It also works
  with earlier versions if the standalone Java Access Bridge SDK has been installed (see 
  [Installing Java Access Bridge](http://docs.oracle.com/javase/accessbridge/2.0.2/setup.htm)).


[Access Bridge Explorer](https://github.com/google/access-bridge-explorer) is compatible
with both the 32-bit and the 64-bit versions of Windows.

## Installation

* Download the latest release from https://github.com/google/access-bridge-explorer/releases/latest
* Extract files from the .zip files
* Execute the "AccessBridgeExplorer.exe" from the extracted folder
* Use the "Accessbility Tree" window to explore the UI components of running
  Java Applications. When applications are started or stopped, use the "Refresh"
  menu item (or the "F5" key) to refresh the "Accessibility Tree" window.
  
**Notes**

* If .NET 4.0 or later is not installed, either install .NET manually or follow
  the installation instructions.
* If the Java Access Bridge is not installed, the "Messages" window will contain
  an error about failing to load the "WindowsAccessBridge-32.dll" or "WindowsAccessBridge-64.dll".
  Please make sure to install the Java Access Bridge, either the "x86" or "x64" version depending
  on the Windows version (32-bit or 64-bit).
* If the "Accessbility Tree" window is empty even though some Java applications are running,
  make sure to enable the Java Access Bridge using the "jabswitch.exe" program from the JRE.

## Contributing

[Access Bridge Explorer](https://github.com/google/access-bridge-explorer)
is written in C#, the source code can be compiled with Visual Studio 2015,
or later, including
[Visual Studio 2015 Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx).

For more details, see [CONTRIBUTING.md](/CONTRIBUTING.md).

## Disclaimer

This is not an official Google product.
