# Multiblockreplace for AutoCAD
A plug-in for AutoCAD that enables to replace multiple blocks by one block in one step.

## How to install
You can find installation instructions in the wiki pages of this project:

https://github.com/Fachstelle-Geoinformation-Winterthur/win_multiblockreplace/wiki#how-to-install

## How to use
After installation, the plug-in will load automatically on the startup of AutoCAD. If you have not configured the plug-in folder as a trusted folder, you will be asked by AutoCAD, if you want to load the plug-in nonetheless. In order to use this tool, you need to choose "Always Load" or "Load Once".

In order to use this tool, you first need to open the AutoCAD drawing that contains the multiple blocks which need to be replaced. While the drawing is open, you can start this tool by calling the command _WIN_MULTIBLOCKREPLACE_ on the AutoCAD _Command Line_:

![Call win_multiblockreplace tool in AutoCAD](/assets/call_win_multiblockreplace.png)

...

## Usable versions of AutoCAD
This plug-in has originally been compiled for and tested with AutoCAD 2017, but it should also work out-of-the-box with all subsequent versions of AutoCAD.

## Additional system requirements
.NET Framework version 4.5 (at least) is required (and of course the Windows version that runs it).
