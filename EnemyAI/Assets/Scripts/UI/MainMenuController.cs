using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UI
{
    internal class MainMenuController : MonoBehaviour
    {
        public void OnPlayClicked()
        {
            var gameLoop = ServiceLocator.Get<IGameLoopService>();
            gameLoop.StartGame();
        }

        public void OnExitClicked()
        {
            Application.Quit();
        }
    }
}
