namespace Code.UI.View
{
    public interface IUIViewSettings
    {
        void SelectAIType(bool honest);
        void SelectAIDishonestyLevel(float dishonestyLevel);
        void CloseSettingsPanel();
        void OpenSettingsPanel();
    }
}