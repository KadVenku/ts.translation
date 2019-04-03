using ts.translation.data.definitions.serializable.v1;
using ts.translation.data.holder.text;

namespace ts.translation.common.util.ts
{
    internal static class TextHolderUtility
    {
        internal static void Merge(TextHolder mergeTarget, LocalisationData dataToMerge)
        {
            mergeTarget.Import(dataToMerge);
        }

        internal static void Merge(TextHolder mergeTarget, TextHolder dataToMerge)
        {
            mergeTarget.Merge(dataToMerge);
        }
        
        internal static void Merge(LocalisationData mergeTarget, LocalisationData dataToMerge)
        {
            TextHolder textHolderMergeTarget = new TextHolder(mergeTarget);
            TextHolder textHolderToMerge = new TextHolder(dataToMerge);
            textHolderMergeTarget.Merge(textHolderToMerge);
            mergeTarget = textHolderMergeTarget.ToLocalisationData();
        }
    }
}
