
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        public int moneyP;
        public int treesHave;
        public int rocksHave;
        public int mushroomsHave;
        public int carrotsHave;
        public int watermalonnHave;
        public int applesHave;
        public int pumpkinsHave;
        public int mangosHave;
        public int cornsHave;
        public List<GameObject> openedLevels;

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
