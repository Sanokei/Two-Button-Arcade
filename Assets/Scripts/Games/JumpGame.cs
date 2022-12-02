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
            {new PixelPosition(0,1), 'r'}
        };

        // Create a sprite String for the player
        string player = game.SpriteStringMaker(PlayerSpriteString);
        
        // Create player gameobject
        PixelGameObject Player = gameObject.AddComponent<PixelGameObject>();
            // add pixel sprite component with player string
            PixelSprite sprite = gameObject.AddComponent<PixelSprite>();
            sprite.add(player);
            Player.add("Player_Still", sprite);
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
            PixelBehaviourScript script = gameObject.AddComponent<PixelBehaviourScript>();
            Player.add("PlayerMovement", script);
            ((PixelBehaviourScript) Player.PixelComponents["PlayerMovement"]).add(PlayerMovementScript);
        
        // Create canvas gameobject
        PixelGameObject MainCanvas = gameObject.AddComponent<PixelGameObject>();
            // add pixel canvas
            PixelCanvas canvas = gameObject.AddComponent<PixelCanvas>();
            MainCanvas.add("Main Canvas", canvas);

        // Game
        game.add("Main Canvas", MainCanvas);
        game.add("Player", Player);

        // compile the code and then run it
        game.CompileAndRun(gameObject.transform);

    }
}
