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
        Player.add("PlayerMovement", typeof(PixelBehaviourScript)).add(
            @"-- player movement
            function Start()
                print('test')
            end
            function Update()
                print('crash test')
            end
            function ButtonOnePress()
                -- print(Player.test());
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

        MainCanvas.add("Main Canvas", typeof(PixelSprite)).add(
            new string('b',64)
        );

        // compile the code and then run it
        game.CompileAndRun();
    }
}