// <copyright company="Vermessungsamt Winterthur">
//      Author: Edgar Butwilowski
//      Copyright (c) 2021 Vermessungsamt Winterthur. All rights reserved.
// </copyright>

using Autodesk.AutoCAD.Runtime;
using System.Globalization;

namespace WIN.MULTIBLOCKREPLACE
{
    class LocalizedStrings
    {
        internal const int enter_names_blocks_to_replace = 0;
        internal const int blocks_will_be_replaced = 1;
        internal const int enter_name_of_replace_block = 2;
        internal const int successfully_completed = 3;
        internal const int no_input_or_canceled_by_user = 4;
        internal const int no_input = 5;

        internal static string GetLocalizedStringFor(int stringCode)
        {
            CultureInfo cultureInfo = new CultureInfo(SystemObjects.DynamicLinker.ProductLcid);
            if (cultureInfo.TwoLetterISOLanguageName == "de")
            {
                switch(stringCode)
                {
                    case enter_names_blocks_to_replace:
                        return "Bitte geben Sie die Bezeichnung der zu ersetzenden Blöcke ein (* ist Wildcard).";
                    case blocks_will_be_replaced:
                        return "Blöcke werden ersetzt. Fortfahren (J/N)?";
                    case enter_name_of_replace_block:
                        return "Bitte geben Sie die Bezeichnung des Blocks ein, mit dem ersetzt werden soll.";
                    case successfully_completed:
                        return "Erfolgreich abgeschlossen.";
                    case no_input_or_canceled_by_user:
                        return "Keine Eingabe oder Kommando durch Benutzer abgebrochen. Kommando wird abgebrochen.";
                    case no_input:
                        return "Keine Eingabe. Kommando wird abgebrochen.";
                }
            } else
            {
                switch(stringCode)
                {
                    case enter_names_blocks_to_replace:
                        return "Please enter the names of the blocks that shall be replaced (* is wildcard).";
                    case blocks_will_be_replaced:
                        return "blocks will be replaced. Procede (J/N)?";
                    case enter_name_of_replace_block:
                        return "Please enter the name of the block with which to replace.";
                    case successfully_completed:
                        return "Successfully Completed.";
                    case no_input_or_canceled_by_user:
                        return "No input or canceled by user. Command is aborted.";
                    case no_input:
                        return "No input. Command is aborted.";
                }
            }
            return "";
        }
    }
}
