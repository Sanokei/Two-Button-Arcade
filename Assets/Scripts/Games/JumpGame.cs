using System.Collections.Generic;
using PixelGame;
using UnityEngine;
public class JumpGame : Game
{
    public override void StartGame()
    {
        // Create PixelGameObject's
        game.add("Main Canvas");
        game.add("Player");

        // Add all the components

        /* Player */
        game["Player"].add("PlayerMovement", typeof(PixelBehaviourScript)).add(
            @"-- player movement script
            function Start()
                print('test')
            end
            function Update()
                print('crash test')
            end
            function ButtonOnePress()
                print('button 1');
                Player['Transform'].move(0,1);
            end
            function ButtonTwoPress()
                print('button 2')
                --Player['Transform'].move(0,-1);
                --game.add('kek');
                game['Player']['Transform'].move(0,-1)
                --game['Player'].add('lol', typeof(PixelSprite))--.add('oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo');
            end
            "
        );
        game["Player"]["PlayerMovement"].addPixelGameObjectToScriptGlobals("game",game);
        game["Player"].add("Player_Still", typeof(PixelSprite)).add(
            game.SpriteStringMaker(
                new Dictionary<PixelPosition, char>()
                {
                    {new PixelPosition(1,0), 'c'},
                    {new PixelPosition(1,1), 'r'}
                }
            )
        );
        
        game["Player"].add("Anchor", typeof(AnchorPixel)).add(
            game["Player"]["Player_Still"],
            new PixelPosition(0,0)    
        );

        game["Player"].add("Transform", typeof(PixelTransform)).add(
            game["Player"]["Anchor"],
            new PixelPosition(1,0)
        );

        /* Main Canvas */
        game["Main Canvas"].add("Main Canvas", typeof(PixelSprite)).add(
            new string('b',64)
        );

        // compile the code and then run it
        game.CompileAndRun();
    }
}