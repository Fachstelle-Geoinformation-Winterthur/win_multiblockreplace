# Multiblockreplace for AutoCAD
A plug-in for AutoCAD that enables to replace multiple blocks by one block in one step.

## How to install
You can find installation instructions in the wiki pages of this project:

https://github.com/Fachstelle-Geoinformation-Winterthur/win_multiblockreplace/wiki#how-to-install

## How to use
After installation, the plug-in will load automatically on the startup of AutoCAD. If you have not configured the plug-in folder as a trusted folder, you will be asked by AutoCAD, if you want to load the plug-in nonetheless. In order to use this tool, you need to choose "Always Load" or "Load Once".

In order to use this tool, you first need to open the AutoCAD drawing that contains the multiple blocks which need to be replaced. While the drawing is open, you can start this tool by calling the command _WIN_MULTIBLOCKREPLACE_ on the AutoCAD _Command Line_:

![Call win_multiblockreplace tool in AutoCAD](/assets/call_win_multiblockreplace.png)

The plug-in will guide you through the steps on the _Command Line_. In the first step you will need to provide the names of the blocks that you want to be replaced. You can use the \*-character as a wildcard, as in this example:

![Call win_multiblockreplace tool in AutoCAD](/assets/name_of_blocks_to_replace.png)

This will preselect all blocks that have names that start with "RECTANG" - for example: "RECTANGLE_1", "RECTANGLE_2", "RECTANG1", and so on. Please note that this is case sensitive, thus for example "Rectangle_1" will not be selected as a block that has to be replaced.

In the next step, the tool tells you, how many blocks would be replaced if you procede. In the following example, there are seven blocks that are matched by the "RECTANG*" search string:

![Call win_multiblockreplace tool in AutoCAD](/assets/no_blocks_proceed.png)

You can decide whether you like to procede (J) or not (N).

In the last step you have to provide the name of the block which would replace the other blocks that have been selected in the previous steps. In the following example this block has the name "Magic_Hexagon":

![Call win_multiblockreplace tool in AutoCAD](/assets/name_of_replacing_block.png)

You have to provide the full name of the block. You cannot use a wildcard here since you have to select exactly one block.

That's it, after this step, the tool replaces all the blocks (in this example: the seven blocks that have names that start with "RECTANG*") with one block (in this case the block with the name "Magic_Hexagon").

## Usable versions of AutoCAD
This plug-in has originally been compiled for and tested with AutoCAD 2017, but it should also work out-of-the-box with all subsequent versions of AutoCAD.

## Additional system requirements
.NET Framework version 4.5 (at least) is required (and of course the Windows version that runs it).

## Internationalization/localization
This tool chooses its locale from the operating system settings. The text for the _Command Line_ interaction is available for English and German locales. If you would like to participate in this project, we would be happy to get locales for additional languages.

