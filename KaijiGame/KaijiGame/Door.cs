using System;



namespace KaijiGame
{

    public class Door : IRoomComponent
    {
        private bool isLocked = true;
        private int starsRequired;

        public Door(int starsRequired)
        {
            this.starsRequired = starsRequired;
        }

        public bool IsLocked
        {
            get { return isLocked; }
        }

        public void Unlock()
        {
            if (starsRequired > 0)
            {
                Console.WriteLine("You need {0} more star(s) to unlock this door.", starsRequired);
                return;
            }

            Console.WriteLine("The door is unlocked!");
            isLocked = false;
        }

        public void AddStar()
        {
            starsRequired--;
            Console.WriteLine("You now need {0} more star(s) to unlock this door.", starsRequired);
        }
    }
}