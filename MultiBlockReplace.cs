// <copyright company="Vermessungsamt Winterthur">
//      Author: Edgar Butwilowski
//      Copyright (c) 2021 Vermessungsamt Winterthur. All rights reserved.
// </copyright>

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System.Collections.Generic;
using System.Text.RegularExpressions;

[assembly: CommandClass(typeof(WIN.MULTIBLOCKREPLACE.MultiBlockReplace))]
namespace WIN.MULTIBLOCKREPLACE
{
    public class MultiBlockReplace
    {
        [CommandMethod("win_multiblockreplace")]
        public void MultiBlockReplaceCommand()
        {
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;

            PromptResult blocksToReplaceNameResult = editor.GetString("\n" + typeof(MultiBlockReplace).Name +
                  ": " + LocalizedStrings.GetLocalizedStringFor(LocalizedStrings.enter_names_blocks_to_replace));
            string blocksToReplaceName = MultiBlockReplace
                        ._GetPromptResultString(blocksToReplaceNameResult, editor);
            if(blocksToReplaceName == null)
            {
                return;
            }

            // add start and end delimiters for regex, so
            // that only exact strings are matched:
            string blocksToReplaceNameRegex = "^" + blocksToReplaceName + "$";

            // wildcard in regex is .* instead of just *, so replace:
            blocksToReplaceNameRegex = blocksToReplaceNameRegex.Replace("*", ".*");
            Regex regexPattern = new Regex(blocksToReplaceNameRegex);

            Database database = HostApplicationServices.WorkingDatabase;
            using (Transaction trans = database.TransactionManager.StartTransaction())
            {
                BlockTable blockTable = (BlockTable)trans.GetObject(database.BlockTableId, OpenMode.ForRead);

                List<BlockTableRecord> blocksToReplace = new List<BlockTableRecord>();

                foreach (ObjectId blockId in blockTable)
                {
                    BlockTableRecord blockRecord = (BlockTableRecord)trans.GetObject(blockId, OpenMode.ForRead);
                    // exclude model and paper space blocks:
                    if (!blockRecord.Name.StartsWith("*Model_Space") && !blockRecord.Name.StartsWith("*PaperSpace"))
                    {
                        // test if the name of the block fits the regex definition:
                        if (regexPattern.IsMatch(blockRecord.Name))
                        {
                            blocksToReplace.Add(blockRecord);
                        }
                    }
                }

                PromptResult isProcedeResult = editor.GetString("\n" + typeof(MultiBlockReplace).Name + ": " +
                    blocksToReplace.Count + " " + LocalizedStrings.GetLocalizedStringFor(LocalizedStrings.blocks_will_be_replaced));
                string isProcede = isProcedeResult.StringResult;

                if (isProcede != "J")
                {
                    return;
                }

                PromptResult replacementBlockNameResult = editor.GetString("\n" + typeof(MultiBlockReplace).Name +
                       ": " + LocalizedStrings.GetLocalizedStringFor(LocalizedStrings.enter_name_of_replace_block));
                string replacementBlockName = MultiBlockReplace
                            ._GetPromptResultString(replacementBlockNameResult, editor);
                if (replacementBlockName == null)
                {
                    return;
                }
                ObjectId sigStBlockId;
                try
                {
                    sigStBlockId = blockTable[replacementBlockName];
                    foreach (BlockTableRecord blockToReplace in blocksToReplace)
                    {
                        foreach (ObjectId blockToReplaceRefId in blockToReplace.GetBlockReferenceIds(true, true))
                        {
                            BlockReference blockToReplaceRef = (BlockReference)trans.GetObject(blockToReplaceRefId, OpenMode.ForWrite);
                            blockToReplaceRef.BlockTableRecord = sigStBlockId;
                        }
                    }
                    trans.Commit();
                    editor.WriteMessage("\n" + typeof(MultiBlockReplace).Name + ": " + 
                        LocalizedStrings.GetLocalizedStringFor(LocalizedStrings.successfully_completed));
                }
                catch (Exception ex)
                {
                    trans.Abort();
                    editor.WriteMessage("\n" + typeof(MultiBlockReplace).Name + ": " + ex.Message);
                }
            }
        }


        // Helper method to check prompt result for validity and to transform to a string.
        private static string _GetPromptResultString(PromptResult stringPromptResult, Editor editor)
        {

            if (stringPromptResult == null || stringPromptResult.Status == PromptStatus.Cancel)
            {
                editor.WriteMessage("\n" + typeof(MultiBlockReplace).Name + ": " + 
                    LocalizedStrings.GetLocalizedStringFor(LocalizedStrings.no_input_or_canceled_by_user));
                return null;
            }

            string promptResultString = stringPromptResult.StringResult;
            if (promptResultString == null)
            {
                editor.WriteMessage("\n" + typeof(MultiBlockReplace).Name + ": " +
                    LocalizedStrings.GetLocalizedStringFor(LocalizedStrings.no_input));
                return null;
            }
            promptResultString = promptResultString.Trim();
            if (promptResultString.Length == 0)
            {
                editor.WriteMessage("\n" + typeof(MultiBlockReplace).Name + ": " +
                    LocalizedStrings.GetLocalizedStringFor(LocalizedStrings.no_input));
                return null;
            }

            return promptResultString;
        }
    }
}
