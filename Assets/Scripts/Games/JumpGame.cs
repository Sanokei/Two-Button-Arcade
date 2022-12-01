using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelGame;
using BuildingBlocks.DataTypes;
using MoonSharp.Interpreter;
public class JumpGame : Game
{
    void OnEnable()
    {
        // Pixel Game Object is like a scriptable object
        /*
            PixelTransform
                PixelPosition
                AnchorPixel
            
            PixelCollider
                -isTrigger
                AnchorPixel
            
            PixelSprite
                (prefab) PixelScreen
        */

        // different letters correspond to different colors
        InspectableDictionary<PixelPosition,char> PlayerSpriteString = new InspectableDictionary<PixelPosition, char>()
        {
            {new PixelPosition(0,0), 'c'},
            {new PixelPosition(1,0), 'r'}
        };

        // Create a sprite String for the player
        string player = game.SpriteStringMaker(PlayerSpriteString);
        // Create player gameobject
        PixelGameObject Player = gameObject.AddComponent<PixelGameObject>();
        // add pixel sprite component with player string
        Player.add(new PixelSprite(player));
        // add scripts
        string PlayerMovementScript = 
            @"
                -- player movement
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

        Player.add(new PixelBehaviourScript(PlayerMovementScript));
        
        // Create canvas gameobject
        PixelGameObject MainCanvas = gameObject.AddComponent<PixelGameObject>();
        // add pixel canvas
        MainCanvas.add(new PixelCanvas());

        // Game
        game.add("Main Canvas", MainCanvas);
        game.add("Player", Player);

        // compile the code and then run it
        game.CompileAndRun(gameObject.transform);

    }
}
