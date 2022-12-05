using System.Collections.Generic;
using PixelGame;
public class JumpGame : Game
{
    public override void StartGame()
    {


        // Create player gameobject
        PixelGameObject Player = game.add("Player");
        // Create canvas gameobject
        PixelGameObject MainCanvas = game.add("Main Canvas");

        // Different letters correspond to different colors
        Dictionary<PixelPosition,char> PlayerSpriteString = new Dictionary<PixelPosition, char>()
        {
            {new PixelPosition(0,0), 'c'},
            {new PixelPosition(0,1), 'r'}
        };

        // Create a sprite String for the player
        string player = game.SpriteStringMaker(PlayerSpriteString);
        
        // add pixel sprite component with player string
        PixelSprite sprite = Player.gameObject.AddComponent<PixelSprite>();
            sprite.add(player);
            Player.add("Player_Still", sprite);
        // add scripts
        string PlayerMovementScript =
            @"-- player movement
            function Start()
                print('test')
            end
            function Update()
                print('crash test')
            end
            function ButtonOnePress()
                print('one')
            end
            function ButtonTwoPress()
                print('two')
            end
            ";
        PixelBehaviourScript script = Player.gameObject.AddComponent<PixelBehaviourScript>();
            string PlayerMovementScriptName = "PlayerMovement";
            script.add(PlayerMovementScriptName, PlayerMovementScript);
            Player.add(PlayerMovementScriptName, script);
        
            // add pixel canvas
            PixelCanvas canvas = MainCanvas.gameObject.AddComponent<PixelCanvas>();
            MainCanvas.add("Main Canvas", canvas);

        // compile the code and then run it
        game.CompileAndRun();
    }
}

// TextIcon PlayerMovementScriptIcon = (TextIcon) ScriptableObject.CreateInstance("TextIcon");
//     PlayerMovementScriptIcon.name = PlayerMovementScriptName;
//     PlayerMovementScriptIcon.FileData = PlayerMovementScript;
//     ((PixelBehaviourScript) Player.PixelComponents[PlayerMovementScriptName]).add(PlayerMovementScriptName, PlayerMovementScriptIcon);