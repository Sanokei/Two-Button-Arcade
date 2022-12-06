using System.Collections.Generic;
using PixelGame;
using UnityEngine;
public class JumpGame : Game
{
    public override void StartGame()
    {
        // Create PixelGameObject's
        PixelGameObject MainCanvas = game.add("Main Canvas");
        PixelGameObject Player = game.add("Player");

        // Add all the components

        /* Player */
        Player.add("PlayerMovement", typeof(PixelBehaviourScript)).add(
            @"-- player movement script
            function Start()
                print('test')
            end
            function Update()
                print('crash test')
            end
            function ButtonOnePress()
                -- print(Player.test());
                -- print(Player['Player_Still'].test());
            end
            function ButtonTwoPress()
                print('two')
            end
            "
        );

        Player.add("Player_Still", typeof(PixelSprite)).add(
            game.SpriteStringMaker(
                new Dictionary<PixelPosition, char>()
                {
                    {new PixelPosition(1,0), 'c'},
                    {new PixelPosition(1,1), 'r'}
                }
            )
        );
        
        Player.add("Anchor", typeof(AnchorPixel)).add(
            (PixelSprite)Player["Player_Still"],
            new PixelPosition(0,0)    
        );

        Player.add("Transform", typeof(PixelTransform)).add(
            (AnchorPixel)Player["Anchor"],
            new PixelPosition(1,0)
        );

        /* Main Canvas */
        MainCanvas.add("Main Canvas", typeof(PixelSprite)).add(
            new string('b',64)
        );

        // compile the code and then run it
        game.CompileAndRun();
    }
}