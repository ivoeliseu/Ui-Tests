using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Screens
{
    //ScreenManager irá cuidar das cenas.
    //screenBases é uma lista com todas as cenas contidas.
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;
        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _currentScreen;

        //Esconde todas as telas
        //Mostra a tela Inicial.
        private void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        /*
         * ShowByType recebe o parametro ScreenType.
         * Se a lista de "screenBases" for diferente de nula, esconde tal tela.
         * Variavel nextScreen é igual ao parametro recebido.
         * Atual tela ("_currentScreenBase") é igual ao nextScreen.
         * Mostra a próxima tela atual.
         */
        public void ShowByType (ScreenType type)
        {
            if (_currentScreen != null) _currentScreen.Hide();
            var nextScreen = screenBases.Find(i => i.screenType == type);

            _currentScreen = nextScreen;
            nextScreen.Show();
        }

        //Metodo que esconde todas as telas.
        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }
    }
}
