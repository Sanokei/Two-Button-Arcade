using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using InGameCodeEditor;

public class FileManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextIcon textIcon;
    public CodeEditorTheme[] codeEditorTheme;
    public enum editorThemeNames{light, dark, terminal}; // Dark is the default. 
    public CodeLanguageTheme[] codeLanguageTheme;
    public enum languageThemeNames{json, lua, txt, cs, ms}; // Csharp and Miniscript is just for future proofing. Not actually used meaningfully.
    public string file_path;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            // Create Physical Representation of Window
            WindowMaker window = Instantiate(Resources.Load($"Computer/Window/CodeEditor") as WindowMaker, transform.parent);
            
            // Set the window's title.
            window.text.text = $"{textIcon.name}.{textIcon.textType.ToString()}";

            // Edit Physical Representation of Window
            window.CreateWindow(textIcon);

            // Set the window's parent.
            window.transform.SetParent(transform.parent);

            // Change Code Editor
            foreach(editorThemeNames name in System.Enum.GetValues(typeof(editorThemeNames))) // TODO: This may become problematic later, if I allow users to create their own theme at runtime.
            {
                if(name.ToString().ToLower() == PlayerOptions.Instance.defaultTheme.ToString().ToLower())
                {
                    window.codeEditor.EditorTheme = (codeEditorTheme[(int)name]);
                    break;
                }
            }

            foreach(languageThemeNames name in System.Enum.GetValues(typeof(languageThemeNames)))
            {
                if(name.ToString().ToLower() == textIcon.textType.ToString().ToLower())
                {
                    window.codeEditor.LanguageTheme = (codeLanguageTheme[(int)name]);
                    break;
                }
            }
        }
    }
}